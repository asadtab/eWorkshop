import 'package:admin/bloc/client_secret/client_secret_bloc.dart';
import 'package:admin/bloc/klijenti/klijenti_bloc.dart';
import 'package:admin/screens/dodaj_klijenta.dart';
import 'package:commons/models/klijenti.dart';
import 'package:commons/models/korisnik.dart';
import 'package:commons/providers/klijenti_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class KlijentiListScreen extends StatefulWidget {
  @override
  _KlijentiListScreenState createState() => _KlijentiListScreenState();
}

class _KlijentiListScreenState extends State<KlijentiListScreen> {
  TextEditingController nazivKlijentaController = TextEditingController();
  TextEditingController idKlijentaController = TextEditingController();

  List<Korisnik> korisnici = [];

  late KlijentiProvider klijentProvider;
  List<Klijenti> klijenti = [];

  String _selected = "";

  @override
  void initState() {
    klijentProvider = context.read<KlijentiProvider>();
    // TODO: implement initState
    super.initState();
    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    var client = await klijentProvider.get(map, "Client");

    setState(() {
      klijenti = client;
    });
  }

  @override
  Widget build(BuildContext context) {
    final KlijentiBloc klijentiBloc = BlocProvider.of<KlijentiBloc>(context);
    final ClientSecretBloc clientSecretBloc = BlocProvider.of<ClientSecretBloc>(context);

    return Scaffold(
      body: SingleChildScrollView(
          child: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            Card(
              child: Padding(
                padding: const EdgeInsets.all(8.0),
                child: Row(
                  children: [
                    Expanded(
                      child: TextField(
                        controller: nazivKlijentaController,
                        decoration: InputDecoration(labelText: 'Naziv klijenta'),
                      ),
                    ),
                    SizedBox(width: 16),
                    Expanded(
                      child: TextField(
                        controller: idKlijentaController,
                        decoration: InputDecoration(labelText: 'Id klijenta'),
                      ),
                    ),
                    SizedBox(width: 16),
                    ElevatedButton(
                      onPressed: () {
                        klijentiBloc.add(KlijentiSearchEvent(naziv: nazivKlijentaController.text, id: idKlijentaController.text));
                      },
                      child: Text('Prikaži'),
                    ),
                    SizedBox(width: 16),
                    ElevatedButton(
                      onPressed: () async {
                        showDialog(
                          context: context,
                          builder: (BuildContext context) => AddClientDialog(klijentiLista: klijenti),
                        ).then((value) {
                          //klijentiBloc.add(KlijentiInitialDataEvent());
                        });
                      },
                      child: Text('Dodaj novog klijenta'),
                    ),
                  ],
                ),
              ),
            ),
            SizedBox(height: 20),
            Text("Lista klijenata"),
            BlocConsumer<KlijentiBloc, KlijentiState>(
              bloc: klijentiBloc,
              listener: (context, state) {},
              //buildWhen: (previous, current) => current is KorisniciRequest,
              builder: (context, state) {
                if (state is KlijentiLoadingState) {
                  return Center(child: CircularProgressIndicator());
                }
                if (state is KlijentiDataLoaded) {
                  return Card(
                    child: Container(
                      width: 200,
                      child: DataTable(
                        showCheckboxColumn: false,
                        columns: [
                          DataColumn(label: Text('Naziv klijenta')),
                          DataColumn(label: Text('ID klijenta')),
                          DataColumn(label: Text('Opcije')),
                        ],
                        rows: state.klijenti
                            .map(
                              (klijent) => DataRow(
                                onSelectChanged: (isSelected) async => {
                                  if (isSelected!)
                                    {
                                      clientSecretBloc.add(ClientSecretIdEvent(clientId: klijent.id!)),
                                      showDialog(
                                        context: context,
                                        builder: (BuildContext context) => AddClientDialog(
                                          klijent: klijent,
                                          klijentiLista: klijenti,
                                        ),
                                      ).then((value) {
                                        //klijentiBloc.add(KlijentiInitialDataEvent());
                                      })
                                    },
                                },
                                cells: [
                                  DataCell(Text(klijent.clientName ?? "")),
                                  DataCell(Text(klijent.clientId ?? "")),
                                  DataCell(PopupMenuButton<String>(
                                    initialValue: _selected,
                                    // Callback that sets the selected popup menu item.
                                    onSelected: (izbor) async {
                                      if (izbor == "delete") {
                                        showDialog(
                                            context: context,
                                            builder: (BuildContext context) {
                                              return AlertDialog(
                                                  title: Text("Da li želite izbrisati ApiScope"),
                                                  content: Container(
                                                      height: 170,
                                                      child: Row(children: [
                                                        MinimalisticButton(
                                                          text: "Potvrdi",
                                                          onPressed: () async {
                                                            var result = await klijentProvider.delete(klijent.id, klijent, "Client");

                                                            klijentiBloc.add(KlijentiInitialDataEvent());

                                                            ScaffoldMessenger.of(context)
                                                                .showSnackBar(CustomNotification.infoSnack(result!["message"].toString()));

                                                            Navigator.of(context).pop();
                                                          },
                                                          icons: Icon(
                                                            Icons.save,
                                                            color: Colors.blueAccent,
                                                          ),
                                                        ),
                                                        MinimalisticButton(
                                                            text: "Poništi",
                                                            onPressed: () {
                                                              Navigator.of(context).pop();
                                                            },
                                                            icons: Icon(Icons.cancel, color: Colors.redAccent))
                                                      ])));
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
                              ),
                            )
                            .toList(),
                      ),
                    ),
                  );
                }
                return Center(child: Text("Podaci ne postoje"));
              },
            ),
          ],
        ),
      )),
    );
  }
}
