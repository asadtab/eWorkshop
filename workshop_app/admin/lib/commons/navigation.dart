import 'package:admin/screens/acc.dart';
import 'package:admin/screens/login_screen.dart';
import 'package:admin/screens/radni_zadaci.dart';
import 'package:admin/screens/radni_zadaci_lista.dart';
import 'package:admin/screens/raspored_uredjaja.dart';
import 'package:admin/screens/uredjaji.dart';
import 'package:commons/models/user.dart';
import 'package:commons/providers/auth_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../screens/administrator.dart';
import '../screens/konzola.dart';

class CommonNavigation extends StatefulWidget {
  final int initialSelectedIndex;
  final Function(int) onItemSelected;

  CommonNavigation({required this.onItemSelected, required this.initialSelectedIndex});

  @override
  _CommonNavigationState createState() => _CommonNavigationState();
}

class _CommonNavigationState extends State<CommonNavigation> {
  late int selectedIndex;

  @override
  void initState() {
    super.initState();
    selectedIndex = widget.initialSelectedIndex;
  }

  @override
  Widget build(BuildContext context) {
    return Row(
      children: <Widget>[
        NavigationRail(
          leading: Container(
            decoration: BoxDecoration(
              border: Border(
                bottom: BorderSide(
                  color: Colors.grey,
                  width: 2.0,
                ),
              ),
            ),
            child: Column(
              children: [
                PopupMenuButton(
                  itemBuilder: (BuildContext context) => <PopupMenuEntry<String>>[
                    PopupMenuItem<String>(
                      child: Text('Profil'),
                      value: 'profile',
                    ),
                    PopupMenuItem<String>(
                      child: Text('Odjava'),
                      value: 'logout',
                    ),
                  ],
                  icon: Icon(Icons.account_circle),
                  onSelected: (izbor) {
                    switch (izbor) {
                      case 'profile':
                        Navigator.push(context, MaterialPageRoute(builder: (context) => UserAccountScreen()));
                        break;
                      case 'logout':
                        logout(context);
                        break;
                      default:
                    }
                  },
                ),
                Text(User.name ?? ""),
              ],
            ),
          ),
          selectedIndex: selectedIndex,
          onDestinationSelected: (int index) {
            setState(() {
              selectedIndex = index;
            });
            widget.onItemSelected(index);
          },
          groupAlignment: -1,
          labelType: NavigationRailLabelType.all,
          destinations: <NavigationRailDestination>[
            NavigationRailDestination(
              icon: Icon(Icons.dashboard),
              label: Text('Konzola'),
            ),
            NavigationRailDestination(
              icon: Icon(Icons.developer_board),
              label: Text('Uređaji'),
            ),
            NavigationRailDestination(
              icon: Icon(Icons.task),
              label: Text('Radni zadaci'),
            ),
            NavigationRailDestination(
              icon: Icon(Icons.table_chart),
              label: Text('Raspored uređaja'),
            ),
            if (User.roles.contains("Administrator"))
              NavigationRailDestination(
                icon: Icon(Icons.settings),
                label: Text('Administrator'),
              ),
          ],
        ),
        VerticalDivider(thickness: 1, width: 1),
        Expanded(
          child: IndexedStack(
            index: selectedIndex,
            children: [KonzolaScreen(), UredjajiScreen(), RadniZadaciLista(),RasporedUredjaja(), AdministratorScreen()],
          ),
        ),
      ],
    );
  }

  void logout(BuildContext context) {
    User.name = null;
    User.email = null;
    User.token = null;

    context.read<AuthProvider>().setLoggedIn(false);

    Navigator.pushReplacement(
      context,
      MaterialPageRoute(builder: (context) => LoginMainScreen()),
    );
  }
}
