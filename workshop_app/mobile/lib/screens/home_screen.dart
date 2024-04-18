import 'package:commons/models/radni_zadatak.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/providers/radniZadaci_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:commons/providers/statistika_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:commons/models/statistika.dart';
import 'package:workshop_app/screens/statistika_screen.dart';
import '../common_widget/radni_zadaci.dart';
import '../helpers/common_widget.dart';
import '../helpers/master_screen.dart';

class HomeScreen extends StatefulWidget {
  static const routeName = "/homeScreen";
  const HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  RadniZadaciProvider? radniZadaciProvider = null;
  RadniZadaciUredjajProvider? radniZadaciUredjajProvider = null;
  List<RadniZadatakUredjaj> radniZadatakUredjajData = [];
  List<RadniZadatak> radniZadatak = [];
  bool _isLoading = true;
  double progres = 0;
  Statistika? stat = null;

  late StatistikaProvider? statistikaProvider;

  @override
  void initState() {
    super.initState();

    radniZadaciProvider = context.read<RadniZadaciProvider>();
    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();

    statistikaProvider = context.read<StatistikaProvider>();

    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    setState(() {
      _isLoading = true;
    });

    try {
      var responseZadaci = await radniZadaciProvider?.get({'StateMachine': 'active'}, "RadniZadatak");
      var items = await radniZadaciUredjajProvider?.get({'StateMachine': 'active'}, "RadniZadatakUredjaj/Flutter");
      var statistikaResponse = await statistikaProvider!.get(null, "Statistika/Uredjaji");

      setState(() {
        radniZadatak = responseZadaci!;
        radniZadatakUredjajData = items!;
        stat = statistikaResponse.first;
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
      appBar: AppBar(
        title: Text(
          "SS&TK",
          style: TextStyle(fontWeight: FontWeight.bold),
        ),
      ),
      body: _isLoading
          ? Center(child: CircularProgressIndicator())
          : Container(
              child: Column(
                children: [
                  Container(
                    padding: EdgeInsets.fromLTRB(10, 20, 10, 0),
                    child: Card(
                      child: Container(
                        color: Color(0xFFCBE4DE),
                        padding: EdgeInsets.all(5),
                        child: Text(
                          "Informacioni sistem za podršku rada servisne radionice",
                          style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold),
                        ),
                      ),
                    ),
                  ),
                  CommonWidget.dividerDetalji(),
                  Container(
                    padding: EdgeInsets.fromLTRB(0, 20, 0, 20),
                    child: Text(
                      "Aktivni radni zadaci: ",
                      style: TextStyle(fontSize: 20),
                    ),
                  ),
                  Expanded(
                    child: SizedBox(
                      height: 100, // Fixed height for GridView
                      child: GridView(
                          gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(crossAxisCount: 1, childAspectRatio: 3.5, mainAxisSpacing: 10),
                          scrollDirection: Axis.horizontal,
                          children: RadniZadatakCommon.zadatak(context, radniZadatakUredjajData, radniZadatak)),
                    ),
                  ),
                  MinimalisticButton(
                    text: "Statistika",
                    onPressed: () {
                      Navigator.push(context, MaterialPageRoute(builder: (context) => StatistikaScreen()));
                    },
                    icons: Icon(
                      Icons.bar_chart,
                      color: Colors.black,
                    ),
                  )
                ],
              ),
            ),
    );
  }
}
