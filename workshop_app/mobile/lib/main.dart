import 'package:commons/models/radni_zadatak.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/models/user.dart';
import 'package:commons/providers/auth_provider.dart';
import 'package:commons/providers/statistika_provider.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/helpers/common_widget.dart';
import 'package:commons/providers/izvrseni_servis_provider.dart';
import 'package:commons/providers/komponente_provider.dart';
import 'package:commons/providers/lokacija_provider.dart';
import 'package:commons/providers/radniZadaci_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';

import 'package:commons/providers/tip_uredjaja_provider.dart';
import 'package:workshop_app/screens/home_screen.dart';
import 'package:workshop_app/screens/login_screen.dart';
import 'package:workshop_app/screens/radni_zadaci/dodaj_uredi_zadatak.dart';
import 'package:workshop_app/screens/radni_zadaci/lista_zadataka.dart';
import 'package:workshop_app/screens/servis/servisiraj.dart';
import 'package:workshop_app/screens/uredjaji/dodaj_uredi_uredjaj.dart';
import 'package:workshop_app/screens/uredjaji/lista_uredjaja.dart';
import 'package:commons/providers/reparacija_provider.dart';
import 'screens/radni_zadaci/radni_zadatak_detalji.dart';
import 'screens/uredjaji/uredjaj_detalji.dart';

/*void main() {
  runApp(const MyApp());
}*/

void main() => runApp(MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => UredjajProvider()),
        ChangeNotifierProvider(create: (_) => RadniZadaciProvider()),
        ChangeNotifierProvider(create: (_) => RadniZadaciUredjajProvider()),
        ChangeNotifierProvider(create: (_) => ReparacijaProvider()),
        ChangeNotifierProvider(create: (_) => IzvrseniServisProvider()),
        ChangeNotifierProvider(create: (_) => KomponenteProvider()),
        ChangeNotifierProvider(create: (_) => TipUredjajaProvider()),
        ChangeNotifierProvider(create: (_) => LokacijaProvider()),
        //ChangeNotifierProvider(create: (_) => StaniceUredjajProvider()),
        //ChangeNotifierProvider(create: (_) => StaniceProvider()),
        ChangeNotifierProvider(create: (_) => AuthProvider()),
        ChangeNotifierProvider(create: (_) => StatistikaProvider())
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
          floatingActionButtonTheme: FloatingActionButtonThemeData(backgroundColor: Color(0xFF0E8388))),
      home: const MyHomePage(title: 'Flutter Demo Home Page'),
      onGenerateRoute: (settings) {
        if (settings.name == UredjajiListScreen.routeName) {
          return MaterialPageRoute(builder: ((context) => UredjajiListScreen()));
        }
        if (settings.name == RadniZadatakDetaljiScreen.routeName) {
          return MaterialPageRoute(builder: ((context) => RadniZadatakDetaljiScreen()));
        }
        if (settings.name == UredjajDetaljiScreen.routeName) {
          return MaterialPageRoute(builder: ((context) => UredjajDetaljiScreen()));
        }
        if (settings.name == ServisirajScreen.routeName) {
          return MaterialPageRoute(builder: ((context) => ServisirajScreen()));
        }
        if (settings.name == DodajUrediUredjajScreen.routeName) {
          return MaterialPageRoute(builder: ((context) => DodajUrediUredjajScreen()));
        }
        if (settings.name == MyApp.routeName) {
          return MaterialPageRoute(builder: ((context) => MyApp()));
        }
        if (settings.name == HomeScreen.routeName) {
          return MaterialPageRoute(builder: ((context) => HomeScreen()));
        }
        if (settings.name == ListaZadataka.routeName) {
          return MaterialPageRoute(builder: ((context) => ListaZadataka()));
        }
        if (settings.name == RadniZadatakDodajUredi.routeName) {
          return MaterialPageRoute(builder: ((context) => RadniZadatakDodajUredi()));
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
  bool? isLoggedIn = false;

  @override
  void initState() {
    super.initState();

    isLoggedIn = context.read<AuthProvider>().isLoggedIn;
    radniZadaciProvider = context.read<RadniZadaciProvider>();
    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();

    print("called initState");
    //_fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    //var response = await radniZadaciProvider?.get({'UredjajState': 'active'});

    try {
      var items = await radniZadaciUredjajProvider?.get({'search': 'active'}, "RadniZadatakUredjaj/Flutter");

      setState(() {
        radniZadatakUredjajData = items!;
      });
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
    }
  }

  @override
  Widget build(BuildContext context) {
    return WillPopScope(
        onWillPop: () async {
          if (User.id != null) {
            Navigator.push(context, MaterialPageRoute(builder: (context) => HomeScreen()));
            return false;
          }
          return true;
        },
        child: Scaffold(
            //drawer: DrawerWidget(),
            appBar: AppBar(
              title: Text(
                "SS&TK",
                style: TextStyle(fontWeight: FontWeight.bold),
              ),
            ),
            body: Center(
                child: FractionallySizedBox(
                    widthFactor: 0.8,
                    child: Align(
                      alignment: Alignment.center,
                      child: Padding(
                        padding: EdgeInsets.all(16.0),
                        child: !isLoggedIn! ? LoginForm() : HomeScreen(),
                      ),
                    )))));
  }
}
