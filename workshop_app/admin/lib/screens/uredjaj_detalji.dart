import 'package:admin/bloc/statistika_bloc/statistika_bloc.dart';
import 'package:admin/bloc/uredjaji/bloc/uredjaj_bloc.dart';
import 'package:admin/bloc/uredjaji_lista_zadatak.dart/bloc/uredjaji_lista_zadatak_bloc.dart';
import 'package:admin/screens/dodaj_uredi_uredjaj.dart';
import 'package:admin/screens/servisiraj.dart';
import 'package:commons/helpers/change_state_helper.dart';
import 'package:commons/helpers/format_datuma.dart';
import 'package:commons/helpers/state_helper.dart';
import 'package:commons/providers/izvrseni_servis_provider.dart';
import 'package:commons/models/izvrseni_servis.dart';
import 'package:commons/providers/reparacija_provider.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:provider/provider.dart';
import 'package:timeline_list/timeline_list.dart';
import 'package:admin/commons/app_bar.dart';
import 'package:commons/models/reparacija.dart';

class UredjajDetaljiScreen extends StatefulWidget {
  final Uredjaj? uredjaj;
  //final UredjajiBloc uredjajiBloc;
  BuildContext? context;

  UredjajDetaljiScreen({required this.uredjaj, this.context});

  @override
  _UredjajDetaljiScreenState createState() => _UredjajDetaljiScreenState();
}

class _UredjajDetaljiScreenState extends State<UredjajDetaljiScreen> {
  final GlobalKey<TooltipState> tooltipkey = GlobalKey<TooltipState>();

  bool check = true;
  List<IzvrseniServis> servis = [];
  List<Reparacija> reparacija = [];
  //Uredjaj? uredjaj;

  ReparacijaProvider? reparacijaProvider;
  IzvrseniServisProvider? izvrseniServisProvider;
  UredjajProvider? uredjajProvider;

  UredjajBloc? uredjajBlocTemp;

  @override
  void initState() {
    reparacijaProvider = context.read<ReparacijaProvider>();
    izvrseniServisProvider = context.read<IzvrseniServisProvider>();
    uredjajProvider = context.read<UredjajProvider>();

    uredjajBlocTemp = BlocProvider.of<UredjajBloc>(context);

    uredjajBlocTemp!.add(UredjajRefreshEvent(id: widget.uredjaj!.uredjajId!));

    var map = {'id': widget.uredjaj!.uredjajId!.toString()};

    _fetchData(map);

    super.initState();
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    final response = await izvrseniServisProvider?.get(map, "Reparacija/IzvrseniServis");

    final reparacijaGet = await reparacijaProvider!.get({'UredjajId': widget.uredjaj!.uredjajId.toString()}, "Reparacija");

    setState(() {
      servis = response!;
      reparacija = reparacijaGet;
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
    final UredjajBloc uredjajBlocTemp = BlocProvider.of<UredjajBloc>(context);
    final UredjajiListaZadatakBloc zadaciActiveUredjaj = BlocProvider.of<UredjajiListaZadatakBloc>(context);
    final StatistikaBloc statistikaBloc = BlocProvider.of<StatistikaBloc>(context);

    return BlocProvider(
      create: (context) => UredjajBloc(uredjajiProvider: uredjajProvider!),
      child: Scaffold(
          appBar: BarrApp(
            naslov: widget.uredjaj!.tipOpis ?? "",
          ),
          body: BlocConsumer<UredjajBloc, UredjajState>(
            bloc: uredjajBlocTemp,
            listenWhen: (previous, current) => current is UredjajDataLoadedState,
            listener: (context, state) {
              // TODO: implement listener
            },
            builder: (context, state) {
              if (state is LoadingEvent) {
                return Center(
                  child: CircularProgressIndicator(),
                );
              } else if (state is UredjajLoadedState) {
                var uredjaj = state.data;
                return Row(
                  children: [
                    Expanded(
                      child: Card(
                        elevation: 4.0,
                        margin: EdgeInsets.all(16.0),
                        child: Padding(
                          padding: const EdgeInsets.all(16.0),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Text(
                                ' ${uredjaj.tipOpis}',
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
                                      const DataCell(Text('ID')),
                                      DataCell(tekstInfo(uredjaj.uredjajId.toString())),
                                    ],
                                  ),
                                  DataRow(
                                    cells: [
                                      DataCell(Text('Tip')),
                                      DataCell(tekstInfo(uredjaj.tipNaziv ?? "")),
                                    ],
                                  ),
                                  DataRow(
                                    cells: [
                                      DataCell(Text('Koda')),
                                      DataCell(tekstInfo(uredjaj.koda ?? "")),
                                    ],
                                  ),
                                  DataRow(
                                    cells: [
                                      DataCell(Text('Serijski broj')),
                                      DataCell(tekstInfo(uredjaj.serijskiBroj ?? "")),
                                    ],
                                  ),
                                  DataRow(
                                    cells: [
                                      DataCell(Text('Stanje')),
                                      DataCell(tekstInfo(StateHelper.nizRezultat(uredjaj.status ?? ""))),
                                    ],
                                  ),
                                  DataRow(
                                    cells: [
                                      DataCell(Text('Lokacija')),
                                      DataCell(tekstInfo(uredjaj.lokacijaNaziv ?? "")),
                                    ],
                                  ),
                                ],
                              ),
                            ],
                          ),
                        ),
                      ),
                    ),
                    Expanded(
                      child: Container(
                          width: 250,
                          child: Card(
                            elevation: 4.0,
                            margin: EdgeInsets.all(16.0),
                            child: ListView(
                              physics: AlwaysScrollableScrollPhysics(),
                              shrinkWrap: true,
                              children: [
                                if (ChangeStateHelper.buttonAktiviraj_rezervniDijelovi(uredjaj.status.toString()))
                                  ListTile(
                                    title: MinimalisticButton(
                                      text: 'Aktiviraj',
                                      onPressed: () async {
                                        try {
                                          await uredjajProvider!.update(uredjaj.uredjajId, null, "Uredjaj/Aktiviraj-Ready-Vrati");
                                          poruka("Uređaj je aktiviran");
                                          uredjajBlocTemp.add(UredjajRefreshEvent(id: widget.uredjaj!.uredjajId!));
                                          zadaciActiveUredjaj.add(UredjajiLoadZadatakEvent());
                                          statistikaBloc.add(StatistikaRefreshEvent());
                                        } catch (e) {
                                          poruka(e.toString());
                                        }
                                      },
                                    ),
                                  ),
                                if (ChangeStateHelper.buttonServisiraj(uredjaj.status ?? ""))
                                  ListTile(
                                    title: MinimalisticButton(
                                      text: 'Servisiraj',
                                      onPressed: () {
                                        Navigator.push(context, MaterialPageRoute(builder: (context) => ServisirajScreen(uredjaj: uredjaj)))
                                            .then((value)  {_fetchData({'id': widget.uredjaj!.uredjajId!.toString()});
                                            uredjajBlocTemp.add(UredjajRefreshEvent(id: widget.uredjaj!.uredjajId!));
                                      });
                                            //uredjajBlocTemp.add(UredjajRefreshEvent(id: widget.uredjaj!.uredjajId!));
                                        statistikaBloc.add(StatistikaRefreshEvent());
                                      },
                                    ),
                                  ),
                                if (ChangeStateHelper.buttonSpremi(uredjaj.status ?? ""))
                                  ListTile(
                                    title: MinimalisticButton(
                                      text: 'Spremi',
                                      onPressed: () async {
                                        try {
                                          await uredjajProvider!.update(uredjaj.uredjajId, null, "Uredjaj/Aktiviraj-Ready-Vrati");
                                          poruka("Uređaj je spreman za isporuku");
                                          uredjajBlocTemp.add(UredjajRefreshEvent(id: widget.uredjaj!.uredjajId!));
                                          statistikaBloc.add(StatistikaRefreshEvent());
                                        } catch (e) {
                                          poruka(e.toString());
                                        }
                                      },
                                    ),
                                  ),
                                if (ChangeStateHelper.buttonPosalji(uredjaj.status ?? ""))
                                  ListTile(
                                    title: MinimalisticButton(
                                      text: 'Pošalji',
                                      onPressed: () async {
                                        try {
                                          await uredjajProvider!.update(uredjaj.uredjajId, null, "Uredjaj/Posalji");
                                          poruka("Uređaj je poslan");
                                          uredjajBlocTemp.add(UredjajRefreshEvent(id: widget.uredjaj!.uredjajId!));
                                          statistikaBloc.add(StatistikaRefreshEvent());
                                        } catch (e) {
                                          poruka(e.toString());
                                        }
                                      },
                                    ),
                                  ),
                                if (ChangeStateHelper.buttonVrati(uredjaj.status ?? ""))
                                  ListTile(
                                    title: MinimalisticButton(
                                      text: 'Vrati',
                                      onPressed: () async {
                                        try {
                                          await uredjajProvider!.update(uredjaj.uredjajId, null, "Uredjaj/Aktiviraj-Ready-Vrati");
                                        } catch (e) {
                                          poruka(e.toString());
                                        }

                                        poruka("Uređaj je ponovo vraćen u servis");

                                        uredjajBlocTemp.add(UredjajRefreshEvent(id: widget.uredjaj!.uredjajId!));
                                        statistikaBloc.add(StatistikaRefreshEvent());
                                      },
                                    ),
                                  ),
                                if (ChangeStateHelper.buttonAktiviraj_rezervniDijelovi(uredjaj.status ?? ""))
                                  ListTile(
                                    title: MinimalisticButton(
                                      text: 'Rezervni dijelovi',
                                      onPressed: () async {
                                        try {
                                          await uredjajProvider!.update(uredjaj.uredjajId, null, "Uredjaj/SpareParts");
                                          poruka("Uređaj je ostavljen za rezervne dijelove");
                                          uredjajBlocTemp.add(UredjajRefreshEvent(id: widget.uredjaj!.uredjajId!));
                                          statistikaBloc.add(StatistikaRefreshEvent());
                                        } catch (e) {
                                          poruka(e.toString());
                                        }
                                      },
                                    ),
                                  ),
                                if (ChangeStateHelper.buttonDeaktiviraj(uredjaj.status ?? ""))
                                  ListTile(
                                    title: MinimalisticButton(
                                      text: 'Deaktiviraj',
                                      onPressed: () async {
                                        try {
                                          await uredjajProvider!.update(uredjaj.uredjajId, null, "Uredjaj/Deaktiviraj");
                                          poruka("Uređaj je deaktiviran.");
                                          uredjajBlocTemp.add(UredjajRefreshEvent(id: widget.uredjaj!.uredjajId!));
                                          statistikaBloc.add(StatistikaRefreshEvent());
                                        } catch (e) {
                                          poruka(e.toString());
                                        }
                                      },
                                    ),
                                  ),
                                if (ChangeStateHelper.buttonAktiviraj_rezervniDijelovi(uredjaj.status ?? ""))
                                  ListTile(
                                    title: MinimalisticButton(
                                      text: 'Uredi',
                                      onPressed: () {
                                        showDialog(
                                          context: context,
                                          builder: (BuildContext context) => DodajUrediUredjaj(
                                            editUredjaj: uredjaj,
                                          ),
                                        ).then((x) => uredjajBlocTemp.add(UredjajRefreshEvent(id: widget.uredjaj!.uredjajId!)));
                                      },
                                    ),
                                  ),
                                if (ChangeStateHelper.buttonAktiviraj_rezervniDijelovi(uredjaj.status ?? ""))
                                  if (check) ListTile(),
                                if ((uredjaj.status ?? "") == "parts")
                                  ListTile(
                                    title: MinimalisticButton(
                                      text: 'Recikliraj',
                                      onPressed: () async {
                                        try {
                                          await uredjajProvider!.update(uredjaj.uredjajId, null, "Uredjaj/Aktiviraj-Ready-Vrati");
                                          poruka("Uređaj je aktiviran");
                                          uredjajBlocTemp.add(UredjajRefreshEvent(id: widget.uredjaj!.uredjajId!));
                                          statistikaBloc.add(StatistikaRefreshEvent());
                                        } catch (e) {
                                          poruka(e.toString());
                                        }
                                      },
                                    ),
                                  ),
                              ],
                            ),
                          )),
                    ),
                    Padding(padding: EdgeInsets.fromLTRB(50, 0, 0, 0)),
                    Container(
                        width: 600,
                        height: 800,
                        padding: EdgeInsets.fromLTRB(70, 60, 0, 0),
                        child: Timeline(children: reparacija
                              .map((e) =>Marker(
                                
                                iconAlignment: MarkerIconAlignment.top,
                                icon:Icon(
                                  
                                      Icons.build,
                                      color: Colors.black,
                                      size: 15,
                                    ),child:  Column(children: [
                                Container(
                                      decoration: BoxDecoration(
                                        border: e.isExpanded? Border.all(
                                          color: Colors.black12, // Border color
                                          width: 2.0, // Border width
                                        ):null,
                                      ),
                                      width: MediaQuery.of(context).size.width * 0.2,
                                      height: 200,
                                      child: ListView(
                                        children: <Widget>[

                                          ExpansionPanelList(
                                              elevation: 4,
                                              expandedHeaderPadding: EdgeInsets.all(8),
                                              expansionCallback: (int index, bool isExpanded) {
                                                setState(() {
                                                  e.isExpanded = isExpanded;
                                                });
                                              },
                                              children: [
                                                ExpansionPanel(
                                                    canTapOnHeader: true,
                                                    headerBuilder: (BuildContext context, bool isExpanded) {
                                                      return ListTile(
                                                        title: Text(FormatirajDatum.formatiraj(DateTime.parse(e.datum.toString())),
                                                      ));
                                                    },
                                                    body: ListTile(
                                                      title: Column(
                                                        mainAxisSize: MainAxisSize.min,
                                                        children: [
                                                          _buildDataTable(servis.where((element) => element.servisId == e.servisId).toList()),
                                                          Text("Servisirao: " +
                                                              reparacija
                                                                  .where((element) => element.servisId == e.servisId)
                                                                  .toList()
                                                                  .first
                                                                  .servisirao
                                                                  .toString())
                                                        ],
                                                      ), //_buildDataTable(),
                                                    ),
                                                    isExpanded: e.isExpanded)
                                              ]),
                                        ],
                                      ),
                                    ),
                              ],))).toList())),
                  ],
                );
              } else {
                return CircularProgressIndicator();
              }
            },
          )),
    );
  }

  Text tekstInfo(String uredjaj) => Text(
        uredjaj,
        style: const TextStyle(fontWeight: FontWeight.bold),
      );

  void poruka(String msg) {
    ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack(msg));
  }


  Widget _buildDataTable(List<IzvrseniServis> komp) {
    return Column(
      mainAxisSize: MainAxisSize.min,
      children: [
        DataTable(
          columns: [
            //DataColumn(label: Text('#')),
            DataColumn(label: Text('Naziv')),
            DataColumn(label: Text('Vrijednost')),
            DataColumn(label: Text('Koda')),
            //DataColumn(label: Text('ID')),
          ],
          rows: komp.isEmpty
              ? [
                  const DataRow(cells: [
                    DataCell(Text("")),
                    DataCell(Text("")),
                    DataCell(Text("")),
                  ])
                ]
              : komp
                  .map((e) => DataRow(cells: [
                        DataCell(Text(e.naziv ?? "")),
                        DataCell(Text(e.vrijednost ?? "")),
                        DataCell(Text(e.tip ?? "")),
                      ]))
                  .toList(),
        )
      ],
    );
  }
}
