import 'package:commons/models/user.dart';
import 'package:commons/providers/auth_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/screens/end-user/home_screen.dart';
import 'package:workshop_app/screens/komponente/komponente_list.dart';
import 'package:workshop_app/screens/login_screen.dart';
import 'package:workshop_app/screens/user_screen.dart';

import '../screens/home_screen.dart';
import '../screens/radni_zadaci/lista_zadataka.dart';
import '../screens/uredjaji/lista_uredjaja.dart';
import 'common_widget.dart';

class DrawerWidget extends StatelessWidget {
  final String? userName;
  final String? userEmail;

  const DrawerWidget({
    Key? key,
    this.userName,
    this.userEmail,
  }) : super(key: key);

    void logout(BuildContext context) {
    User.name = null;
    User.email = null;
    User.token = null;

    context.read<AuthProvider>().setLoggedIn(false);

    Navigator.push(context, MaterialPageRoute(builder: (context) => LoginForm()));
    
  }

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(
        padding: EdgeInsets.zero,
        children: [
          DrawerHeader(
            decoration: BoxDecoration(
              color: Colors.blue,
            ),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Text(
                  'Menu',
                  style: TextStyle(
                    color: Colors.white,
                    fontSize: 24,
                  ),
                ),
                SizedBox(height: 8),
                Text(
                  'Logged in as:',
                  style: TextStyle(
                    color: Colors.white,
                    fontSize: 16,
                  ),
                ),
                SizedBox(height: 4),
                Row(
                  children: [
                    Column(children: [
                      Text(
                        User.name ?? "",
                        style: TextStyle(
                          color: Colors.white,
                          fontSize: 20,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      Text(
                        User.email ?? "",
                        style: TextStyle(
                          color: Colors.white,
                          fontSize: 16,
                        ),
                      ),
                    ]),
                    IconButton(
                        onPressed: () {
                          Navigator.push(context, MaterialPageRoute(builder: (context) => UserScreen()));
                        },
                        icon: Icon(Icons.account_box, color: Colors.white))
                  ],
                )
              ],
            ),
          ),
          ListTile(
            title: Text(
              'Uređaji',
              style: TextStyle(fontSize: 20),
            ),
            onTap: () {
              Navigator.pushNamed(context, UredjajiListScreen.routeName);
            },
          ),
          CommonWidget.divider(),
          ListTile(
            title: Text(
              'Radni zadaci',
              style: TextStyle(fontSize: 20),
            ),
            onTap: () {
              Navigator.pushNamed(context, ListaZadataka.routeName);
            },
          ),
          CommonWidget.divider(),
          ListTile(
            title: Text(
              'Komponente',
              style: TextStyle(fontSize: 20),
            ),
            onTap: () {
              Navigator.push(context, MaterialPageRoute(builder: (context) => KomponenteList()));
            },
          ),
          CommonWidget.divider(),
          ListTile(
            title: Text(
              'Početna',
              style: TextStyle(fontSize: 20),
            ),
            onTap: () {
              Navigator.pushNamed(context, HomeScreen.routeName);
            },
          ),
          CommonWidget.divider(),
          
          ListTile(
            title: Text(
              'Logout',
              style: TextStyle(fontSize: 20),
            ),
            onTap: () {
              logout(context);

            },
          ),
          ListTile(
            title: Text(
              'EndHomeScreen',
              style: TextStyle(fontSize: 20),
            ),
            onTap: () {
              Navigator.push(context, MaterialPageRoute(builder: (context) => EndHomeScreen()));

            },
          )
        ],
      ),
    );
  }
}
