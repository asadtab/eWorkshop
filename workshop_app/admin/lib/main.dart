import 'package:admin/bloc/api_resources/api_resources_bloc.dart';
import 'package:admin/bloc/api_scopes/api_scopes_bloc.dart';
import 'package:admin/bloc/client_secret/client_secret_bloc.dart';
import 'package:admin/bloc/klijenti/klijenti_bloc.dart';
import 'package:admin/bloc/lokacija/lokacija_bloc.dart';
import 'package:admin/bloc/radni_zadatak_uredjaj/bloc/radni_zadatak_uredjaj_block_bloc.dart';
import 'package:admin/bloc/statistika_bloc/statistika_bloc.dart';
import 'package:admin/bloc/uloge/uloge_bloc.dart';
import 'package:admin/bloc/uredjaji/bloc/uredjaj_bloc.dart';
import 'package:admin/bloc/uredjaji_lista_zadatak.dart/bloc/uredjaji_lista_zadatak_bloc.dart';
import 'package:admin/bloc/user/bloc/korisnici_bloc.dart';
import 'package:admin/screens/login_screen.dart';
import 'package:commons/providers/client_grant_type_provider.dart';
import 'package:commons/providers/ids_provider.dart';
import 'package:commons/providers/izvrseni_servis_provider.dart';
import 'package:commons/providers/klijenti_provider.dart';
import 'package:commons/providers/komponente_provider.dart';
import 'package:commons/providers/lokacija_provider.dart';
import 'package:commons/providers/reparacija_provider.dart';
import 'package:commons/providers/client_secret_provider.dart';
import 'package:commons/providers/statistika_provider.dart';
import 'package:commons/providers/tip_uredjaja_provider.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:commons/providers/auth_provider.dart';
import 'package:commons/providers/uloge_provider.dart';
import 'package:commons/providers/api_scopes_provider.dart';
import 'package:commons/providers/api_resources_provider.dart';
import 'package:commons/providers/client_scope_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:provider/provider.dart';
import 'package:commons/providers/radniZadaci_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:commons/providers/korisnici_provider.dart';
import 'commons/navigation.dart';

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
      ChangeNotifierProvider(create: (_) => IzvrseniServisProvider()),
      ChangeNotifierProvider(create: (_) => KomponenteProvider()),
      ChangeNotifierProvider(create: (_) => AuthProvider()),
      ChangeNotifierProvider(create: (_) => IdsProvider()),
      ChangeNotifierProvider(create: (_) => KorisniciProvider()),
      ChangeNotifierProvider(create: (_) => UlogeProvider()),
      ChangeNotifierProvider(create: (_) => KlijentiProvider()),
      ChangeNotifierProvider(create: (_) => ApiScopesProvider()),
      ChangeNotifierProvider(create: (_) => ApiResourcesProvider()),
      ChangeNotifierProvider(create: (_) => ClientSecretProvider()),
      ChangeNotifierProvider(create: (_) => ClientScopeProvider()),
      ChangeNotifierProvider(create: (_) => ClientGrantTypeProvider()),
      ChangeNotifierProvider(create: (_) => StatistikaProvider()),
    ],
    child: const MyApp(),
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    RadniZadaciUredjajProvider radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();
    var uredjajProvider = context.read<UredjajProvider>();
    KorisniciProvider korisniciProvider = context.read<KorisniciProvider>();
    UlogeProvider ulogeProvider = context.read<UlogeProvider>();
    LokacijaProvider lokacijaProvider = context.read<LokacijaProvider>();
    KlijentiProvider klijentiProvider = context.read<KlijentiProvider>();
    ApiScopesProvider apiScopesProvider = context.read<ApiScopesProvider>();
    ApiResourcesProvider apiResourcesProvider = context.read<ApiResourcesProvider>();
    ClientSecretProvider clientSecretProvider = context.read<ClientSecretProvider>();
    StatistikaProvider statistikaProvider = context.read<StatistikaProvider>();

    return MultiBlocProvider(
        providers: [
          BlocProvider<UredjajBloc>(create: (context) => UredjajBloc(uredjajiProvider: uredjajProvider)..add(LoadingEvent())),
          BlocProvider<RadniZadatakUredjajBloc>(
              create: (context) => RadniZadatakUredjajBloc(radniZadaciUredjajProvider: radniZadaciUredjajProvider)..add(RadniZadatakLoadingEvent())),
          BlocProvider<UredjajiListaZadatakBloc>(
              create: (context) => UredjajiListaZadatakBloc(uredjajiProvider: uredjajProvider)..add(UredjajiLoadZadatakEvent())),
          BlocProvider<KorisniciBloc>(create: (context) => KorisniciBloc(korisniciProvider: korisniciProvider)..add(KorisniciLoad())),
          BlocProvider<UlogeBloc>(create: (context) => UlogeBloc(ulogeProvider: ulogeProvider)..add(UlogeRequest())),
          BlocProvider<LokacijaBloc>(create: (context) => LokacijaBloc(lokacijaProvider: lokacijaProvider)..add(LokacijaInitialEvent())),
          BlocProvider<KlijentiBloc>(create: (context) => KlijentiBloc(klijentiProvider: klijentiProvider)..add(KlijentiInitialDataEvent())),
          BlocProvider<ApiScopesBloc>(create: (context) => ApiScopesBloc(apiScopesProvider: apiScopesProvider)..add(ApiScopeLoadDataEvent())),
          BlocProvider<ApiResourcesBloc>(
              create: (context) => ApiResourcesBloc(apiResourcesProvider: apiResourcesProvider)..add(ApiResourcesDataLoadEvent())),
          BlocProvider<ClientSecretBloc>(
              create: (context) => ClientSecretBloc(clientSecretProvider: clientSecretProvider)..add(ClientSecretLoadDataEvent())),
          BlocProvider<StatistikaBloc>(create: (context) => StatistikaBloc(statistikaProvider: statistikaProvider)..add(StatistikaRefreshEvent())),
        ],
        child: MaterialApp(
          title: 'Flutter Demo',
          theme: ThemeData(),
          home: const MyHomePage(title: 'Flutter Demo Home Page'),
        ));
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

  bool? isLoggedIn = false;

  @override
  void initState() {
    isLoggedIn = context.read<AuthProvider>().isLoggedIn;

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
        body: !isLoggedIn!
            ? LoginMainScreen()
            : CommonNavigation(
                initialSelectedIndex: _selectedIndex,
                onItemSelected: _onItemSelected,
              ));
  }
}
