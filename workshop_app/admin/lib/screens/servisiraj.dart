import 'package:admin/bloc/radni_zadatak_uredjaj/bloc/radni_zadatak_uredjaj_block_bloc.dart';
import 'package:admin/commons/app_bar.dart';
import 'package:commons/helpers/state_helper.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/models/user.dart';
import 'package:commons/providers/izvrseni_servis_provider.dart';
import 'package:commons/providers/komponente_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:commons/providers/reparacija_provider.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:darq/darq.dart';
import 'package:flutter/material.dart';
import 'package:commons/models/komponenta.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:provider/provider.dart';
import 'package:commons/providers/radniZadaci_provider.dart';

class ServisirajScreen extends StatefulWidget {
  Uredjaj uredjaj;

  ServisirajScreen({required this.uredjaj});

  @override
  _ServisirajScreenState createState() => _ServisirajScreenState();
}

class _ServisirajScreenState extends State<ServisirajScreen> {
  List<Komponenta> komponenteList = [];
  List<Komponenta> preporuceneKomponenteList = [];
  IzvrseniServisProvider? izvrseniServisProvider;
  KomponenteProvider? komponenteProvider;
  RadniZadaciProvider? radniZadatakProvider;
  RadniZadaciUredjajProvider? radniZadatakUredjajProvider;
  ReparacijaProvider? reparacijaProvider;
  UredjajProvider? uredjajProvider;

  String evidencijskiBroj = '123';
  String tip = 'Desktop';
  String koda = 'ABC123';
  String serijskiBroj = '456';
  String status = 'Active';
  String lokacija = 'Office';

  bool _validate = false;
  String selected = "";

  List<String> komponente = ['Komponenta A', 'Komponenta B', 'Komponenta C'];
  Komponenta? selectedKomponenta;

  TextEditingController nazivController = TextEditingController();
  TextEditingController kodaController = TextEditingController();
  TextEditingController vrijednostController = TextEditingController();
  TextEditingController opisController = TextEditingController();

  @override
  initState() {
    izvrseniServisProvider = context.read<IzvrseniServisProvider>();
    komponenteProvider = context.read<KomponenteProvider>();
    radniZadatakProvider = context.read<RadniZadaciProvider>();
    radniZadatakUredjajProvider = context.read<RadniZadaciUredjajProvider>();
    reparacijaProvider = context.read<ReparacijaProvider>();
    uredjajProvider = context.read<UredjajProvider>();

    opisController.text =
        "Zamijenjeno je kućište uređaja i očišćeni su kontakti releja. Kućišta osigurača, osigurači i signalne sijalice su pregledani i izvršena je izmjena istih ako su oštećeni (vidi zamijenjene elemente). Natpisne letvice releja su zamjenjene novim. Konektori uređaja su pregledani, očišćeni i izvršen je test uklapanja konektora u odgovarajućem mjestu u ramu. Namotaji releja su ispitani dovođenjem istosmjernog napona preko zaštitnog otpornika ili direktno na pojedine namotaje u zavisnosti od tipa ispitanog releja. Ostale komponente uređaja su ispitane i izvršena je izmjena istih u slučaju neispravnog rada.";

    var mapState = {'UredjajId': widget.uredjaj.uredjajId.toString()};
    _fetchData(mapState);

    super.initState();
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    var mapState = {'TipUredjajaNaziv': widget.uredjaj.tipNaziv};

    //var temp = await komponenteProvider!.get(map, "ServisIzvrsen/Komponente");
    var tempRecommended = await komponenteProvider!.get(mapState, "ServisIzvrsen/Komponente");

    setState(() {
      //komponenteList = temp;
      preporuceneKomponenteList = tempRecommended;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: BarrApp(
        naslov: 'Servisiraj',
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text('Info o uređaju', style: TextStyle(fontSize: 20)),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Expanded(
                    child: Card(
                      elevation: 5,
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(15.0),
                      ),
                      child: Padding(
                        padding: const EdgeInsets.all(16.0),
                        child: Row(
                          crossAxisAlignment: CrossAxisAlignment.center,
                          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                          children: [
                            _buildInfoCard('Evidencijski broj', widget.uredjaj.uredjajId.toString()),
                            _buildInfoCard('Tip', widget.uredjaj.tipNaziv ?? ""),
                            _buildInfoCard('Koda', widget.uredjaj.koda ?? ""),
                            _buildInfoCard('Serijski broj', widget.uredjaj.serijskiBroj ?? ""),
                            _buildInfoCard('Status', StateHelper.nizRezultat(widget.uredjaj.status ?? "")),
                            _buildInfoCard('Lokacija', widget.uredjaj.lokacijaNaziv ?? ""),
                          ],
                        ),
                      ),
                    ),
                  ),
                  SizedBox(width: 30),
                ],
              ),
              SizedBox(height: 20),
              Text('Dodaj komponentu', style: TextStyle(fontSize: 20)),
              Card(
                child: Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      SizedBox(height: 10),
                      Column(
                        children: [
                          SizedBox(height: 10),
                          Container(
                            width: 300,
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                              children: [
                                _buildTextField('Naziv', nazivController, false),
                                _buildTextField('Koda', kodaController, false),
                                _buildTextField('Vrijednost/Količina', vrijednostController, false),
                                Container(
                                    width: 300,
                                    child: MinimalisticButton(
                                        icons: const Icon(
                                          Icons.save,
                                          color: Colors.black,
                                        ),
                                        onPressed: () async {
                                          if (nazivController.text == "") {
                                            setState(() {
                                              _validate = true;
                                            });
                                            return;
                                          }

                                          var kompSearch = {
                                            'Naziv': nazivController.text,
                                            'Vrijednost': vrijednostController.text,
                                            'Tip': kodaController.text
                                          };
                                          setState(() {
                                            _validate = false;
                                          });

                                          _validate = false;

                                          var komp = await komponenteProvider!.get(kompSearch, "Komponente");

                                          if (komp.isEmpty && nazivController.text != "") {
                                            var komponenta;
                                            try {
                                              komponenta = await komponenteProvider!.insert(kompSearch, "Komponente");
                                            } catch (e) {
                                              poruka(e.toString());
                                              return;
                                            }

                                            if (dodajUListu(komponenta ?? komp.first)) {
                                              poruka("Komponenta je dodana na listu zamijenjenih komponenti");
                                              clearTextBox();
                                              return;
                                            }

                                            clearTextBox();
                                            return;
                                          }

                                          if (dodajUListu(komp.first)) {
                                            poruka("Komponenta je dodana na listu zamijenjenih komponenti");
                                            clearTextBox();
                                          }
                                        },
                                        text: "Sačuvaj i dodaj komponentu"))
                              ],
                            ),
                          ),
                        ],
                      ),
                      SizedBox(width: 10),
                      Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          _buildDropdownButton(),
                          SizedBox(height: 10),
                          MinimalisticButton(
                            icons: const Icon(
                              Icons.add,
                              color: Colors.black,
                            ),
                            onPressed: () {
                              dodajUListu(selectedKomponenta);
                            },
                            text: 'Dodaj komponentu',
                          ),
                        ],
                      ),
                    ],
                  ),
                ),
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                //crossAxisAlignment: CrossAxisAlignment.,
                children: [
                  Container(width: 500, child: _buildTextField('Opis aktivnosti servisa', opisController, true)),
                  Card(
                    child: Column(
                      children: [
                        Text('Lista zamijenjenih komponenti', style: TextStyle(fontSize: 20)),
                        SizedBox(height: 10),
                        Column(children: [_buildDataTable(komponenteList)]),
                      ],
                    ),
                  ),
                  BlocProvider(
                    create: (context) => RadniZadatakUredjajBloc(radniZadaciUredjajProvider: radniZadatakUredjajProvider!),
                    child: MinimalisticButton(
                        icons: const Icon(
                          Icons.build,
                          color: Colors.black,
                        ),
                        text: "Servisiraj",
                        onPressed: () async {
                          List<int> komponenteId = [];

                          var radniZadatakRequest = {'UredjajId': widget.uredjaj.uredjajId.toString(), 'RadniZadatakState': 'active'};

                          var radniZadatak = await radniZadatakProvider!.get(radniZadatakRequest, "RadniZadatakUredjaj");

                          if (komponenteList.isNotEmpty) {
                            komponenteId = komponenteList.select((element, index) => element.komponentaId).toList();
                          }

                          var request = {
                            'napomena': '',
                            'korisnikId': User.id,
                            'uredjajId': widget.uredjaj.uredjajId,
                            'radniZadatakId': radniZadatak.length != 0 ? radniZadatak.first.radniZadatakId : 1,
                            'datum': DateTime.now().toIso8601String(),
                            'komponenteIdList': komponenteId
                          };

                          try {
                            var temp = await uredjajProvider!.update(null, request, "Uredjaj/Servisiraj");

                            poruka("Uređaj je uspješno servisiran.");
                          } catch (e, stackTrace) {
                            poruka(e.toString());
                          }

                          setState(() {
                            komponenteList = [];
                            selectedKomponenta = null;
                          });

                          clearTextBox();
                        }),
                  )
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }

  bool dodajUListu(Komponenta? selectedKomponenta) {
    if (selectedKomponenta == null) {
      poruka("Odaberite komponentu");
      return false;
    }

    for (var komp in komponenteList) {
      if (komp.komponentaId == selectedKomponenta.komponentaId) {
        poruka("Komponenta je već u listi");
        return false;
      }
    }

    setState(() {
      komponenteList.add(selectedKomponenta);
    });
    return true;
  }

  void poruka(String poruka) {
    ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack(poruka));
  }

  void clearTextBox() {
    vrijednostController.clear();
    kodaController.clear();
    nazivController.clear();
  }

  Widget _buildInfoCard(String title, String value) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Text(
          title,
          style: TextStyle(
            fontSize: 14,
            fontWeight: FontWeight.bold,
            color: Colors.grey,
          ),
        ),
        SizedBox(height: 5),
        Text(
          value,
          style: TextStyle(
            fontSize: 16,
            fontWeight: FontWeight.bold,
          ),
        ),
      ],
    );
  }

  Widget _buildTextField(String placeholder, TextEditingController controller, bool rich) {
    return Container(
      margin: EdgeInsets.only(bottom: 10),
      child: TextField(
        maxLines: rich ? 10 : 1,
        textAlign: TextAlign.justify,
        controller: controller,
        decoration: InputDecoration(
            labelText: placeholder,
            border: OutlineInputBorder(),
            errorText: _validate && controller == nazivController ? 'Unesite naziv komponente' : null),
      ),
    );
  }

  Widget _buildDropdownButton() {
    return DropdownButton<Komponenta>(
      value: selectedKomponenta,
      onChanged: (Komponenta? value) {
        setState(() {
          selectedKomponenta = value!;
        });
      },
      items: preporuceneKomponenteList.map<DropdownMenuItem<Komponenta>>((Komponenta value) {
        return DropdownMenuItem<Komponenta>(
          value: value,
          child: Text(value.naziv.toString() + " - " + value.vrijednost.toString() + " - " + value.tip.toString()),
        );
      }).toList(),
      hint: Text('Prijedlog komponente'),
    );
  }

  Widget _buildDataTable(List<Komponenta> komp) {
    return DataTable(
      columns: [
        DataColumn(label: Text('#')),
        DataColumn(label: Text('Naziv')),
        DataColumn(label: Text('Vrijednost')),
        DataColumn(label: Text('Koda')),
        DataColumn(label: Text('ID')),
        DataColumn(label: Text('Opcije')),
      ],
      rows: komp
          .map((e) => DataRow(cells: [
                DataCell(Text((komp.indexWhere((element) => element.komponentaId == e.komponentaId) + 1).toString())),
                DataCell(Text(e.naziv ?? "")),
                DataCell(Text(e.vrijednost ?? "")),
                DataCell(Text(e.tip ?? "")),
                DataCell(Text(e.komponentaId.toString())),
                DataCell(PopupMenuButton<String>(
                                          initialValue: selected,
                                          // Callback that sets the selected popup menu item.
                                          onSelected: (izbor) {
                                            showDialog(
                                                  context: context,
                                                  builder: (BuildContext context) {
                                                    return AlertDialog(
                                                      title: Text("Da li želite ukloniti komponentu?"),
                                                      content: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                                                        ElevatedButton(
                                                            child: Text("Potvrdi"),
                                                            style: ElevatedButton.styleFrom(
                                                              elevation: 2,
                                                            ),
                                                            onPressed: () async {
                                                              setState(() {
                                                                
                                                              komponenteList.remove(e);
                                                              });
                                                              Navigator.pop(context);
                                                            }),
                                                        ElevatedButton(
                                                            child: Text("Poništi", style: TextStyle(color: Colors.white),),
                                                            style: ElevatedButton.styleFrom(elevation: 2, backgroundColor: Colors.redAccent),
                                                            onPressed: () async {
                                                              Navigator.pop(context);
                                                            })
                                                      ]),
                                                    );
                                                  });
                                          },
                                          itemBuilder: (BuildContext context) => <PopupMenuEntry<String>>[
                                            PopupMenuItem<String>(
                                              child: Text('Ukloni'),
                                              value: 'remove',
                                            ),
                                          ],
                                        )),
              ]))
          .toList(),
    );
  }
}
