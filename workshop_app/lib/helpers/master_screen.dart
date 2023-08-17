import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

import '../screens/end-user/raspored.dart';
import '../screens/home_screen.dart';
import '../screens/radni_zadaci/lista_zadataka.dart';
import '../screens/uredjaji/lista_uredjaja.dart';
import 'common_widget.dart';

class DrawerWidget extends StatefulWidget {
  Widget? child;
  DrawerWidget({this.child, Key? key}) : super(key: key);

  @override
  State<DrawerWidget> createState() => _DrawerWidgetState();
}

class _DrawerWidgetState extends State<DrawerWidget> {
  @override
  Widget build(BuildContext context) {
    return Drawer(
        child: ListView(
      padding: EdgeInsets.zero,
      children: [
        const DrawerHeader(child: Text("")),
        ListTile(
          title: const Text(
            "Uređaji",
            style: TextStyle(fontSize: 20),
          ),
          onTap: () {
            Navigator.pushNamed(context, UredjajiListScreen.routeName);
          },
        ),
        CommonWidget.divider(),
        ListTile(
          title: const Text("Radni zadaci", style: TextStyle(fontSize: 20)),
          onTap: () {
            Navigator.pushNamed(context, ListaZadataka.routeName);
          },
        ),
        CommonWidget.divider(),
        ListTile(
          title: const Text("Komponente", style: TextStyle(fontSize: 20)),
          onTap: () {
            Navigator.pushNamed(context, UredjajiListScreen.routeName);
          },
        ),
        CommonWidget.divider(),
        ListTile(
          title: const Text("Moj račun", style: TextStyle(fontSize: 20)),
          onTap: () {
            Navigator.pushNamed(context, UredjajiListScreen.routeName);
          },
        ),
        CommonWidget.divider(),
        ListTile(
          title: const Text("Home", style: TextStyle(fontSize: 20)),
          onTap: () {
            Navigator.pushNamed(context, HomeScreen.routeName);
          },
        ),
        CommonWidget.divider(),
        ListTile(
          title: const Text("Raspored", style: TextStyle(fontSize: 20)),
          onTap: () {
            Navigator.pushNamed(context, Raspored.routeName);
          },
        )
      ],
    ));
  }
}
