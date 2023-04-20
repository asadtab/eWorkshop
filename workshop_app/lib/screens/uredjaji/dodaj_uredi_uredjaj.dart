import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/providers/tip_uredjaja_provider.dart';

import '../../helpers/bottom_bar.dart';
import '../../helpers/common_widget.dart';
import '../../helpers/master_screen.dart';
import '../../model/lokacija.dart';
import '../../model/tip_uredjaja.dart';
import '../../model/uredjaj.dart';
import '../../providers/lokacija_provider.dart';
import '../../providers/uredjaji_provider.dart';

class DodajUrediUredjajScreen extends StatefulWidget {
  static const String routeName = "/dodajUredi";
  Uredjaj? uredjaj = new Uredjaj();

  DodajUrediUredjajScreen.uredi(Uredjaj? uredjaj) {
    this.uredjaj = uredjaj;
  }

  DodajUrediUredjajScreen({super.key});

  @override
  State<DodajUrediUredjajScreen> createState() => _DodajUrediUredjajScreen(uredjaj);
}

class _DodajUrediUredjajScreen extends State<DodajUrediUredjajScreen> {
  Uredjaj? uredjaj;
  int EvBroj = 0;

  TipUredjaja? dropdownvalue;
  Lokacija? lokacijaDropdownValue;

  TipUredjajaProvider? tipUredjajaProvider = null;
  UredjajiProvider? uredjajiProvider = null;
  LokacijaProvider? lokacijaProvider = null;

  List<TipUredjaja> tipUredjajaList = [];
  List<Lokacija> lokacijaList = [];

  final _formKey = GlobalKey<FormState>();
  final _formKeyTip = GlobalKey<FormState>();
  final _formKeyLokacija = GlobalKey<FormState>();

  final kodaTextController = TextEditingController();
  final izdanjeTextController = TextEditingController();
  final serijskiBrojTextController = TextEditingController();
  final prijemTextController = TextEditingController();

  final tipNazivTextController = TextEditingController();
  final tipOpisTextController = TextEditingController();

  final lokacijaTextController = TextEditingController();

  _DodajUrediUredjajScreen(Uredjaj? uredjaj) {
    this.uredjaj = uredjaj;

    kodaTextController.text = uredjaj!.koda ?? "";
    izdanjeTextController.text = uredjaj.datumIzvedbe ?? "";
    serijskiBrojTextController.text = uredjaj.serijskiBroj ?? "";
  }

  @override
  void initState() {
    super.initState();

    tipUredjajaProvider = context.read<TipUredjajaProvider>();
    lokacijaProvider = context.read<LokacijaProvider>();
    uredjajiProvider = context.read<UredjajiProvider>();
    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    var items = await tipUredjajaProvider?.get(null, "TipUredjaja");
    var lokacija = await lokacijaProvider?.get(null, "Lokacija");
    var uredjaji = await uredjajiProvider?.get({'GetNajveciEvBroj': true}, "Uredjaj");
    if (mounted) {
      setState(() {
        tipUredjajaList = items!;
        lokacijaList = lokacija!;

        for (var i = 0; i < lokacijaList.length; i++) {
          if (lokacijaList[i].naziv == uredjaj!.lokacijaNaziv) {
            lokacijaDropdownValue = lokacijaList[i];
          }
        }

        for (var i = 0; i < tipUredjajaList.length; i++) {
          if (tipUredjajaList[i].naziv == uredjaj!.tipNaziv) {
            dropdownvalue = tipUredjajaList[i];
          }
        }
        uredjaji!.sort((a, b) => b.uredjajId!.compareTo(a.uredjajId!));
        EvBroj = uredjaji.first.uredjajId!;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    return Scaffold(
      drawer: DrawerWidget(),
      appBar: AppBar(title: (Text("Prijem uređaja"))),
      bottomNavigationBar: MyBottomBar(),
      floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          if (_formKey.currentState!.validate() && dropdownvalue != null && lokacijaDropdownValue != null) {
            _formKey.currentState!.save();

            _sacuvaj();
          } else if (!_formKey.currentState!.validate()) {
            ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Popunite obavezna polja!"));
          } else if (dropdownvalue == null) {
            ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Tip uređaja nije odabran!"));
          } else if (lokacijaDropdownValue == null) {
            ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Lokacija nije odabrana!"));
          } else {
            ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Netačan unos!"));
            return;
          }
        },
        child: Icon(Icons.done),
      ),
      body: SingleChildScrollView(
          child: Container(
              padding: EdgeInsets.fromLTRB(10, 50, 20, 10),
              child: Column(
                children: [
                  Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                    Container(
                        child: Text(
                      "Posljedni evidencijski broj:",
                      style: TextStyle(fontSize: 20),
                    )),
                    Container(
                      child: Text(EvBroj.toString(), style: TextStyle(fontSize: 20)),
                    )
                  ]),
                  Container(
                    padding: EdgeInsets.fromLTRB(0, 20, 0, 20),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [
                        DropdownButton<TipUredjaja>(
                          value: dropdownvalue,
                          icon: const Icon(Icons.arrow_downward),
                          elevation: 16,
                          hint: Container(child: Text("Odaberi tip uređaja")),
                          style: const TextStyle(color: Colors.deepPurple),
                          underline: Container(
                            height: 2,
                            color: Colors.blueGrey,
                          ),
                          onChanged: (TipUredjaja? valueSet) {
                            setState(() {
                              dropdownvalue = valueSet;
                            });
                          },
                          items: tipUredjajaList.map<DropdownMenuItem<TipUredjaja>>((TipUredjaja value) {
                            return DropdownMenuItem<TipUredjaja>(
                              value: value,
                              child: Text(value.opisNaziv.toString()),
                            );
                          }).toList(),
                        ),
                        ElevatedButton(
                          onPressed: () {
                            noviTipUredjaja();
                          },
                          child: const Icon(Icons.add),
                          style: ElevatedButton.styleFrom(shape: CircleBorder(), padding: EdgeInsets.all(10)),
                        ),
                      ],
                    ),
                  ),
                  Container(
                      child: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                    DropdownButton<Lokacija>(
                      value: lokacijaDropdownValue,
                      icon: const Icon(Icons.arrow_downward),
                      elevation: 16,
                      hint: Container(child: Text("Odaberi lokaciju")),
                      style: const TextStyle(color: Colors.deepPurple),
                      underline: Container(
                        height: 2,
                        color: Colors.blueGrey,
                      ),
                      onChanged: (Lokacija? valueSet) {
                        // This is called when the user selects an item.
                        setState(() {
                          lokacijaDropdownValue = valueSet;
                        });
                      },
                      items: lokacijaList.map<DropdownMenuItem<Lokacija>>((Lokacija value) {
                        return DropdownMenuItem<Lokacija>(
                          value: value,
                          child: Text(value.naziv.toString()),
                        );
                      }).toList(),
                    ),
                    ElevatedButton(
                      onPressed: () {
                        novaLokacija();
                      },
                      child: const Icon(Icons.add),
                      style: ElevatedButton.styleFrom(shape: CircleBorder(), padding: EdgeInsets.all(10)),
                    )
                  ])),
                  Container(
                      padding: EdgeInsets.fromLTRB(0, 0, 0, 10),
                      child: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                        Container(
                            width: 300,
                            child: Form(
                                key: _formKey,
                                child: Column(children: [
                                  TextFormField(
                                    controller: kodaTextController,
                                    decoration: InputDecoration(
                                      labelText: 'Koda',
                                    ),
                                    //initialValue: _koda,
                                    validator: (value) {
                                      if (value == null || value.isEmpty) {
                                        return 'Unesi kodu uređaja';
                                      }
                                      return null;
                                    },
                                    onSaved: (value) {},
                                  ),
                                  TextFormField(
                                    controller: izdanjeTextController,
                                    decoration: InputDecoration(
                                      labelText: 'Izdanje',
                                    ),
                                    //initialValue: _izdanje,
                                    validator: (value) {
                                      if (value == null || value.isEmpty) {
                                        return 'Unesi izdanje uređaja';
                                      }
                                      return null;
                                    },
                                    onSaved: (value) {},
                                  ),
                                  TextFormField(
                                    controller: serijskiBrojTextController,
                                    decoration: InputDecoration(
                                      labelText: 'Serijski broj',
                                    ),
                                    //initialValue: _serijskiBroj,
                                    validator: (value) {
                                      if (value == null || value.isEmpty) {
                                        return 'Unesi serijski broj uređaja';
                                      }
                                      return null;
                                    },
                                    onSaved: (value) {},
                                  ),
                                  TextFormField(
                                    controller: prijemTextController,
                                    decoration: InputDecoration(
                                      labelText: 'Opis uređaja kod prijema',
                                    ),
                                    //initialValue: _prijem,
                                    onSaved: (value) {},
                                  )
                                ])))
                      ])),
                  Row(mainAxisAlignment: MainAxisAlignment.center, children: [
                    Container(
                        padding: EdgeInsets.fromLTRB(0, 20, 0, 0),
                        height: 50,
                        width: 170,
                        child: ElevatedButton(
                          onPressed: () {
                            serijskiBrojTextController.text = EvBroj.toString() + "/" + DateTime.now().year.toString();
                          },
                          child: const Text("Generiši serijski broj"),
                          style: ElevatedButton.styleFrom(),
                        ))
                  ]),
                ],
              ))),
    );
  }

  void _sacuvaj() async {
    var request = {
      'tipId': dropdownvalue!.tipUredjajaId,
      'koda': kodaTextController.text,
      'serijskiBroj': serijskiBrojTextController.text,
      'datumIzvedbe': izdanjeTextController.text,
      'lokacijaId': lokacijaDropdownValue!.lokacijaId
    };

    if (uredjaj!.uredjajId == null) {
      await uredjajiProvider!.insert(request, "Uredjaj");
    }

    if (uredjaj!.uredjajId != null) {
      await uredjajiProvider!.update(uredjaj!.uredjajId, request, "Uredjaj");
    }

    ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Uspješno!"));

    clear();
  }

  void clear() {
    kodaTextController.clear();
    izdanjeTextController.clear();
    serijskiBrojTextController.clear();
    prijemTextController.clear();

    dropdownvalue = null;
    lokacijaDropdownValue = null;
  }

  void noviTipUredjaja() {
    showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text("Dodaj novi tip uređaja"),
            content: Container(
                height: 250,
                child: Column(children: [
                  Form(
                      key: _formKeyTip,
                      child: Column(children: [
                        TextFormField(
                          controller: tipNazivTextController,
                          decoration: InputDecoration(
                            labelText: 'Naziv',
                          ),
                          //initialValue: _koda,
                          validator: (value) {
                            if (value == null || value.isEmpty) {
                              return 'Unesi naziv tipa uređaja';
                            }
                            return null;
                          },
                          onSaved: (value) {},
                        ),
                        TextFormField(
                          controller: tipOpisTextController,
                          decoration: InputDecoration(
                            labelText: 'Opis',
                          ),
                          //initialValue: _izdanje,
                          validator: (value) {
                            if (value == null || value.isEmpty) {
                              return 'Unesi puno ime tipa uređaja';
                            }
                            return null;
                          },
                          onSaved: (value) {},
                        )
                      ])),
                  Container(
                      padding: EdgeInsets.fromLTRB(0, 20, 0, 0),
                      child: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                        ElevatedButton(
                            child: Text("Potvrdi"),
                            style: ElevatedButton.styleFrom(
                              elevation: 2,
                            ),
                            onPressed: () async {
                              var request = {'naziv': tipNazivTextController.text, 'opis': tipOpisTextController.text};

                              if (_formKeyTip.currentState!.validate()) {
                                _formKeyTip.currentState!.save();

                                try {
                                  await tipUredjajaProvider?.insert(request, "TipUredjaja");
                                } catch (e) {
                                  ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
                                  Navigator.pop(context);
                                  return;
                                }

                                ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Uspješno je dodan novi tip uređaja"));
                                tipOpisTextController.clear();
                                tipNazivTextController.clear();
                                _fetchData(null);
                                Navigator.pop(context);
                              }
                            }),
                        ElevatedButton(
                            child: Text("Poništi"),
                            style: ElevatedButton.styleFrom(
                              primary: Color.fromARGB(255, 170, 70, 63),
                              elevation: 2,
                            ),
                            onPressed: () {
                              tipOpisTextController.clear();
                              tipNazivTextController.clear();
                              Navigator.pop(context);
                            })
                      ]))
                ])),
          );
        });
  }

  void novaLokacija() {
    showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text("Dodaj novu lokaciju"),
            content: Container(
                height: 170,
                child: Column(children: [
                  Form(
                      key: _formKeyLokacija,
                      child: Column(children: [
                        TextFormField(
                          controller: lokacijaTextController,
                          decoration: InputDecoration(
                            labelText: 'Naziv lokacije',
                          ),
                          //initialValue: _koda,
                          validator: (value) {
                            if (value == null || value.isEmpty) {
                              return 'Unesite naziv lokacije';
                            }
                            return null;
                          },
                          onSaved: (value) {},
                        ),
                      ])),
                  Container(
                      padding: EdgeInsets.fromLTRB(0, 29, 0, 0),
                      child: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                        ElevatedButton(
                            child: Text("Potvrdi"),
                            style: ElevatedButton.styleFrom(
                              elevation: 2,
                            ),
                            onPressed: () async {
                              var request = {'naziv': lokacijaTextController.text};

                              await lokacijaProvider!.insert(request, "Lokacija");

                              if (_formKeyLokacija.currentState!.validate()) {
                                _formKeyLokacija.currentState!.save();

                                try {
                                  await lokacijaProvider!.insert(request, "Lokacija");
                                } catch (e) {
                                  ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
                                }

                                ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Uspješno je dodana nova lokacija"));
                                lokacijaTextController.clear();
                                _fetchData(null);
                                Navigator.pop(context);
                              }
                            }),
                        ElevatedButton(
                            child: Text("Poništi"),
                            style: ElevatedButton.styleFrom(
                              primary: Color.fromARGB(255, 170, 70, 63),
                              elevation: 2,
                            ),
                            onPressed: () {
                              lokacijaTextController.clear();
                              Navigator.pop(context);
                            })
                      ]))
                ])),
          );
        });
  }
}
