import 'package:commons/models/komponenta.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/models/user.dart';
import 'package:commons/providers/izvrseni_servis_provider.dart';
import 'package:commons/providers/komponente_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:commons/providers/uredjaj_provider.dart';

import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';

import 'package:provider/provider.dart';
import 'package:workshop_app/helpers/common_widget.dart';
import 'package:workshop_app/screens/uredjaji/uredjaj_detalji.dart';

import '../../helpers/bottom_bar.dart';
import '../../helpers/master_screen.dart';

class ServisirajScreen extends StatefulWidget {
  static const routeName = "/Servisiraj";
  Uredjaj? uredjaj;

  ServisirajScreen();

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
  KomponenteProvider? komponenteProvider = null;
  IzvrseniServisProvider? izvrseniServisProvider = null;
  UredjajProvider? uredjajProvider = null;
  List<Komponenta> poreporuceneKomponente = [];
  List<Komponenta> servisKomponente = [];
  String? selected;
  RadniZadatakUredjaj? radniZadatakUredjaj = null;

  late RadniZadaciUredjajProvider radniZadaciUredjajProvider;

  bool provjera = false;

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

    komponenteProvider = context.read<KomponenteProvider>();

    izvrseniServisProvider = context.read<IzvrseniServisProvider>();

    uredjajProvider = context.read<UredjajProvider>();

    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();

    provjera = true;

    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    var komponenteRecommended = await komponenteProvider!.get({'TipUredjajaNaziv': widget.uredjaj!.tipNaziv}, "ServisIzvrsen/Komponente");

    List<RadniZadatakUredjaj> uredjajIzZadatka = [];

    if (widget.uredjaj!.status == "task" || widget.uredjaj!.status == "fix" || widget.uredjaj!.status == "ready" || widget.uredjaj!.status == "out") {
      uredjajIzZadatka =
          await radniZadaciUredjajProvider.get({'UredjajId': widget.uredjaj!.uredjajId, 'StateMachine': 'active'}, "RadniZadatakUredjaj/Flutter");
    }

    setState(() {
      poreporuceneKomponente = komponenteRecommended;
      if (uredjajIzZadatka.isNotEmpty) {
        radniZadatakUredjaj = uredjajIzZadatka.first;
      }
    });
  }

  void servis() async {
    List<int> komponenteId = [];

    for (var i = 0; i < servisKomponente.length; i++) {
      komponenteId.add(servisKomponente[i].komponentaId);
    }

    Map<String, dynamic> request = {
      'napomena': '',
      'korisnikId': User.id,
      'uredjajId': uredjaj!.uredjajId.toString(),
      'radniZadatakId': radniZadatakUredjaj?.radniZadatakId ?? "1",
      'komponenteIdList': komponenteId,
      'datum': DateTime.now().toIso8601String()
    };

    await uredjajProvider!.update(null, request, "Uredjaj/Servisiraj");
  }

  @override
  Widget build(BuildContext context) {
    return WillPopScope(
      onWillPop: () async {
        return false;
      },
      child: Scaffold(
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
                        content: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                          ElevatedButton(
                              child: Text("Potvrdi"),
                              style: ElevatedButton.styleFrom(
                                elevation: 0,
                              ),
                              onPressed: () async {
                                servis();

                                Navigator.pop(context);
                                Navigator.push(context, MaterialPageRoute(builder: (context) => UredjajDetaljiScreen.detalji(uredjaj!)));

                                for (var i = 0; i < servisKomponente.length; i++) {
                                  servisKomponente.removeAt(i);
                                }

                                setState(() {
                                  dropdownvalue = null;
                                });

                                return showDialog(
                                    context: context,
                                    builder: (BuildContext context) {
                                      return AlertDialog(
                                        title: Text("Uređaj je uspješno servisiran"),
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
            child: Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
              Container(padding: EdgeInsets.fromLTRB(10, 10, 0, 0), child: CommonWidget.UredjajDetalji(uredjaj!)),
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
                        unosKomponente("Vrijednost/Količina", vrijednostTextController),
                      ],
                    )),
                Container(
                    padding: EdgeInsets.fromLTRB(50, 0, 0, 0),
                    child: ElevatedButton(
                        child: Text("Dodaj"),
                        onPressed: () {
                          var map = {
                            'naziv': nazivTextController.text,
                            'vrijednost': vrijednostTextController.text,
                            'opis': '',
                            'tip': kodaTextController.text
                          };
                          dodajKomponentu(map);
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
                      setState(() {
                        dropdownvalue = valueSet;
                      });
                    },
                    items: poreporuceneKomponente.map<DropdownMenuItem<Komponenta>>((Komponenta value) {
                      return DropdownMenuItem<Komponenta>(
                        value: value,
                        child: Text(value.naziv.toString() + " - " + value.tip.toString()),
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
                          if (servisKomponente[i].komponentaId == dropdownvalue!.komponentaId) {
                            ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Komponenta već postoji na listi!"));
                            return;
                          }
                        }

                        if (dropdownvalue != null) {
                          setState(() {
                            servisKomponente.add(dropdownvalue!);
                          });
                          ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Uspješno je dodana komponenta na listu!"));
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
                    columns: [DataColumn(label: Text("Naziv")), DataColumn(label: Text("Vrijednost/Koda")), DataColumn(label: Text("Opcije"))],
                    rows: komponente()),
              ),
            ]),
          )),
    );
  }

  List<DataRow> komponente() {
    List<DataRow> list = servisKomponente
        .map((e) => DataRow(onLongPress: () {}, cells: [
              DataCell(Text(e.naziv.toString())),
              DataCell(Text((e.vrijednost == null ? '' : e.vrijednost.toString()) + e.tip.toString())),
              DataCell(PopupMenuButton<String>(
                initialValue: selected,
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
                                          padding: const EdgeInsets.fromLTRB(0, 0, 0, 10),
                                          height: 50,
                                          width: 200,
                                          child: TextField(
                                              controller: nazivEditTextController,
                                              decoration: InputDecoration(
                                                border: OutlineInputBorder(),
                                                labelText: "Naziv",
                                              ))),
                                      Container(
                                          padding: const EdgeInsets.fromLTRB(0, 0, 0, 10),
                                          height: 50,
                                          width: 200,
                                          child: TextField(
                                              controller: kodaEditTextController,
                                              decoration: InputDecoration(
                                                border: OutlineInputBorder(),
                                                labelText: "Koda",
                                              ))),
                                      Container(
                                          padding: const EdgeInsets.fromLTRB(0, 0, 0, 10),
                                          height: 50,
                                          width: 200,
                                          child: TextField(
                                              controller: vrijednostEditTextController,
                                              decoration: InputDecoration(
                                                border: OutlineInputBorder(),
                                                labelText: "Vrijednost",
                                              ))),
                                      Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                                        ElevatedButton(
                                            child: Text("Potvrdi"),
                                            style: ElevatedButton.styleFrom(
                                              primary: Colors.blueAccent,
                                              elevation: 0,
                                            ),
                                            onPressed: () async {
                                              var request = {
                                                'naziv': nazivEditTextController.text,
                                                'vrijednost': vrijednostEditTextController.text,
                                                'opis': e.opis ?? '',
                                                'tip': kodaEditTextController.text
                                              };

                                              var prijePromjene = e;

                                              try {
                                                var komponenta = await komponenteProvider!.update(e.komponentaId, request, 'Komponente');

                                                setState(() {
                                                  e = komponenta!;
                                                  servisKomponente.remove(prijePromjene);
                                                  servisKomponente.add(e);
                                                });

                                                Navigator.pop(context);

                                                showDialog(
                                                    context: context,
                                                    builder: (BuildContext context) {
                                                      return AlertDialog(title: Text("Uspješno je uređena komponenta"));
                                                    });
                                              } catch (ex) {
                                                showDialog(
                                                    context: context,
                                                    builder: (BuildContext context) {
                                                      return AlertDialog(title: Text(ex.toString()));
                                                    });
                                              }
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
                      showDialog(
                        context: context,
                        builder: (BuildContext context) {
                          return AlertDialog(
                            title: Text("Da li želite ukloniti komponentu sa liste zamijenjenih komponenti?"),
                            content: Container(
                                height: 200,
                                child: Row(
                                  mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                                  children: [
                                    ElevatedButton(
                                        child: Text("Potvrdi"),
                                        style: ElevatedButton.styleFrom(
                                          primary: Colors.blueAccent,
                                          elevation: 0,
                                        ),
                                        onPressed: () {
                                          setState(() {
                                            servisKomponente.remove(e);
                                          });
                                          Navigator.pop(context);
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
                                  ],
                                )),
                          );
                        },
                      );
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

  Container editKomponenta(String nazivPolja, TextEditingController controller) {
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

  Container unosKomponente(String nazivPolja, TextEditingController controller) {
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
    mapSearch = {'Naziv': map['naziv']!, 'Vrijednost': map['vrijednost']!, 'Opis': map['opis']!, 'Tip': map['tip']!};
    var provjera = await komponenteProvider!.get(mapSearch, "Komponente");

    List<Komponenta> komponente = [];

    setState(() {
      komponente = provjera;
    });

    //komponenta ne postoji u bazi
    if (komponente.isEmpty) {
      try {
        var komp = await komponenteProvider!.insert(map, "Komponente");

        setState(() {
          servisKomponente.add(komp!);
        });

        showDialog(
            context: context,
            builder: (BuildContext context) {
              return AlertDialog(title: Text("Komponenta je uspješno dodana"));
            });
      } catch (e) {
        showDialog(
            context: context,
            builder: (BuildContext context) {
              return AlertDialog(title: Text(e.toString()));
            });
      }

      nazivTextController.clear();
      kodaTextController.clear();
      vrijednostTextController.clear();
    }
    //komponenta postoji u bazi
    else if (komponente.isNotEmpty) {
      for (var i = 0; i < servisKomponente.length; i++) {
        if (servisKomponente[i].komponentaId == komponente.first.komponentaId) {
          return showDialog(
              context: context,
              builder: (BuildContext context) {
                return AlertDialog(title: Text("Komponenta već postoji na listi"));
              });
        }
        setState(() {
          servisKomponente.add(komponente.first);
        });
      }
    }
    nazivTextController.clear();
    kodaTextController.clear();
    vrijednostTextController.clear();
  }
}
