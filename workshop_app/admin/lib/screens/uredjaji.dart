import 'package:admin/bloc/uredjaji/bloc/uredjaj_bloc.dart';
import 'package:admin/commons/app_bar.dart';
import 'package:admin/screens/dodaj_uredi_uredjaj.dart';
import 'package:admin/screens/uredjaj_detalji.dart';
import 'package:admin/widgets/status_icons.dart';
import 'package:commons/helpers/state_helper.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import "package:commons/providers/uredjaj_provider.dart";
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/dialog_notification.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/foundation.dart';
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
                SizedBox(height: 20,),
            Row(mainAxisAlignment: MainAxisAlignment.end, children: [
            ]),
            Card(
  color: Color(0xFFf3f5fb),
  child: Padding(
    padding: const EdgeInsets.all(8.0),
    child: LayoutBuilder(
      builder: (context, constraints) {
        return Wrap(
          spacing: 12,
          runSpacing: 12,
          crossAxisAlignment: WrapCrossAlignment.center,
          alignment: WrapAlignment.spaceEvenly,
          children: [
            Container(
              width: constraints.maxWidth < 600 ? constraints.maxWidth : 250,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  Text(
                    "Odaberi status uređaja",
                    style: TextStyle(fontWeight: FontWeight.bold),
                  ),
                  SizedBox(height: 4),
                  DropdownButton<String>(
                    value: dropdownvalue,
                    isExpanded: true,
                    elevation: 16,
                    padding: EdgeInsets.all(8),
                    hint: Text("Odaberi status"),
                    style: const TextStyle(color: Colors.black),
                    borderRadius: BorderRadius.all(Radius.circular(10)),
                    underline: Container(
                      height: 5,
                      color: Color(0xFFa2cdbc),
                    ),
                    onChanged: (String? value) {
                      uredjajBloc.add(
                          UredjajFilterEvent(status: StateHelper.nizSearch(value!)));
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
                  ),
                ],
              ),
            ),
            _responsiveInputField("Id", idController),
            _responsiveInputField("Tip", tipController),
            _responsiveInputField("Naziv", nazivController),
            _responsiveInputField("Koda", kodaController),
            SizedBox(
              height: 70,
              child: MinimalisticButton(
                icons: Icon(Icons.search, color: Colors.black),
                text: "Pretraga",
                color: Color(0xFFa2cdbc),
                textColor: Colors.black,
                onPressed: () {
                  uredjajBloc.add(UredjajFilterEvent(
                    status: StateHelper.nizSearch(dropdownvalue),
                    id: idController.text.isEmpty ? null : int.tryParse(idController.text),
                    tip: tipController.text,
                    naziv: nazivController.text,
                    koda: kodaController.text,
                    opis: opisController.text,
                  ));
                },
              ),
            ),
            Padding(
                padding: EdgeInsets.all(10),
                child: SizedBox(height: 70,child: MinimalisticButton(
                  color: Color(0xFFae8765),
                  icons: Icon(color: Colors.black,Icons.add),
                  textColor: Colors.black,
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
                )))
          ],
        );
      },
    ),
  ),
),

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
                      Expanded(
                        child: Card(
                          color: Color(0xFFf3f5fb),
                          child: DataTable(
                              showCheckboxColumn: false,
                              columns: [
                                DataColumn(label: Text('Id')),
                                DataColumn(label: Text('Tip')),
                                DataColumn(label: Text('Naziv')),
                                DataColumn(label: Text('Koda')),
                                DataColumn(label: Text('Ser. broj')),
                                DataColumn(label: Text('Status')),
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
                                            DataCell(buildIcon.buildStatusCellUredjaj(x.status)),

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
                                                            MinimalisticButton(
                                                                text: "Potvrdi",
                                                                icons: Icon(Icons.save, color: Colors.blueAccent,),
                                                                onPressed: () async {
                                                                  try {
                                                                    await _uredjajiProvider!.delete(x.uredjajId, x, "Uredjaj");
                                                                  } catch (e) {}
                                                                  uredjajBloc.add(UredjajFilterEvent(status: 'idle'));
                                                                  Navigator.pop(context);
                                                                  ScaffoldMessenger.of(context)
                                                      .showSnackBar(CustomNotification.infoSnack("Uređaj je uspješno izbrisan"));
                                                                }),
                                                            MinimalisticButton(
                                                              text: "Poništi",
                                                              icons: Icon(Icons.cancel, color: Colors.redAccent,),
                                                                onPressed: () async {Navigator.pop(context);})
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
                                  .toList()),
                        ),
                      )
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
  Widget _responsiveInputField(String label, TextEditingController controller) {
  return ConstrainedBox(
    constraints: BoxConstraints(minWidth: 70, maxWidth: 150),
    child: SizedBox(
      height: 40,
      child: TextField(
        controller: controller,
        decoration: InputDecoration(
          labelText: label,
          border: OutlineInputBorder(),
        ),
        onChanged: (text) {},
      ),
    ),
  );
}


}
