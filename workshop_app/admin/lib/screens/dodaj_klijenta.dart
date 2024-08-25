import 'package:admin/bloc/api_scopes/api_scopes_bloc.dart';
import 'package:admin/bloc/klijenti/klijenti_bloc.dart';
import 'package:admin/widgets/date_picker.dart';
import 'package:commons/models/client_grant_type.dart';
import 'package:commons/models/client_scope.dart';
import 'package:commons/models/client_secret.dart';
import 'package:commons/models/klijenti.dart';
import 'package:commons/providers/client_grant_type_provider.dart';
import 'package:commons/providers/client_scope_provider.dart';
import 'package:commons/providers/client_secret_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:darq/darq.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class AddClientDialog extends StatefulWidget {
  late Klijenti? klijent;
  late ClientSecret? clientSecret;
  List<Klijenti> klijentiLista;

  AddClientDialog({this.klijent, this.clientSecret, required this.klijentiLista});

  @override
  _AddClientDialogState createState() => _AddClientDialogState();
}

class _AddClientDialogState extends State<AddClientDialog> {
  TextEditingController clientNameController = TextEditingController();
  TextEditingController clientIdController = TextEditingController();
  TextEditingController clientUriController = TextEditingController();
  TextEditingController protocolTypeController = TextEditingController();
  TextEditingController allowedGrantTypesController = TextEditingController();
  TextEditingController clientSecretController = TextEditingController();

  TextEditingController descriptionSecretController = TextEditingController();
  TextEditingController valueSecretController = TextEditingController();
  TextEditingController expirationController = TextEditingController();
  TextEditingController typeController = TextEditingController();

  late ClientSecretProvider clientSecretProvider;
  late ClientScopeProvider clientScopeProvider;
  late ClientGrantTypeProvider clientGrantTypeProvider;

  List<ClientSecret> clientSecretList = [];
  List<ClientSecret> clientSecretListWidget = [];

  bool requirePkce = false;
  bool allowOfflineAccess = false;
  bool requireSecret = true;

  late GlobalKey<FormState> _formKey; // = GlobalKey<FormState>();

  bool aktivan = true;

  String selectedScope = '';

  String selectedGrantType = '';
  List<String> allowedGrantTypes = [];

  List<String> addClientScopes = [];
  List<Map<String, Object>> addGrantTypeMap = [];
  List<Map<String, Object>> addClientScopesMap = [];
  List<Map<String, Object>> clientScopesMap = [];

  bool provjera = false;

  List<Map<String, String>> allowedGrantTypesMap = [
    {"authorization_code": "Authorization Code Grant"},
    {"implicit": "Implicit Grant"},
    {"password": "Resource Owner Password Credentials (ROPC) Grant"},
    {"client_credentials": "Client Credentials Grant"},
    {"device_code": "Device Authorization Grant (Device Flow)"},
    {"refresh_token": "Refresh Token Grant"}
  ];

  List<Map<String, String>> clientSecrets = [];
  List<ClientScope> clientScopes = [];
  List<ClientGrantType> clientGrantType = [];

  @override
  void initState() {
    super.initState();
    clientSecretProvider = context.read<ClientSecretProvider>();
    clientScopeProvider = context.read<ClientScopeProvider>();
    clientGrantTypeProvider = context.read<ClientGrantTypeProvider>();

    clientNameController.text = widget.klijent?.clientName ?? '';
    clientIdController.text = widget.klijent?.clientId ?? '';
    clientUriController.text = widget.klijent?.clientUri ?? '';
    protocolTypeController.text = widget.klijent?.protocolType ?? '';

    _formKey = GlobalKey<FormState>();

    if (widget.klijent != null) {
      _fetchData({'ClientId': widget.klijent!.id!.toString()});
    }
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    final response = await clientSecretProvider.get(map, "ClientSecret");
    final scopeResponse = await clientScopeProvider.get(map, "ClientScope");
    final grantTypeResponse = await clientGrantTypeProvider.get(map, "ClientGrantType");

    setState(() {
      clientSecretList = response;
      clientScopes = scopeResponse;
      clientGrantType = grantTypeResponse;
    });
  }

  int _currentPageIndex = 0;
  final PageController _pageController = PageController();

  Map<String, bool> checkboxStates = {};

  @override
  Widget build(BuildContext context) {
    final KlijentiBloc clientBloc = BlocProvider.of<KlijentiBloc>(context);

    return AlertDialog(
      title: Text('Dodaj novog klijenta'),
      content: SingleChildScrollView(
        child: SizedBox(
          width: 400,
          height: 400,
          child: Column(
            children: [
              Expanded(
                child: PageView(
                  controller: _pageController,
                  onPageChanged: (index) {
                    setState(() {
                      _currentPageIndex = index;
                    });
                  },
                  children: [basicInfo(), scopeKlijenta(context), clientSecret()],
                ),
              ),
            ],
          ),
        ),
      ),
      actions: [
        Column(
          mainAxisAlignment: MainAxisAlignment.end,
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                //if (_currentPageIndex > 0)
                IconButton(
                  icon: Icon(Icons.arrow_circle_left),
                  iconSize: 50,
                  color: Colors.greenAccent,
                  onPressed: _currentPageIndex > 0
                      ? () {
                          _pageController.previousPage(
                            duration: Duration(milliseconds: 500),
                            curve: Curves.easeInOut,
                          );
                        }
                      : null,
                ),
                Text(
                  '${_currentPageIndex + 1}/3',
                  style: TextStyle(fontSize: 20),
                ),
                //if (_currentPageIndex < 2)
                IconButton(
                  icon: Icon(Icons.arrow_circle_right),
                  iconSize: 50,
                  color: Colors.greenAccent,
                  onPressed: _currentPageIndex < 2
                      ? () {
                          _pageController.nextPage(
                            duration: Duration(milliseconds: 500),
                            curve: Curves.easeInOut,
                          );
                          if (_currentPageIndex == 0) {
                            provjera = _formKey.currentState!.validate();
                          }
                        }
                      : null,
                ),
              ],
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
                  onPressed: () {
                    if (_currentPageIndex < 1) {
                      provjera = _formKey.currentState!.validate();
                    }

                    if (provjera && clientScopes.isNotEmpty && allowedGrantTypesMap.isNotEmpty) {
                      Map<String, Object> request = {
                        'clientName': clientNameController.text,
                        'clientId': clientIdController.text,
                        'clientUri': clientUriController.text,
                        'protocolType': protocolTypeController.text,
                        'requireClientSecret': requireSecret,
                        'enabled': true,
                        'clientGrantTypes': clientGrantType,
                        'clientScopes': clientScopes,
                        'requirePkce': requirePkce,
                        'allowOfflineAccess': allowOfflineAccess,
                        'clientSecrets': clientSecretList
                      };

                      for (var client in widget.klijentiLista) {
                        if (client.clientId == clientIdController.text) {
                          return showDialog(
                              context: context,
                              builder: (context) {
                                return AlertDialog(
                                  title: Text('Klijent sa ID-om već postoji u bazi.'),
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

                      if (widget.klijent != null) {
                       

                        clientBloc.add(KlijentiUpdateEvent(klijent: request, klijentId: widget.klijent!.id!));
                        Navigator.of(context).pop();
                        return null;
                      }

                      clientBloc.add(KlijentiAddEvent(request: request));
                      Navigator.of(context).pop();
                      return showDialog(
                          context: context,
                          builder: (context) {
                            return AlertDialog(
                              title: Text('Uspješno dodan klijent.'),
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

                    } else {
                      ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack("Popunite obavezna polja!"));
                    }
                  },
                  text: 'Sačuvaj',
                ),
              ],
            ),
          ],
        ),
      ],
    );
  }

  Widget clientSecret() {
    String? validateDescription(String? value) {
      if (value == null || value.isEmpty) {
        return 'Unesite opis tajnog koda';
      }
      return null;
    }

    String? validateClientId(String? value) {
      if (value == null || value.isEmpty) {
        return 'Unesite vrijednost tajnog koda';
      }
      return null;
    }

    String? validateExpiration(String? value) {
      // You can add additional logic for validating expiration if needed
      return null;
    }

    String? validateType(String? value) {
      if (value == null || value.isEmpty) {
        return 'Unesite tip ClientSecret';
      }
      return null;
    }

    DateTime? _selectedDateTime;

    GlobalKey<FormState> _formKeySecret = GlobalKey<FormState>();

    Widget tabelaSecret() {
      return DataTable(
          showCheckboxColumn: false,
          columns: [
            DataColumn(label: Text('Description')),
            DataColumn(label: Text('Expiration')),
            DataColumn(label: Text('Type')),
            //DataColumn(label: Text('Created')),
          ],
          rows: clientSecretList.map((secret) {
            return DataRow(
              onSelectChanged: (value) async {
                if (widget.klijent != null) {
                  await clientSecretProvider.delete(secret.id, [secret, "ClientSecret"]);
                }

                setState(() {
                  clientSecretList = List.from(clientSecretList)..remove(secret);
                });
              },
              cells: [
                DataCell(Text(secret.description ?? '')),
                DataCell(Text(
                    "${DateTime.parse(secret.expiration!).day}. ${DateTime.parse(secret.expiration!).month}. ${DateTime.parse(secret.expiration!).year}, ${DateTime.parse(secret.expiration!).hour}:${DateTime.parse(secret.expiration!).minute}")),
                DataCell(Text(secret.expiration ?? '')),
              ],
            );
          }).toList());
    }

    return SingleChildScrollView(
      child: Column(
        children: [
          RichText(
              text: TextSpan(style: DefaultTextStyle.of(context).style, children: <TextSpan>[
            TextSpan(
                text: 'Unesite vrijednosti za ',
                style: TextStyle(
                  fontSize: 16.0,
                )),
            TextSpan(
              text: 'Client secret',
              style: TextStyle(
                fontStyle: FontStyle.italic,
                fontSize: 16.0,
              ),
            ),
            TextSpan(
                text: ' klijenta',
                style: TextStyle(
                  fontSize: 16.0,
                ))
          ])),
          Row(
            children: [
              Container(
                width: 400,
                child: Form(
                  key: _formKeySecret,
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      TextFormField(
                        controller: descriptionSecretController,
                        decoration: InputDecoration(labelText: 'Opis'),
                        validator: validateDescription,
                      ),
                      TextFormField(
                        controller: valueSecretController,
                        obscureText: true,
                        decoration: InputDecoration(labelText: 'Vrijednost'),
                        validator: validateClientId,
                      ),
                      TextFormField(
                        controller: typeController,
                        decoration: InputDecoration(labelText: 'Tip'),
                        validator: validateType,
                      ),
                      SizedBox(
                        height: 16,
                      ),
                      Row(
                        children: [
                          Container(
                            width: 300,
                            child: DateTimePickerWidget(
                              onDateTimeSelected: (DateTime selectedDate) {
                                _selectedDateTime = selectedDate;
                              },
                            ),
                          ),
                        ],
                      ),
                      MinimalisticButton(
                          text: "Dodaj",
                          onPressed: () {
                            if (!_formKeySecret.currentState!.validate() || _selectedDateTime == null) {
                              showDialog(
                                  context: context,
                                  builder: (BuildContext context) {
                                    return AlertDialog(
                                      title: Text('Unesite obavezne vrijednosti'),
                                      content: Text('Datum i vrijeme isteka, opis, vrijednost i tip tajnog koda'),
                                      actions: [
                                        TextButton(
                                          onPressed: () {
                                            Navigator.of(context).pop(); // Close the dialog
                                          },
                                          child: Text('Close'),
                                        ),
                                      ],
                                    );
                                  });
                              return;
                            }

                            if (_formKeySecret.currentState!.validate()) {
                              setState(() {
                                clientSecretList.add(ClientSecret(
                                    description: descriptionSecretController.text,
                                    expiration: _selectedDateTime?.toIso8601String(),
                                    type: typeController.text,
                                    value: valueSecretController.text,
                                    created: DateTime.now().toIso8601String()));
                              });
                            }
                          },
                          icons: Icon(
                            Icons.add,
                            color: Colors.blueAccent,
                          )),
                      Text("Izbrišite unos klikom na red"),
                      Container(
                        child: tabelaSecret(),
                      )
                    ],
                  ),
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }

  Widget basicInfo() {
    String? validateClientName(String? value) {
      if (value == null || value.isEmpty) {
        return 'Unesite ime klijenta';
      }
      return null;
    }

    String? validateClientId(String? value) {
      if (value == null || value.isEmpty) {
        return 'Unesite ID klijenta';
      }
      return null;
    }

    String? validateClientUri(String? value) {
      if (value == null || value.isEmpty) {
        return 'Unesite URI klijenta';
      }
      // Dodajte dodatnu logiku validacije po potrebi
      return null;
    }

    String? validateProtocolType(String? value) {
      if (value == null || value.isEmpty) {
        return 'Unesite vrstu protokola';
      }
      // Dodajte dodatnu logiku validacije po potrebi
      return null;
    }

    String? validateClientSecret(String? value) {
      if (value == null || value.isEmpty) {
        return 'Unesite vrstu protokola';
      }
      // Dodajte dodatnu logiku validacije po potrebi
      return null;
    }

    @override
    void initState() {
      super.initState();
    }

    return SingleChildScrollView(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          /* Row(
            children: [
              Checkbox(
                value: aktivan,
                onChanged: (bool? value) {
                  setState(() {
                    aktivan = value!;
                  });
                },
              ),
              Text('Aktiviraj'),
            ],
          ),*/
          Form(
            key: _formKey,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                TextFormField(
                  controller: clientNameController,
                  decoration: InputDecoration(labelText: 'Ime klijenta'),
                  validator: validateClientName,
                ),
                TextFormField(
                  controller: clientIdController,
                  decoration: InputDecoration(labelText: 'ID klijenta'),
                  validator: validateClientId,
                ),
                TextFormField(
                  controller: clientUriController,
                  decoration: InputDecoration(labelText: 'URI klijenta'),
                  validator: validateClientUri,
                ),
                TextFormField(
                  controller: protocolTypeController,
                  decoration: InputDecoration(labelText: 'Vrsta protokola'),
                  validator: validateProtocolType,
                ),
              ],
            ),
          ),
          SizedBox(
            height: 16,
          ),
          Row(
            children: [
              Checkbox(
                value: requirePkce,
                onChanged: (bool? value) {
                  setState(() {
                    if (value!) {
                      requireSecret = false;
                      requirePkce = value;
                    } else {
                      requirePkce = value;
                    }
                  });
                },
              ),
              Text('Require PKCE'),
            ],
          ),
          Row(
            children: [
              Checkbox(
                value: requireSecret,
                onChanged: (bool? value) {
                  setState(() {
                    if (value!) {
                      requirePkce = false;
                      requireSecret = value;
                    } else {
                      requireSecret = value;
                    }
                  });
                },
              ),
              Text('Require Secret'),
            ],
          ),
          Row(
            children: [
              Checkbox(
                value: allowOfflineAccess,
                onChanged: (bool? value) {
                  setState(() {
                    allowOfflineAccess = value!;
                  });
                },
              ),
              Text('Allow Offline Access'),
            ],
          ),
          SizedBox(
            height: 16,
          ),
        ],
      ),
    );
  }

  Widget scopeKlijenta(BuildContext context) {
    final ApiScopesBloc scopesBloc = BlocProvider.of<ApiScopesBloc>(context);

    return SingleChildScrollView(
      child: Column(
        children: [
          RichText(
            text: TextSpan(style: DefaultTextStyle.of(context).style, children: <TextSpan>[
              TextSpan(
                text: 'Odaberi ',
                style: TextStyle(
                  fontSize: 16.0,
                ),
              ),
              TextSpan(
                text: 'scopes',
                style: TextStyle(
                  fontStyle: FontStyle.italic,
                  fontSize: 16.0,
                ),
              ),
              TextSpan(
                text: ' klijenta',
                style: TextStyle(
                  fontSize: 16.0,
                ),
              ),
            ]),
          ),
          BlocConsumer<ApiScopesBloc, ApiScopesState>(
            bloc: scopesBloc,
            listener: (context, state) {
              // TODO: implement listener
            },
            builder: (context, state) {
              if (state is ApiScopesLoadingState) {
                return CircularProgressIndicator();
              }
              if (state is ApiScopesDataLoadedState) {
                return ListView.builder(
                  shrinkWrap: true,
                  itemCount: state.apiScopes.length,
                  itemBuilder: (context, index) {
                    final apiScope = state.apiScopes[index];
                    final bool hasClientScope = clientScopes.where((x) => true).select((element, index) => element.scope).contains(apiScope.name);
                    return CheckboxListTile(
                      title: Text(apiScope.displayName ?? ""),
                      value: hasClientScope,
                      onChanged: (value) {
                        setState(() {
                          if (value!) {
                            clientScopes.add(ClientScope(scope: apiScope.name));
                            //clientScopesMap.add({'scope': clientScopes.firstWhere((element) => element.scope == apiScope.name)});
                          } else {
                            clientScopes.remove(clientScopes.firstWhere((element) => element.scope == apiScope.name));
                          }
                        });
                      },
                    );
                  },
                );
              } else {
                return Center(
                  child: Text("Nema podataka"),
                );
              }
            },
          ),
          SizedBox(
            height: 16,
          ),
          Divider(
            height: 20,
            color: Colors.grey,
          ),
          SizedBox(
            height: 16,
          ),
          RichText(
            text: TextSpan(style: DefaultTextStyle.of(context).style, children: <TextSpan>[
              TextSpan(
                text: 'Odaberi ',
                style: TextStyle(
                  fontSize: 16.0,
                ),
              ),
              TextSpan(
                text: 'GrantTypes',
                style: TextStyle(
                  fontStyle: FontStyle.italic,
                  fontSize: 16.0,
                ),
              ),
              TextSpan(
                text: ' klijenta',
                style: TextStyle(
                  fontSize: 16.0,
                ),
              ),
            ]),
          ),
          Container(
            height: 300,
            child: ListView.builder(
              itemCount: allowedGrantTypesMap.length,
              itemBuilder: (context, index) {
                String key = allowedGrantTypesMap[index].keys.first;
                String value = allowedGrantTypesMap[index][key]!;
                bool isChecked = clientGrantType.where((element) => true).select((element, index) => element.grantType).contains(key);

                return CheckboxListTile(
                  title: Text(value),
                  value: isChecked,
                  onChanged: (bool? value) {
                    setState(() {
                      if (value!) {
                        clientGrantType.add(ClientGrantType(grantType: allowedGrantTypesMap[index].keys.first));
                      } else {
                        clientGrantType.removeWhere((element) => element.grantType == allowedGrantTypesMap[index].keys.first);
                      }
                    });
                  },
                );
              },
            ),
          )
        ],
      ),
    );
  }
}
