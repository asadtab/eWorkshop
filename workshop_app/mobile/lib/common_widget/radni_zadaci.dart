import 'package:commons/models/radni_zadatak.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:percent_indicator/circular_percent_indicator.dart';

import '../screens/radni_zadaci/radni_zadatak_detalji.dart';

class RadniZadatakCommon {
  static List<Widget> zadatak(BuildContext context, List<RadniZadatakUredjaj> data, List<RadniZadatak> zadatak) {
    if (zadatak.length == 0) {
      return [Text("Radni zadaci ne postoje")];
    }

    double progres = 0;

    List<RadniZadatakUredjaj> getUredjaj(int id) {
      return data.where((x) => x.radniZadatakId == id).toList();
    }

    double postotak(int id) {
      var uredjaji = getUredjaj(id);
      int brojac = 0;

      for (var i = 0; i < uredjaji.length; i++) {
        if (uredjaji[i].uredjajStatus == "fix" || uredjaji[i].uredjajStatus == "ready" || uredjaji[i].uredjajStatus == "out") {
          brojac++;
        }

        progres = brojac / uredjaji.length;
      }

      return progres;
    }

    List<Widget> items(int id) {
      if (data.length == 0) {
        return [Text("Uređaji ne postoje!")];
      }
      //postotak(id);

      List<Widget> list = getUredjaj(id)
          .map((x) => Container(
              padding: EdgeInsets.fromLTRB(10, 10, 0, 0),
              width: 150,
              height: 30,
              child: Text(x.uredjajId.toString() + " - " + x.tipNaziv.toString(), style: TextStyle(fontWeight: FontWeight.bold))))
          .cast<Widget>()
          .toList();

      return list;
    }

    List<Widget> list = zadatak
        .map((x) => Column(children: [
              Card(
                  child: Container(
                width: 150,
                height: 250,
                child: SingleChildScrollView(
                  child: Column(mainAxisAlignment: MainAxisAlignment.start, children: [
                    InkWell(
                        onTap: () {
                          var uredjaji = data.where((y) => y.radniZadatakId == x.radniZadatakId).toList();

                          MaterialPageRoute(builder: (context) => RadniZadatakDetaljiScreen.zadaciUredjaji(uredjaji, x.radniZadatakId));

                          Navigator.push(
                              context, MaterialPageRoute(builder: (context) => RadniZadatakDetaljiScreen.zadaciUredjaji(uredjaji, x.radniZadatakId)));
                        },
                        child: Container(
                          width: 150,
                          height: 50,
                          child: Column(children: [
                            Card(
                                child: Center(
                                    child: Text("ID: " + x.radniZadatakId.toString(), style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold)))),
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
                    Column(
                      children: items(x.radniZadatakId),
                    ),
                  ]),
                ),
              )),
              Padding(
                  padding: EdgeInsets.fromLTRB(0, 20, 0, 0),
                  child: new CircularPercentIndicator(
                    radius: 40,
                    lineWidth: 13.0,
                    animation: true,
                    percent: postotak(x.radniZadatakId),
                    center: new Text(
                      (progres * 100).round().toString() + "%",
                      style: new TextStyle(fontWeight: FontWeight.bold, fontSize: 15.0),
                    ),
                    circularStrokeCap: CircularStrokeCap.round,
                    progressColor: Color(0xFF0E8388),
                  ))
            ]))
        .cast<Widget>()
        .toList();

    return list;
  }
}
