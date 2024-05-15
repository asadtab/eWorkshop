import 'package:admin/bloc/api_resources/api_resources_bloc.dart';
import 'package:admin/screens/dodaj_uredi_resurs.dart';
import 'package:commons/models/api_resources.dart';
import 'package:commons/models/korisnik.dart';
import 'package:commons/providers/api_resources_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
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
  List<ApiResources> apiResursi = [];

  late ApiResourcesProvider apiResourcesProvider;

  @override
  void initState() {
    apiResourcesProvider = context.read<ApiResourcesProvider>();

    // TODO: implement initState
    super.initState();
    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    var resursi = await apiResourcesProvider.get(map, "ApiResource");

    setState(() {
      apiResursi = resursi;
    });
  }

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
                      onPressed: () {
                        apiResourcesBloc.add(ApiResourcesSearchEvent(naziv: _nazivController.text, tip: _tipImeController.text));
                      },
                      child: Text('Prikaži'),
                    ),
                    SizedBox(width: 16),
                    ElevatedButton(
                      onPressed: () async {
                        showDialog(
                          context: context,
                          builder: (BuildContext context) => DodajUrediResurs(resursi: apiResursi),
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
                                      showDialog(
                                        context: context,
                                        builder: (BuildContext context) => DodajUrediResurs(apiResources: resource, resursi: apiResursi),
                                      )
                                    },
                                },
                                cells: [
                                  DataCell(Text(resource.name ?? "")),
                                  DataCell(Text(resource.displayName ?? "")),
                                  DataCell(Text(resource.description ?? "")),
                                  DataCell(PopupMenuButton<String>(
                                    initialValue: _selected,
                                    onSelected: (izbor) {
                                      if (izbor == "delete") {
                                        showDialog(
                                            context: context,
                                            builder: (BuildContext context) {
                                              return AlertDialog(
                                                  title: Text("Da li želite izbrisati ApiResource"),
                                                  content: Container(
                                                      height: 170,
                                                      child: Row(children: [
                                                        MinimalisticButton(
                                                          text: "Potvrdi",
                                                          onPressed: () async {
                                                            var result = await apiResourcesProvider.delete(resource.id, resource, "ApiResource");

                                                            apiResourcesBloc.add(ApiResourcesDataLoadEvent());

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
