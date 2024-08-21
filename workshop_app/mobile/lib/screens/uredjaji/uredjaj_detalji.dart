import 'package:commons/models/izvrseni_servis.dart';
import 'package:commons/models/lokacija.dart';
import 'package:commons/models/reparacija.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/izvrseni_servis_provider.dart';
import 'package:commons/providers/komponente_provider.dart';
import 'package:commons/providers/lokacija_provider.dart';
import 'package:commons/providers/reparacija_provider.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:expandable/expandable.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import 'package:flutter_speed_dial/flutter_speed_dial.dart';
import '../../helpers/bottom_bar.dart';
import '../../helpers/common_widget.dart';
import '../../helpers/master_screen.dart';
import '../servis/servisiraj.dart';

class UredjajDetaljiScreen extends StatefulWidget {
  static const String routeName = "/uredjajDetalji";
  UredjajDetaljiScreen({super.key});
  Uredjaj uredjaj = new Uredjaj();

  UredjajDetaljiScreen.detalji(Uredjaj uredjaj) {
    this.uredjaj = uredjaj;
  }

  @override
  State<UredjajDetaljiScreen> createState() => _UredjajDetaljiState(uredjaj);
}

class _UredjajDetaljiState extends State<UredjajDetaljiScreen> {
  Uredjaj uredjaj = new Uredjaj();
  Lokacija? lokacijaDropdownValue;

  List<Reparacija> reparacija = [];
  List<IzvrseniServis> izvrseniServis = [];
  List<IzvrseniServis> filtriraniServis = []; //komponente
  List<Lokacija> lokacijaList = [];

  LokacijaProvider? lokacijaProvider = null;
  ReparacijaProvider? reparacijaProvider = null; //servis
  IzvrseniServisProvider? izvrseniServisProvider = null;
  KomponenteProvider? komponenteProvider = null;
  UredjajProvider? uredjajProvider = null;

  _UredjajDetaljiState(Uredjaj uredjaj) {
    this.uredjaj = uredjaj;
  }

  @override
  void initState() {
    super.initState();

    izvrseniServisProvider = context.read<IzvrseniServisProvider>();
    komponenteProvider = context.read<KomponenteProvider>();
    uredjajProvider = context.read<UredjajProvider>();
    lokacijaProvider = context.read<LokacijaProvider>();
    reparacijaProvider = context.read<ReparacijaProvider>();

    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    var komponente = await izvrseniServisProvider?.get({'id': uredjaj.uredjajId}, "Reparacija/IzvrseniServis");

    var item = await uredjajProvider?.get({'UredjajId': uredjaj.uredjajId}, "Uredjaj");

    var lokacija = await lokacijaProvider?.get(null, "Lokacija");

    var reparacijaResponse = await reparacijaProvider!.get({'UredjajId': uredjaj.uredjajId}, "Reparacija");

    if (mounted) {
      setState(() {
        reparacija = reparacijaResponse;
        izvrseniServis = komponente!;
        uredjaj = item!.first;
        lokacijaList = lokacija!;
        lokacijaDropdownValue = lokacijaList.firstWhere((x) => x.naziv == uredjaj.lokacijaNaziv);
      });
    }
  }

  void aktivirajReadyVrati() async {
    try {
      await uredjajProvider?.update(uredjaj.uredjajId, null, "Uredjaj/Aktiviraj-Ready-Vrati");
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
      return;
    }

    ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Uspješno promijenjeno stanje uređaja"));
    _fetchData(null);
  }

  void posalji() async {
    //var request = {'uredjajId': uredjaj.uredjajId};

    try {
      await uredjajProvider!.update(uredjaj.uredjajId, null, "Uredjaj/Posalji");
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
      return;
    }
    ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Uređaj je uspješno poslan"));
    _fetchData(null);
  }

  ValueNotifier<bool> isDialOpen = ValueNotifier(false);
  @override
  Widget build(BuildContext context) {
    return WillPopScope(
        onWillPop: () async {
          if (isDialOpen.value) {
            isDialOpen.value = false;
            return false;
          } else {
            return true;
          }
        },
        child: Scaffold(
            drawer: DrawerWidget(),
            bottomNavigationBar: MyBottomBar(),
            floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
            floatingActionButton: SpeedDial(
              animatedIcon: AnimatedIcons.view_list,
              openCloseDial: isDialOpen,
              overlayColor: Colors.grey,
              overlayOpacity: 0.5,
              spacing: 15,
              spaceBetweenChildren: 15,
              closeManually: true,
              children: [
                if (uredjaj.status == "idle" || uredjaj.status == "parts")
                  SpeedDialChild(
                      child: Icon(Icons.auto_fix_high),
                      label: 'Aktiviraj',
                      backgroundColor: Colors.blue,
                      onTap: () {
                        isDialOpen.value = false;
                        CommonWidget.aktivirajReadyVratiDialog(context, "Potvrdi promjenu stanja", aktivirajReadyVrati);
                      }),
                if (uredjaj.status == "active" || uredjaj.status == "fix" || uredjaj.status == "ready" || uredjaj.status == "task")
                  SpeedDialChild(
                      child: Icon(Icons.build),
                      label: 'Servisiraj',
                      onTap: () {
                        isDialOpen.value = false;
                        Navigator.push(context, MaterialPageRoute(builder: (context) => ServisirajScreen.servis(uredjaj)));
                      }),
                if (uredjaj.status == "fix")
                  SpeedDialChild(
                      child: Icon(Icons.done),
                      label: 'Spremi',
                      onTap: () {
                        isDialOpen.value = false;
                        CommonWidget.aktivirajReadyVratiDialog(context, "Potvrdi promjenu stanja", aktivirajReadyVrati);
                      }),
                if (uredjaj.status == "ready")
                  SpeedDialChild(
                      child: Icon(Icons.airport_shuttle),
                      label: 'Pošalji',
                      onTap: () {
                        showDialog(
                            context: context,
                            builder: (BuildContext context) {
                              return AlertDialog(
                                  title: Text("Da li želite poslati uređaj?"),
                                  content: Container(
                                    height: 150,
                                    child: Column(children: [
                                      Container(
                                          padding: EdgeInsets.fromLTRB(0, 20, 0, 0),
                                          child: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                                            ElevatedButton(
                                                child: Text("Potvrdi"),
                                                style: ElevatedButton.styleFrom(
                                                  elevation: 2,
                                                ),
                                                onPressed: () {
                                                  posalji();
                                                  Navigator.pop(context);
                                                }),
                                            ElevatedButton(
                                                child: Text("Poništi"),
                                                style: ElevatedButton.styleFrom(
                                                  elevation: 2,
                                                ),
                                                onPressed: () {
                                                  Navigator.pop(context);
                                                })
                                          ]))
                                    ]),
                                  ));
                            });
                        isDialOpen.value = false;
                      }),
                if (uredjaj.status == "out")
                  SpeedDialChild(
                      child: Icon(Icons.arrow_downward),
                      label: 'Vrati',
                      onTap: () {
                        isDialOpen.value = false;
                        CommonWidget.aktivirajReadyVratiDialog(context, "Potvrdi promjenu stanja", aktivirajReadyVrati);
                      }),
                if (uredjaj.status == "idle")
                  SpeedDialChild(
                      child: Icon(Icons.recycling),
                      label: 'Rezervni dijelovi',
                      onTap: () async {
                        try {
                          await uredjajProvider!.update(uredjaj.uredjajId, null, "Uredjaj/SpareParts");

                          ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Uspješna promjena stanja uređaja"));

                          _fetchData(null);
                        } catch (e) {
                          ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
                        }

                        isDialOpen.value = false;
                      }),
                if (uredjaj.status == "active")
                  SpeedDialChild(
                      child: Icon(Icons.not_interested),
                      label: 'Deaktiviraj',
                      backgroundColor: Colors.redAccent,
                      onTap: () async {
                        try {
                          await uredjajProvider!.update(uredjaj.uredjajId, null, "Uredjaj/Deaktiviraj");

                          ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Uspješna promjena stanja uređaja"));

                          _fetchData(null);
                        } catch (e) {
                          ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
                        }
                        isDialOpen.value = false;
                      })
              ],
            ),
            appBar: AppBar(title: Text("Uređaj")),
            body: SafeArea(
                child: SingleChildScrollView(
                    child: Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
              Container(
                child: Padding(
                    padding: EdgeInsets.all(10),
                    child: Container(
                      decoration: BoxDecoration(),
                      child: CommonWidget.UredjajDetalji(uredjaj),
                    )),
              ),
              CommonWidget.dividerDetalji(),
              Padding(
                  padding: EdgeInsets.all(10),
                  child: Text(
                    "Historija servisiranja:",
                    style: TextStyle(fontSize: 20),
                  )),
              Padding(padding: EdgeInsets.all(10), child: Column(children: historijaServisa())),
            ])))));
  }

  List<Widget> historijaServisa() {
    if (this.reparacija.length == 0) {
      return [Text("Uređaj nije servisiran.")];
    }

    var servisi = reparacija;

    List<Widget> list = servisi
        .map((x) => ExpandableNotifier(
              child: Column(mainAxisAlignment: MainAxisAlignment.start, children: [
                Expandable(
                    collapsed: ExpandableButton(
                        child: Card(
                            child: Container(
                      padding: EdgeInsets.all(20),
                      child: Text(vrijemeFormat(x.datum!), style: TextStyle(fontSize: 20)),
                    ))),
                    expanded: Column(children: [
                      Card(
                          child: Container(
                        padding: EdgeInsets.all(20),
                        child: Column(
                          children: [
                            DataTable(
                              columns: [DataColumn(label: Text("Naziv")), DataColumn(label: Text("Vrijednost"))],
                              rows: komponenteList(x.servisId),
                            ),
                            Text(
                              "Servisirao: " + x.servisirao.toString(),
                              style: TextStyle(fontSize: 20),
                            )
                          ],
                        ),
                      )),
                      ExpandableButton(
                        child: Container(
                            padding: EdgeInsets.fromLTRB(0, 10, 0, 10),
                            child: Text(
                              "Zatvori",
                              style: TextStyle(fontSize: 20),
                            )),
                      )
                    ])),
              ]),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }

  List<DataRow> komponenteList(int servisId) {
    filtriraniServis = izvrseniServis.where((x) => x.servisId == servisId).toList();

    List<DataRow> list =
        filtriraniServis.map((e) => DataRow(cells: [DataCell(Text(e.naziv.toString())), DataCell(Text(e.tip.toString()))])).cast<DataRow>().toList();

    return list;
  }

  Widget _offsetPopup() => PopupMenuButton<int>(
      itemBuilder: (context) => [
            PopupMenuItem(
              value: 1,
              child: Text(
                "Asad",
                style: TextStyle(color: Colors.black, fontWeight: FontWeight.w700),
              ),
            ),
            PopupMenuItem(
              value: 2,
              child: Text(
                "Tabak",
                style: TextStyle(color: Colors.black, fontWeight: FontWeight.w700),
              ),
            ),
          ],
      icon: Container(
        height: double.infinity,
        width: double.infinity,
        decoration: ShapeDecoration(
            color: Colors.blue,
            shape: StadiumBorder(
              side: BorderSide(color: Colors.white, width: 2),
            )),
      ));

  String vrijemeFormat(String datumTekst) {
    var datum = DateTime.parse(datumTekst);

    return datum.day.toString() + "." + datum.month.toString() + "." + datum.year.toString();
  }
}
