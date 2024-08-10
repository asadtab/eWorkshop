import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:flutter/material.dart';

class EndUredjaji extends StatefulWidget {
  late List<RadniZadatakUredjaj> uredjaji;

  EndUredjaji({required this.uredjaji});

  @override
  State<EndUredjaji> createState() => _EndUredjajiState();
}

class _EndUredjajiState extends State<EndUredjaji> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(appBar: AppBar(title: Text("Radna jedinica: Sarajevo"), backgroundColor: Color(0xFF4592AF), ), body: SafeArea(child: 
    SingleChildScrollView(
          scrollDirection: Axis.horizontal,
          child: DataTable(
            columns: const <DataColumn>[
              DataColumn(
                label: Text(
                  'Ev.Br',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
              DataColumn(
                label: Text(
                  'Tip',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
              DataColumn(
                label: Text(
                  'Naziv',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
              DataColumn(
                label: Text(
                  'Koda',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
              DataColumn(
                label: Text(
                  'Serijski broj',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ],
            rows:widget.uredjaji.map((x)
            {
              return DataRow(
              color: WidgetStateProperty.resolveWith<Color?>(
  (Set<WidgetState> states) {
    return x.uredjajStatus == 'fix'|| x.uredjajStatus == 'ready' || x.uredjajStatus == 'out' ? Colors.lightGreenAccent : Colors.redAccent;
  },
),
                cells: <DataCell>[
                  DataCell(Text(x.uredjajId.toString())),
                  DataCell(Text(x.tipNaziv ?? "")),
                  DataCell(Text(x.tipOpis ?? "")),
                  DataCell(Text(x.koda ?? "")),
                  DataCell(Text(x.serijskiBroj ??"")),
                  
                ]);
              }).toList()))));
  }
}