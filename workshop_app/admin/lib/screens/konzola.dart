import 'package:admin/bloc/uredjaji_bloc.dart';
import 'package:admin/bloc/zadatak_uredjaj_bloc.dart';
import 'package:admin/commons/app_bar.dart';
import 'package:commons/models/radni_zadatak.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/providers/radniZadaci_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/radni_zadatak.dart';
import 'package:darq/darq.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

class KonzolaScreen extends StatefulWidget {
  final void Function()? refreshKonzolaCallback;

  KonzolaScreen({this.refreshKonzolaCallback = defaultRefreshCallback});

  //const KonzolaScreen({super.key});

  @override
  State<KonzolaScreen> createState() => _KonzolaScreenState();

  static void defaultRefreshCallback() {}
}

class _KonzolaScreenState extends State<KonzolaScreen> {
  RadniZadaciProvider? radniZadaciProvider = null;
  RadniZadaciUredjajProvider? radniZadaciUredjajProvider = null;

  List<RadniZadatakUredjaj> radniZadatakUredjajData = [];
  List<RadniZadatak> radniZadatakDetalj = [];

  bool _isLoading = true;

  ZadatakUredjajBloc? zadatakUredjajBloc;

  @override
  void initState() {
    radniZadaciProvider = context.read<RadniZadaciProvider>();
    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();

    zadatakUredjajBloc = ZadatakUredjajBloc(zadatakProvider: radniZadaciUredjajProvider);

    zadatakUredjajBloc!.eventSink.add(UredjajAction.Refresh);

    super.initState();
    //_fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    setState(() {
      _isLoading = true;
    });

    var response = await radniZadaciProvider?.get({'StateMachine': 'active'}, "RadniZadatak");
    //var items = await radniZadaciUredjajProvider?.get({'search': 'active'}, "RadniZadatakUredjaj/Flutter");

    setState(() {
      //radniZadatakUredjajData = items!;
      radniZadatakDetalj = response!;
      _isLoading = false;
    });

    KonzolaScreen.defaultRefreshCallback();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: BarrApp(naslov: "Informacioni sistem za podršku rada servisne radionice"),
        body: SafeArea(
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
                child: StreamBuilder<List<RadniZadatakUredjaj>>(
                    stream: zadatakUredjajBloc?.zadatakUredjajStream,
                    builder: (context, snapshot) {
                      if (snapshot.hasData) {
                        var listDistinct = Set();

                        //final zadatakUredjajiDataDistinct = snapshot.data!.distinct().toList();
                        final zadatakUredjajiData = snapshot.data!;

                        List<RadniZadatakUredjaj> unique = zadatakUredjajiData.where((x) => listDistinct.add(x.radniZadatakId)).toList();

                        return Row(
                            children: unique
                                .map((e) => RadniZadaciWidget(
                                      radniZadatakUredjaj:
                                          zadatakUredjajiData!.where((uredjaj) => uredjaj.radniZadatakId == e.radniZadatakId).toList(),
                                      radniZadatak: e,
                                    ))
                                .toList());
                      } else {
                        return CircularProgressIndicator();
                      }
                    })),
            Container(
              child: MinimalisticButton(
                text: "Osvježi",
                onPressed: () {
                  zadatakUredjajBloc!.eventSink.add(UredjajAction.Refresh);
                },
              ),
            )
          ]),
        )));
  }
}
