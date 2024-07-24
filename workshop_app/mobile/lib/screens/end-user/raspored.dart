import 'package:commons/providers/stanice_provider.dart';
import 'package:commons/providers/stanice_uredjaj_provider.dart';
import 'package:expandable/expandable.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';
import '../../helpers/bottom_bar.dart';
import '../../helpers/common_widget.dart';
import '../../helpers/master_screen.dart';
import 'package:commons/models/stanica.dart';
import 'package:commons/models/stanica_uredjaj.dart';

class Raspored extends StatefulWidget {
  static const String routeName = "/raspored";

  const Raspored({super.key});

  @override
  State<Raspored> createState() => _RasporedState();
}

class _RasporedState extends State<Raspored> {
  StaniceUredjajProvider? staniceUredjajProvider = null;
  StaniceProvider? staniceProvider = null;
  bool _isLoading = false;
  List<StanicaUredjaj>? staniceUredjaj = [];
  List<Stanica>? stanice = [];

  @override
  void initState() {
    super.initState();

    staniceUredjajProvider = context.read<StaniceUredjajProvider>();
    staniceProvider = context.read<StaniceProvider>();

    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    setState(() {
      _isLoading = true;
    });

    try {
      var data = await staniceUredjajProvider!.get(map, "StaniceUredjaj");
      var stanice = await staniceProvider!.get(map, "Stanice");

      setState(() {
        staniceUredjaj = data;
        this.stanice = stanice;
        _isLoading = false;
      });
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        drawer: DrawerWidget(),
        appBar: AppBar(title: (Text("Raspored relejnih uređaja"))),
        bottomNavigationBar: MyBottomBar(),
        floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
        floatingActionButton: FloatingActionButton(onPressed: () async {}, child: Icon(Icons.add)),
        body: SafeArea(
            child: SingleChildScrollView(
                child: Wrap(children: [
          Padding(
              padding: EdgeInsets.fromLTRB(0, 0, 0, 0),
              child: Container(
                alignment: Alignment.center,
                child: Card(child: Padding(padding: EdgeInsets.all(20), child: Text("Radna jedinica: Sarajevo", style: TextStyle(fontSize: 20)))),
              )),
          Column(
            children: staniceUredjaji(),
          )
        ]))));
  }

  List<Widget> staniceUredjaji() {
    List<Widget> list = stanice!
        .map((stanica) => ExpandableNotifier(
                child: Column(children: [
              ExpandablePanel(
                header: Container(
                    alignment: Alignment.center,
                    height: 50,
                    child: Text(
                      stanica.naziv!,
                      style: TextStyle(fontSize: 20, color: Colors.black),
                    )),
                // <-- Driven by ExpandableController from ExpandableNotifier
                collapsed:
                    // <-- Expands when tapped on the cover photo
                    CommonWidget.dividerDetalji(),

                expanded: Container(
                    child: Column(children: [
                  DataTable(
                      columnSpacing: 20,
                      columns: [
                        DataColumn(label: Text("Ev.Br.")),
                        DataColumn(label: Text("Tip")),
                        DataColumn(label: Text("Naziv")),
                        DataColumn(label: Text("Koda")),
                        DataColumn(label: Text("Opcije"))
                      ],
                      rows: staniceUredjaj!
                          .where((z) => z.naziv == stanica.naziv)
                          .map((uredjaj) => DataRow(
                                  onLongPress: () {
                                    CommonWidget.dialogInfo(
                                        context, "Uredi info " + uredjaj.uredjajId.toString() + " - " + uredjaj.uredjajTip.toString());
                                  },
                                  cells: <DataCell>[
                                    DataCell(Text(uredjaj.uredjajId.toString())),
                                    DataCell(Text(uredjaj.uredjajTip ?? "")),
                                    DataCell(Text(uredjaj.uredjajNaziv ?? "")),
                                    DataCell(Text(uredjaj.koda ?? "")),
                                    DataCell(PopupMenuButton(
                                      onSelected: (izbor) {
                                        switch (izbor) {
                                          case 'move':
                                            dialogIzmjena(uredjaj);
                                            break;
                                          case 'kick':
                                            break;
                                        }
                                      },
                                      itemBuilder: (BuildContext context) => <PopupMenuEntry<String>>[
                                        PopupMenuItem<String>(
                                          child: Text('Premjesti'),
                                          value: 'move',
                                        ),
                                        PopupMenuItem<String>(
                                          child: Text('Izbaci'),
                                          value: 'kick',
                                        )
                                      ],
                                    )),
                                  ]))
                          .toList()),
                ])),
              )
            ])))
        .cast<Widget>()
        .toList();

    return list;
  }

  Future<void>? dialogIzmjena(StanicaUredjaj uredjaj) {
    showDialog<void>(
        context: context,
        builder: (BuildContext context) {
          return SimpleDialog(
              title: Text(uredjaj.uredjajId.toString() + " - " + uredjaj.uredjajTip.toString() + " - " + uredjaj.koda.toString()),
              children: stanice!
                  .map((staniceThis) => SimpleDialogOption(
                        child: Text(
                          staniceThis.naziv.toString(),
                          style: TextStyle(fontSize: 15),
                        ),
                        onPressed: () {
                          HapticFeedback.vibrate();

                          Navigator.pop(context);

                          premjestiUredjajDialog(
                              "Da li želite premjestiti uređaj sa ev. brojem -" +
                                  uredjaj.uredjajId.toString() +
                                  "- u stanicu " +
                                  staniceThis.naziv.toString(),
                              uredjaj.uredjajId,
                              0,
                              staniceThis.id);
                        },
                      ))
                  .toList());
        });
  }

  void premjestiUredjaj(int uredjajId, int stanicaId, int promjenaStaniceId) async {
    var result = await staniceUredjajProvider!.get({'StanicaId': stanicaId, 'UredjajId': uredjajId}, "StaniceUredjaj");

    var update = null;

    try {
      update = await staniceUredjajProvider!.update(result.first.id, {'stanicaId': promjenaStaniceId, 'uredjajId': uredjajId}, "StaniceUredjaj");
    } catch (e) {
      CommonWidget.infoSnack(e.toString());
    }

    if (update == null) {
      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Neuspješna akcija!"));
    }

    ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Uspješno promijenjena lokacija!"));

    _fetchData(null);
  }

  Future premjestiUredjajDialog(String? Info, int uredjajId, int stanicaId, int promjenaStaniceId) {
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
                    Navigator.pop(context);
                    premjestiUredjaj(uredjajId, stanicaId, promjenaStaniceId);
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
}
