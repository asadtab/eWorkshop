import 'package:flutter/material.dart';

class AddScopeDialog extends StatefulWidget {
  const AddScopeDialog({super.key});

  @override
  State<AddScopeDialog> createState() => _AddScopeDialogState();
}

class _AddScopeDialogState extends State<AddScopeDialog> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  final TextEditingController _scopeTipController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      content: Container(
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Form(
            key: _formKey,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                TextFormField(
                  controller: _scopeTipController,
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
                  onPressed: () {
                    if (_formKey.currentState!.validate()) {}
                  },
                  child: Text('Potvrdi'),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
