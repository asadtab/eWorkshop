import 'package:darq/darq.dart';
import 'package:flinq/flinq.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:focused_menu/focused_menu.dart';
import 'package:focused_menu/modals.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/helpers/common_widget.dart';
import 'package:workshop_app/providers/izvrseni_servis_provider.dart';
import 'package:workshop_app/screens/uredjaji/uredjaj_detalji.dart';

import '../../helpers/bottom_bar.dart';
import '../../helpers/master_screen.dart';
import '../../helpers/state_helper.dart';
import '../../model/komponenta.dart';
import '../../model/uredjaj.dart';
import '../../providers/komponente_provider.dart';
import '../../providers/komponente_recommended_provider.dart';
import '../../providers/uredjaji_provider.dart';

class ServisirajScreen extends StatefulWidget {
  static const routeName = "/Servisiraj";
  Uredjaj? uredjaj;

  ServisirajScreen({super.key});

  ServisirajScreen.servis(Uredjaj uredjaj) {
    this.uredjaj = uredjaj;
  }

  @override
  State<ServisirajScreen> createState() => _ServisirajScreenState(uredjaj);
}

enum SampleItem { itemOne, itemTwo, itemThree }

class _ServisirajScreenState extends State<ServisirajScreen> {
  Uredjaj? uredjaj;
  _ServisirajScreenState(Uredjaj? uredjaj) {
    this.uredjaj = uredjaj;
  }
  Komponenta? dropdownvalue = null;
  KomponenteRecommendedProvider? komponentaRecommendedProvider = null;
  KomponenteProvider? komponenteProvider = null;
  IzvrseniServisProvider? izvrseniServisProvider = null;
  UredjajiProvider? uredjajProvider = null;
  List<Komponenta> poreporuceneKomponente = [];
  List<Komponenta> servisKomponente = [];
  String? selected;

  final nazivTextController = TextEditingController();
  final kodaTextController = TextEditingController();
  final vrijednostTextController = TextEditingController();

  final nazivEditTextController = TextEditingController();
  final kodaEditTextController = TextEditingController();
  final vrijednostEditTextController = TextEditingController();

  @override
  void dispose() {
    nazivTextController.dispose();
    kodaTextController.dispose();
    vrijednostTextController.dispose();
    super.dispose();
  }

  @override
  void initState() {
    super.initState();

    komponentaRecommendedProvider =
        context.read<KomponenteRecommendedProvider>();

    komponenteProvider = context.read<KomponenteProvider>();

    izvrseniServisProvider = context.read<IzvrseniServisProvider>();

    uredjajProvider = context.read<UredjajiProvider>();

    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    var items = await komponentaRecommendedProvider?.get(
        {'TipUredjajaNaziv': uredjaj!.tipNaziv}, "ServisIzvrsen/Komponente");

    setState(() {
      poreporuceneKomponente = items!;
    });
  }

  void servis() async {
    List<int> komponenteId = [];

    for (var i = 0; i < servisKomponente.length; i++) {
      komponenteId.add(servisKomponente[i].komponentaId);
    }

    Map<String, dynamic> request = {
      'napomena': '',
      'korisnikId': '1',
      'uredjajId': uredjaj!.uredjajId.toString(),
      'radniZadatakId': '1',
      'komponenteIdList': komponenteId,
      'datum': DateTime.now().toIso8601String()
    };

    await uredjajProvider!.update(null, request, "Uredjaj/Servisiraj");
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        drawer: DrawerWidget(),
        appBar: AppBar(title: (Text("Servis"))),
        bottomNavigationBar: MyBottomBar(),
        floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
        floatingActionButton: FloatingActionButton(
          onPressed: () async {
            showDialog(
                context: context,
                builder: (BuildContext context) {
                  return AlertDialog(
                      title: Text("Da li želite servisirati uređaj?"),
                      content: Row(
                          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                          children: [
                            ElevatedButton(
                                child: Text("Potvrdi"),
                                style: ElevatedButton.styleFrom(
                                  elevation: 0,
                                ),
                                onPressed: () async {
                                  servis();

                                  Navigator.pop(context);
                                  Navigator.push(
                                      context,
                                      MaterialPageRoute(
                                          builder: (context) =>
                                              UredjajDetaljiScreen.detalji(
                                                  uredjaj!)));

                                  return showDialog(
                                      context: context,
                                      builder: (BuildContext context) {
                                        return AlertDialog(
                                          title: Text(
                                              "Uređaj je uspješno servisiran"),
                                          content: ElevatedButton(
                                              child: Text("Ok"),
                                              onPressed: () {
                                                Navigator.pop(context);
                                              }),
                                        );
                                      });
                                }),
                            ElevatedButton(
                                child: Text("Poništi"),
                                style: ElevatedButton.styleFrom(
                                  primary: Color.fromARGB(255, 170, 70, 63),
                                  elevation: 0,
                                ),
                                onPressed: () {
                                  Navigator.pop(context);
                                })
                          ]));
                });
          },
          child: Icon(Icons.done),
        ),
        body: SingleChildScrollView(
          child:
              Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
            Container(
                padding: EdgeInsets.fromLTRB(10, 10, 0, 0),
                child: CommonWidget.UredjajDetalji(uredjaj!)),
            CommonWidget.dividerDetalji(),
            Container(
              padding: EdgeInsets.fromLTRB(10, 10, 0, 10),
              child: Text(
                "Dodaj komponentu:",
                style: TextStyle(fontSize: 20),
              ),
            ),
            Row(children: [
              Container(
                  padding: EdgeInsets.fromLTRB(10, 10, 0, 0),
                  child: Column(
                    children: [
                      unosKomponente("Naziv", nazivTextController),
                      unosKomponente("Koda", kodaTextController),
                      unosKomponente(
                          "Vrijednost/Količina", vrijednostTextController),
                    ],
                  )),
              Container(
                  padding: EdgeInsets.fromLTRB(50, 0, 0, 0),
                  child: ElevatedButton(
                      child: Text("Dodaj"),
                      onPressed: () {
                        showDialog(
                          context: context,
                          builder: (context) {
                            return AlertDialog(
                              content: Text(nazivTextController.text +
                                  ", " +
                                  kodaTextController.text +
                                  ", " +
                                  vrijednostTextController.text),
                            );
                          },
                        );
                      }))
            ]),
            CommonWidget.dividerDetalji(),
            Container(
              padding: EdgeInsets.fromLTRB(10, 10, 0, 0),
              child: Text(
                "Preporučene komponente:",
                style: TextStyle(fontSize: 20),
              ),
            ),
            Row(children: [
              Container(
                padding: EdgeInsets.fromLTRB(10, 0, 0, 0),
                child: DropdownButton<Komponenta>(
                  value: dropdownvalue,
                  icon: const Icon(Icons.arrow_downward),
                  elevation: 16,
                  hint: Container(child: Text("Odaberi komponentu")),
                  style: const TextStyle(color: Colors.deepPurple),
                  underline: Container(
                    height: 2,
                    color: Colors.blueGrey,
                  ),
                  onChanged: (Komponenta? valueSet) {
                    // This is called when the user selects an item.
                    setState(() {
                      dropdownvalue = valueSet;
                    });
                  },
                  items: poreporuceneKomponente
                      .map<DropdownMenuItem<Komponenta>>((Komponenta value) {
                    return DropdownMenuItem<Komponenta>(
                      value: value,
                      child: Text(value.naziv.toString() +
                          " - " +
                          value.tip.toString()),
                    );
                  }).toList(),
                ),
              ),
              Container(
                  padding: EdgeInsets.fromLTRB(50, 0, 0, 0),
                  child: ElevatedButton(
                    child: Text("Dodaj"),
                    onPressed: () {
                      for (var i = 0; i < servisKomponente.length; i++) {
                        if (servisKomponente[i].komponentaId ==
                            dropdownvalue!.komponentaId) {
                          ScaffoldMessenger.of(context).showSnackBar(
                              CommonWidget.infoSnack(
                                  "Komponenta već postoji na listi!"));
                          return;
                        }
                      }

                      if (dropdownvalue != null) {
                        setState(() {
                          servisKomponente.add(dropdownvalue!);
                        });
                        ScaffoldMessenger.of(context).showSnackBar(
                            CommonWidget.infoSnack(
                                "Uspješno je dodana komponenta na listu!"));
                      }
                    },
                  ))
            ]),
            CommonWidget.dividerDetalji(),
            Container(
              padding: EdgeInsets.fromLTRB(10, 10, 0, 0),
              child: Text(
                "Lista zamijenjenih komponenti:",
                style: TextStyle(fontSize: 20),
              ),
            ),
            Container(
              padding: EdgeInsets.fromLTRB(0, 0, 0, 50),
              child: DataTable(
                  showBottomBorder: true,
                  columns: [
                    DataColumn(label: Text("Naziv")),
                    DataColumn(label: Text("Vrijednost/Koda")),
                    DataColumn(label: Text("Opcije"))
                  ],
                  rows: komponente()),
            ),
          ]),
        ));
  }

  List<DataRow> komponente() {
    List<DataRow> list = servisKomponente
        .map((e) => DataRow(onLongPress: () {}, cells: [
              DataCell(Text(e.naziv.toString())),
              DataCell(Text(
                  (e.vrijednost == null ? '' : e.vrijednost.toString()) +
                      e.tip.toString())),
              DataCell(PopupMenuButton<String>(
                initialValue: selected,
                // Callback that sets the selected popup menu item.
                onSelected: (izbor) {
                  switch (izbor) {
                    case 'edit':
                      nazivEditTextController.text = e.naziv ?? '';
                      kodaEditTextController.text = e.tip ?? '';
                      vrijednostEditTextController.text = e.vrijednost ?? '';
                      showDialog(
                          context: context,
                          builder: (BuildContext context) {
                            return AlertDialog(
                                title: Text("Uredi info"),
                                content: Container(
                                    height: 200,
                                    child: Column(children: [
                                      Container(
                                          padding: const EdgeInsets.fromLTRB(
                                              0, 0, 0, 10),
                                          height: 50,
                                          width: 200,
                                          child: TextField(
                                              controller:
                                                  nazivEditTextController,
                                              decoration: InputDecoration(
                                                border: OutlineInputBorder(),
                                                labelText: "Naziv",
                                              ))),
                                      Container(
                                          padding: const EdgeInsets.fromLTRB(
                                              0, 0, 0, 10),
                                          height: 50,
                                          width: 200,
                                          child: TextField(
                                              controller:
                                                  kodaEditTextController,
                                              decoration: InputDecoration(
                                                border: OutlineInputBorder(),
                                                labelText: "Koda",
                                              ))),
                                      Container(
                                          padding: const EdgeInsets.fromLTRB(
                                              0, 0, 0, 10),
                                          height: 50,
                                          width: 200,
                                          child: TextField(
                                              controller:
                                                  vrijednostEditTextController,
                                              decoration: InputDecoration(
                                                border: OutlineInputBorder(),
                                                labelText: "Vrijednost",
                                              ))),
                                      Row(
                                          mainAxisAlignment:
                                              MainAxisAlignment.spaceEvenly,
                                          children: [
                                            ElevatedButton(
                                                child: Text("Potvrdi"),
                                                style: ElevatedButton.styleFrom(
                                                  primary: Colors.blueAccent,
                                                  elevation: 0,
                                                ),
                                                onPressed: () async {
                                                  var request = {
                                                    'naziv':
                                                        nazivEditTextController
                                                            .text,
                                                    'vrijednost':
                                                        vrijednostEditTextController
                                                            .text,
                                                    'opis': e.opis ?? '',
                                                    'tip':
                                                        kodaEditTextController
                                                            .text
                                                  };

                                                  var prijePromjene = e;

                                                  var komponenta =
                                                      await komponenteProvider!
                                                          .update(
                                                              e.komponentaId,
                                                              request,
                                                              'Komponente');

                                                  setState(() {
                                                    e = komponenta!;
                                                    servisKomponente
                                                        .remove(prijePromjene);
                                                    servisKomponente.add(e);
                                                  });
                                                }),
                                            ElevatedButton(
                                                child: Text("Poništi"),
                                                style: ElevatedButton.styleFrom(
                                                  primary: Colors.red,
                                                  elevation: 0,
                                                ),
                                                onPressed: () {
                                                  Navigator.pop(context);
                                                })
                                          ])
                                    ])));
                          });

                      break;
                    case 'delete':
                      setState(() {
                        servisKomponente.remove(e);
                      });

                      showDialog(
                          context: context,
                          builder: (BuildContext context) {
                            return AlertDialog(title: Text("Izbrisi"));
                          });
                  }
                },
                itemBuilder: (BuildContext context) => <PopupMenuEntry<String>>[
                  PopupMenuItem<String>(
                    child: Text('Uredi'),
                    value: 'edit',
                  ),
                  PopupMenuItem<String>(
                    child: Text('Izbriši'),
                    value: 'delete',
                  ),
                ],
              ))
            ]))
        .cast<DataRow>()
        .toList();

    return list;
  }

  Container editKomponenta(
      String nazivPolja, TextEditingController controller) {
    return Container(
        padding: const EdgeInsets.fromLTRB(0, 0, 0, 10),
        height: 50,
        width: 200,
        child: TextField(
            controller: controller,
            decoration: InputDecoration(
              border: OutlineInputBorder(),
              labelText: nazivPolja,
            )));
  }

  Container unosKomponente(
      String nazivPolja, TextEditingController controller) {
    return Container(
        padding: const EdgeInsets.fromLTRB(0, 0, 0, 10),
        height: 50,
        width: 200,
        child: TextField(
            controller: controller,
            decoration: InputDecoration(
              border: OutlineInputBorder(),
              labelText: nazivPolja,
            )));
  }

  void dodajKomponentu(Map<String, String> map) async {
    Map<String, String> mapSearch = {};
    mapSearch = {
      'Naziv': map['naziv']!,
      'Vrijednost': map['vrijednost']!,
      'Opis': map['opis']!,
      'Tip': map['tip']!
    };
    var provjera = await komponenteProvider!.get(mapSearch, "Komponente");

    List<Komponenta> komponente = [];

    setState(() {
      komponente = provjera;
    });

    if (komponente.isEmpty) {
      var request = komponenteProvider?.insert(map, "Komponente");

      nazivTextController.clear();
      kodaTextController.clear();
      vrijednostTextController.clear();

      return showDialog(
          context: context,
          builder: (BuildContext context) {
            return AlertDialog(title: Text("Komponenta je uspješno dodana"));
          });
    }

    for (var i = 0; i < servisKomponente.length; i++) {
      if (servisKomponente[i].komponentaId == komponente.first.komponentaId) {
        return showDialog(
            context: context,
            builder: (BuildContext context) {
              return AlertDialog(
                  title: Text("Komponenta već postoji na listi"));
            });
      }
    }

    setState(() {
      servisKomponente.add(komponente.first);
    });

    nazivTextController.clear();
    kodaTextController.clear();
    vrijednostTextController.clear();

    return showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(title: Text("Komponenta postoji u bazi"));
        });
  }
}
