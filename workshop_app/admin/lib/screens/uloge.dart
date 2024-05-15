import 'package:admin/widgets/dodaj_ulogu.dart';
import 'package:commons/models/uloge.dart';
import 'package:commons/providers/uloge_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../bloc/uloge/uloge_bloc.dart';

class UlogeScreen extends StatefulWidget {
  const UlogeScreen({super.key});

  @override
  State<UlogeScreen> createState() => _UlogeScreenState();
}

class _UlogeScreenState extends State<UlogeScreen> {
  TextEditingController _nazivUlogeController = TextEditingController();

  late UlogeProvider ulogeProvider;

  var userData = {'userName': 'asad', 'email': 'mail'};
  List<Uloge> uloge = [];

  @override
  void initState() {
    ulogeProvider = context.read<UlogeProvider>();

    super.initState();
    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    var roles = await ulogeProvider.get(map, "Uloge");

    setState(() {
      uloge = roles;
    });
  }

  @override
  Widget build(BuildContext context) {
    final UlogeBloc ulogeBloc = BlocProvider.of<UlogeBloc>(context);

    var _selected;
    return Scaffold(
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: SingleChildScrollView(
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
                          controller: _nazivUlogeController,
                          decoration: InputDecoration(labelText: 'Naziv uloge'),
                        ),
                      ),
                      SizedBox(width: 16),
                      ElevatedButton(
                        onPressed: () {
                          ulogeBloc.add(UlogeSearch(nazivUloge: _nazivUlogeController.text));
                        },
                        child: Text('Prikaži'),
                      ),
                      SizedBox(width: 16),
                      ElevatedButton(
                        onPressed: () async {
                          showDialog(
                            context: context,
                            builder: (BuildContext context) => DodajUlogu(uloge),
                          ).then((value) {
                            ulogeBloc.add(UlogeRequest());
                          });
                        },
                        child: Text('Dodaj novu ulogu'),
                      ),
                    ],
                  ),
                ),
              ),
              SizedBox(height: 20),
              Text("Lista uloga"),
              BlocConsumer<UlogeBloc, UlogeState>(
                bloc: ulogeBloc,
                listener: (context, state) {
                  // TODO: implement listener
                },
                builder: (context, state) {
                  if (state is UlogeLoading) {
                    return Center(
                      child: CircularProgressIndicator(),
                    );
                  }
                  if (state is UlogeData) {
                    var uloge = state.ulogeData;
                    return Card(
                      child: Container(
                        width: 200,
                        child: DataTable(
                          showCheckboxColumn: false,
                          columns: [
                            DataColumn(label: Text('Naziv')),
                            //DataColumn(label: Text('E-mail adresa')),
                            DataColumn(label: Text('Opcije')),
                          ],
                          rows: uloge
                              .map(
                                (role) => DataRow(
                                  cells: [
                                    DataCell(Text(role.name ?? "")),
                                    //DataCell(Text(user.email ?? "")),
                                    DataCell(PopupMenuButton<String>(
                                      initialValue: _selected,
                                      onSelected: (izbor) {
                                        if (izbor == "delete") {
                                          showDialog(
                                              context: context,
                                              builder: (BuildContext context) {
                                                return AlertDialog(
                                                    title: Text("Da li želite izbrisati ulogu?"),
                                                    content: Container(
                                                        height: 170,
                                                        child: Row(children: [
                                                          MinimalisticButton(
                                                            text: "Potvrdi",
                                                            onPressed: () async {
                                                              var result = await ulogeProvider.delete(role.id, role, "Uloge");

                                                              ulogeBloc.add(UlogeRequest());

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
                  } else {
                    return Center(
                      child: Text("Nema podataka"),
                    );
                  }
                },
              )
            ],
          ),
        ),
      ),
    );
  }
}
