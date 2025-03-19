import 'package:admin/bloc/lokacija/lokacija_bloc.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:darq/darq.dart';
import 'package:flutter/material.dart';
import 'package:commons/models/lokacija.dart';
import 'package:commons/models/tip_uredjaja.dart';
import 'package:commons/providers/tip_uredjaja_provider.dart';
import 'package:commons/providers/lokacija_provider.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:provider/provider.dart';

class DodajUrediUredjaj extends StatefulWidget {
  Uredjaj? editUredjaj;

  DodajUrediUredjaj({this.editUredjaj});

  @override
  State<DodajUrediUredjaj> createState() => _DodajUrediUredjajState();
}

class _DodajUrediUredjajState extends State<DodajUrediUredjaj> {
  Uredjaj uredjaj = Uredjaj();
  int? EvBroj = 0;

  TipUredjaja? dropdownvalue;
  Lokacija? lokacijaDropdownValue;

  TipUredjajaProvider? tipUredjajaProvider = null;
  UredjajProvider? uredjajiProvider = null;
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

  @override
  void initState() {
    tipUredjajaProvider = context.read<TipUredjajaProvider>();
    lokacijaProvider = context.read<LokacijaProvider>();
    uredjajiProvider = context.read<UredjajProvider>();

    kodaTextController.text = widget.editUredjaj?.koda ?? "";
    izdanjeTextController.text = widget.editUredjaj?.godinaIzvedbe ?? "";
    serijskiBrojTextController.text = widget.editUredjaj?.serijskiBroj ?? "";

    _fetchData(null);

    super.initState();
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    var items = await tipUredjajaProvider?.get(null, "TipUredjaja");
    var lokacija = await lokacijaProvider?.get(null, "Lokacija");
    var uredjaji = await uredjajiProvider?.get({'GetNajveciEvBroj': true}, "Uredjaj");
    if (mounted) {
      setState(() {
        tipUredjajaList = items!;
        lokacijaList = lokacija!;

        if (widget.editUredjaj != null) {
          dropdownvalue = null;
          lokacijaDropdownValue = null;

          dropdownvalue = tipUredjajaList.where((element) => widget.editUredjaj!.tipNaziv == element.naziv).firstOrDefault();

          for (var i = 0; i < lokacijaList.length; i++) {
            if (lokacijaList[i].naziv == widget.editUredjaj!.lokacijaNaziv) {
              lokacijaDropdownValue = lokacijaList[i];
            }
          }
        }

        if (uredjaji!.isNotEmpty) {
          uredjaji.sort((a, b) => b.uredjajId!.compareTo(a.uredjajId!));
          EvBroj = uredjaji.first.uredjajId ?? 0;
        }
      });
    }
  }
      void dropdownValueNull(){
      lokacijaDropdownValue = null;
      dropdownvalue = null;
    }

  @override
  Widget build(BuildContext context) {
    final LokacijaBloc lokacijaBloc = BlocProvider.of<LokacijaBloc>(context);



    void novaLokacija() {

dropdownValueNull();
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

                                if (_formKeyLokacija.currentState!.validate()) {
                                  _formKeyLokacija.currentState!.save();


                                  try {
                                  await lokacijaProvider!.insert(request, "Lokacija");
                                } catch (e) {
                                  ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack(e.toString()));
                                  return;
                                }

                                  ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Uspješno je dodana nova lokacija"));
                                  lokacijaTextController.clear();
                                  _fetchData(null);

                                  Navigator.pop(context);
                                }
                              }),
                          ElevatedButton(
                              child: Text("Poništi"),
                              style: ElevatedButton.styleFrom(
                                backgroundColor: Color.fromARGB(255, 170, 70, 63),
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

    return SingleChildScrollView(
      child: AlertDialog(
        content: Column(
          crossAxisAlignment: CrossAxisAlignment.end,
          children: [
            Container(
              child: IconButton(
                  onPressed: () {
                    Navigator.pop(context);
                  },
                  icon: Icon(Icons.cancel)),
            ),
            Container(
                padding: EdgeInsets.fromLTRB(10, 20, 20, 10),
                child: Column(
                  children: [
                    Row(mainAxisAlignment: MainAxisAlignment.center, children: [
                      Container(
                          child: Text(
                        "Posljedni evidencijski broj: ",
                        style: TextStyle(fontSize: 20),
                      )),
                      Container(
                        child: Text(EvBroj.toString(), style: TextStyle(fontSize: 20)),
                      )
                    ]),
                    Container(
                      padding: EdgeInsets.fromLTRB(0, 20, 0, 20),
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.center,
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
                          Tooltip(
                              message: "Dodaj novi tip uređaja",
                              child: ElevatedButton(
                                onPressed: () {
                                  noviTipUredjaja();
                                },
                                child: const Icon(Icons.add),
                                style: ElevatedButton.styleFrom(shape: CircleBorder(), padding: EdgeInsets.all(10)),
                              )),
                        ],
                      ),
                    ),
                   

                           Container(
                              child: Row(mainAxisAlignment: MainAxisAlignment.center, children: [
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
                            Tooltip(
                                message: "Dodaj novu lokaciju",
                                child: ElevatedButton(
                                  onPressed: () {
                                    novaLokacija();
                                  },
                                  child: const Icon(Icons.add),
                                  style: ElevatedButton.styleFrom(shape: CircleBorder(), padding: EdgeInsets.all(10)),
                                ))
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
                                          return 'Unesite kodu uređaja';
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
                                          return 'Unesite izdanje uređaja';
                                        }
                                        return null;
                                      },
                                      onSaved: (value) {},
                                    ),
                                    Container(
                                      child: Row(children: [
                                        Expanded(
                                          child: TextFormField(
                                            controller: serijskiBrojTextController,
                                            decoration: InputDecoration(
                                              labelText: 'Serijski broj',
                                            ),
                                            //initialValue: _serijskiBroj,
                                            validator: (value) {
                                              if (value == null || value.isEmpty) {
                                                return 'Unesite serijski broj uređaja';
                                              }
                                              return null;
                                            },
                                            onSaved: (value) {},
                                          ),
                                        ),
                                        Tooltip(
                                            message: "Generiši serijski broj",
                                            child: ElevatedButton(
                                                style: ElevatedButton.styleFrom(shape: CircleBorder(), padding: EdgeInsets.all(10)),
                                                onPressed: () {
                                                  serijskiBrojTextController.text = EvBroj.toString() + "/" + DateTime.now().year.toString();
                                                },
                                                child: Icon(
                                                  Icons.generating_tokens,
                                                  size: 30,
                                                )))
                                      ]),
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
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        MinimalisticButton(
                          icons: Icon(
                            Icons.cancel,
                            color: Colors.redAccent,
                          ),
                          text: "Poništi",
                          onPressed: () {
                            clear();
                            Navigator.pop(context);
                          },
                        ),
                        MinimalisticButton(
                            icons: Icon(
                              Icons.save,
                              color: Colors.blueAccent,
                            ),
                            text: "Sačuvaj",
                            onPressed: () {
                              if (_formKey.currentState!.validate() && dropdownvalue != null && lokacijaDropdownValue != null) {
                                _formKey.currentState!.save();

                                _sacuvaj();
                              } else if (!_formKey.currentState!.validate()) {
                                ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Popunite obavezna polja!"));
                              } else if (dropdownvalue == null) {
                                ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Tip uređaja nije odabran!"));
                              } else if (lokacijaDropdownValue == null) {
                                ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Lokacija nije odabrana!"));
                              } else {
                                ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Netačan unos!"));
                                return;
                              }
                            }),
                      ],
                    ),
                  ],
                )),
          ],
        ),
      ),
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

    if (widget.editUredjaj == null) {
      await uredjajiProvider!.insert(request, "Uredjaj");
    }

    if (widget.editUredjaj != null) {
      await uredjajiProvider!.update(widget.editUredjaj!.uredjajId, request, "Uredjaj");
    }

    ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Uspješno!"));
    Navigator.of(context).pop(true);
    clear();
  }

  void clear() {
    kodaTextController.clear();
    izdanjeTextController.clear();
    serijskiBrojTextController.clear();
    prijemTextController.clear();

    setState(() {
      dropdownvalue = null;
      lokacijaDropdownValue = null;
    });
  }

  void noviTipUredjaja() {

    tipUredjajaList = [];
        lokacijaList = [];

dropdownValueNull();

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
                                  ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack(e.toString()));
                                  Navigator.pop(context);
                                  return;
                                }

                                ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Uspješno je dodan novi tip uređaja"));
                                tipOpisTextController.clear();
                                tipNazivTextController.clear();
                                _fetchData(null);
                                Navigator.pop(context);
                              }
                            }),
                        ElevatedButton(
                            child: Text("Poništi"),
                            style: ElevatedButton.styleFrom(
                              backgroundColor: Color.fromARGB(255, 170, 70, 63),
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
}
