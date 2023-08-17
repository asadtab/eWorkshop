import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:workshop_app/helpers/master_screen.dart';

import '../../helpers/bottom_bar.dart';

class Premjesti extends StatefulWidget {
  static const String routeName = "/premjesti";
  const Premjesti({super.key});

  @override
  State<Premjesti> createState() => _PremjestiState();
}

class _PremjestiState extends State<Premjesti> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: DrawerWidget(),
      appBar: AppBar(title: (Text("Raspored relejnih uređaja"))),
      bottomNavigationBar: MyBottomBar(),
      floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
      floatingActionButton: FloatingActionButton(onPressed: () async {}, child: Icon(Icons.check)),
    );
  }
}
