import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:percent_indicator/circular_percent_indicator.dart';

import '../helpers/common_widget.dart';
import '../model/radni_zadatak.dart';
import '../model/radni_zadatak_uredjaj.dart';
import '../screens/radni_zadaci/radni_zadatak_detalji.dart';

class Box {
  static List<Widget> BoxPodaci(BuildContext context, List<dynamic> data) {
    if (data.length == 0) {
      return [Text("Podaci ne postoje")];
    }

    //postotak(id);

    /*    List<Widget> list = getUredjaj(id)
          .map((x) => Container(
              padding: EdgeInsets.fromLTRB(10, 10, 0, 0),
              width: 150,
              height: 30,
              child: Text(x.uredjajId.toString() + " - " + x.tipNaziv.toString(), style: TextStyle(fontWeight: FontWeight.bold))))
          .cast<Widget>()
          .toList();

      return list;
    }*/

    List<Widget> list = data
        .map((x) => Column(children: [
              Card(
                  child: Container(
                width: 150,
                height: 250,
                child: SingleChildScrollView(
                  child: Column(mainAxisAlignment: MainAxisAlignment.start, children: [
                    InkWell(
                        onTap: () {},
                        child: Container(
                          width: 150,
                          height: 50,
                          child: Column(children: [
                            Card(child: Center(child: Text("ID: " + x.naziv, style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold)))),
                            Card(
                                color: Color(0xFFCBE4DE),
                                shadowColor: Color(0xFFCBE4DE),
                                child: Center(
                                    child: Text(
                                  x.naziv!,
                                  style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold),
                                )))
                          ]),
                        )),
                    Column(),
                  ]),
                ),
              )),
            ]))
        .cast<Widget>()
        .toList();

    return list;
  }
}
