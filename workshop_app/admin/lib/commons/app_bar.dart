import 'package:flutter/material.dart';

class BarrApp extends StatelessWidget implements PreferredSizeWidget {
  BarrApp({required this.naslov});

  String naslov;

  @override
  Widget build(BuildContext context) {
    return AppBar(
        title: Row(mainAxisAlignment: MainAxisAlignment.center, children: [
          Text(
            naslov,
            style: TextStyle(color: Colors.black),
          ),
        ]),
        centerTitle: true,
        backgroundColor: Colors.transparent,
        elevation: 0);
  }

  @override
  Size get preferredSize => Size.fromHeight(kToolbarHeight);
}
