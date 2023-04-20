import 'package:darq/darq.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:percent_indicator/circular_percent_indicator.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/screens/radni_zadaci/radni_zadatak_detalji.dart';

import '../helpers/bottom_bar.dart';
import '../helpers/common_widget.dart';
import '../helpers/master_screen.dart';
import '../model/radni_zadatak.dart';
import '../model/radni_zadatak_uredjaj.dart';
import '../providers/radniZadaci_provider.dart';
import '../providers/radniZadaci_uredjaj_provider.dart';

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
  List<RadniZadatak> data = [];
  bool _isLoading = true;
  double progres = 0;

  @override
  void initState() {
    super.initState();

    radniZadaciProvider = context.read<RadniZadaciProvider>();
    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();
    print("called initState");
    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    setState(() {
      _isLoading = true;
    });

    //var response = await radniZadaciProvider?.get({'UredjajState': 'active'});
    var items = await radniZadaciUredjajProvider?.get({'search': 'active'}, "RadniZadatakUredjaj/Flutter");

    setState(() {
      radniZadatakUredjajData = items!;
      _isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        bottomNavigationBar: MyBottomBar(),
        drawer: DrawerWidget(),
        floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
        floatingActionButton: FloatingActionButton(
          onPressed: () {},
          child: Icon(Icons.add),
        ),
        appBar: AppBar(
          title: Text(
            "SS&TK",
            style: TextStyle(fontWeight: FontWeight.bold),
          ),
        ),
        body: _isLoading
            ? Center(child: CircularProgressIndicator())
            : Container(
                child: Column(children: [
                Container(
                    padding: EdgeInsets.fromLTRB(10, 20, 10, 0),
                    child: Card(
                      child: Container(
                          color: Color(0xFFCBE4DE),
                          padding: EdgeInsets.all(5),
                          child: Text("Informacioni sistem za podršku rada servisne radionice",
                              style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold))),
                    )),
                CommonWidget.dividerDetalji(),
                Container(
                    padding: EdgeInsets.fromLTRB(0, 20, 0, 20),
                    child: Text(
                      "Aktivni radni zadaci: ",
                      style: TextStyle(fontSize: 20),
                    )),
                Expanded(
                    child: Container(
                        height: 100,
                        child: GridView(
                            gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(crossAxisCount: 1, childAspectRatio: 3.5, mainAxisSpacing: 10),
                            scrollDirection: Axis.horizontal,
                            children: zadatak(context, radniZadatakUredjajData.distinct((x) => [x.radniZadatakId]).toList())))),
                SizedBox(
                  height: 150,
                  child: Text("Asad"),
                )
              ])));
  }

  List<RadniZadatakUredjaj> getUredjaj(int id) {
    return radniZadatakUredjajData.where((x) => x.radniZadatakId == id).toList();
  }

  List<Widget> items(int id) {
    if (radniZadatakUredjajData.length == 0) {
      return [CircularProgressIndicator()];
    }
    postotak(id);

    List<Widget> list = getUredjaj(id)
        .map((x) => Container(
            padding: EdgeInsets.fromLTRB(10, 10, 0, 0),
            width: 150,
            height: 30,
            child: Text(x.uredjajId.toString() + " - " + x.tipNaziv.toString(), style: TextStyle(fontWeight: FontWeight.bold))))
        .cast<Widget>()
        .toList();

    return list;
  }

  void postotak(int id) {
    var uredjaji = getUredjaj(id);
    int brojac = 0;

    for (var i = 0; i < uredjaji.length; i++) {
      if (uredjaji[i].uredjajStatus == "fix" || uredjaji[i].uredjajStatus == "ready" || uredjaji[i].uredjajStatus == "out") {
        brojac++;
      }

      progres = brojac / uredjaji.length;
    }
  }

  List<Widget> zadatak(BuildContext context, List<RadniZadatakUredjaj> data) {
    if (radniZadatakUredjajData.length == 0) {
      return [CircularProgressIndicator()];
    }

    var listDistinct = Set();

    List<RadniZadatakUredjaj> unique = data.where((x) => listDistinct.add(x.radniZadatakId)).toList();

    List<Widget> list = unique
        .map((x) => Column(children: [
              Card(
                  child: Container(
                width: 150,
                height: 250,
                child: SingleChildScrollView(
                  child: Column(mainAxisAlignment: MainAxisAlignment.start, children: [
                    InkWell(
                      onTap: () {
                        var uredjaji = getUredjaj(x.radniZadatakId);

                        MaterialPageRoute(builder: (context) => RadniZadatakDetaljiScreen.zadaci(uredjaji));

                        Navigator.push(context, MaterialPageRoute(builder: (context) => RadniZadatakDetaljiScreen.zadaci(uredjaji)));
                      },
                      child: Container(
                          width: 150,
                          height: 30,
                          child: Card(
                              color: Color(0xFFCBE4DE),
                              shadowColor: Color(0xFFCBE4DE),
                              child: Center(
                                  child: Text(
                                x.radniZadatakNaziv ?? "",
                                style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold),
                              )))),
                    ),

                    Column(
                      children: items(x.radniZadatakId),
                    ),
                    //CommonWidget.dividerLista(),
                  ]),
                ),
              )),
              new CircularPercentIndicator(
                radius: 40,
                lineWidth: 13.0,
                animation: true,
                percent: progres,
                center: new Text(
                  (progres * 100).round().toString() + "%",
                  style: new TextStyle(fontWeight: FontWeight.bold, fontSize: 15.0),
                ),
                circularStrokeCap: CircularStrokeCap.round,
                progressColor: Color(0xFF0E8388),
              ),
            ]))
        .cast<Widget>()
        .toList();

    return list;
  }
}
