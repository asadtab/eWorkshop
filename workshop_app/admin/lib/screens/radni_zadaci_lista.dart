import 'package:admin/commons/app_bar.dart';
import 'package:admin/screens/radni_zadaci.dart';
import 'package:commons/helpers/format_datuma.dart';
import 'package:commons/helpers/state_helper.dart';
import 'package:commons/models/radni_zadatak.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/providers/radniZadaci_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/dialog_notification.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class RadniZadaciLista extends StatefulWidget {
  const RadniZadaciLista({super.key});

  @override
  State<RadniZadaciLista> createState() => _RadniZadaciListaState();
}

class _RadniZadaciListaState extends State<RadniZadaciLista> {
  String dropdownvalue = "Aktivni";
  List<RadniZadatak> radniZadatakData = [];
  String selected = "";

  bool rowSelected = false;
  int? selectedRowIndex;

  List<RadniZadatakUredjaj> radniZadatakUredjaj = [];
  List<RadniZadatak> radniZadatak = [];

  RadniZadaciUredjajProvider? radniZadaciUredjajProvider = null;
  RadniZadaciProvider? radniZadaciProvider = null;

  final _formKeyZadatak = GlobalKey<FormState>();

  final zadatakTextController = TextEditingController();

  @override
  void initState() {
    super.initState();

    radniZadaciProvider = context.read<RadniZadaciProvider>();
    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();

    var map = {'StateMachine': 'active'};

    _fetchData(map);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    final zadatak = await radniZadaciProvider!.get(map, "RadniZadatak");

    setState(() {
      radniZadatak = zadatak;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: BarrApp(
          naslov: "Lista radnih zadataka",
        ),
        body: SingleChildScrollView(
            child: Column(crossAxisAlignment: CrossAxisAlignment.center, children: [
          Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
            Padding(
                padding: EdgeInsets.all(20),
                child: Container(
                  
                  child: Card(
                    color: Color(0xFFCBE4DE),
                    child: Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: Column(
                        children: [
                          Padding(
                            padding: const EdgeInsets.all(8.0),
                            child: Text("Odaberi status radnog zadatka"),
                          ),
                          DropdownButton<String>(
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
                              _fetchData({'StateMachine': StateHelper.nizZadatakStateSearch(value!)});
                          
                              setState(() {
                                dropdownvalue = value;
                          
                                selectedRowIndex = null; 
                                            this.radniZadatakUredjaj = [];
                              });
                            },
                            items: StateHelper.nizZadatakStateOpis.map<DropdownMenuItem<String>>((String value) {
                              return DropdownMenuItem<String>(
                                value: value,
                                child: Text(value),
                              );
                            }).toList(),
                          ),
                        ],
                      ),
                    ),
                  ),
                )),
            Container(
                height: 40,
                width: 200,

                child: TextField(
                    decoration: InputDecoration(
                      labelText: 'Pretraga', // Placeholder text
                      border: OutlineInputBorder(), // Border for the input field
                    ),
                    onChanged: (text) {
                      // Handle text input changes here
                    })),
            Padding(
                padding: EdgeInsets.all(20),
                child: MinimalisticButton(
                  icons: Icon(
                    Icons.add,
                    color: Colors.black,
                  ),
                  text: "Dodaj novi radni zadatak",
                  onPressed: () {
                    noviRadniZadatak();
                  },
                ))
          ]),
          SingleChildScrollView(
              child: Row(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children:[
                  Card(color: Color(0xFFCBE4DE), child: Container(padding: EdgeInsets.fromLTRB(50, 10, 50, 10), child: 
                Text("Radni zadaci", style: TextStyle(fontWeight: FontWeight.bold),))),
              Card(
                child: DataTable(
                  showCheckboxColumn: false,
                  columnSpacing: 21,
                  columns: [
                    
                    DataColumn(label: Text('Id')),
                    DataColumn(label: Text('Naziv')),
                    DataColumn(label: Text('Stanje')),
                    DataColumn(label: Text('Datum')),
                    DataColumn(label: Text('Opcije')),
                  ],
                  rows: radniZadatak
                      .map((x) => DataRow(
                            color: MaterialStateProperty.resolveWith<Color>((Set<MaterialState> states) {
                              if (selectedRowIndex == x.radniZadatakId) {
                                // Color when the row is selected
                                return Colors.blueGrey;
                              }
                              return Colors.transparent;
                            }),
                            onSelectChanged: (isSelected) async {
                              if (isSelected != null && isSelected) {
                                final _radniZadatakUredjaj =
                                    await radniZadaciUredjajProvider!.get({'RadniZadatakId': '${x.radniZadatakId}'}, "RadniZadatakUredjaj/Flutter");

                                setState(() {
                                  selectedRowIndex = x.radniZadatakId; 
                                  this.radniZadatakUredjaj = _radniZadatakUredjaj;
                                });
                              }
                            },
                            cells: [
                              DataCell(Text(x.radniZadatakId.toString())),
                              DataCell(Text(x.naziv.toString())),
                              DataCell(Text(x.stateMachine ?? "")),
                              DataCell(Text(FormatirajDatum.formatiraj(DateTime.parse(x.datum.toString())))),
                              DataCell(PopupMenuButton<String>(
                                initialValue: selected,
                                onSelected: (izbor) {
                                  switch (izbor) {
                                    case 'delete':
                                    if(x.stateMachine != 'idle'){
                                      ScaffoldMessenger.of(context)
                                                  .showSnackBar(CustomNotification.infoSnack("Samo neaktivni radni zadaci se mogu izbrisati."));
                                                  return;
                                    }
                                    showDialog(
                                                  context: context,
                                                  builder: (BuildContext context) {
                                                    return AlertDialog(
                                                      title: Text("Da li želite izbrisati radni zadatak"),
                                                      content: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                                                        MinimalisticButton(
                                                            text: "Potvrdi",
                                                            icons: Icon(Icons.save, color: Colors.blueAccent,),
                                                            onPressed: () async {
                                                              try {
                                                                await radniZadaciProvider!.delete(x.radniZadatakId, x, "RadniZadatak");
                                                              } catch (e) {
                                                                ScaffoldMessenger.of(context)
                                                  .showSnackBar(CustomNotification.infoSnack('Neuspješna akcija. Poruka: ' + e.toString()));
                                                              }
                                                              Navigator.pop(context);
                                                              
                                                                _fetchData({'StateMachine': 'idle'});
                                                            
                                                              ScaffoldMessenger.of(context)
                                                  .showSnackBar(CustomNotification.infoSnack("Radni zadatak je uspješno izbrisan"));
                                                            }),
                                                        MinimalisticButton(
                                                          text: "Poništi",
                                                          icons: Icon(Icons.cancel, color: Colors.redAccent,),
                                                            onPressed: () async {Navigator.pop(context);})
                                                      ]),
                                                    );
                                                  });
                                  }
                                },
                                itemBuilder: (BuildContext context) => <PopupMenuEntry<String>>[
                                
                                  PopupMenuItem<String>(
                                    child: Text('Izbriši'),
                                    value: 'delete',
                                  ),
                                ],
                              )),
                            ],
                          ))
                      .toList(),
                ),
              )]),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children:[
                Card(color: Color(0xFFCBE4DE),child: Container(padding: EdgeInsets.fromLTRB(50, 10, 50, 10), child: 
                Text("Uređaji u odabranom radnom zadatku", style: TextStyle(fontWeight: FontWeight.bold),))),
              Card(
                child: DataTable(
                  columnSpacing: 21,
                  columns: [
                    DataColumn(label: Text('Id')),
                    DataColumn(label: Text('Tip')),
                    DataColumn(label: Text('Koda')),
                    DataColumn(label: Text('Serijski broj')),
                  ],
                  rows: radniZadatakUredjaj
                      .map((x) => DataRow(
                            cells: [
                              DataCell(Text(x.uredjajId.toString())),
                              DataCell(Text(x.tipNaziv ?? "")),
                              DataCell(Text(x.koda ?? "")),
                              DataCell(Text(x.serijskiBroj ?? ""))
                            ],
                          ))
                      .toList(),

                ),
              )]),
            ],
          ))
        ])));
  }

  void noviRadniZadatak() {
    showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text("Dodaj novi radni zadatak"),
            content: Container(
                height: 170,
                child: Column(children: [
                  Form(
                      key: _formKeyZadatak,
                      child: Column(children: [
                        TextFormField(
                          controller: zadatakTextController,
                          decoration: InputDecoration(
                            labelText: 'Naziv',
                          ),
                          //initialValue: _koda,
                          validator: (value) {
                            if (value == null || value.isEmpty) {
                              return 'Unesite naziv radnog zadatka';
                            }
                            return null;
                          },
                          onSaved: (value) {},
                        ),
                      ])),
                  Container(
                      padding: EdgeInsets.fromLTRB(0, 29, 0, 0),
                      child: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                        ElevatedButton(
                            child: Text("Potvrdi"),
                            style: ElevatedButton.styleFrom(
                              elevation: 2,
                            ),
                            onPressed: () async {
                              var request = {'naziv': zadatakTextController.text, 'datum': DateTime.now().toIso8601String()};

                              if (_formKeyZadatak.currentState!.validate()) {
                                _formKeyZadatak.currentState!.save();

                                try {
                                  await radniZadaciProvider!.insert(request, "RadniZadatak");
                                } catch (e) {
                                  ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack(e.toString()));
                                  Navigator.pop(context);
                                  return;
                                }

                                ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Uspješno je dodan novi radni zadatak"));

                                zadatakTextController.clear();
                                _fetchData({'StateMachine': 'idle'});
                                setState(() {
                                  dropdownvalue = "Neaktivni";
                                });
                                Navigator.pop(context);
                                DialogNotifikacija.showCustomNotification(context, "Uspješno je dodan novi radni zadatak");
                                showCustomNotification(context, "Uspješno je dodan novi radni zadatak", isSuccess: true);

                                ScaffoldMessenger.of(context)
                                    .showSnackBar(CustomNotification.infoSnack("Aktiviraj radni zadatak dodavanjem aktivnog uređeja"));
                              }
                            }),
                        ElevatedButton(
                            child: Text("Poništi", style: TextStyle(color: Colors.white),),
                            style: ElevatedButton.styleFrom(
                              backgroundColor: Color.fromARGB(255, 170, 70, 63),
                              elevation: 2,
                            ),
                            onPressed: () {
                              zadatakTextController.clear();
                              Navigator.pop(context);
                            })
                      ]))
                ])),
          );
        });
  }
  void showCustomNotification(BuildContext context, String message, {bool isSuccess = true}) {
  showDialog(
    context: context,
    barrierDismissible: true, 
    builder: (BuildContext context) {
      return Dialog(
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)), 
        elevation: 10,
        child: Container(
          padding: EdgeInsets.all(20),
          decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(16),
            color: Colors.white,
          ),
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              Icon(
                isSuccess ? Icons.check_circle : Icons.error, 
                size: 60, 
                color: isSuccess ? Colors.green : Colors.red,
              ),
              SizedBox(height: 15),
              Text(
                isSuccess ? "Success" : "Error",
                style: TextStyle(
                  fontSize: 18,
                  fontWeight: FontWeight.bold,
                  color: Colors.black87,
                ),
              ),
              SizedBox(height: 10),
              Text(
                message,
                textAlign: TextAlign.center,
                style: TextStyle(fontSize: 16, color: Colors.black54),
              ),
              SizedBox(height: 20),
              ElevatedButton(
                onPressed: () => Navigator.of(context).pop(),
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.blueAccent,
                  shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                  padding: EdgeInsets.symmetric(horizontal: 30, vertical: 12),
                ),
                child: Text("OK", style: TextStyle(fontSize: 16)),
              ),
            ],
          ),
        ),
      );
    },
  );
}

}
