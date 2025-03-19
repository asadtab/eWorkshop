import 'package:admin/bloc/uredjaji/bloc/uredjaj_bloc.dart';
import 'package:admin/commons/app_bar.dart';
import 'package:admin/screens/dodaj_uredi_uredjaj.dart';
import 'package:admin/screens/uredjaj_detalji.dart';
import 'package:commons/helpers/state_helper.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import "package:commons/providers/uredjaj_provider.dart";
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/dialog_notification.dart';
import 'package:commons/widgets/notification.dart';
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
                      ).then((uslov){
                        if(uslov){
                          setState(() {
                            dropdownvalue = 'Neaktivni';
                          });
                          DialogNotifikacija.showCustomNotification(context, "Uspješno je dodan novi uređaj");
                          uredjajBloc.add(UredjajFilterEvent(status: StateHelper.nizSearch('Neaktivni')));
                          
                        }
                      });
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
                        labelText: 'Id',
                        border: OutlineInputBorder(),
                      ),
                      onChanged: (text) {})),
              Container(
                  height: 40,
                  width: 200,
                  child: TextField(
                      controller: nazivController,
                      decoration: InputDecoration(
                        labelText: 'Tip',
                        border: OutlineInputBorder(),
                      ),
                      onChanged: (text) {})),
              Container(
                  height: 40,
                  width: 200,
                  child: TextField(
                      controller: opisController,
                      decoration: InputDecoration(
                        labelText: 'Naziv',
                        border: OutlineInputBorder(),
                      ),
                      onChanged: (text) {})),
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
              listener: (context, state) {},
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
                                          onSelected: (izbor) {
                                            if (x.status == "idle") {
                                              showDialog(
                                                  context: context,
                                                  builder: (BuildContext context) {
                                                    return AlertDialog(
                                                      title: Text("Da li želite izbrisati uređaj"),
                                                      content: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                                                        ElevatedButton(
                                                            child: Text("Potvrdi"),
                                                            style: ElevatedButton.styleFrom(
                                                              elevation: 2,
                                                            ),
                                                            onPressed: () async {
                                                              try {
                                                                await _uredjajiProvider!.delete(x.uredjajId, x, "Uredjaj");
                                                              } catch (e) {}
                                                              uredjajBloc.add(UredjajFilterEvent(status: 'idle'));
                                                              Navigator.pop(context);
                                                            }),
                                                        ElevatedButton(
                                                            child: Text("Poništi"),
                                                            style: ElevatedButton.styleFrom(elevation: 2, backgroundColor: Colors.redAccent),
                                                            onPressed: () async {})
                                                      ]),
                                                    );
                                                  });
                                            } else {
                                              ScaffoldMessenger.of(context)
                                                  .showSnackBar(CustomNotification.infoSnack("Samo neaktivni uređaji se mogu izbrisati."));
                                            }
                                          },
                                          itemBuilder: (BuildContext context) => <PopupMenuEntry<String>>[
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
