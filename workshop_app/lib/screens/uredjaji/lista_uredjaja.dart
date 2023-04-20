import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:workshop_app/helpers/common_widget.dart';
import 'package:workshop_app/model/uredjaj.dart';
import 'package:workshop_app/providers/uredjaji_provider.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/helpers/state_helper.dart';
import 'package:workshop_app/screens/radni_zadaci/radni_zadatak_detalji.dart';
import 'package:workshop_app/screens/uredjaji/uredjaj_detalji.dart';

import '../../helpers/bottom_bar.dart';
import '../../helpers/master_screen.dart';
import '../../providers/radniZadaci_uredjaj_provider.dart';
import 'dodaj_uredi_uredjaj.dart';

class UredjajiListScreen extends StatefulWidget {
  static const String routeName = "/uredjaji";
  bool addZadatakActive = false;
  int radniZadatakId = 0;

  UredjajiListScreen({super.key});

  UredjajiListScreen.add(int radniZadatakId) {
    addZadatakActive = true;
    this.radniZadatakId = radniZadatakId;
  }

  @override
  State<UredjajiListScreen> createState() => _UredjajiListScreenState(addZadatakActive, radniZadatakId);
}

class _UredjajiListScreenState extends State<UredjajiListScreen> {
  UredjajiProvider? _uredjajiProvider = null;
  List<Uredjaj> data = [];
  String selected = "";
  List<Uredjaj> uredjajRadniZadatak = [];
  String dropdownvalue = "";
  int radniZadatakId = 0;

  late List<dynamic> _dataList;
  bool _isLoading = true;
  bool addZadatakActive = false;
  RadniZadaciUredjajProvider? radniZadaciUredjajProvider = null;

  _UredjajiListScreenState(bool addZadatakActive, int radniZadatakId) {
    this.addZadatakActive = addZadatakActive;
    dropdownvalue = StateHelper.nizOpis[1];
    this.radniZadatakId = radniZadatakId;
  }

  @override
  void initState() {
    super.initState();

    _uredjajiProvider = context.read<UredjajiProvider>();
    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();
    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    setState(() {
      _isLoading = true;
    });
    if (addZadatakActive) {
      map = {'Status': 'active'};
    }

    final response = await _uredjajiProvider?.get(map, "Uredjaj");

    setState(() {
      data = response!;
      _isLoading = false;
    });
  }

  void dodajUZadatak() async {
    if (uredjajRadniZadatak.isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Odaberite uređaje za radni zadatak!"));
      return;
    }

    for (var i = 0; i < uredjajRadniZadatak.length; i++) {
      var request = {'radniZadatakId': radniZadatakId, 'uredjajId': uredjajRadniZadatak[i].uredjajId, 'korisnikId': 1, 'napomena': ""};

      await _uredjajiProvider?.update(null, request, "Uredjaj/RadniZadatak");
    }
    ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Uređaji su uspješno dodani!"));
    Navigator.pop(context);
    Navigator.push(context, MaterialPageRoute(builder: (context) => RadniZadatakDetaljiScreen.addUredjaj(radniZadatakId)));

    return;
  }

  @override
  Widget build(BuildContext context) {
    print("called build");
    return Scaffold(
        drawer: DrawerWidget(),
        appBar: AppBar(
          title: Text("Uređaji"),
        ),
        bottomNavigationBar: MyBottomBar(),
        floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
        floatingActionButton: FloatingActionButton(
          onPressed: () {
            if (addZadatakActive == true) {
              dodajUZadatak();
            } else {
              Navigator.pushNamed(context, DodajUrediUredjajScreen.routeName);
            }
          },
          child: Icon(Icons.add),
        ),
        body: _isLoading
            ? Center(child: CircularProgressIndicator())
            : SafeArea(
                child: SingleChildScrollView(
                    child: Column(
                  children: [
                    Row(children: [
                      Padding(
                          padding: EdgeInsets.fromLTRB(20, 0, 0, 0),
                          child: DropdownButton<String>(
                            value: dropdownvalue,
                            icon: const Icon(Icons.arrow_downward),
                            elevation: 16,
                            hint: Container(child: Text("Odaberi status")),
                            style: const TextStyle(color: Colors.deepPurple),
                            underline: Container(
                              height: 2,
                              color: Colors.blueGrey,
                            ),
                            onChanged: (String? value) {
                              if (addZadatakActive && StateHelper.nizSearch(value!) != "active") {
                                ScaffoldMessenger.of(context)
                                    .showSnackBar(CommonWidget.infoSnack("Samo aktivni uređaji se mogu dodati u radni zadatak!"));
                              }

                              _fetchData({'Status': StateHelper.nizSearch(value!)});

                              setState(() {
                                dropdownvalue = value;
                                final dataResult = data;
                              });
                            },
                            items: StateHelper.nizOpis.map<DropdownMenuItem<String>>((String value) {
                              return DropdownMenuItem<String>(
                                value: value,
                                child: Text(value),
                              );
                            }).toList(),
                          )),
                    ]),
                    CommonWidget.dividerDetalji(),
                    Container(
                        height: 800,
                        child: GridView(
                            gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                                crossAxisCount: 2, childAspectRatio: 1.5, mainAxisSpacing: 10, crossAxisSpacing: 10),
                            children: data
                                .map((x) => Card(
                                    color: x.isChecked ? Color(0xFF579BB1) : Color(0xFFCBE4DE),
                                    child: InkWell(
                                        onTap: () {
                                          if (addZadatakActive) {
                                            HapticFeedback.vibrate();
                                            setState(() {
                                              if (!x.isChecked) {
                                                x.isChecked = true;
                                                uredjajRadniZadatak.add(x);
                                              } else {
                                                x.isChecked = false;
                                                uredjajRadniZadatak.remove(x);
                                              }
                                            });
                                          } else {
                                            Navigator.push(context, MaterialPageRoute(builder: (context) => UredjajDetaljiScreen.detalji(x)));
                                          }
                                        },
                                        child: Column(
                                          children: [
                                            Row(
                                              mainAxisAlignment:
                                                  addZadatakActive && x.isChecked ? MainAxisAlignment.start : MainAxisAlignment.spaceBetween,
                                              children: [
                                                Container(
                                                  padding: const EdgeInsets.all(10),
                                                  child: Text(x.uredjajId.toString(), style: TextStyle(fontSize: 17, fontWeight: FontWeight.bold)),
                                                ),
                                                if (addZadatakActive && x.isChecked) Container(child: Icon(Icons.done)),
                                                if (!addZadatakActive)
                                                  Container(
                                                    padding: const EdgeInsets.all(0),
                                                    child: PopupMenuButton<String>(
                                                      initialValue: selected,
                                                      // Callback that sets the selected popup menu item.
                                                      onSelected: (izbor) {
                                                        switch (izbor) {
                                                          case 'edit':
                                                            Navigator.push(
                                                                context, MaterialPageRoute(builder: (context) => DodajUrediUredjajScreen.uredi(x)));
                                                        }
                                                      },
                                                      itemBuilder: (BuildContext context) => <PopupMenuEntry<String>>[
                                                        const PopupMenuItem<String>(
                                                          value: 'edit',
                                                          child: Text('Uredi'),
                                                        ),
                                                        const PopupMenuItem<String>(
                                                          value: 'delete',
                                                          child: Text('Izbriši'),
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
                                .toList()))
                  ],
                )),
              ));
  }
}
