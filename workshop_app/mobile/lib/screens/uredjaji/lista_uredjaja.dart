import 'package:commons/models/uredjaj.dart';
import 'package:commons/models/user.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:workshop_app/helpers/common_widget.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/helpers/state_helper.dart';
import 'package:workshop_app/screens/radni_zadaci/radni_zadatak_detalji.dart';
import 'package:workshop_app/screens/uredjaji/uredjaj_detalji.dart';
import 'package:commons/providers/uredjaj_provider.dart';

import '../../helpers/bottom_bar.dart';
import '../../helpers/master_screen.dart';
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
  UredjajProvider? _uredjajiProvider = null;
  List<Uredjaj> data = [];
  String selected = "";
  List<Uredjaj> uredjajRadniZadatak = [];
  String dropdownvalue = "Aktivni";
  int radniZadatakId = 0;

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

    _uredjajiProvider = context.read<UredjajProvider>();
    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();

    var map = {'Status': 'active'};

    _fetchData(map);
  }

  Future<void> _fetchData(Map<String, dynamic>? map) async {
    setState(() {
      _isLoading = true;
    });
    if (addZadatakActive) {
      map = {'Status': 'active'};
    } else if (dropdownvalue == "Izbrisani") {
      map = {'isDeleted': true};
    }

    try {
      final response = await _uredjajiProvider?.get(map, "Uredjaj");

      setState(() {
        data = response!;
        _isLoading = false;
      });
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
    }
  }

  void dodajUZadatak() async {
    if (uredjajRadniZadatak.isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Odaberite uređaje za radni zadatak!"));
      return;
    }

    for (var i = 0; i < uredjajRadniZadatak.length; i++) {
      var request = {'radniZadatakId': radniZadatakId, 'uredjajId': uredjajRadniZadatak[i].uredjajId, 'korisnikId': User.id, 'napomena': ""};

      await _uredjajiProvider?.update(null, request, "Uredjaj/RadniZadatak");
    }
    ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Uređaji su uspješno dodani!"));
    Navigator.pop(context);
    Navigator.push(context, MaterialPageRoute(builder: (context) => RadniZadatakDetaljiScreen.addUredjaj(radniZadatakId)));

    return;
  }

  @override
  Widget build(BuildContext context) {
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
            : Container(
                child: SafeArea(
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
                          height: MediaQuery.of(context).size.height - 250,
                          child: GridView(
                              gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                                  crossAxisCount: 2, childAspectRatio: 1.3, mainAxisSpacing: 10, crossAxisSpacing: 10),
                              children: data
                                  .map((x) => Card(
                                    
                                      color: x.isSelected ? Color(0xFF579BB1) : Color(0xFFCBE4DE),
                                      child: InkWell(
                                          onTap: () {
                                            if (addZadatakActive) {
                                              HapticFeedback.vibrate();
                                              setState(() {
                                                if (!x.isSelected) {
                                                  x.isSelected = true;
                                                  uredjajRadniZadatak.add(x);
                                                } else {
                                                  x.isSelected = false;
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
                                                    addZadatakActive && x.isSelected ? MainAxisAlignment.start : MainAxisAlignment.spaceBetween,
                                                children: [
                                                  Container(
                                                    padding: const EdgeInsets.all(10),
                                                    child: Text(x.uredjajId.toString(), style: TextStyle(fontSize: 17, fontWeight: FontWeight.bold)),
                                                  ),
                                                  if (addZadatakActive && x.isSelected) Container(child: Icon(Icons.done)),
                                                  if (!addZadatakActive)
                                                    Container(
                                                      padding: const EdgeInsets.all(0),
                                                      child: PopupMenuButton<String>(
                                                        initialValue: selected,
                                                        onSelected: (izbor) async {
                                                          switch (izbor) {
                                                            case 'edit':
                                                              Navigator.push(
                                                                  context, MaterialPageRoute(builder: (context) => DodajUrediUredjajScreen.uredi(x)));
                                                              break;
                                                            case 'delete':
                                                              if (x.status == "idle") {
                                                                izbrisi(x);
                                                              } else {
                                                                ScaffoldMessenger.of(context).showSnackBar(
                                                                    CommonWidget.infoSnack("Samo se neaktivni uređaji mogu izbrisati."));
                                                              }
                                          
                                                              break;
                                                          }
                                                        },
                                                        itemBuilder: (BuildContext context) => <PopupMenuEntry<String>>[
                                                          const PopupMenuItem<String>(
                                                            value: 'edit',
                                                            child: Text('Uredi'),
                                                          ),
                                                          if (x.status == "idle")
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
                ),
              ));
  }

  izbrisi(Uredjaj x) async {
    return showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text("Da li želite izbrisati uređaj"),
            content: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
              ElevatedButton(
                  child: Text("Potvrdi"),
                  style: ElevatedButton.styleFrom(
                    elevation: 2,
                  ),
                  onPressed: () async {
                    try {
                      await _uredjajiProvider!.delete(x.uredjajId, x, "Uredjaj");

                      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Uređaj je izbrisan."));
                    } catch (e) {
                      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
                    }
                    Navigator.pop(context);

                    _fetchData({'Status': 'idle'});
                  }),
              ElevatedButton(
                  child: Text("Poništi"), style: ElevatedButton.styleFrom(elevation: 2, backgroundColor: Colors.redAccent), onPressed: () async {})
            ]),
          );
        });
  }
}
