import 'package:admin/screens/dodaj_uredi_uredjaj.dart';
import 'package:admin/screens/servisiraj.dart';
import 'package:commons/bloc/statistika_bloc/statistika_bloc.dart';
import 'package:commons/bloc/uredjaji/bloc/uredjaj_bloc.dart';
import 'package:commons/bloc/uredjaji_lista_zadatak.dart/bloc/uredjaji_lista_zadatak_bloc.dart';
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
            naslov: "Informacije o uređaju",
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
                    Column(
                      children: [
                        Card(
                          color: Color(0xFFf3f5fb),
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
                                  columns: const [
                                    DataColumn(label: Text('ID')),
                                    DataColumn(label: Text('Tip')),
                                    DataColumn(label: Text('Koda')),
                                    DataColumn(label: Text('Serijski broj')),
                                    DataColumn(label: Text('Stanje')),
                                    DataColumn(label: Text('Lokacija')),
                                  ],
                                  rows: [
                                    DataRow(
                                      cells: [
                                        DataCell(tekstInfo(
                                            uredjaj.uredjajId.toString())),
                                        DataCell(
                                            tekstInfo(uredjaj.tipNaziv ?? "")),
                                        DataCell(tekstInfo(uredjaj.koda ?? "")),
                                        DataCell(tekstInfo(
                                            uredjaj.serijskiBroj ?? "")),
                                        DataCell(tekstInfo(
                                            StateHelper.nizRezultat(
                                                uredjaj.status ?? ""))),
                                        DataCell(tekstInfo(
                                            uredjaj.lokacijaNaziv ?? "")),
                                      ],
                                    ),
                                  ],
                                )
                              ],
                            ),
                          ),
                        ),
                        Container(
  width: 350,
  child: Card(
    color: Color(0xFFf3f5fb),
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
              textColor: Colors.black,
              icons: Icon(Icons.play_arrow, color: Colors.black),
              color: Colors.green.shade300,
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
              textColor: Colors.black,
              icons: Icon(Icons.build, color: Colors.black),
              color: Colors.orange.shade300,
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => ServisirajScreen(uredjaj: uredjaj)),
                ).then((value) {
                  _fetchData({'id': widget.uredjaj!.uredjajId!.toString()});
                  uredjajBlocTemp.add(UredjajRefreshEvent(id: widget.uredjaj!.uredjajId!));
                });
                statistikaBloc.add(StatistikaRefreshEvent());
              },
            ),
          ),
        if (ChangeStateHelper.buttonSpremi(uredjaj.status ?? ""))
          ListTile(
            title: MinimalisticButton(
              text: 'Spremi',
              textColor: Colors.black,
              icons: Icon(Icons.outbox, color: Colors.white),
              color: Colors.indigo.shade300,
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
              textColor: Colors.black,
              icons: Icon(Icons.local_shipping, color: Colors.white),
              color: Colors.brown.shade300,
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
              textColor: Colors.black,
              icons: Icon(Icons.undo, color: Colors.white),
              color: Colors.amber.shade300,
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
            title: SizedBox(
              width: 100,
              child: MinimalisticButton(
                text: 'Rezervni dijelovi',
                textColor: Colors.black,
                icons: Icon(Icons.inventory_2, color: Colors.white),
                color: Colors.purple.shade300,
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
          ),
        if (ChangeStateHelper.buttonDeaktiviraj(uredjaj.status ?? ""))
          ListTile(
            title: MinimalisticButton(
              text: 'Deaktiviraj',
              textColor: Colors.black,
              icons: Icon(Icons.power_off, color: Colors.white),
              color: Colors.grey.shade400,
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
              textColor: Colors.black,
              icons: Icon(Icons.edit, color: Colors.white),
              color: Colors.blueAccent.shade200,
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
              textColor: Colors.black,
              icons: Icon(Icons.inventory_2, color: Colors.white),
              color: Colors.teal.shade300,
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
  ),
)
,]),
                  
                    SingleChildScrollView(
                      child: Padding(
                        padding: const EdgeInsets.fromLTRB(20, 20, 0 ,0 ),
                        child: Card(
                          color: Color(0xFFf3f5fb),
                          elevation: 4.0,
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            mainAxisAlignment: MainAxisAlignment.start, children: [
                            
                            Padding(
                              padding: const EdgeInsets.fromLTRB(20, 30,0,0),
                              child: Text("Historija servisiranja", style: TextStyle(
                                          fontSize: 20,
                                          fontWeight: FontWeight.bold,
                                        )),
                            ),
                          Padding(padding: EdgeInsets.fromLTRB(50, 0, 0, 0)),
                          Container(
                              width: 600,
                            
                              padding: EdgeInsets.fromLTRB(70, 60, 0, 0),
                              child: reparacija.isEmpty ? Text("--Nema podataka--", style: TextStyle(
                                    fontSize: 15,
                                    fontWeight: FontWeight.bold,
                                  )): Timeline(children: reparacija
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
                                            ]),
                        ),
                      ),
                    )]);
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
