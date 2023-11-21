import 'package:flutter/material.dart';

class BarrApp extends StatelessWidget implements PreferredSizeWidget {
  BarrApp({required this.naslov});

  String naslov;

  @override
  Widget build(BuildContext context) {
    return AppBar(
        iconTheme: IconThemeData(color: Colors.black),
        title: Row(mainAxisAlignment: MainAxisAlignment.center, children: [
          Text(
            naslov,
            style: TextStyle(color: Color(0xFF071815)),
          ),
        ]),
        centerTitle: true,
        backgroundColor: Color(0xFF8dc4dd),
        elevation: 0);
  }

  @override
  Size get preferredSize => Size.fromHeight(kToolbarHeight);
}
