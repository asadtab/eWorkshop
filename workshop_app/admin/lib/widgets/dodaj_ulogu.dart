import 'package:admin/bloc/uloge/uloge_bloc.dart';
import 'package:commons/models/uloge.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class DodajUlogu extends StatefulWidget {
  List<Uloge> uloge = [];

  DodajUlogu(this.uloge);

  @override
  _DodajUloguState createState() => _DodajUloguState();
}

class _DodajUloguState extends State<DodajUlogu> {
  final TextEditingController _ulogeNazivController = TextEditingController();
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    final UlogeBloc ulogeBloc = BlocProvider.of<UlogeBloc>(context);

    return AlertDialog(
      content: SingleChildScrollView(
        child: Container(
          height: 200,
          child: Center(
            child: Padding(
              padding: const EdgeInsets.all(16.0),
              child: Form(
                key: _formKey,
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    TextFormField(
                      controller: _ulogeNazivController,
                      decoration: InputDecoration(labelText: 'Naziv uloge'),
                      validator: (value) {
                        if (value == null || value.isEmpty) {
                          return 'Unesite naziv uloge';
                        }
                        return null;
                      },
                    ),
                    SizedBox(height: 16.0),
                    ElevatedButton(
                        child: Text('Potvrdi'),
                        onPressed: () {
                          if (!_formKey.currentState!.validate()) {
                            return;
                          }

                          for (var uloga in widget.uloge) {
                            if (uloga.name!.toLowerCase().contains(_ulogeNazivController.text)) {
                              showDialog(
                                  context: context,
                                  builder: (context) {
                                    return AlertDialog(title: Text('Uloga sa tim nazivom već postoji.'), actions: [
                                      TextButton(
                                        onPressed: () {
                                          Navigator.pop(context);
                                        },
                                        child: Text('OK'),
                                      ),
                                    ]);
                                  });
                              return;
                            }
                          }

                          if (_formKey.currentState!.validate()) {
                            ulogeBloc.add(UlogeAdd(nazivUloge: _ulogeNazivController.text));
                          }
                          _ulogeNazivController.text = "";
                          Navigator.pop(context);
                          ulogeBloc.add(UlogeRequest());
                        }),
                  ],
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }

  void poruka(String msg) {
    ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack(msg));
  }
}
