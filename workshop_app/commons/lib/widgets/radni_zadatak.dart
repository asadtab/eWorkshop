import 'package:commons/helpers/progres.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/models/radni_zadatak.dart';
import 'package:flutter/material.dart';
import 'package:percent_indicator/circular_percent_indicator.dart';

class RadniZadaciWidget extends StatefulWidget {
  List<RadniZadatakUredjaj> radniZadatakUredjaj = [];
  RadniZadatakUredjaj? radniZadatak;

  RadniZadaciWidget({required this.radniZadatakUredjaj, required this.radniZadatak});

  @override
  State<RadniZadaciWidget> createState() => _RadniZadaciWidgetState();
}

class _RadniZadaciWidgetState extends State<RadniZadaciWidget> {
  @override
  void initState() {
    super.initState();
  }

  //var radniZadatak = widget.radniZadatakUredjaj.first;
  List<RadniZadatakUredjaj> uredjaji = [];

  @override
  Widget build(BuildContext context) {
    return Column(children: [
      Card(
          child: Container(
        width: 150,
        height: 250,
        child: SingleChildScrollView(
          child: Column(mainAxisAlignment: MainAxisAlignment.start, children: [
            InkWell(
                onTap: () {
                  
                },
                child: Container(
                  width: 150,
                  height: 70,
                  child: Column(children: [
                    Card(
                        child: Center(
                            child: Text("ID: " + widget.radniZadatak!.radniZadatakId.toString(),
                                style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold)))),
                    Card(
                        color: Color(0xFFCBE4DE),
                        shadowColor: Color(0xFFCBE4DE),
                        child: Center(
                            child: Text(
                          widget.radniZadatak!.radniZadatakNaziv ?? "",
                          style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold, color: Colors.black),
                        )))
                  ]),
                )),
            Column(
                children: widget.radniZadatakUredjaj.map((e) {
              for (var x in widget.radniZadatakUredjaj) {
                if (x.radniZadatakId == e.radniZadatakId) {
                  uredjaji.add(e);
                }
              }
              return Container(
                  padding: EdgeInsets.fromLTRB(10, 10, 0, 0),
                  width: 150,
                  height: 30,
                  child: Text(e.uredjajId.toString() + " - " + e.tipNaziv.toString(), style: TextStyle(fontWeight: FontWeight.bold)));
            }).toList()),
          ]),
        ),
      )),
      Padding(
          padding: EdgeInsets.fromLTRB(0, 20, 0, 0),
          child: new CircularPercentIndicator(
            radius: 40,
            lineWidth: 13.0,
            animation: true,
            percent: CustomProgres.postotak(uredjaji),
            center: new Text(
              (CustomProgres.postotak(uredjaji) * 100).round().toString() + "%",
              style: new TextStyle(fontWeight: FontWeight.bold, fontSize: 15.0),
            ),
            circularStrokeCap: CircularStrokeCap.round,
            progressColor: Color(0xFF0E8388),
          ))
    ]);
  }
}
