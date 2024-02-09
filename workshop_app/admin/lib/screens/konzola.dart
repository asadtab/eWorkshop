import 'package:admin/bloc/radni_zadatak_uredjaj/bloc/radni_zadatak_uredjaj_block_bloc.dart';
import 'package:admin/commons/app_bar.dart';

import 'package:admin/widgets/radni_zadatak.dart';
import 'package:commons/models/radni_zadatak.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/radniZadaci_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';

import 'package:commons/widgets/button.dart';
import 'package:darq/darq.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:http/http.dart';
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

  bool _isLoading = true;

  @override
  void initState() {
    radniZadaciProvider = context.read<RadniZadaciProvider>();
    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();

    //radniZadaciProvider

    super.initState();
    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    setState(() {
      _isLoading = true;
    });

    var response = await radniZadaciProvider?.get({'StateMachine': 'active'}, "RadniZadatak");
    var items = await radniZadaciUredjajProvider?.get({'search': 'active'}, "RadniZadatakUredjaj/Flutter");

    setState(() {
      radniZadatakUredjajData = items!;
      radniZadatakDetalj = response!;
      _isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    final RadniZadatakUredjajBloc uredjajBloc = BlocProvider.of<RadniZadatakUredjajBloc>(context);

    return BlocProvider(
        create: (context) => RadniZadatakUredjajBloc(radniZadaciUredjajProvider: radniZadaciUredjajProvider!)..add(RadniZadatakLoadingEvent()),
        child: Scaffold(
          appBar: BarrApp(naslov: "Informacioni sistem za podršku rada servisne radionice"),
          body: BlocConsumer<RadniZadatakUredjajBloc, RadniZadatakUredjajState>(
            bloc: uredjajBloc,
            listenWhen: (previous, current) => previous is DataLoadedState,
            listener: (context, state) {
              //uredjajBloc.add(LoadingEvent());
              if (state is DataLoadedState) radniZadatakUredjajData = state.data;
            },
            buildWhen: (previous, current) => current is DataLoadedState,
            builder: (context, state) {
              if (state is LoadingState) {
                return const Center(
                  child: CircularProgressIndicator(),
                );
              } else if (state is DataLoadedState) {
                var temp = radniZadatakUredjajData;
                var uredjaji = state.data;
                var uredjajiDistinct = uredjaji.distinct((x) => x.radniZadatakId).toList();
                return SafeArea(
                    child: SingleChildScrollView(
                  scrollDirection: Axis.horizontal,
                  child: Column(crossAxisAlignment: CrossAxisAlignment.center, children: [
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
                    Padding(
                        padding: EdgeInsets.fromLTRB(20, 0, 20, 0),
                        child: Row(
                            children: uredjajiDistinct
                                .map((e) => RadniZadaciWidget(
                                      radniZadatakUredjaj: uredjaji,
                                      radniZadatak: e,
                                    ))
                                .toList())),
                    /* Container(
                      child: MinimalisticButton(
                        text: "Osvježi",
                        onPressed: () {
                          uredjajBloc.add(RadniZadatakLoadingEvent());
                        },
                      ),
                    )*/
                  ]),
                ));
              } else {
                return Center(child: CircularProgressIndicator());
              }
            },
          ),
        ));
  }
}
