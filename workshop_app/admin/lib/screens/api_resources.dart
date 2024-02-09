import 'package:admin/bloc/api_resources/api_resources_bloc.dart';
import 'package:admin/screens/dodaj_klijenta.dart';
import 'package:commons/models/korisnik.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class ApiResourcesScreen extends StatefulWidget {
  @override
  _ApiResourcesScreenState createState() => _ApiResourcesScreenState();
}

class _ApiResourcesScreenState extends State<ApiResourcesScreen> {
  TextEditingController _tipImeController = TextEditingController();
  TextEditingController _nazivController = TextEditingController();

  List<Korisnik> korisnici = [];

  String _selected = "";

  @override
  Widget build(BuildContext context) {
    final ApiResourcesBloc apiResourcesBloc = BlocProvider.of<ApiResourcesBloc>(context);

    return Scaffold(
      body: SingleChildScrollView(
          child: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            // Input fields and buttons in a Row
            Card(
              child: Padding(
                padding: const EdgeInsets.all(8.0),
                child: Row(
                  children: [
                    Expanded(
                      child: TextField(
                        controller: _tipImeController,
                        decoration: InputDecoration(labelText: 'Tip scope-a'),
                      ),
                    ),
                    SizedBox(width: 16),
                    Expanded(
                      child: TextField(
                        controller: _nazivController,
                        decoration: InputDecoration(labelText: 'Naziv scope-a'),
                      ),
                    ),
                    SizedBox(width: 16),
                    ElevatedButton(
                      onPressed: () {},
                      child: Text('Prikaži'),
                    ),
                    SizedBox(width: 16),
                    ElevatedButton(
                      onPressed: () async {
                        showDialog(
                          context: context,
                          builder: (BuildContext context) => AddClientDialog(),
                        ).then((value) {});
                      },
                      child: Text('Dodaj novi resurs'),
                    ),
                  ],
                ),
              ),
            ),
            SizedBox(height: 20),

            BlocConsumer<ApiResourcesBloc, ApiResourcesState>(
              bloc: apiResourcesBloc,
              listener: (context, state) {},
              //buildWhen: (previous, current) => current is KorisniciRequest,
              builder: (context, state) {
                if (state is ApiResourcesLoadingState) {
                  return Center(child: CircularProgressIndicator());
                }
                if (state is ApiResourcesDataLoadedState) {
                  return Card(
                    child: Container(
                      width: 200,
                      child: DataTable(
                        showCheckboxColumn: false,
                        columns: [
                          DataColumn(label: Text('Tip')),
                          DataColumn(label: Text('Naziv')),
                          DataColumn(label: Text('Opis')),
                          DataColumn(label: Text('Opcije')),
                        ],
                        rows: state.resources
                            .map(
                              (resource) => DataRow(
                                onSelectChanged: (isSelected) async => {
                                  if (isSelected!)
                                    {
                                      /*Navigator.push(context, MaterialPageRoute(builder: (context) => UserAccountScreen(korisnik: user)))
                                          .then((value) {})*/
                                    },
                                },
                                cells: [
                                  DataCell(Text(resource.name ?? "")),
                                  DataCell(Text(resource.displayName ?? "")),
                                  DataCell(Text(resource.description ?? "")),
                                  DataCell(PopupMenuButton<String>(
                                    initialValue: _selected,
                                    // Callback that sets the selected popup menu item.
                                    onSelected: (izbor) {
                                      if (izbor == "edit") {
                                        /*showDialog(
                                          context: context,
                                          builder: (BuildContext context) => DodajKorisnikaDialog(user),
                                        ).then((value) {
                                          korisniciBloc.add(KorisniciLoad());
                                        });*/
                                      }
                                    },
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
