import 'package:admin/bloc/uredjaji/bloc/uredjaj_bloc.dart';
import 'package:admin/commons/app_bar.dart';
import 'package:admin/screens/dodaj_uredi_uredjaj.dart';
import 'package:admin/screens/uredjaj_detalji.dart';
import 'package:commons/helpers/state_helper.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import "package:commons/providers/uredjaj_provider.dart";
import 'package:commons/widgets/button.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:provider/provider.dart';

class UredjajiScreen extends StatefulWidget {
  const UredjajiScreen({super.key});
  @override
  State<UredjajiScreen> createState() => _UredjajiScreenState();
}

class _UredjajiScreenState extends State<UredjajiScreen> {
  UredjajProvider? _uredjajiProvider = null;
  //List<Uredjaj> uredjajiData = [];

  String selected = "";
  List<Uredjaj> uredjajRadniZadatak = [];
  String dropdownvalue = "Aktivni";
  int radniZadatakId = 0;

  bool addZadatakActive = false;
  RadniZadaciUredjajProvider? radniZadaciUredjajProvider = null;

  TextEditingController idController = TextEditingController();
  TextEditingController tipController = TextEditingController();
  TextEditingController nazivController = TextEditingController();
  TextEditingController opisController = TextEditingController();
  TextEditingController kodaController = TextEditingController();

  @override
  void initState() {
    super.initState();

    _uredjajiProvider = context.read<UredjajProvider>();
  }

  @override
  Widget build(BuildContext context) {
    final UredjajBloc uredjajBloc = BlocProvider.of<UredjajBloc>(context);

    return BlocProvider(
      create: (context) => UredjajBloc(uredjajiProvider: _uredjajiProvider!),
      child: Scaffold(
          appBar: BarrApp(naslov: "Uređaji"),
          body: SingleChildScrollView(
              child: Column(crossAxisAlignment: CrossAxisAlignment.center, children: [
            Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
              Padding(
                  padding: EdgeInsets.all(20),
                  child: DropdownButton<String>(
                    value: dropdownvalue,
                    icon: const Icon(Icons.arrow_downward),
                    elevation: 16,
                    hint: Container(child: Text("Odaberi status")),
                    style: const TextStyle(color: Colors.deepPurple),
                    underline: Container(
                      height: 2,
                      color: Colors.blueGrey,
                    ),
                    onChanged: (String? value) {
                      uredjajBloc.add(UredjajFilterEvent(status: StateHelper.nizSearch(value!)));

                      setState(() {
                        dropdownvalue = value;
                      });
                    },
                    items: StateHelper.nizOpis.map<DropdownMenuItem<String>>((String value) {
                      return DropdownMenuItem<String>(
                        value: value,
                        child: Text(value),
                      );
                    }).toList(),
                  )),
              Padding(
                  padding: EdgeInsets.all(20),
                  child: MinimalisticButton(
                    icons: Icon(Icons.add),
                    text: "Dodaj novi uređaj",
                    onPressed: () {
                      showDialog(
                        context: context,
                        builder: (BuildContext context) => DodajUrediUredjaj(),
                      ); /*.then((value) {
                                          korisniciBloc.add(KorisniciLoad());
                                        });*/

                      //Navigator.push(context, MaterialPageRoute(builder: (context) => DodajUrediUredjaj()));
                    },
                  ))
            ]),
            Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
              Container(
                  height: 40,
                  width: 200,
                  child: TextField(
                      controller: idController,
                      decoration: InputDecoration(
                        labelText: 'Id', // Placeholder text
                        border: OutlineInputBorder(), // Border for the input field
                      ),
                      onChanged: (text) {
                        // Handle text input changes here
                      })),
              Container(
                  height: 40,
                  width: 200,
                  child: TextField(
                      controller: nazivController,
                      decoration: InputDecoration(
                        labelText: 'Tip', // Placeholder text
                        border: OutlineInputBorder(), // Border for the input field
                      ),
                      onChanged: (text) {
                        // Handle text input changes here
                      })),
              Container(
                  height: 40,
                  width: 200,
                  child: TextField(
                      controller: opisController,
                      decoration: InputDecoration(
                        labelText: 'Naziv', // Placeholder text
                        border: OutlineInputBorder(), // Border for the input field
                      ),
                      onChanged: (text) {
                        // Handle text input changes here
                      })),
              Container(
                  height: 40,
                  width: 200,
                  child: TextField(
                      controller: kodaController,
                      decoration: InputDecoration(
                        labelText: 'Koda', // Placeholder text
                        border: OutlineInputBorder(), // Border for the input field
                      ),
                      onChanged: (text) {
                        // Handle text input changes here
                      })),
              MinimalisticButton(
                  text: "Pretraga",
                  onPressed: () {
                    uredjajBloc.add(UredjajFilterEvent(
                        status: StateHelper.nizSearch(dropdownvalue),
                        id: idController.text.isEmpty ? null : int.parse(idController.text),
                        tip: tipController.text,
                        naziv: nazivController.text,
                        koda: kodaController.text,
                        opis: opisController.text));
                  })
            ]),
            BlocConsumer<UredjajBloc, UredjajState>(
              bloc: uredjajBloc,
              listener: (context, state) {
                // TODO: implement listener
              },
              builder: (context, state) {
                if (state is UredjajLoadingState) {
                  return Center(
                    child: CircularProgressIndicator(),
                  );
                } else if (state is UredjajDataLoadedState) {
                  var uredjajiData = state.data;

                  return Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      DataTable(
                          showCheckboxColumn: false,
                          columnSpacing: 21,
                          columns: [
                            DataColumn(label: Text('Id')),
                            DataColumn(label: Text('Tip')),
                            DataColumn(label: Text('Naziv')),
                            DataColumn(label: Text('Koda')),
                            DataColumn(label: Text('Serijski broj')),
                            DataColumn(label: Text('Stanje')),
                            DataColumn(label: Text('Lokacija')),
                            DataColumn(label: Text('Opcije')),
                          ],
                          rows: uredjajiData
                              .map((x) => DataRow(
                                      onSelectChanged: (isSelected) async => {
                                            if (isSelected!)
                                              {
                                                await Navigator.push(
                                                    context,
                                                    MaterialPageRoute(
                                                        builder: (context) => UredjajDetaljiScreen(
                                                              uredjaj: x,
                                                              context: context,
                                                            ))).then(
                                                    (value) => uredjajBloc.add(UredjajFilterEvent(status: StateHelper.nizSearch(dropdownvalue))))
                                              },
                                          },
                                      cells: [
                                        DataCell(Text(x.uredjajId.toString())),
                                        DataCell(Text(x.tipNaziv ?? "")),
                                        DataCell(Text(x.tipOpis ?? "")),
                                        DataCell(Text(x.koda ?? "")),
                                        DataCell(Text(x.serijskiBroj ?? "")),
                                        DataCell(Text(StateHelper.nizRezultat(x.status.toString()))),
                                        DataCell(Text(x.lokacijaNaziv ?? "")),
                                        DataCell(PopupMenuButton<String>(
                                          initialValue: selected,
                                          // Callback that sets the selected popup menu item.
                                          onSelected: (izbor) {},
                                          itemBuilder: (BuildContext context) => <PopupMenuEntry<String>>[
                                            PopupMenuItem<String>(
                                              child: Text('Uredi'),
                                              value: 'edit',
                                            ),
                                            PopupMenuItem<String>(
                                              child: Text('Izbriši'),
                                              value: 'delete',
                                            ),
                                          ],
                                        )),
                                      ]))
                              .toList())
                    ],
                  );
                } else {
                  return CircularProgressIndicator();
                }
              },
            )
          ]))),
    );
  }
}
