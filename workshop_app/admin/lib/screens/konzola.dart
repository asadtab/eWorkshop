import 'package:admin/bloc/radni_zadatak_uredjaj/bloc/radni_zadatak_uredjaj_block_bloc.dart';
import 'package:admin/bloc/statistika_bloc/statistika_bloc.dart';
import 'package:admin/commons/app_bar.dart';
import 'package:admin/widgets/radni_zadatak.dart';
import 'package:commons/models/radni_zadatak.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/providers/radniZadaci_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:darq/darq.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:provider/provider.dart';

class KonzolaScreen extends StatefulWidget {
  KonzolaScreen();

  //const KonzolaScreen({super.key});

  @override
  State<KonzolaScreen> createState() => _KonzolaScreenState();
}

class _KonzolaScreenState extends State<KonzolaScreen> {
  RadniZadaciProvider? radniZadaciProvider = null;
  RadniZadaciUredjajProvider? radniZadaciUredjajProvider = null;

  List<RadniZadatakUredjaj> radniZadatakUredjajData = [];
  List<RadniZadatak> radniZadatakDetalj = [];

  @override
  void initState() {
    radniZadaciProvider = context.read<RadniZadaciProvider>();
    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();

    //radniZadaciProvider

    super.initState();
    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    var items = await radniZadaciUredjajProvider?.get({'search': 'active'}, "RadniZadatakUredjaj/Flutter");
    var response = await radniZadaciProvider?.get({'StateMachine': 'active'}, "RadniZadatak");

    setState(() {
      radniZadatakUredjajData = items!;
      radniZadatakDetalj = response!;
    });
  }

 

  @override
  Widget build(BuildContext context) {
    final RadniZadatakUredjajBloc uredjajBloc = BlocProvider.of<RadniZadatakUredjajBloc>(context);
    final StatistikaBloc statistikaBloc = BlocProvider.of<StatistikaBloc>(context);
    statistikaBloc.add(StatistikaRefreshEvent());

    return BlocProvider(
        create: (context) => RadniZadatakUredjajBloc(radniZadaciUredjajProvider: radniZadaciUredjajProvider!)..add(RadniZadatakLoadingEvent()),
        child: Scaffold(
          appBar: BarrApp(naslov: "Informacioni sistem za podršku rada servisne radionice"),
          body: SingleChildScrollView(
              child: BlocConsumer<RadniZadatakUredjajBloc, RadniZadatakUredjajState>(
            bloc: uredjajBloc,
            listenWhen: (previous, current) => previous is DataLoadedState,
            listener: (context, state) {
              if (state is DataLoadedState) radniZadatakUredjajData = state.data;
            },
            buildWhen: (previous, current) => current is DataLoadedState,
            builder: (context, state) {
              if (state is LoadingState) {
                return const Center(
                  child: CircularProgressIndicator(),
                );
              } else if (state is DataLoadedState) {
                var uredjaji = state.data;

                var uredjajiDistinct = uredjaji.distinct((x) => x.radniZadatakId ?? 0).toList();

                if (uredjajiDistinct.isEmpty) {
                  Center(
                    child: Text("Trenutno nema aktivni radnih zadataka."),
                  );
                }

                return Column(
                  children: [
                    Column(crossAxisAlignment: CrossAxisAlignment.center, children: [
                      Container(
                        child: Row(
                          children: [
                            Container(
                                padding: EdgeInsets.all(20),
                                child: Text(
                                  "Aktivni radni zadaci:",
                                  style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold),
                                ))
                          ],
                        ),
                      ),
                      Container(
                        height: 400,
                        child: Padding(
                            padding: EdgeInsets.fromLTRB(20, 0, 20, 0),
                            child: SingleChildScrollView(
                              scrollDirection: Axis.horizontal,
                              child: uredjajiDistinct.isEmpty
                                  ? Center(
                                      child: Column(children: [
                                        Text(
                                            "Trenutno nema aktivnih radnih zadataka. Aktiviraj radni zadatak dodavanjem uređaja u sekciji Raspored uređaja."),
                                      ]),
                                    )
                                  : Row(
                                      mainAxisAlignment: MainAxisAlignment.start,
                                      children: uredjajiDistinct
                                          .map((e) => RadniZadaciWidget(
                                                radniZadatakUredjaj: uredjaji,
                                                radniZadatak: e,
                                              ))
                                          .toList()),
                            )),
                      ),
                    ]),
                    SingleChildScrollView(
                      scrollDirection: Axis.horizontal,
                      child: ConstrainedBox(
                        constraints: BoxConstraints(
                          maxWidth: MediaQuery.of(context).size.width,
                        ),
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            BlocConsumer<StatistikaBloc, StatistikaState>(
                              listener: (context, state) {
                                // TODO: implement listener
                              },
                              bloc: statistikaBloc,
                              builder: (context, state) {
                                if (state is StatistikaInitial) {
                                  var stat = state.statistika;

                                  return Card(
                                    elevation: 4,
                                    shape: RoundedRectangleBorder(
                                      borderRadius: BorderRadius.circular(16),
                                    ),
                                    child: Padding(
                                      padding: const EdgeInsets.all(16),
                                      child: Container(
                                        child: Column(
                                          crossAxisAlignment: CrossAxisAlignment.center,
                                          children: [
                                            Text(
                                              'Uređaji',
                                              style: TextStyle(
                                                fontSize: 20,
                                                fontWeight: FontWeight.bold,
                                              ),
                                            ),
                                            SizedBox(height: 16),
                                            Row(
                                              mainAxisAlignment: MainAxisAlignment.center,
                                              children: [
                                                _buildStatItem('Ukupno uređaja', stat?.uredjajiUkupno.toString() ?? ""),
                                                _buildStatItem('Aktivni uređaji', stat?.aktivniUredjaji.toString() ?? ""),
                                                _buildStatItem('Servisirani uređaji', stat?.servisiraniUredjaji.toString() ?? ""),
                                                _buildStatItem('Poslani uređaji', stat?.poslaniUredjaji.toString() ?? ""),
                                                _buildStatItem('Spremni uređaji', stat?.spremniUredjaji.toString() ?? ""),
                                                _buildStatItem('Neaktivni uređaji', stat?.neaktivniUredjaji.toString() ?? ""),
                                              ],
                                            ),
                                            SizedBox(height: 16),
                                            Text(
                                              'Radni zadaci',
                                              style: TextStyle(
                                                fontSize: 20,
                                                fontWeight: FontWeight.bold,
                                              ),
                                            ),
                                            SizedBox(height: 16),
                                            Row(
                                              mainAxisAlignment: MainAxisAlignment.center,
                                              children: [
                                                _buildStatItem('Ukupno radnih zadataka', stat?.radniZadaciUkupno.toString() ?? ""),
                                                _buildStatItem('Aktivni radni zadaci', stat?.aktivniRadniZadaci.toString() ?? ""),
                                                _buildStatItem('Završeni radni zadaci', stat?.zavrseniRadniZadaci.toString() ?? ""),
                                                _buildStatItem('Neaktivni radni zadaci', stat?.neaktivniRadniZadaci.toString() ?? ""),
                                                _buildStatItem('Fakturisani radni zadaci', stat?.fakturisaniRadniZadaci.toString() ?? ""),
                                              ],
                                            ),
                                          ],
                                        ),
                                      ),
                                    ),
                                  );
                                } else {
                                  return Container(
                                    child: Text("Podaci nedostupni"),
                                  );
                                }
                              },
                            ),
                          ],
                        ),
                      ),
                    )
                  ],
                );
              } else {
                return Center(child: CircularProgressIndicator());
              }
            },
          )),
        ));
  }

  Widget _buildStatItem(String title, String value) {
    return Padding(
      padding: EdgeInsets.all(16),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            title,
            style: TextStyle(
              fontSize: 16,
              color: Colors.grey[600],
            ),
          ),
          SizedBox(height: 8),
          Text(
            value,
            style: TextStyle(
              fontSize: 20,
              fontWeight: FontWeight.bold,
            ),
          ),
        ],
      ),
    );
  }
}
