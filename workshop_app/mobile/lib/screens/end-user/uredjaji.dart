import 'package:commons/models/korisnik.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/models/user.dart';
import 'package:flutter/material.dart';

class EndUredjaji extends StatefulWidget {
  late List<Uredjaj> uredjaji;
  late Korisnik korisnik;

  EndUredjaji({required this.uredjaji, required this.korisnik});

  @override
  State<EndUredjaji> createState() => _EndUredjajiState();
}

class _EndUredjajiState extends State<EndUredjaji> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(appBar: AppBar(title: Text("Radna jedinica: ${widget.korisnik.radnaJedinica}"), backgroundColor: Color(0xFF4592AF), ), body: SafeArea(child: 
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
    return x.status == 'fix'|| x.status == 'ready' || x.status == 'out' ? Colors.lightGreenAccent : Colors.redAccent;
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