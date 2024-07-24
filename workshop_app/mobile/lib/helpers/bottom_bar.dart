import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';

class MyBottomBar extends StatefulWidget {
  MyBottomBar({super.key}) {}

  @override
  State<MyBottomBar> createState() => _MyBottomBarState();
}

class _MyBottomBarState extends State<MyBottomBar> {
  @override
  Widget build(BuildContext context) {
    return BottomAppBar(
        shape: const CircularNotchedRectangle(),
        child: Container(
            padding: EdgeInsets.fromLTRB(20, 0, 20, 0),
            height: 50.0,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: [
                /*IconButton(
                  tooltip: 'Open navigation menu',
                  icon: const Icon(Icons.menu),
                  onPressed: () {
                    Scaffold.of(context).openDrawer();
                  },
                )*/
                const Spacer(),
                // IconButton(
                //   tooltip: 'Open navigation menu',
                //   icon: const Icon(Icons.arrow_back),
                //   onPressed: () {
                //     Navigator.pop(context);
                //   },
                // ),
              ],
            )));
  }
}
