import 'package:admin/bloc/user/bloc/korisnici_bloc.dart';
import 'package:commons/models/korisnik.dart';
import 'package:commons/providers/korisnici_provider.dart';
import 'package:commons/providers/uloge_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:provider/provider.dart';

class DodajKorisnikaDialog extends StatefulWidget {
  List<Korisnik> korisnici = [];
  Korisnik? korisnik;

  DodajKorisnikaDialog(this.korisnik, this.korisnici);

  @override
  _DodajKorisnikaDialogState createState() => _DodajKorisnikaDialogState();
}

class _DodajKorisnikaDialogState extends State<DodajKorisnikaDialog> {
  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
        child: AlertDialog(
      content: Container(
        width: double.maxFinite,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                IconButton(
                  icon: Icon(Icons.cancel),
                  onPressed: (() {
                    Navigator.pop(context);
                  }),
                ),
              ],
            ),
            SingleChildScrollView(child: AddUserForm(widget.korisnik, widget.korisnici)),

            // Add more pages as needed
          ],
        ),
      ),
    ));
  }
}

class AddUserForm extends StatefulWidget {
  Korisnik? korisnik;
  List<Korisnik> korisnici = [];

  AddUserForm(this.korisnik, this.korisnici);
  @override
  _AddUserFormState createState() => _AddUserFormState();
}

class _AddUserFormState extends State<AddUserForm> {
  final TextEditingController _imeController = TextEditingController();
  final TextEditingController _prezimeController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  UlogeProvider? ulogeProvider;
  KorisniciProvider? korisniciProvider;

  List<String> uloge = [];

  List<String> errors = [];

  RegExp nonAlphanumericRegex = RegExp(r'[!@#$%^&*()\-_=+`~,.<>;:/?|\\{}\[\]]');
  RegExp digitRegex = RegExp(r'[0-9]');
  RegExp uppercaseRegex = RegExp(r'[A-Z]');

  @override
  void initState() {
    ulogeProvider = context.read<UlogeProvider>();
    korisniciProvider = context.read<KorisniciProvider>();

    _imeController.text = widget.korisnik?.ime ?? "";
    _prezimeController.text = widget.korisnik?.prezime ?? "";
    _emailController.text = widget.korisnik?.email ?? "";

    _fetchData(null);

    super.initState();
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    final response = await ulogeProvider?.get(map, "Uloge");

    setState(() {
      for (var element in response!) {
        uloge.add(element.name!);
      }
    });
  }

  List<String> selectedRoles = [];

  bool isSelected = false;
  bool aktivan = true;

  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    final KorisniciBloc korisniciBloc = BlocProvider.of<KorisniciBloc>(context);

    return Form(
      key: _formKey,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: [
          TextFormField(
            controller: _imeController,
            decoration: InputDecoration(labelText: 'Ime'),
            validator: (value) {
              if (value!.isEmpty) {
                return 'Obavezno polje';
              }
              return null;
            },
          ),
          TextFormField(
            controller: _prezimeController,
            decoration: InputDecoration(labelText: 'Prezime'),
            validator: (value) {
              if (value!.isEmpty) {
                return 'Obavezno polje';
              }
              return null;
            },
          ),
          TextFormField(
            controller: _emailController,
            decoration: InputDecoration(labelText: 'Email'),
            keyboardType: TextInputType.emailAddress,
            validator: (value) {
              if (value!.isEmpty) {
                return 'Obavezno polje';
              }
              return null;
            },
          ),
          TextFormField(
            controller: _passwordController,
            decoration: InputDecoration(labelText: 'Password'),
            obscureText: true,
            validator: (value) {
              if (value!.isEmpty) {
                return 'Obavezno polje';
              }
              return null;
            },
          ),
          SizedBox(height: 16.0),

          // List Tiles for Roles
          Text('Uloge', style: Theme.of(context).textTheme.bodyMedium),
          if (!isSelected)
            Container(
                width: 300,
                child: Column(
                  children: uloge.map((role) {
                    return CheckboxListTile(
                      title: Text(role),
                      value: selectedRoles.contains(role),
                      onChanged: (bool? value) {
                        setState(() {
                          if (value!) {
                            selectedRoles.add(role);
                          } else {
                            selectedRoles.remove(role);
                          }
                        });
                      },
                    );
                  }).toList(),
                )),

          SizedBox(height: 16.0),

          SizedBox(height: 16.0),
          Row(
            children: [
              Text("Aktivan"),
              Checkbox(
                value: aktivan,
                semanticLabel: "Asad",
                onChanged: (bool? value) {
                  setState(() {
                    aktivan = value!;
                  });
                },
              ),
            ],
          ),

          SizedBox(height: 16.0),

          MinimalisticButton(
              text: 'Submit',
              onPressed: () async {
                if (!nonAlphanumericRegex.hasMatch(_passwordController.text)) {
                  errors.add("Password mora sadržavati barem jedan znakovni karakter.");
                }
                if (!digitRegex.hasMatch(_passwordController.text)) {
                  errors.add("Password mora sadržavati barem jedan karakter koji je broj.");
                }
                if (!uppercaseRegex.hasMatch(_passwordController.text)) {
                  errors.add("Password mora sadržavati barem jedno veliko slovo.");
                }

                if (errors.isNotEmpty) {
                  return showDialog(
                      context: context,
                      builder: (context) {
                        return AlertDialog(
                          title: Text('Password ne zadovoljava kriterij'),
                          content: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            mainAxisSize: MainAxisSize.min,
                            children: errors.map((error) => Text(error)).toList(),
                          ),
                          actions: [
                            TextButton(
                              onPressed: () {
                                errors.clear();
                                Navigator.pop(context);
                              },
                              child: Text('OK'),
                            ),
                          ],
                        );
                      });
                }

                if (_formKey.currentState!.validate()) {
                  var request = {
                    "email": _emailController.text,
                    "passwordHash": _passwordController.text,
                    "ime": _imeController.text,
                    "prezime": _prezimeController.text,
                    "uloge": selectedRoles,
                    "status": aktivan
                  };

                  for (var users in widget.korisnici) {
                    if ('${_imeController.text.toLowerCase()}.${_prezimeController.text.toLowerCase()}' == users.userName.toString()) {
                      return showDialog(
                          context: context,
                          builder: (context) {
                            return AlertDialog(
                              title: Text('Korisničko ime je već u upotrebi'),
                              actions: [
                                TextButton(
                                  onPressed: () {
                                    errors.clear();
                                    Navigator.pop(context);
                                  },
                                  child: Text('OK'),
                                ),
                              ],
                            );
                          });
                    }
                  }

                  try {
                    await korisniciProvider!.insert(request, "Account", true);
                    korisniciBloc.add(KorisniciLoad());

                    emptyBox();
                    setState(() {
                      selectedRoles = [];
                    });
                    Navigator.pop(context);
                  } catch (e) {
                    if (e
                        .toString()
                        .contains("Username '${_imeController.text.toLowerCase()}.${_prezimeController.text.toLowerCase()}' is already taken.")) {
                      return showDialog(
                          context: context,
                          builder: (context) {
                            return AlertDialog(
                              title: Text('Korisničko ime je već u upotrebi.'),
                              actions: [
                                TextButton(
                                  onPressed: () {
                                    errors.clear();
                                    Navigator.pop(context);
                                  },
                                  child: Text('OK'),
                                ),
                              ],
                            );
                          });
                    }

                    poruka(e.toString());
                    return;
                  }
                  poruka("Korisnik je uspješno dodan");
                }
              }),
        ],
      ),
    );
  }

  void poruka(String msg) {
    ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack(msg));
  }

  void emptyBox() {
    _imeController.clear();
    _prezimeController.clear();
    _emailController.clear();
    _passwordController.clear();
  }
}
