import 'package:darq/darq.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/helpers/common_widget.dart';
import 'package:workshop_app/model/izvrseni_servis.dart';
import 'package:workshop_app/model/radni_zadatak.dart';
import 'package:workshop_app/providers/izvrseni_servis_provider.dart';
import 'package:workshop_app/providers/komponente_provider.dart';
import 'package:workshop_app/providers/komponente_recommended_provider.dart';
import 'package:workshop_app/providers/lokacija_provider.dart';
import 'package:workshop_app/providers/radniZadaci_provider.dart';
import 'package:workshop_app/providers/radniZadaci_uredjaj_provider.dart';
import 'package:workshop_app/providers/tip_uredjaja_provider.dart';
import 'package:workshop_app/providers/uredjaji_provider.dart';
import 'package:workshop_app/screens/home_screen.dart';
import 'package:workshop_app/screens/servis/servisiraj.dart';
import 'package:workshop_app/screens/uredjaji/dodaj_uredi_uredjaj.dart';
import 'package:workshop_app/screens/uredjaji/lista_uredjaja.dart';
import 'package:percent_indicator/percent_indicator.dart';

import 'helpers/master_screen.dart';
import 'model/radni_zadatak_uredjaj.dart';
import 'providers/reparacija_provider.dart';
import 'screens/radni_zadaci/radni_zadatak_detalji.dart';
import 'screens/uredjaji/uredjaj_detalji.dart';

/*void main() {
  runApp(const MyApp());
}*/

void main() => runApp(MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => UredjajiProvider()),
        ChangeNotifierProvider(create: (_) => RadniZadaciProvider()),
        ChangeNotifierProvider(create: (_) => RadniZadaciUredjajProvider()),
        ChangeNotifierProvider(create: (_) => ReparacijaProvider()),
        ChangeNotifierProvider(create: (_) => IzvrseniServisProvider()),
        ChangeNotifierProvider(create: (_) => KomponenteRecommendedProvider()),
        ChangeNotifierProvider(create: (_) => KomponenteProvider()),
        ChangeNotifierProvider(create: (_) => TipUredjajaProvider()),
        ChangeNotifierProvider(create: (_) => LokacijaProvider())
      ],
      child: const MyApp(),
    ));

class MyApp extends StatelessWidget {
  static const routeName = "/home";
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
          brightness: Brightness.light,
          primarySwatch: Colors.blueGrey,
          elevatedButtonTheme: ElevatedButtonThemeData(
              style: ButtonStyle(
            backgroundColor: MaterialStatePropertyAll<Color>(Color(0xFF4592AF)),
          )),
          floatingActionButtonTheme: FloatingActionButtonThemeData(
              backgroundColor: Color(0xFF0E8388))),
      home: const MyHomePage(title: 'Flutter Demo Home Page'),
      onGenerateRoute: (settings) {
        if (settings.name == UredjajiListScreen.routeName) {
          return MaterialPageRoute(
              builder: ((context) => UredjajiListScreen()));
        }
        if (settings.name == RadniZadatakDetaljiScreen.routeName) {
          return MaterialPageRoute(
              builder: ((context) => RadniZadatakDetaljiScreen()));
        }
        if (settings.name == UredjajDetaljiScreen.routeName) {
          return MaterialPageRoute(
              builder: ((context) => UredjajDetaljiScreen()));
        }
        if (settings.name == ServisirajScreen.routeName) {
          return MaterialPageRoute(builder: ((context) => ServisirajScreen()));
        }
        if (settings.name == DodajUrediUredjajScreen.routeName) {
          return MaterialPageRoute(
              builder: ((context) => DodajUrediUredjajScreen()));
        }
        if (settings.name == MyApp.routeName) {
          return MaterialPageRoute(builder: ((context) => MyApp()));
        }
        if (settings.name == HomeScreen.routeName) {
          return MaterialPageRoute(builder: ((context) => HomeScreen()));
        }
      },
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key, required this.title});
  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  RadniZadaciProvider? radniZadaciProvider = null;
  RadniZadaciUredjajProvider? radniZadaciUredjajProvider = null;
  List<RadniZadatakUredjaj> radniZadatakUredjajData = [];
  List<RadniZadatak> data = [];
  bool _isLoading = true;

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
    var items = await radniZadaciUredjajProvider
        ?.get({'search': 'active'}, "RadniZadatakUredjaj/Flutter");

    setState(() {
      radniZadatakUredjajData = items!;
      _isLoading = false;
    });
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
            : GridView(
                gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                    crossAxisCount: 1,
                    childAspectRatio: 5,
                    mainAxisSpacing: 10),
                scrollDirection: Axis.horizontal,
                children: zadatak(context, radniZadatakUredjajData)));
  }

  List<RadniZadatakUredjaj> getUredjaj(int id) {
    return radniZadatakUredjajData
        .where((x) => x.radniZadatakId == id)
        .toList();
  }

  List<Widget> items(int id) {
    if (radniZadatakUredjajData.length == 0) {
      return [CircularProgressIndicator()];
    }

    List<Widget> list = getUredjaj(id)
        .map((x) => Container(
            padding: EdgeInsets.fromLTRB(10, 10, 0, 0),
            width: 150,
            height: 30,
            child: Text(x.uredjajId.toString() + " - " + x.tipNaziv.toString(),
                style: TextStyle(fontWeight: FontWeight.bold))))
        .cast<Widget>()
        .toList();

    return list;
  }

  List<Widget> zadatak(BuildContext context, List<RadniZadatakUredjaj> data) {
    if (radniZadatakUredjajData.length == 0) {
      return [CircularProgressIndicator()];
    }

    var distinct =
        radniZadatakUredjajData.distinct((x) => [x.radniZadatakNaziv]);

    List<Widget> list = distinct
        .map((x) => Column(children: [
              Card(
                child: Container(
                  width: 150,
                  height: 250,
                  child: Column(
                      mainAxisAlignment: MainAxisAlignment.start,
                      children: [
                        InkWell(
                          onTap: () {
                            var uredjaji = getUredjaj(x.radniZadatakId);

                            MaterialPageRoute(
                                builder: (context) =>
                                    RadniZadatakDetaljiScreen.zadaci(uredjaji));

                            Navigator.push(
                                context,
                                MaterialPageRoute(
                                    builder: (context) =>
                                        RadniZadatakDetaljiScreen.zadaci(
                                            uredjaji)));
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
                                    style: TextStyle(
                                        fontSize: 15,
                                        fontWeight: FontWeight.bold),
                                  )))),
                        ),
                        Column(
                          children: items(x.radniZadatakId),
                        ),
                        CommonWidget.dividerLista(),
                      ]),
                ),
              ),
              new CircularPercentIndicator(
                radius: 40,
                lineWidth: 13.0,
                animation: true,
                percent: 0.7,
                center: new Text(
                  "70.0%",
                  style: new TextStyle(
                      fontWeight: FontWeight.bold, fontSize: 15.0),
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
