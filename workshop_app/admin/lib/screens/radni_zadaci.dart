import 'package:admin/bloc/uredjaji_bloc.dart';
import 'package:admin/bloc/zadatak_uredjaj_bloc.dart';
import 'package:admin/commons/app_bar.dart';
import 'package:admin/screens/radni_zadaci_lista.dart';
import 'package:commons/helpers/state_helper.dart';
import 'package:commons/models/radni_zadatak.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/radniZadaci_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class RadniZadaciScreen extends StatefulWidget {
  int? radniZadatakId;

  //final void Function()? refreshKonzolaCallback;

  //RadniZadaciScreen({this.refreshKonzolaCallback});

  RadniZadaciScreen({Key? key}) : super(key: key);

  RadniZadaciScreen.uredi({this.radniZadatakId});

  @override
  _RadniZadaciScreenState createState() => _RadniZadaciScreenState();
}

class _RadniZadaciScreenState extends State<RadniZadaciScreen> {
  List<Uredjaj> targetList = [];

  List<Uredjaj> aktivniUredjaji = [];
  List<RadniZadatakUredjaj> radniZadatakUredjaj = [];
  List<RadniZadatak> radniZadatak = [];

  int? odabraniZadatakId;

  List<RadniZadatakUredjaj> odabraniRadniZadatakUredjaj = [];
  RadniZadatak odabraniRadniZadatak = RadniZadatak();
  RadniZadatak? dummyRadniZadatak;

  bool _isLoading = true;

  int? dropdownvalue;

  UredjajProvider? uredjajiProvider = null;
  RadniZadaciUredjajProvider? radniZadaciUredjajProvider = null;
  RadniZadaciProvider? radniZadaciProvider = null;

  ZadatakUredjajBloc? zadatakUredjajBloc;

  @override
  void initState() {
    super.initState();

    uredjajiProvider = context.read<UredjajProvider>();
    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();
    radniZadaciProvider = context.read<RadniZadaciProvider>();

    zadatakUredjajBloc = ZadatakUredjajBloc(zadatakProvider: radniZadaciUredjajProvider);

    zadatakUredjajBloc!.eventSink.add(UredjajAction.Refresh);

    //var map = {'Status': 'active'};

    //_fetchData(map);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    setState(() {
      _isLoading = true;
    });

    Map<String, String>? mapZadatak;

    if (widget.radniZadatakId == null) {
      mapZadatak = {'StateMachine': 'active'};
    } else {
      mapZadatak = {'RadniZadatakId': widget.radniZadatakId.toString()};
      dropdownvalue = widget.radniZadatakId;
      odabraniZadatakId = widget.radniZadatakId;
    }

    final response = await uredjajiProvider?.get(map, "Uredjaj");

    final responseZadatakUredjaj = await radniZadaciUredjajProvider?.get(mapZadatak, "RadniZadatakUredjaj/Flutter");

    var mapCustomZadatak = {
      'StateMachineArray': ['active', 'idle']
    };

    final responseZadatak = await radniZadaciProvider?.get(mapCustomZadatak, "RadniZadatak");

    odabraniRadniZadatak = new RadniZadatak();
    odabraniRadniZadatak.radniZadatakId = 0;
    odabraniRadniZadatak.naziv = "";
    odabraniRadniZadatak.stateMachine = "";
    odabraniRadniZadatak.datum = "";

    setState(() {
      aktivniUredjaji = response!;
      radniZadatakUredjaj = responseZadatakUredjaj!;
      radniZadatak = responseZadatak!;
      _isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: BarrApp(naslov: "Radni zadaci"),
        body: SingleChildScrollView(
            child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            SizedBox(
              height: 50,
            ),
            MinimalisticButton(
              icons: Icon(
                Icons.exit_to_app,
                color: Colors.black,
              ),
              text: "Lista radnih zadataka",
              onPressed: () {
                Navigator.push(context, MaterialPageRoute(builder: (context) => RadniZadaciLista()));
              },
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Card(
                  child: Column(
                    children: [
                      // Header for the left Card
                      Padding(
                        padding: const EdgeInsets.all(8.0),
                        child: Text(
                          "Aktivni uređaji", // Your header text
                          style: TextStyle(
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ),
                      Container(
                        height: 500,
                        width: 300,
                        child: ListView.builder(
                          itemCount: aktivniUredjaji.length,
                          itemBuilder: (context, index) {
                            return Draggable<Uredjaj>(
                              data: aktivniUredjaji[index],
                              feedback: Material(
                                elevation: 4.0,
                                child: Container(
                                  padding: EdgeInsets.all(10),
                                  child: Text(aktivniUredjaji[index].uredjajId.toString() +
                                      " - " +
                                      aktivniUredjaji[index].tipNaziv! +
                                      " - " +
                                      aktivniUredjaji[index].koda!),
                                ),
                              ),
                              child: Material(
                                color: Colors.white,
                                child: ListTile(
                                  title: Text(aktivniUredjaji[index].uredjajId.toString() +
                                      " - " +
                                      aktivniUredjaji[index].tipNaziv! +
                                      " - " +
                                      aktivniUredjaji[index].koda!),
                                ),
                              ),
                            );
                          },
                        ),
                      ),
                    ],
                  ),
                ),
                Padding(
                  padding: EdgeInsets.all(40),
                ),
                Card(
                  child: Column(
                    children: [
                      // Header for the right Card
                      Padding(
                        padding: const EdgeInsets.all(8.0),
                        child: Text(
                          odabraniRadniZadatak.naziv ?? "", // Your header text
                          style: TextStyle(
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ),
                      DragTarget<Uredjaj>(
                        onAccept: (data) async {
                          _dodajUredjajIRefreshListu(data);

                          setState(() {
                            targetList.add(data);
                          });
                        },
                        builder: (context, candidateData, rejectedData) {
                          return Container(
                            height: 500,
                            width: 300,
                            child: Padding(
                              padding: EdgeInsets.all(10),
                              child: Column(
                                children: [
                                  Expanded(
                                    child: (dropdownvalue == null)
                                        ? Center(child: Text("Odaberi radni zadatak"))
                                        : ListView.builder(
                                            itemCount: radniZadatakUredjaj.length,
                                            itemBuilder: (context, index) {
                                              return ListTile(
                                                title: Text(radniZadatakUredjaj[index].uredjajId.toString() +
                                                    " - " +
                                                    radniZadatakUredjaj[index].tipNaziv.toString() +
                                                    " - " +
                                                    radniZadatakUredjaj[index].koda.toString()),
                                              );
                                            },
                                          ),
                                  ),
                                ],
                              ),
                            ),
                          );
                        },
                      ),
                    ],
                  ),
                ),
                Padding(
                  padding: EdgeInsets.all(20),
                ),
                Column(
                  children: [
                    Container(
                        width: 200,
                        child: DropdownButton<int>(
                          value: dropdownvalue ?? widget.radniZadatakId,
                          icon: const Icon(Icons.arrow_downward),
                          elevation: 16,
                          hint: Container(child: Text("Odaberi radni zadatak")),
                          style: const TextStyle(color: Colors.deepPurple),
                          underline: Container(
                            height: 2,
                            color: Colors.blueGrey,
                          ),
                          onChanged: (int? value) async {
                            var zadataktemp = await radniZadaciUredjajProvider!.get({'RadniZadatakId': value}, 'RadniZadatakUredjaj/Flutter');
                            var odabraniZadatakTemp = await radniZadaciProvider!.get({'RadniZadatakId': value}, 'RadniZadatak');

                            setState(() {
                              dropdownvalue = value!;
                              odabraniZadatakId = dropdownvalue;
                              odabraniRadniZadatak = odabraniZadatakTemp.first;

                              radniZadatakUredjaj = zadataktemp;
                            });
                          },
                          items: radniZadatak.map<DropdownMenuItem<int>>((RadniZadatak value) {
                            return DropdownMenuItem<int>(
                              value: value.radniZadatakId,
                              child: Text(value.naziv.toString()),
                            );
                          }).toList(),
                        )),
                    Container(
                        width: 200,
                        child: Card(
                            elevation: 2.0,
                            margin: EdgeInsets.fromLTRB(0, 20, 0, 0),
                            child: ListTile(
                              title: Text('Info'),
                              subtitle: Column(children: [
                                ListTile(
                                  title: Text('Naziv'),
                                  subtitle: Text(odabraniRadniZadatak.naziv ?? ""),
                                ),
                                ListTile(
                                  title: Text('Stanje'),
                                  subtitle: Text(odabraniRadniZadatak.stateMachine ?? ""),
                                ),
                                ListTile(
                                  title: Text('Ukupno uređaja'),
                                  subtitle: Text(radniZadatakUredjaj.length.toString()),
                                ),
                                ListTile(
                                    title: Text('Progres'),
                                    //subtitle: Text('Task Name'),
                                    subtitle: LinearProgressIndicator(
                                      value: 0.33,
                                    ))
                              ]),
                            )))
                  ],
                )
              ],
            ),
          ],
        )));
  }

  void _dodajUredjajIRefreshListu(Uredjaj data) async {
    if (dropdownvalue == null) {
      ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Radni zadatak nije odabran."));
      return;
    }

    for (var uredjaj in radniZadatakUredjaj) {
      if (data.uredjajId == uredjaj.uredjajId) {
        ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Uređaj već postoji u radnom zadatku."));
        return;
      }
    }

    var request = {'radniZadatakId': odabraniZadatakId, 'uredjajId': data.uredjajId, 'napomena': "napomena", 'korisnikId': 1003};

    try {
      await radniZadaciUredjajProvider!.update(null, request, "Uredjaj/RadniZadatak");

      ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Uspješno je dodan uredjaj u radni zadatak."));
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack(e.toString()));
    }

    var zadatakUredjaj = await radniZadaciUredjajProvider!.get({'RadniZadatakId': odabraniZadatakId}, "RadniZadatakUredjaj/Flutter");
    var uredjajiTemp = await uredjajiProvider?.get({'Status': 'active'}, "Uredjaj");

    zadatakUredjajBloc!.eventSink.add(UredjajAction.Refresh);

    setState(() {
      radniZadatakUredjaj = zadatakUredjaj;
      aktivniUredjaji = uredjajiTemp!;
    });

    //_fetchData({'Status': 'active'});
  }
}
