import 'package:admin/bloc/api_resources/api_resources_bloc.dart';
import 'package:commons/models/api_resources.dart';
import 'package:commons/providers/api_resources_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class DodajUrediResurs extends StatefulWidget {
  late ApiResources? apiResources;
  List<ApiResources> resursi = [];

  DodajUrediResurs({this.apiResources, required this.resursi});

  @override
  State<DodajUrediResurs> createState() => _DodajUrediResursState();
}

class _DodajUrediResursState extends State<DodajUrediResurs> {
  late GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  TextEditingController descriptionController = TextEditingController();
  TextEditingController displayNameController = TextEditingController();
  TextEditingController nameController = TextEditingController();

  late ApiResourcesProvider apiResursProvider;

  @override
  void initState() {
    super.initState();

    descriptionController.text = widget.apiResources?.description ?? "";
    nameController.text = widget.apiResources?.name ?? "";
    displayNameController.text = widget.apiResources?.displayName ?? "";

    apiResursProvider = context.read<ApiResourcesProvider>();
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
    final ApiResourcesBloc apiResourceBloc = BlocProvider.of<ApiResourcesBloc>(context);

    return AlertDialog(
        title: Text("Api resource"),
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

                            for (var resurs in widget.resursi) {
                              if (resurs.name == nameController.text) {
                                return showDialog(
                                    context: context,
                                    builder: (context) {
                                      return AlertDialog(
                                        title: Text('Tip resursa već postoji u bazi.'),
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

                            if (widget.apiResources != null) {
                              try {
                                var result = await apiResursProvider.update(widget.apiResources!.id, widget.apiResources!, "ApiResource");
                              } catch (e) {
                                poruka(e.toString());
                              }

                              Navigator.of(context).pop();

                              return;
                            }

                            try {
                              var result = await apiResursProvider.insert(request, "ApiResource");
                            } catch (e) {
                              poruka(e.toString());
                            }

                            Navigator.of(context).pop();

                            apiResourceBloc.add(ApiResourcesDataLoadEvent());
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
