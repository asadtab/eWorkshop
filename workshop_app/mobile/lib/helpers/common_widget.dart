import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:workshop_app/helpers/state_helper.dart';

import 'package:workshop_app/screens/uredjaji/uredjaj_detalji.dart';

import '../screens/radni_zadaci/radni_zadatak_detalji.dart';

class CommonWidget {
  static Container detaljiContainer(String vrijednost) {
    return Container(
        padding: EdgeInsets.all(5),
        child: Text(
          vrijednost,
          style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold),
        ));
  }

  static List<Widget> zadatak(BuildContext context, List<RadniZadatakUredjaj> data) {
    if (data.length == 0) {
      return [Text("Radni zadaci ne postoje")];
    }

    var listDistinct = Set();

    List<RadniZadatakUredjaj> unique = data.where((x) => listDistinct.add(x.radniZadatakId)).toList();

    List<Widget> list = unique
        .map((x) => Column(children: [
              Card(
                  child: Container(
                width: 150,
                height: 250,
                child: SingleChildScrollView(
                  child: Column(mainAxisAlignment: MainAxisAlignment.start, children: [
                    InkWell(
                      onTap: () {
                        var uredjaji = data.where((y) => y.radniZadatakId == x.radniZadatakId).toList();

                        MaterialPageRoute(builder: (context) => RadniZadatakDetaljiScreen.zadaci(uredjaji));

                        Navigator.push(context, MaterialPageRoute(builder: (context) => RadniZadatakDetaljiScreen.zadaci(uredjaji)));
                      },
                      child: Container(
                          width: 150,
                          height: 30,
                          child: Card(
                              color: Color(0xFFCBE4DE),
                              shadowColor: Color(0xFFCBE4DE),
                              child: Center(
                                  child: Text(
                                x.radniZadatakNaziv ?? "",
                                style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold),
                              )))),
                    ),

                    //CommonWidget.dividerLista(),
                  ]),
                ),
              )),
            ]))
        .cast<Widget>()
        .toList();

    return list;
  }

  static Container tekstUnos(String nazivPolja, TextEditingController controller, bool? validate) {
    return Container(
        padding: const EdgeInsets.fromLTRB(0, 0, 0, 10),
        height: 50,
        width: 170,
        child: TextField(
            controller: controller,
            decoration: InputDecoration(
              border: OutlineInputBorder(),
              labelText: nazivPolja,
            )));
  }

  static Divider divider() {
    return const Divider(
      height: 10,
      thickness: 2,
      indent: 20,
      endIndent: 0,
      color: Color(0xFF2C3333),
    );
  }

  static Divider dividerDetalji() {
    return const Divider(
      height: 20,
      thickness: 1,
      indent: 20,
      endIndent: 20,
      color: Color(0xFF2C3333),
    );
  }

  static Row UredjajDetalji(Uredjaj uredjaj) {
    return Row(mainAxisAlignment: MainAxisAlignment.start, children: [
      Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          CommonWidget.detaljiContainer("Evidencijski broj:"),
          CommonWidget.detaljiContainer("Tip:"),
          CommonWidget.detaljiContainer("Koda:"),
          CommonWidget.detaljiContainer("Serijski broj:"),
          CommonWidget.detaljiContainer("Izvedba:"),
          CommonWidget.detaljiContainer("Lokacija:"),
          CommonWidget.detaljiContainer("Status:"),
          SizedBox(
            width: 200,
          ),
        ],
      ),
      Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          CommonWidget.detaljiContainer(uredjaj.uredjajId.toString()),
          CommonWidget.detaljiContainer(uredjaj.tipNaziv.toString()),
          CommonWidget.detaljiContainer(uredjaj.koda.toString()),
          CommonWidget.detaljiContainer(uredjaj.serijskiBroj.toString()),
          CommonWidget.detaljiContainer(uredjaj.godinaIzvedbe ?? "Nepoznato"),
          CommonWidget.detaljiContainer(uredjaj.lokacijaNaziv.toString()),
          CommonWidget.detaljiContainer(StateHelper.nizRezultat(uredjaj.status.toString())),
        ],
      ),
    ]);
  }

  static SnackBar infoSnack(String? poruka) {
    return SnackBar(
      content: Text(poruka.toString()),
      action: SnackBarAction(
        label: 'OK',
        onPressed: () {
          // Code to execute.
        },
      ),
      behavior: SnackBarBehavior.floating,
    );
  }

  static Divider dividerLista() {
    return const Divider(
      height: 5,
      thickness: 1,
      indent: 10,
      endIndent: 10,
      color: Color(0xFF2C3333),
    );
  }

  static Future aktivirajReadyVratiDialog(BuildContext context, String? Info, func) {
    return showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text(Info.toString()),
            content: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
              ElevatedButton(
                  child: Text("Potvrdi"),
                  style: ElevatedButton.styleFrom(
                    elevation: 2,
                  ),
                  onPressed: () {
                    func();
                    Navigator.pop(context);
                  }),
              ElevatedButton(
                  child: Text("Poništi"),
                  style: ElevatedButton.styleFrom(elevation: 2, backgroundColor: Colors.redAccent),
                  onPressed: () {
                    Navigator.pop(context);
                  })
            ]),
          );
        });
  }

  static Future dialogInfo(BuildContext context, String? Info) {
    return showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text(Info!),
            content: ElevatedButton(
                child: Text("Ok"),
                style: ElevatedButton.styleFrom(
                  primary: Colors.blueAccent,
                  elevation: 2,
                ),
                onPressed: () {
                  Navigator.pop(context);
                }),
          );
        });
  }

  static DropdownButton<dynamic> lokacijaTipDropdown(String? info, dynamic objekat, List<dynamic> objekatList, context) {
    return DropdownButton<dynamic>(
      value: objekat,
      icon: const Icon(Icons.arrow_downward),
      elevation: 16,
      hint: Container(child: Text("Odaberi lokaciju")),
      style: const TextStyle(color: Colors.deepPurple),
      underline: Container(
        height: 2,
        color: Colors.blueGrey,
      ),
      onChanged: (dynamic valueSet) {
        // This is called when the user selects an item.
        context.setState(() {
          objekat = valueSet;
        });
      },
      items: objekatList.map<DropdownMenuItem<dynamic>>((dynamic value) {
        return DropdownMenuItem<dynamic>(
          value: value,
          child: Text(value.naziv.toString()),
        );
      }).toList(),
    );
  }

  static List<Widget> list(BuildContext context, List<Uredjaj> dataResult, UredjajProvider? provider, int? radniZadatakId) {
    //final dataResult = data;

    String selected = "";

    List<Widget> list = dataResult
        .map((x) => Card(
            color: Color(0xFFCBE4DE),
            child: InkWell(
                onTap: () {
                  Navigator.push(context, MaterialPageRoute(builder: (context) => UredjajDetaljiScreen.detalji(x)));
                },
                child: Column(
                  children: [
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Container(
                          padding: const EdgeInsets.all(10),
                          child: Text(x.uredjajId.toString(), style: TextStyle(fontWeight: FontWeight.bold)),
                        ),
                        Container(
                          padding: const EdgeInsets.all(0),
                          child: PopupMenuButton<String>(
                            initialValue: selected,
                            // Callback that sets the selected popup menu item.
                            onSelected: (izbor) {
                              switch (izbor) {
                                case 'delete':
                                  showDialog(
                                      context: context,
                                      builder: (BuildContext context) {
                                        return AlertDialog(
                                          title: Text("Da li želite ukloniti uređaj iz radnog zadatka?"),
                                          content: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                                            ElevatedButton(
                                                child: Text("Potvrdi"),
                                                style: ElevatedButton.styleFrom(
                                                  elevation: 2,
                                                ),
                                                onPressed: () async {
                                                  try {
                                                    await provider!.update(x.uredjajId, null, "Uredjaj/VratiIzTaska");
                                                    Navigator.pop(context);
                                                    Navigator.push(
                                                        context,
                                                        MaterialPageRoute(
                                                            builder: (context) => RadniZadatakDetaljiScreen.addUredjaj(radniZadatakId!)));
                                                    ScaffoldMessenger.of(context)
                                                        .showSnackBar(CommonWidget.infoSnack("Uređaj je uspješno uklonjen iz radnog zadatka!"));
                                                  } catch (e) {
                                                    ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
                                                  }
                                                }),
                                            ElevatedButton(
                                                child: Text("Poništi"),
                                                style: ElevatedButton.styleFrom(
                                                  elevation: 2,
                                                ),
                                                onPressed: () {
                                                  Navigator.pop(context);
                                                })
                                          ]),
                                        );
                                      });
                              }
                            },
                            itemBuilder: (BuildContext context) => <PopupMenuEntry<String>>[
                              const PopupMenuItem<String>(
                                value: 'delete',
                                child: Text('Ukloni'),
                              ),
                            ],
                          ),
                        )
                      ],
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Flexible(
                            child: Container(
                          child: Text(
                            x.tipNaziv ?? "",
                            style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                          ),
                        ))
                      ],
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Flexible(
                            child: Container(
                          child: Text(
                            x.tipOpis ?? "",
                            style: TextStyle(fontWeight: FontWeight.bold),
                          ),
                        ))
                      ],
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Container(
                          child: Text(
                            x.koda ?? "",
                            style: TextStyle(fontWeight: FontWeight.bold),
                          ),
                        )
                      ],
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Flexible(
                            child: Container(
                          child: Text(
                            x.serijskiBroj ?? "",
                            style: TextStyle(fontWeight: FontWeight.bold),
                          ),
                        ))
                      ],
                    )
                  ],
                ))))
        .cast<Widget>()
        .toList();

    return list;
  }
}
