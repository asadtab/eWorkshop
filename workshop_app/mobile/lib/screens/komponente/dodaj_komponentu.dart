import 'package:commons/models/komponenta.dart';
import 'package:commons/providers/komponente_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/helpers/bottom_bar.dart';
import 'package:workshop_app/helpers/common_widget.dart';

class DodajKomponentu extends StatefulWidget {
  final Komponenta? urediKomponentu;

  const DodajKomponentu({this.urediKomponentu, Key? key}) : super(key: key);

  @override
  _DodajKomponentuState createState() => _DodajKomponentuState();
}

class _DodajKomponentuState extends State<DodajKomponentu> {
  final TextEditingController _nazivController = TextEditingController();
  final TextEditingController _tipController = TextEditingController();
  final TextEditingController _vrijednostController = TextEditingController();

  final _formKey = GlobalKey<FormState>();

  late KomponenteProvider komponenteProvider;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    if (widget.urediKomponentu != null) {
      widget.urediKomponentu?.opis = "test";
    }

    _nazivController.text = widget.urediKomponentu?.naziv ?? "";
    _tipController.text = widget.urediKomponentu?.tip ?? "";
    _vrijednostController.text = widget.urediKomponentu?.vrijednost ?? "";

    komponenteProvider = context.read<KomponenteProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Dodaj Komponentu'),
      ),
      bottomNavigationBar: MyBottomBar(),
      floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
      floatingActionButton: FloatingActionButton(
        onPressed: () async {
          var request = {'naziv': _nazivController.text, 'vrijednost': _vrijednostController.text, 'tip': _tipController.text};

          if (widget.urediKomponentu != null && _formKey.currentState!.validate()) {
            try {
              await komponenteProvider.update(widget.urediKomponentu!.komponentaId, request, "Komponente");
            } catch (e) {
              ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
            }
          } else if (_formKey.currentState!.validate()) {
            try {
              await komponenteProvider.insert(request, "Komponente");
            } catch (e) {
              ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
            }
          }
        },
        child: Icon(Icons.done),
      ),
      body: Center(
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Form(
            key: _formKey,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                TextFormField(
                  controller: _nazivController,
                  decoration: InputDecoration(
                    labelText: 'Naziv',
                    border: OutlineInputBorder(),
                  ),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Naziv cannot be empty';
                    }
                    return null;
                  },
                ),
                SizedBox(height: 16.0),
                TextFormField(
                  controller: _tipController,
                  decoration: InputDecoration(
                    labelText: 'Tip',
                    border: OutlineInputBorder(),
                  ),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Tip cannot be empty';
                    }
                    return null;
                  },
                ),
                SizedBox(height: 16.0),
                TextFormField(
                  controller: _vrijednostController,
                  decoration: InputDecoration(
                    labelText: 'Vrijednost',
                    border: OutlineInputBorder(),
                  ),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Vrijednost cannot be empty';
                    }
                    return null;
                  },
                ),
                SizedBox(height: 16.0),
                ElevatedButton(
                  onPressed: () {},
                  child: Text('Submit'),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
