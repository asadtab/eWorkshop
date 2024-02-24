import 'package:admin/bloc/radni_zadatak_uredjaj/bloc/radni_zadatak_uredjaj_block_bloc.dart';
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
    var response = await radniZadaciProvider?.get({'StateMachine': 'active'}, "RadniZadatak");
    var items = await radniZadaciUredjajProvider?.get({'search': 'active'}, "RadniZadatakUredjaj/Flutter");

    setState(() {
      radniZadatakUredjajData = items!;
      radniZadatakDetalj = response!;
    });
  }

  @override
  Widget build(BuildContext context) {
    final RadniZadatakUredjajBloc uredjajBloc = BlocProvider.of<RadniZadatakUredjajBloc>(context);

    return BlocProvider(
        create: (context) => RadniZadatakUredjajBloc(radniZadaciUredjajProvider: radniZadaciUredjajProvider!)..add(RadniZadatakLoadingEvent()),
        child: Scaffold(
          appBar: BarrApp(naslov: "Informacioni sistem za podršku rada servisne radionice"),
          body: SingleChildScrollView(
              child:
                  //scrollDirection: Axis.horizontal,
                  BlocConsumer<RadniZadatakUredjajBloc, RadniZadatakUredjajState>(
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
                var uredjaji = state.data;
                var uredjajiDistinct = uredjaji.distinct((x) => x.radniZadatakId).toList();
                return Column(
                  children: [
                    SingleChildScrollView(
                      scrollDirection: Axis.horizontal,
                      child: Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
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
                              child: Row(
                                  children: uredjajiDistinct
                                      .map((e) => RadniZadaciWidget(
                                            radniZadatakUredjaj: uredjaji,
                                            radniZadatak: e,
                                          ))
                                      .toList())),
                        ),
                      ]),
                    ),
                    Row(
                      //mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Padding(
                            padding: EdgeInsets.fromLTRB(20, 0, 0, 0),
                            child: Card(elevation: 3, borderOnForeground: true, shadowColor: Colors.amber, child: ListView(
                                physics: AlwaysScrollableScrollPhysics(),
                                shrinkWrap: false, // This is important to allow the ListView to be used inside a Column
                                children: []))),
                      ],
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
}
