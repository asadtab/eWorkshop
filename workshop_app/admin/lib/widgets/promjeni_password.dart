import 'package:flutter/material.dart';
import 'package:commons/providers/korisnici_provider.dart';
import 'package:provider/provider.dart';

class ChangePasswordDialog extends StatefulWidget {
  final int userId; // User ID for password update

  ChangePasswordDialog({required this.userId});

  @override
  _ChangePasswordDialogState createState() => _ChangePasswordDialogState();
}

class _ChangePasswordDialogState extends State<ChangePasswordDialog> {
  final _formKey = GlobalKey<FormState>();
  final TextEditingController _oldPasswordController = TextEditingController();
  final TextEditingController _newPasswordController = TextEditingController();
  final TextEditingController _confirmPasswordController = TextEditingController();

  bool _isLoading = false;
  List<String> _errors = [];

  final RegExp _nonAlphanumericRegex = RegExp(r'[!@#$%^&*()\-_=+`~,.<>;:/?|\\{}\[\]]');
  final RegExp _digitRegex = RegExp(r'[0-9]');
  final RegExp _uppercaseRegex = RegExp(r'[A-Z]');

  @override
  Widget build(BuildContext context) {
    final korisniciProvider = context.read<KorisniciProvider>();

    return AlertDialog(
      title: Text('Promjena lozinke'),
      content: SingleChildScrollView(
        child: Form(
          key: _formKey,
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              TextFormField(
                controller: _oldPasswordController,
                decoration: InputDecoration(labelText: 'Stara lozinka'),
                obscureText: true,
                validator: (value) => value!.isEmpty ? 'Obavezno polje' : null,
              ),
              SizedBox(height: 12),
              TextFormField(
                controller: _newPasswordController,
                decoration: InputDecoration(labelText: 'Nova lozinka'),
                obscureText: true,
                validator: (value) {
                  if (value!.isEmpty) return 'Obavezno polje';
                  if (!_nonAlphanumericRegex.hasMatch(value)) return 'Mora sadržavati barem jedan specijalni znak';
                  if (!_digitRegex.hasMatch(value)) return 'Mora sadržavati barem jedan broj';
                  if (!_uppercaseRegex.hasMatch(value)) return 'Mora sadržavati barem jedno veliko slovo';
                  return null;
                },
              ),
              SizedBox(height: 12),
              TextFormField(
                controller: _confirmPasswordController,
                decoration: InputDecoration(labelText: 'Potvrdi novu lozinku'),
                obscureText: true,
                validator: (value) {
                  if (value!.isEmpty) return 'Obavezno polje';
                  if (value != _newPasswordController.text) return 'Lozinke se ne podudaraju';
                  return null;
                },
              ),
              if (_errors.isNotEmpty)
                Padding(
                  padding: const EdgeInsets.only(top: 10),
                  child: Column(
                    children: _errors.map((error) => Text(error, style: TextStyle(color: Colors.red))).toList(),
                  ),
                ),
            ],
          ),
        ),
      ),
      actions: [
        TextButton(
          onPressed: () => Navigator.pop(context),
          child: Text('Odustani'),
        ),
        ElevatedButton(
          onPressed: _isLoading ? null : () async {
            if (_formKey.currentState!.validate()) {
              setState(() => _isLoading = true);
              try {
                await korisniciProvider.insert({"userId": widget.userId,
                  "currentPassword": _oldPasswordController.text,
                  "newPassword": _newPasswordController.text,
                }, "Korisnici/PromijeniPassword");

                Navigator.pop(context);
                ScaffoldMessenger.of(context).showSnackBar(
                  SnackBar(content: Text('Lozinka uspješno promijenjena')),
                );
              } catch (e) {
                setState(() => _errors = [e.toString()]);
              }
              setState(() => _isLoading = false);
            }
          },
          child: _isLoading ? CircularProgressIndicator() : Text('Promijeni lozinku'),
        ),
      ],
    );
  }
}
