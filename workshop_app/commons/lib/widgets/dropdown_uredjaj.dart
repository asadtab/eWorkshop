import 'package:flutter/material.dart';

class DropdownUredjaj extends StatelessWidget {
  final String value;         
  final List<String> opcije;
  final ValueChanged<String> onChanged;

  const DropdownUredjaj({
    super.key,
    required this.value,
    required this.opcije,
    required this.onChanged,
  });

  @override
  Widget build(BuildContext context) {
    return DropdownButton<String>(
      value: value,
      elevation: 16,
      padding: const EdgeInsets.all(8),
      hint: const Text("Odaberi status"),
      style: const TextStyle(color: Colors.black),
      borderRadius: const BorderRadius.all(Radius.circular(10)),
      underline: Container(height: 5, color: const Color(0xFFa2cdbc)),
      onChanged: (String? val) {
        if (val != null) onChanged(val); 
      },
      items: opcije
          .map((v) => DropdownMenuItem(value: v, child: Text(v)))
          .toList(),
    );
  }
}