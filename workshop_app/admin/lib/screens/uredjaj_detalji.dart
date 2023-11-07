import 'package:admin/bloc/uredjaji_bloc.dart';
import 'package:commons/helpers/change_state_helper.dart';
import 'package:commons/providers/izvrseni_servis_provider.dart';
import 'package:commons/models/reparacija.dart';
import 'package:commons/models/izvrseni_servis.dart';
import 'package:commons/providers/reparacija_provider.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:darq/darq.dart';
import 'package:expandable/expandable.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:timeline_list/timeline.dart';
import 'package:timeline_list/timeline_model.dart';

class UredjajDetaljiScreen extends StatefulWidget {
  final Uredjaj? uredjaj;

  UredjajDetaljiScreen({required this.uredjaj});

  @override
  _UredjajDetaljiScreenState createState() => _UredjajDetaljiScreenState();
}

class _UredjajDetaljiScreenState extends State<UredjajDetaljiScreen> {
  final GlobalKey<TooltipState> tooltipkey = GlobalKey<TooltipState>();

  bool check = true;
  List<IzvrseniServis> servis = [];
  Uredjaj? uredjaj;

  ReparacijaProvider? reparacijaProvider;
  IzvrseniServisProvider? izvrseniServisProvider;
  UredjajProvider? uredjajProvider;

  UredjajiBloc? uredjajBloc;

  @override
  void initState() {
    reparacijaProvider = context.read<ReparacijaProvider>();
    izvrseniServisProvider = context.read<IzvrseniServisProvider>();
    uredjajProvider = context.read<UredjajProvider>();

    uredjajBloc = UredjajiBloc(uredjajProvider, "");

    var map = {'id': widget.uredjaj!.uredjajId.toString()};

    _fetchData(map);

    // TODO: implement initState
    super.initState();
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    final response = await izvrseniServisProvider?.get(map, "Reparacija/IzvrseniServis");
    final uredjajResponse = await uredjajProvider?.get({'UredjajId': widget.uredjaj!.uredjajId.toString()}, "Uredjaj");

    setState(() {
      servis = response!;
      uredjaj = uredjajResponse!.first;
    });
  }

  bool isExpanded = false;

  void toggleExpanded() {
    setState(() {
      isExpanded = !isExpanded;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Info'),
      ),
      body: Row(
        children: [
          Card(
            elevation: 4.0,
            margin: EdgeInsets.all(16.0),
            child: Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    'Ev. broj: ${uredjaj?.uredjajId.toString() ?? ""}',
                    style: TextStyle(
                      fontSize: 20,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  SizedBox(height: 20),
                  DataTable(
                    columns: [
                      DataColumn(label: Text('')),
                      DataColumn(label: Text('')),
                    ],
                    rows: [
                      DataRow(
                        cells: [
                          DataCell(Text('ID')),
                          DataCell(Text(uredjaj?.uredjajId.toString() ?? "")),
                        ],
                      ),
                      DataRow(
                        cells: [
                          DataCell(Text('Tip')),
                          DataCell(Text(uredjaj?.tipNaziv ?? "")),
                        ],
                      ),
                      DataRow(
                        cells: [
                          DataCell(Text('Koda')),
                          DataCell(Text(uredjaj?.koda ?? "")),
                        ],
                      ),
                      DataRow(
                        cells: [
                          DataCell(Text('Serijski broj')),
                          DataCell(Text(uredjaj?.serijskiBroj ?? "")),
                        ],
                      ),
                      DataRow(
                        cells: [
                          DataCell(Text('Stanje')),
                          DataCell(Text(uredjaj?.status ?? "")),
                        ],
                      ),
                      DataRow(
                        cells: [
                          DataCell(Text('Lokacija')),
                          DataCell(Text(uredjaj?.lokacijaNaziv ?? "")),
                        ],
                      ),
                      // Add more properties here
                    ],
                  ),
                ],
              ),
            ),
          ),
          Container(
              width: 250,
              child: Card(
                elevation: 4.0,
                margin: EdgeInsets.all(16.0),
                child: ListView(
                  physics: AlwaysScrollableScrollPhysics(),
                  shrinkWrap: true, // This is important to allow the ListView to be used inside a Column
                  children: [
                    if (ChangeStateHelper.buttonAktiviraj_rezervniDijelovi(uredjaj?.status.toString() ?? ""))
                      ListTile(
                        title: MinimalisticButton(
                          text: 'Aktiviraj',
                          onPressed: () async {
                            try {
                              await uredjajProvider!.update(uredjaj!.uredjajId, null, "Uredjaj/Aktiviraj-Ready-Vrati");
                              poruka("Uređaj je uspješno aktiviran");
                            } catch (e) {
                              poruka(e.toString());
                            }

                            setState(() {
                              // _fetchData(map);
                            });
                          },
                        ),
                      ),
                    if (ChangeStateHelper.buttonServisiraj(uredjaj?.status ?? ""))
                      ListTile(
                        title: MinimalisticButton(
                          text: 'Servisiraj',
                          onPressed: () {},
                        ),
                      ),
                    if (ChangeStateHelper.buttonSpremi(uredjaj?.status ?? ""))
                      ListTile(
                        title: MinimalisticButton(
                          text: 'Spremi',
                          onPressed: () async {
                            try {
                              await uredjajProvider!.update(uredjaj!.uredjajId, null, "Uredjaj/Aktiviraj-Ready-Vrati");
                              poruka("Uređaj je spreman za isporuku");
                              var map = {'id': uredjaj?.uredjajId.toString() ?? ""};
                              _fetchData(map);
                            } catch (e) {
                              poruka(e.toString());
                            }
                          },
                        ),
                      ),
                    if (ChangeStateHelper.buttonPosalji(uredjaj?.status ?? ""))
                      ListTile(
                        title: MinimalisticButton(
                          text: 'Pošalji',
                          onPressed: () {},
                        ),
                      ),
                    if (ChangeStateHelper.buttonVrati(uredjaj?.status ?? ""))
                      ListTile(
                        title: MinimalisticButton(
                          text: 'Vrati',
                          onPressed: () async {
                            uredjajBloc?.filterSink.add("active");

                            /*try {
                              await uredjajProvider!.update(uredjaj!.uredjajId, null, "Uredjaj/Aktiviraj-Ready-Vrati");
                              poruka("Uređaj je ponovo vraćen u servis");
                            } catch (e) {
                              poruka(e.toString());
                            }
                            setState(() {});*/
                          },
                        ),
                      ),
                    if (ChangeStateHelper.buttonAktiviraj_rezervniDijelovi(uredjaj?.status ?? ""))
                      ListTile(
                        title: MinimalisticButton(
                          text: 'Rezervni dijelovi',
                          onPressed: () {},
                        ),
                      ),
                    if (ChangeStateHelper.buttonDeaktiviraj(uredjaj?.status ?? ""))
                      ListTile(
                        title: MinimalisticButton(
                          text: 'Deaktiviraj',
                          onPressed: () {},
                        ),
                      ),
                    if (ChangeStateHelper.buttonAktiviraj_rezervniDijelovi(uredjaj?.status ?? ""))
                      ListTile(
                        title: MinimalisticButton(
                          text: 'Uredi',
                          onPressed: () {},
                        ),
                      ),
                    if (ChangeStateHelper.buttonAktiviraj_rezervniDijelovi(uredjaj?.status ?? ""))
                      if (check)
                        ListTile(
                          title: MinimalisticButton(
                            text: 'Izbriši',
                            onPressed: () {},
                          ),
                        ),
                    if ((uredjaj?.status ?? "") == "parts")
                      ListTile(
                        title: MinimalisticButton(
                          text: 'Recikliraj',
                          onPressed: () {},
                        ),
                      ),
                  ],
                ),
              )),
          Padding(padding: EdgeInsets.fromLTRB(50, 0, 0, 0)),
          Container(
              width: 500,
              height: 800,
              padding: EdgeInsets.all(50),
              child: Timeline(
                children: servis
                    .distinct((x) => x.servisId)
                    .map((e) => TimelineModel(
                          Container(
                            height: 200,
                            child: ListView(
                              children: <Widget>[
                                ExpansionPanelList(
                                    elevation: 2,
                                    expandedHeaderPadding: EdgeInsets.all(8),
                                    expansionCallback: (int index, bool isExpanded) {
                                      setState(() {
                                        e.isExpanded = isExpanded;
                                      });
                                    },
                                    children: [
                                      ExpansionPanel(
                                          headerBuilder: (BuildContext context, bool isExpanded) {
                                            return ListTile(
                                              title: Text(e.datum.toString()),
                                            );
                                          },
                                          body: ListTile(
                                            title: Text("item.expandedValue"),
                                          ),
                                          isExpanded: e.isExpanded)
                                    ]),
                              ],
                            ),
                          ),
                          icon: Icon(
                            Icons.build,
                            color: Colors.white,
                          ),
                          iconBackground: Colors.blue,
                        ))
                    .toList(),
                position: TimelinePosition.Right,
                iconSize: 30,
                lineColor: Colors.blueGrey,
              )),
        ],
      ),
    );
  }

  void poruka(String msg) {
    ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack(msg));
  }
}
