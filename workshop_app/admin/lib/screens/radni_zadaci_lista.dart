import 'package:admin/bloc/radni_zadatak/radni_zadatak_bloc.dart';
import 'package:admin/commons/app_bar.dart';
import 'package:admin/screens/radniZadatak_detalji.dart';
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
import 'package:flutter_bloc/flutter_bloc.dart';
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

  final GlobalKey<ScaffoldState> _scaffoldKey = GlobalKey<ScaffoldState>();
  int? selectedRadniZadatakId;

  RadniZadatakBloc? radniZadatakBloc;

  @override
  void initState() {
    super.initState();

    radniZadaciProvider = context.read<RadniZadaciProvider>();
    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();

    radniZadatakBloc = BlocProvider.of<RadniZadatakBloc>(context);

    radniZadatakBloc!.add(RadniZadatakAllEvent(status: "active"));

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
        key: _scaffoldKey,
        appBar: BarrApp(
          naslov: "Lista radnih zadataka",
        ),
        body: BlocConsumer<RadniZadatakBloc, RadniZadatakState>(
          bloc: radniZadatakBloc,
          listener: (context, state) {
            // TODO: implement listener
          },
          builder: (context, state) {
            if(state is ZadaciLoadingState){
              return Center(child: CircularProgressIndicator(),);
            }
            else if(state is RadniZadatakRefreshListaState){
              radniZadatakBloc!.add(RadniZadatakAllEvent(status: StateHelper.nizSearch(dropdownvalue)));

              return Center(child: CircularProgressIndicator(),);
            }
            else if (state is ZadaciDataLoadedState) {
              var zadaci = state.data;
    
              return SingleChildScrollView(
                  child: Column(
                      crossAxisAlignment: CrossAxisAlignment.center,
                      children: [
                    Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: Card(
                        color: Color(0xFFf3f5fb),
                        child: Row(
                            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                            children: [
                              Padding(
                                  padding: EdgeInsets.all(20),
                                  child: Container(
                                    child: Padding(
                                      padding: const EdgeInsets.all(8.0),
                                      child: Column(
                                        children: [
                                          Text(
                                            "Odaberi status radnog zadatka",
                                            style: TextStyle(
                                                fontWeight: FontWeight.bold),
                                          ),
                                          DropdownButton<String>(
                                            value: dropdownvalue,
                                            elevation: 16,
                                            padding: EdgeInsets.all(8),
                                            borderRadius: BorderRadius.all(
                                                Radius.circular(5)),
                                            hint: Container(
                                                child:
                                                    Text("Odaberi status")),
                                            style: const TextStyle(
                                                color: Colors.black),
                                            underline: Container(
                                              height: 5,
                                              color: Color(0xFFa2cdbc),
                                            ),
                                            onChanged: (String? value) {
                                              setState(() {
                                                dropdownvalue = value!;
    
                                                selectedRowIndex = null;
                                                this.radniZadatakUredjaj = [];
                                              });
                                              
                                              radniZadatakBloc!.add(
                                                  RadniZadatakAllEvent(
                                                      status: StateHelper
                                                          .nizZadatakStateSearch(
                                                              dropdownvalue)));
    
                                              
                                            },
                                            items: StateHelper
                                                .nizZadatakStateOpis
                                                .map<
                                                        DropdownMenuItem<
                                                            String>>(
                                                    (String value) {
                                              return DropdownMenuItem<String>(
                                                value: value,
                                                child: Text(value),
                                              );
                                            }).toList(),
                                          ),
                                        ],
                                      ),
                                    ),
                                  )),
                              Padding(
                                  padding: EdgeInsets.all(20),
                                  child: SizedBox(
                                    height: 70,
                                    child: MinimalisticButton(
                                      color: Color(0xFFae8765),
                                      icons: Icon(
                                        Icons.add,
                                        color: Colors.black,
                                      ),
                                      text: "Dodaj novi radni zadatak",
                                      onPressed: () {
                                        noviRadniZadatak();
                                        radniZadatakBloc!.add(RadniZadatakAllEvent(status: 'idle'));
                                      },
                                    ),
                                  ))
                            ]),
                      ),
                    ),
                    SingleChildScrollView(
                        child: Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Expanded(
                          child: Card(
                            child: DataTable(
                              showCheckboxColumn: false,
                              columnSpacing: 21,
                              columns: [
                                DataColumn(label: Text('Id')),
                                DataColumn(label: Text('Naziv')),
                                DataColumn(label: Text('Status')),
                                DataColumn(label: Text('Datum')),
                                DataColumn(label: Text('Opcije')),
                              ],
                              rows: zadaci
                                  .map((x) => DataRow(
                                        onSelectChanged: (isSelected) async {
                                          if (isSelected != null &&
                                              isSelected) {
                                            final _radniZadatakUredjaj =
                                                await radniZadaciUredjajProvider!
                                                    .get({
                                              'RadniZadatakId':
                                                  '${x.radniZadatakId}'
                                            }, "RadniZadatakUredjaj/Flutter");
    
                                            await Navigator.push(
                                                context,
                                                MaterialPageRoute(
                                                    builder: (context) =>
                                                        RadnizadatakDetaljiScreen(
                                                          radniZadatak: x,
                                                          radniZadatakUredjaj:
                                                              _radniZadatakUredjaj,
                                                        ))).then((value) {
                                              radniZadatakBloc!.add(
                                                  RadniZadatakAllEvent(
                                                      status: StateHelper
                                                          .nizZadatakStateSearch(
                                                              dropdownvalue)));
                                            });
    
                                            setState(() {
                                              selectedRowIndex =
                                                  x.radniZadatakId;
                                              this.radniZadatakUredjaj =
                                                  _radniZadatakUredjaj;
                                              selectedRadniZadatakId =
                                                  x.radniZadatakId;
                                            });
                                          }
                                        },
                                        cells: [
                                          DataCell(Text(
                                              x.radniZadatakId.toString())),
                                          DataCell(Text(x.naziv.toString())),
                                          DataCell(buildStatusCell(
                                              x.stateMachine)),
                                          DataCell(Text(
                                              FormatirajDatum.formatiraj(
                                                  DateTime.parse(
                                                      x.datum.toString())))),
                                          DataCell(PopupMenuButton<String>(
                                            initialValue: selected,
                                            onSelected: (izbor) {
                                              switch (izbor) {
                                                case 'delete':
                                                  if (x.stateMachine !=
                                                      'idle') {
                                                    ScaffoldMessenger.of(
                                                            context)
                                                        .showSnackBar(
                                                            CustomNotification
                                                                .infoSnack(
                                                                    "Samo neaktivni radni zadaci se mogu izbrisati."));
                                                    return;
                                                  }
                                                  showDialog(
                                                      context: context,
                                                      builder: (BuildContext
                                                          context) {
                                                        return AlertDialog(
                                                          title: Text(
                                                              "Da li želite izbrisati radni zadatak"),
                                                          content: Row(
                                                              mainAxisAlignment:
                                                                  MainAxisAlignment
                                                                      .spaceEvenly,
                                                              children: [
                                                                MinimalisticButton(
                                                                    text:
                                                                        "Potvrdi",
                                                                    icons:
                                                                        Icon(
                                                                      Icons
                                                                          .save,
                                                                      color: Colors
                                                                          .blueAccent,
                                                                    ),
                                                                    onPressed:
                                                                        () async {
                                                                      try {
                                                                        await radniZadaciProvider!.delete(
                                                                            x.radniZadatakId,
                                                                            x,
                                                                            "RadniZadatak");
                                                                      } catch (e) {
                                                                        ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack('Neuspješna akcija. Poruka: ' +
                                                                            e.toString()));
                                                                      }
                                                                      Navigator.pop(
                                                                          context);
    
                                                                      _fetchData({
                                                                        'StateMachine':
                                                                            'idle'
                                                                      });
    
                                                                      ScaffoldMessenger.of(context)
                                                                          .showSnackBar(CustomNotification.infoSnack("Radni zadatak je uspješno izbrisan"));
                                                                    }),
                                                                MinimalisticButton(
                                                                    text:
                                                                        "Poništi",
                                                                    icons:
                                                                        Icon(
                                                                      Icons
                                                                          .cancel,
                                                                      color: Colors
                                                                          .redAccent,
                                                                    ),
                                                                    onPressed:
                                                                        () async {
                                                                      Navigator.pop(
                                                                          context);
                                                                    })
                                                              ]),
                                                        );
                                                      });
                                              }
                                            },
                                            itemBuilder:
                                                (BuildContext context) =>
                                                    <PopupMenuEntry<String>>[
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
                          ),
                        ),
                        Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children:[
                          
                      ]),
                      ],
                    ))
                  ]));
            } else {
              return Center(child: CircularProgressIndicator());
            }
          },
        ));
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
                      child: Row(
                          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                          children: [
                            ElevatedButton(
                                child: Text("Potvrdi"),
                                style: ElevatedButton.styleFrom(
                                  elevation: 2,
                                ),
                                onPressed: () async {
                                  var request = {
                                    'naziv': zadatakTextController.text,
                                    'datum': DateTime.now().toIso8601String()
                                  };

                                  if (_formKeyZadatak.currentState!
                                      .validate()) {
                                    _formKeyZadatak.currentState!.save();

                                    try {
                                      await radniZadaciProvider!
                                          .insert(request, "RadniZadatak");

                                          radniZadatakBloc!.add(RadniZadatakAllEvent(status: 'idle'));
                                    } catch (e) {
                                      ScaffoldMessenger.of(context)
                                          .showSnackBar(
                                              CustomNotification.infoSnack(
                                                  e.toString()));
                                      Navigator.pop(context);
                                      return;
                                    }

                                    ScaffoldMessenger.of(context).showSnackBar(
                                        CustomNotification.infoSnack(
                                            "Uspješno je dodan novi radni zadatak"));

                                    zadatakTextController.clear();
                                    _fetchData({'StateMachine': 'idle'});
                                    setState(() {
                                      dropdownvalue = "Neaktivni";
                                    });
                                    Navigator.pop(context);
                                    DialogNotifikacija.showCustomNotification(
                                        context,
                                        "Uspješno je dodan novi radni zadatak");
                                    showCustomNotification(context,
                                        "Uspješno je dodan novi radni zadatak",
                                        isSuccess: true);

                                    ScaffoldMessenger.of(context).showSnackBar(
                                        CustomNotification.infoSnack(
                                            "Aktiviraj radni zadatak dodavanjem aktivnog uređeja"));
                                  }
                                }),
                            ElevatedButton(
                                child: Text(
                                  "Poništi",
                                  style: TextStyle(color: Colors.white),
                                ),
                                style: ElevatedButton.styleFrom(
                                  backgroundColor:
                                      Color.fromARGB(255, 170, 70, 63),
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

  void showCustomNotification(BuildContext context, String message,
      {bool isSuccess = true}) {
    showDialog(
      context: context,
      barrierDismissible: true,
      builder: (BuildContext context) {
        return Dialog(
          shape:
              RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
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
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(12)),
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

  Widget buildStatusCell(String? stateMachine) {
    final status = stateMachine ?? "";
    IconData icon;
    Color color;
    String label;

    switch (status) {
      case "idle":
        icon = Icons.power_off;
        color = Colors.grey;
        label = "Neaktivni";
        break;
      case "active":
        icon = Icons.play_arrow;
        color = Colors.green;
        label = "Aktivni";
        break;
      case "done":
        icon = Icons.check_circle;
        color = Colors.blue;
        label = "Završeni";
        break;
      case "invoice":
        icon = Icons.receipt_long;
        color = Colors.amber;
        label = "Fakturisano";
        break;
      default:
        icon = Icons.help_outline;
        color = Colors.black45;
        label = status;
        break;
    }

    return Row(
      children: [
        Icon(icon, color: color, size: 18),
        const SizedBox(width: 6),
        Flexible(child: Text(label, overflow: TextOverflow.ellipsis)),
      ],
    );
  }
}
