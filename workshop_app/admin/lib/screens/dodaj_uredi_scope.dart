import 'package:admin/bloc/api_scopes/api_scopes_bloc.dart';
import 'package:commons/models/api_scopes.dart';
import 'package:commons/providers/api_scopes_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class DodajUrediScope extends StatefulWidget {
  late ApiScopes? apiScope;
  List<ApiScopes> scopesLista = [];

  DodajUrediScope({this.apiScope, required this.scopesLista});

  @override
  State<DodajUrediScope> createState() => _DodajUrediScopeState();
}

class _DodajUrediScopeState extends State<DodajUrediScope> {
  late GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  TextEditingController descriptionController = TextEditingController();
  TextEditingController displayNameController = TextEditingController();
  TextEditingController nameController = TextEditingController();

  late ApiScopesProvider apiScopesProvider;

  @override
  void initState() {
    super.initState();

    apiScopesProvider = context.read<ApiScopesProvider>();

    nameController.text = widget.apiScope?.name ?? "";
    displayNameController.text = widget.apiScope?.displayName ?? "";
    descriptionController.text = widget.apiScope?.description ?? "";
  }

  String? validateScopeName(String? value) {
    if (value == null || value.isEmpty) {
      return 'Unesite tip scope-a';
    }
    return null;
  }

  String? validateDisplayName(String? value) {
    if (value == null || value.isEmpty) {
      return 'Unesite naziv scope-a';
    }
    return null;
  }

  String? validateDescription(String? value) {
    if (value == null || value.isEmpty) {
      return 'Unesite opis scope-a';
    }
    return null;
  }

  @override
  Widget build(BuildContext context) {
    final ApiScopesBloc apiScopesBloc = BlocProvider.of<ApiScopesBloc>(context);

    return AlertDialog(
        title: Text("Api scope"),
        content: Container(
          width: MediaQuery.of(context).size.width * 0.4,
          height: MediaQuery.of(context).size.height * 0.5,
          child: Column(
            children: [
              Form(
                key: _formKey,
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
                    TextFormField(
                      controller: nameController,
                      decoration: InputDecoration(labelText: 'Tip'),
                      validator: validateScopeName,
                    ),
                    TextFormField(
                      controller: displayNameController,
                      decoration: InputDecoration(labelText: 'Naziv'),
                      validator: validateDisplayName,
                    ),
                    TextFormField(
                      controller: descriptionController,
                      decoration: InputDecoration(labelText: 'Opis'),
                      validator: validateDescription,
                    ),
                    SizedBox(
                      height: 16,
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.end,
                      children: [
                        MinimalisticButton(
                          icons: Icon(
                            Icons.cancel,
                            color: Colors.red,
                          ),
                          onPressed: () {
                            Navigator.of(context).pop();
                          },
                          text: 'Poništi',
                        ),
                        MinimalisticButton(
                          icons: Icon(
                            Icons.save,
                            color: Colors.blueAccent,
                          ),
                          onPressed: () async {
                            if (!_formKey.currentState!.validate()) {
                              poruka("Ispunite sva polja.");
                              return;
                            }

                            for (var scope in widget.scopesLista) {
                              if (scope.name == nameController.text && widget.apiScope == null) {
                                return showDialog(
                                    context: context,
                                    builder: (context) {
                                      return AlertDialog(
                                        title: Text('Tip scope-a već postoji u bazi.'),
                                        actions: [
                                          TextButton(
                                            onPressed: () {
                                              Navigator.pop(context);
                                            },
                                            child: Text('OK'),
                                          ),
                                        ],
                                      );
                                    });
                              }
                              if (scope.displayName == displayNameController.text && widget.apiScope == null) {
                                return showDialog(
                                    context: context,
                                    builder: (context) {
                                      return AlertDialog(
                                        title: Text('Naziv scope-a već postoji u bazi.'),
                                        actions: [
                                          TextButton(
                                            onPressed: () {
                                              Navigator.pop(context);
                                            },
                                            child: Text('OK'),
                                          ),
                                        ],
                                      );
                                    });
                              }
                            }

                            var request = {
                              'name': nameController.text,
                              'displayName': displayNameController.text,
                              'description': descriptionController.text
                            };

                            if (widget.apiScope != null) {
                              try {
                                var result = await apiScopesProvider.update(widget.apiScope!.id, request, "ApiScopes");
                                poruka("Uspješno ažuriranje.");
                              } catch (e) {
                                poruka(e.toString());
                              }

                              Navigator.of(context).pop();

                              apiScopesBloc.add(ApiScopeLoadDataEvent());

                              return;
                            }

                            try {
                              var result = await apiScopesProvider.insert(request, "ApiScopes");
                            } catch (e) {
                              poruka(e.toString());
                            }

                            Navigator.of(context).pop();
                            apiScopesBloc.add(ScopesAddEvent(request: request));
                          },
                          text: 'Sačuvaj',
                        ),
                      ],
                    ),
                  ],
                ),
              ),
            ],
          ),
        ));
  }

  void poruka(String msg) {
    ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack(msg));
  }
}
