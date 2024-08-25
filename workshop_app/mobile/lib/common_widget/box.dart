import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class Box {
  static List<Widget> BoxPodaci(BuildContext context, List<dynamic> data) {
    if (data.length == 0) {
      return [Text("Podaci ne postoje")];
    }
    
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
