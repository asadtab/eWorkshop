import 'package:commons/providers/radniZadaci_provider.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../../helpers/bottom_bar.dart';
import '../../helpers/common_widget.dart';
import '../../helpers/master_screen.dart';

class RadniZadatakDodajUredi extends StatefulWidget {
  static const String routeName = "/dodajRadniZadatak";
  const RadniZadatakDodajUredi({super.key});

  @override
  State<RadniZadatakDodajUredi> createState() => _RadniZadatakDodajUrediState();
}

class _RadniZadatakDodajUrediState extends State<RadniZadatakDodajUredi> {
  final nazivTextController = TextEditingController();

  final _formKey = GlobalKey<FormState>();

  RadniZadaciProvider? radniZadaciProvider = null;

  @override
  void initState() {
    super.initState();

    radniZadaciProvider = context.read<RadniZadaciProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        drawer: DrawerWidget(),
        appBar: AppBar(title: (Text("Novi radni zadatak"))),
        bottomNavigationBar: MyBottomBar(),
        floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
        floatingActionButton: FloatingActionButton(
            onPressed: () async {
              if (!_formKey.currentState!.validate()) {
                ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Popunite obavezna polja!"));
              } else {
                var request = {'naziv': nazivTextController.text, 'datum': DateTime.now().toIso8601String()};

                await radniZadaciProvider!.insert(request, "RadniZadatak");

                ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Uspješno!"));
                nazivTextController.clear();
              }
            },
            child: Icon(Icons.done)),
        body: Center(
            child: Padding(
                padding: EdgeInsets.fromLTRB(20, 0, 20, 0),
                child: Form(
                    key: _formKey,
                    child: TextFormField(
                      controller: nazivTextController,
                      decoration: InputDecoration(
                        labelText: 'Naziv radnog zadatka',
                      ),
                      //initialValue: _koda,
                      validator: (value) {
                        if (value == null || value.isEmpty) {
                          return 'Unesite naziv radnog zadatka';
                        }
                        return null;
                      },
                      onSaved: (value) {},
                    )))));
  }
}
