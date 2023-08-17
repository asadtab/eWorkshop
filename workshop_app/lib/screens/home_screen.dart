import 'package:darq/darq.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:percent_indicator/circular_percent_indicator.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/screens/radni_zadaci/radni_zadatak_detalji.dart';

import '../common_widget/radni_zadaci.dart';
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
  List<RadniZadatak> radniZadatak = [];
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

    var responseZadaci = await radniZadaciProvider?.get({'StateMachine': 'active'}, "RadniZadatak");
    var items = await radniZadaciUredjajProvider?.get({'StateMachine': 'active'}, "RadniZadatakUredjaj/Flutter");

    setState(() {
      radniZadatak = responseZadaci!;
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
                            children: RadniZadatakCommon.zadatak(context, radniZadatakUredjajData, radniZadatak)))),
                SizedBox(
                  height: 150,
                  child: Text("Asad"),
                )
              ])));
  }
}
