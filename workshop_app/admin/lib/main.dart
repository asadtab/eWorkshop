import 'package:commons/providers/izvrseni_servis_provider.dart';
import 'package:commons/providers/lokacija_provider.dart';
import 'package:commons/providers/reparacija_provider.dart';
import 'package:commons/providers/tip_uredjaja_provider.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:commons/providers/radniZadaci_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'commons/navigation.dart';

/*void main() {
  runApp(const MyApp());
}*/

void main() {
  // Set the maximum size
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (_) => RadniZadaciProvider()),
      ChangeNotifierProvider(create: (_) => RadniZadaciUredjajProvider()),
      ChangeNotifierProvider(create: (_) => UredjajProvider()),
      ChangeNotifierProvider(create: (_) => ReparacijaProvider()),
      ChangeNotifierProvider(create: (_) => IzvrseniServisProvider()),
      ChangeNotifierProvider(create: (_) => LokacijaProvider()),
      ChangeNotifierProvider(create: (_) => TipUredjajaProvider()),
    ],
    child: const MyApp(),
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(),
      home: const MyHomePage(title: 'Flutter Demo Home Page'),
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
  int _selectedIndex = 0;

  @override
  void initState() {
    super.initState();
  }

  void _onItemSelected(int index) {
    setState(() {
      _selectedIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: CommonNavigation(
      selectedIndex: _selectedIndex,
      onItemSelected: _onItemSelected,
    ));
  }
}
