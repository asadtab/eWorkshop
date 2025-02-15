import 'package:admin/bloc/radni_zadatak_uredjaj/bloc/radni_zadatak_uredjaj_block_bloc.dart';
import 'package:admin/bloc/uredjaji_lista_zadatak.dart/bloc/uredjaji_lista_zadatak_bloc.dart';
import 'package:admin/commons/app_bar.dart';
import 'package:admin/screens/radni_zadaci_lista.dart';
import 'package:admin/widgets/radni_zadatak_pdf.dart';
import 'package:commons/helpers/progres.dart';
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
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:provider/provider.dart';
import 'package:commons/models/user.dart';

class RasporedUredjaja extends StatefulWidget {
  int? radniZadatakId;

  RasporedUredjaja();

  RasporedUredjaja.uredi({this.radniZadatakId});

  @override
  _RasporedUredjajaState createState() => _RasporedUredjajaState();
}

class _RasporedUredjajaState extends State<RasporedUredjaja> {
  List<Uredjaj> targetList = [];

  List<Uredjaj> aktivniUredjaji = [];
  List<RadniZadatakUredjaj> radniZadatakUredjaj = [];
  List<RadniZadatak> radniZadatak = [];

  int? odabraniZadatakId;

  List<RadniZadatakUredjaj> odabraniRadniZadatakUredjaj = [];
  RadniZadatak odabraniRadniZadatak = RadniZadatak();
  RadniZadatak? dummyRadniZadatak;

  int? dropdownvalue;
  String? dropdownvalueStatus;

  UredjajProvider? uredjajiProvider = null;
  RadniZadaciUredjajProvider? radniZadaciUredjajProvider = null;
  RadniZadaciProvider? radniZadaciProvider = null;

  UredjajiListaZadatakBloc? uredjajBlocActive;

  RadniZadatakUredjajBloc? uredjajBloc;

  @override
  void initState() {
    uredjajiProvider = context.read<UredjajProvider>();
    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();
    radniZadaciProvider = context.read<RadniZadaciProvider>();

    uredjajBlocActive = BlocProvider.of<UredjajiListaZadatakBloc>(context);

    uredjajBloc = BlocProvider.of<RadniZadatakUredjajBloc>(context);

    //uredjajBloc!.add(RadniZadatakIdEvent(id: 1));

    uredjajBlocActive!.add(UredjajiLoadZadatakEvent());

    dropdownvalueStatus = 'active';

    _fetchData(null);

    super.initState();
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    List<RadniZadatak>? responseZadatak;

    try {
      responseZadatak = await idleActiveZadatak();
    } catch (e) {
      poruka(e.toString());
      return;
    }

    odabraniRadniZadatak = new RadniZadatak();
    odabraniRadniZadatak.radniZadatakId = 0;
    odabraniRadniZadatak.naziv = "";
    odabraniRadniZadatak.stateMachine = "";
    odabraniRadniZadatak.datum = "";

    setState(() {
      radniZadatak = responseZadatak!;
    });
  }

  Future<List<RadniZadatak>?> idleActiveZadatak() async {
    var mapCustomZadatak = {'StateMachine': 'active'};

    late List<RadniZadatak> responseZadatak;

    try {
      responseZadatak = await radniZadaciProvider!.get(mapCustomZadatak, "RadniZadatak");
    } catch (e) {
      poruka(e.toString());
    }

    return responseZadatak;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: BarrApp(naslov: "Raspored uređaja"),
        body: SingleChildScrollView(
            child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            SizedBox(
              height: 50,
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Text("Status radnog zadatka:"),
                SizedBox(width: 20,),
                DropdownButton<String>(

                  value: dropdownvalueStatus,
                  icon: const Icon(Icons.arrow_downward),
                  elevation: 16,
                  hint: Container(child: Text("Odaberi status")),
                  style: const TextStyle(color: Colors.deepPurple),
                  underline: Container(
                    height: 2,
                    color: Colors.blueGrey,
                  ),
                  onChanged: (String? value) async {
                    var zadataktemp;
                    List<RadniZadatak> responseZadatak = [];

                    try {
                      responseZadatak = await radniZadaciProvider!.get({'StateMachine': value}, "RadniZadatak");
                    } catch (e) {
                      poruka(e.toString());
                    }

                    if (responseZadatak.isNotEmpty)
                      zadataktemp = await radniZadaciUredjajProvider!
                          .get({'RadniZadatakId': responseZadatak.first.radniZadatakId}, 'RadniZadatakUredjaj/Flutter');

                    setState(() {
                      dropdownvalue = responseZadatak.isNotEmpty
                          ? responseZadatak.first.radniZadatakId
                          : 0; //provjerava da li je radniZadatak prazna lista i dodjeljuje mu bilo koji id radnog zadatka zbog dropdowwn buttona u kojem se bira radniZadatak
                      radniZadatak = [];
                      dropdownvalueStatus = value;
                      odabraniZadatakId = dropdownvalue;
                      radniZadatak = responseZadatak;
                      if (responseZadatak.isNotEmpty) {
                        odabraniRadniZadatak = responseZadatak.first;
                      } else {
                        odabraniRadniZadatak = RadniZadatak();
                      }
                      radniZadatakUredjaj = zadataktemp == null ? [] : (zadataktemp as List<RadniZadatakUredjaj>);
                    });
                  },
                  items: StateHelper.nizZadatakState.map<DropdownMenuItem<String>>((String value) {
                    return DropdownMenuItem<String>(
                      value: value,
                      child: Text(StateHelper.nizZadatakRezultat(value)),
                    );
                  }).toList(),
                ),
                SizedBox(width: 50,),
                
              ],
            ),
            Text("Prevucite uređaj iz aktivnih uređaja u odabrani aktivni ili neaktivni radni zadatak"),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                BlocProvider(
                  create: (context) => UredjajiListaZadatakBloc(uredjajiProvider: uredjajiProvider!),
                  child: BlocConsumer<UredjajiListaZadatakBloc, UredjajiListaZadatakState>(
                      bloc: uredjajBlocActive,
                      listener: (context, state) {
                        // TODO: implement listener
                      },
                      builder: (context, state) {
                        if (state is UredjajiLoadZadatakState) {
                          return Center(
                            child: CircularProgressIndicator(),
                          );
                        } else if (state is UredjajiActiveZadatakState) {
                          var aktivniUredjaji = state.uredjaji;
                          return Card(
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
                                            iconColor: Colors.amberAccent,
                                          ),
                                        ),
                                      );
                                    },
                                  ),
                                ),
                              ],
                            ),
                          );
                        } else {
                          return CircularProgressIndicator();
                        }
                      }),
                ),
                Padding(
                  padding: EdgeInsets.all(40),
                ),
                Card(
                  child: uredjajiRadniZadatak(radniZadatakUredjaj, odabraniRadniZadatak),
                ),
                Padding(
                  padding: EdgeInsets.all(20),
                ),
                Column(
                  children: [
                    Container(
                        width: 200,
                        child: DropdownButton<int>(
                          value: dropdownvalue, // ?? widget.radniZadatakId,
                          icon: const Icon(Icons.arrow_downward),
                          elevation: 16,
                          hint: Container(child: Text("Odaberi radni zadatak")),
                          style: const TextStyle(color: Colors.deepPurple),
                          underline: Container(
                            height: 2,
                            color: Colors.blueGrey,
                          ),
                          onChanged: (int? value) async {
                            uredjajBloc!.add(RadniZadatakIdEvent(id: value!));

                            var zadataktemp = await radniZadaciUredjajProvider!.get({'RadniZadatakId': value}, 'RadniZadatakUredjaj/Flutter');
                            var odabraniZadatakTemp = await radniZadaciProvider!.get({'RadniZadatakId': value}, 'RadniZadatak');

                            setState(() {
                              dropdownvalue = value;
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
                                  subtitle:
                                      Text(dropdownvalue == null ? "" : StateHelper.nizZadatakRezultat(odabraniRadniZadatak.stateMachine ?? "")),
                                ),
                                ListTile(
                                  title: Text('Ukupno uređaja'),
                                  subtitle: Text(radniZadatakUredjaj.length.toString()),
                                ),
                                ListTile(
                                    title: Text('Progres'),
                                    //subtitle: Text('Task Name'),
                                    subtitle: LinearProgressIndicator(
                                      minHeight: 10,
                                      semanticsLabel: "Asad",
                                      semanticsValue: "Tabak",
                                      borderRadius: BorderRadius.all(Radius.circular(10)),
                                      value: CustomProgres.postotak(radniZadatakUredjaj),
                                      valueColor: AlwaysStoppedAnimation(Colors.deepPurple),
                                    ))
                              ]),
                            ))),
                    Padding(padding: EdgeInsets.fromLTRB(0, 20, 0, 0)),
                    if (dropdownvalue != null && dropdownvalue != 0)
                      Container(
                          width: 200,
                          child: MinimalisticButton(
                            icons: Icon(
                              Icons.print,
                              color: Colors.black,
                            ),
                            onPressed: () {
                              var uredjaji = radniZadatakUredjaj;
                              //.where((uredjaj) => uredjaj.radniZadatakStatus == "done" || uredjaj.radniZadatakStatus == "fix")
                              //.toList();

                              try {
                                GenerisiPdf.generisiPdf(uredjaji);
                              } catch (e) {
                                poruka(e.toString());
                              }
                            },
                            text: "Kreiraj izvještaj",
                          )),
                    if (odabraniRadniZadatak.stateMachine == 'active' || odabraniRadniZadatak.stateMachine == 'idle')
                      Container(
                        width: 200,
                        child: MinimalisticButton(
                          icons: Icon(
                            Icons.done,
                            color: Colors.black,
                          ),
                          onPressed: () async {
                            await zavrsiZadatak();
                          },
                          text: "Završi",
                        ),
                      ),
                    if (odabraniRadniZadatak.stateMachine == 'done')
                      Container(
                        width: 200,
                        child: MinimalisticButton(
                          icons: Icon(
                            Icons.money,
                            color: Colors.black,
                          ),
                          onPressed: () async {
                            await fakturisiZadatak();
                          },
                          text: "Fakturiši",
                        ),
                      )
                  ],
                )
              ],
            ),
          ],
        )));
  }

  Future<RadniZadatak?> fakturisiZadatak() async {
    showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
              title: Text("Da li želite fakturisati zadatak"),
              content: Container(
                  height: 50,
                  child: Container(
                      padding: EdgeInsets.fromLTRB(0, 29, 0, 0),
                      child: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                        ElevatedButton(
                            child: Text("Potvrdi"),
                            style: ElevatedButton.styleFrom(
                              elevation: 2,
                            ),
                            onPressed: () async {
                              var temp;

                              try {
                                temp = await radniZadaciProvider!.update(odabraniZadatakId, null, "RadniZadatak/Fakturisi");
                              } catch (e) {
                                poruka(e.toString());
                              }

                              poruka("Radni zadatak '${(temp as RadniZadatak).naziv}' je fakturisan.");
                              uredjajBlocActive!.add(UredjajiLoadZadatakEvent());
                              uredjajBloc!.add(RadniZadatakLoadingEvent());

                              var zadatakUredjaj =
                                  await radniZadaciUredjajProvider!.get({'RadniZadatakId': odabraniZadatakId}, "RadniZadatakUredjaj/Flutter");

                              var odabraniZadatakTemp = await radniZadaciProvider!.get({'RadniZadatakId': odabraniZadatakId}, 'RadniZadatak');

                              //List<RadniZadatak>? responseZadatak = await idleActiveZadatak();
                              Navigator.pop(context);

                              setState(() {
                                radniZadatakUredjaj = zadatakUredjaj;
                                //radniZadatak = responseZadatak!;
                                odabraniRadniZadatak = odabraniZadatakTemp.first;
                                //dropdownvalue = 0;
                              });
                            }),
                        ElevatedButton(
                            child: Text("Poništi"),
                            style: ElevatedButton.styleFrom(
                              backgroundColor: Color.fromARGB(255, 170, 70, 63),
                              elevation: 2,
                            ),
                            onPressed: () {
                              Navigator.pop(context);
                            })
                      ]))));
        });
    return null;
  }

  Future<RadniZadatak?> zavrsiZadatak() async {
    showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
              title: Text("Da li želite označiti zadatak završenim"),
              content: Container(
                  height: 50,
                  child: Container(
                      padding: EdgeInsets.fromLTRB(0, 29, 0, 0),
                      child: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                        ElevatedButton(
                            child: Text("Potvrdi"),
                            style: ElevatedButton.styleFrom(
                              elevation: 2,
                            ),
                            onPressed: () async {
                              var temp;

                              try {
                                temp = await radniZadaciProvider!.update(odabraniZadatakId, null, "RadniZadatak/Zavrsi");
                              } catch (e) {
                                poruka(e.toString());
                              }
                              uredjajBloc!.add(RadniZadatakLoadingEvent());

                              poruka("Radni zadatak '${(temp as RadniZadatak).naziv}' je završen. Uređaji koji nisu servisirani su ponovno aktivni.");
                              uredjajBlocActive!.add(UredjajiLoadZadatakEvent());
                              uredjajBloc!.add(RadniZadatakLoadingEvent());

                              var zadatakUredjaj =
                                  await radniZadaciUredjajProvider!.get({'RadniZadatakId': odabraniZadatakId}, "RadniZadatakUredjaj/Flutter");

                              var odabraniZadatakTemp = await radniZadaciProvider!.get({'RadniZadatakId': odabraniZadatakId}, 'RadniZadatak');

                              //List<RadniZadatak>? responseZadatak = await idleActiveZadatak();
                              Navigator.pop(context);

                              setState(() {
                                radniZadatakUredjaj = zadatakUredjaj;
                                //radniZadatak = responseZadatak!;
                                odabraniRadniZadatak = odabraniZadatakTemp.first;
                                //dropdownvalue = 0;
                              });
                            }),
                        ElevatedButton(
                            child: Text("Poništi"),
                            style: ElevatedButton.styleFrom(
                              backgroundColor: Color.fromARGB(255, 170, 70, 63),
                              elevation: 2,
                            ),
                            onPressed: () {
                              Navigator.pop(context);
                            })
                      ]))));
        });
    return null;
  }

///////
  Column uredjajiRadniZadatak(List<RadniZadatakUredjaj> odabraniRadniZadatak, RadniZadatak radniZadatak) {
    return Column(
      children: [
        Padding(
          padding: const EdgeInsets.all(8.0),
          child: Text(
            radniZadatak.naziv ?? "",
            style: TextStyle(
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
        DragTarget<Uredjaj>(
          onAccept: (data) async {
            _dodajUredjajIRefreshListu(data);

            await Future.delayed(Duration(seconds: 3));

            uredjajBloc!.add(RadniZadatakLoadingEvent());
            uredjajBlocActive!.add(UredjajiLoadZadatakEvent());

            setState(() {
              targetList.add(data);
            });
          },
          builder: (context, candidateData, rejectedData) {
            return BlocConsumer<RadniZadatakUredjajBloc, RadniZadatakUredjajState>(
              listener: (context, state) {
                // TODO: implement listener
              },
              bloc: uredjajBloc,
              builder: (context, state) {
                return Container(
                  height: 500,
                  width: 300,
                  child: Padding(
                    padding: EdgeInsets.all(10),
                    child: Column(
                      children: [
                        Expanded(
                          child: (dropdownvalue == null || dropdownvalue == 0)
                              ? Center(child: Text(dropdownvalue == null ? "Odaberi radni zadatak" : "Radni zadaci ne postoje"))
                              : ListView.builder(
                                  itemCount: odabraniRadniZadatak.length,
                                  itemBuilder: (context, index) {
                                    return ListTile(
                                      trailing: IconButton(
                                        onPressed: () async {
                                          try {
                                            await uredjajiProvider!.update(odabraniRadniZadatak[index].uredjajId, null, "Uredjaj/VratiIzTaska");
                                          } catch (e) {
                                            poruka(e.toString());
                                            return;
                                          }

                                          uredjajBloc!.add(RadniZadatakLoadingEvent());
                                          uredjajBlocActive!.add(UredjajiLoadZadatakEvent());

                                          var zadatakUredjaj = await radniZadaciUredjajProvider!
                                              .get({'RadniZadatakId': odabraniZadatakId}, "RadniZadatakUredjaj/Flutter");
                                        
                                          setState(() {
                                            radniZadatakUredjaj = zadatakUredjaj;
                                          });
                                        },
                                        icon: Icon(Icons.cancel),
                                      ),
                                      title: Text(odabraniRadniZadatak[index].uredjajId.toString() +
                                          " - " +
                                          odabraniRadniZadatak[index].tipNaziv.toString() +
                                          " - " +
                                          odabraniRadniZadatak[index].koda.toString()),
                                    );
                                  },
                                ),
                        ),
                      ],
                    ),
                  ),
                );
              },
            );
          },
        ),
      ],
    );
  }

  void poruka(String poruka) {
    ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack(poruka));
  }

  void _dodajUredjajIRefreshListu(Uredjaj data) async {
    if (dropdownvalue == null) {
      ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Radni zadatak nije odabran."));
      return;
    }

    if (odabraniRadniZadatak.stateMachine != 'active' && odabraniRadniZadatak.stateMachine != 'idle') {
      poruka("Radni zadatak nije aktivan");
      return;
    }

    for (var uredjaj in radniZadatakUredjaj) {
      if (data.uredjajId == uredjaj.uredjajId) {
        ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Uređaj već postoji u radnom zadatku."));
        return;
      }
    }

    var request = {'radniZadatakId': odabraniZadatakId, 'uredjajId': data.uredjajId, 'napomena': "napomena", 'korisnikId': User.id};

    try {
      await radniZadaciUredjajProvider!.update(null, request, "Uredjaj/RadniZadatak");

      ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Uspješno je dodan uredjaj u radni zadatak."));

    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack(e.toString()));
    }

    var zadatakUredjaj = await radniZadaciUredjajProvider!.get({'RadniZadatakId': odabraniZadatakId}, "RadniZadatakUredjaj/Flutter");
    var odabraniZadatakTemp = await radniZadaciProvider!.get({'RadniZadatakId': odabraniZadatakId}, 'RadniZadatak');

    setState(() {
      radniZadatakUredjaj = zadatakUredjaj;
      odabraniRadniZadatak = odabraniZadatakTemp.first;
    });
  }
}
