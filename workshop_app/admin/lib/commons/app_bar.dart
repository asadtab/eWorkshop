import 'package:flutter/material.dart';

class BarrApp extends StatelessWidget implements PreferredSizeWidget {
  BarrApp({this.naslov, this.bottom});

  PreferredSizeWidget? bottom;
  String? naslov;

  @override
  Widget build(BuildContext context) {
    return AppBar(
        bottom: bottom,
        iconTheme: IconThemeData(color: Colors.black),
        title: Column(
          children: [
            Row(mainAxisAlignment: MainAxisAlignment.center, children: [
              Text(
                naslov ?? "",
                style: TextStyle(color: Colors.black),
              ),
            ]),
            if (bottom != null) SizedBox(height: 50)
          ],
        ),
        centerTitle: true,
        backgroundColor: Color(0xFF80abbc),
        elevation: 0);
  }

  @override
  Size get preferredSize => Size.fromHeight(kToolbarHeight);
}
