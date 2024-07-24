import 'package:admin/commons/app_bar.dart';
import 'package:admin/screens/api_resources.dart';
import 'package:admin/screens/api_scopes.dart';
import 'package:admin/screens/klijenti.dart';
import 'package:admin/screens/korisnici.dart';
import 'package:admin/screens/uloge.dart';

import 'package:flutter/material.dart';

class AdministratorScreen extends StatefulWidget {
  @override
  _AdministratorScreenState createState() => _AdministratorScreenState();
}

class _AdministratorScreenState extends State<AdministratorScreen> {
  @override
  Widget build(BuildContext context) {
    return DefaultTabController(
      length: 5,
      initialIndex: 0,
      child: Scaffold(
        appBar: BarrApp(
          naslov: 'Administrator Screen',
          bottom: TabBar(
            tabs: [
              Tab(text: 'Korisnici'),
              Tab(text: 'Uloge'),
              Tab(text: 'Klijenti'),
              Tab(text: 'Api scopes'),
              Tab(text: 'Api resursi'),
            ],
          ),
        ),
        body: TabBarView(
          children: [
            KorisniciListScreen(),
            UlogeScreen(),
            KlijentiListScreen(),
            ApiScopesScreen(),
            ApiResourcesScreen(),
          ],
        ),
      ),
    );
  }
}
