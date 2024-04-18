import 'package:commons/models/komponenta.dart';
import 'package:commons/providers/komponente_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/helpers/bottom_bar.dart';
import 'package:workshop_app/helpers/common_widget.dart';
import 'package:workshop_app/helpers/master_screen.dart';
import 'package:workshop_app/screens/komponente/dodaj_komponentu.dart';

class KomponenteList extends StatefulWidget {
  const KomponenteList({Key? key}) : super(key: key);

  @override
  _KomponenteListState createState() => _KomponenteListState();
}

class _KomponenteListState extends State<KomponenteList> {
  late KomponenteProvider komponenteProvider;
  List<Komponenta> komponente = [];

  @override
  void initState() {
    super.initState();

    komponenteProvider = context.read<KomponenteProvider>();

    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    try {
      final response = await komponenteProvider.get(map, "Komponente");

      setState(() {
        komponente = response;
      });
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: DrawerWidget(),
      appBar: AppBar(
        title: Text("Komponente"),
      ),
      bottomNavigationBar: MyBottomBar(),
      floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          Navigator.push(context, MaterialPageRoute(builder: (context) => DodajKomponentu()));
        },
        child: Icon(Icons.add),
      ),
      body: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        child: DataTable(
          showCheckboxColumn: false,
          columns: [
            DataColumn(label: Text('R. Br.')),
            DataColumn(label: Text('Naziv')),
            DataColumn(label: Text('Tip')),
            DataColumn(label: Text('Vrijednost')),
          ],
          rows: komponente
              .map((item) => DataRow(
                    cells: [
                      DataCell(Text(item.komponentaId.toString())),
                      DataCell(Text(item.naziv ?? '')),
                      DataCell(Text(item.tip ?? '')),
                      DataCell(Text(item.vrijednost ?? '')),
                    ],
                    onSelectChanged: (isSelected) {
                      if (isSelected != null && isSelected) {
                        Navigator.push(
                            context,
                            MaterialPageRoute(
                                builder: (context) => DodajKomponentu(
                                      urediKomponentu: item,
                                    )));
                      }
                    },
                  ))
              .toList(),
        ),
      ),
    );
  }
}
