import 'package:flutter/material.dart';

class buildIcon {
 static  Widget buildStatusCellUredjaj(String? stateMachine) {
  final status = stateMachine ?? "";
  IconData icon;
  Color color;
  String label;

  switch (status) {
    case "idle":
      icon = Icons.power_off;
      color = Colors.grey;
      label = "Neaktivni";
      break;
    case "active":
      icon = Icons.power;
      color = Colors.green;
      label = "Aktivni";
      break;
    case "fix":
      icon = Icons.build;
      color = Colors.orange;
      label = "Servisirani";
      break;
    case "ready":
      icon = Icons.check_circle;
      color = Colors.blue;
      label = "Spremni";
      break;
    case "out":
      icon = Icons.local_shipping;
      color = Colors.brown;
      label = "Poslani";
      break;
    case "parts":
      icon = Icons.inventory_2;
      color = Colors.purple;
      label = "Rezervni";
      break;
    case "task":
      icon = Icons.assignment;
      color = Colors.teal;
      label = "Radni zadatak";
      break;
    default:
      icon = Icons.help_outline;
      color = Colors.black45;
      label = status;
      break;
  }

  return Row(
    children: [
      Icon(icon, color: color, size: 18),
      const SizedBox(width: 6),
      Flexible(child: Text(label, overflow: TextOverflow.ellipsis)),
    ],
  );
} 
static Widget buildStatusCellZadatak(String? status) {
  IconData icon;
  Color color;
  String label;

  switch (status) {
    case "idle":
      icon = Icons.power_off;
      color = Colors.grey;
      label = "Neaktivni";
      break;
    case "active":
      icon = Icons.play_arrow;
      color = Colors.green;
      label = "Aktivni";
      break;
    case "done":
      icon = Icons.check_circle_outline;
      color = Colors.blue;
      label = "Završeni";
      break;
    case "invoice":
      icon = Icons.receipt_long;
      color = Colors.amber.shade700;
      label = "Fakturisano";
      break;
    default:
      icon = Icons.help_outline;
      color = Colors.black54;
      label = status ?? "Nepoznat";
      break;
  }

  return Row(
    children: [
      Icon(icon, color: color, size: 18),
      const SizedBox(width: 6),
      Flexible(child: Text(label, overflow: TextOverflow.ellipsis, style: TextStyle(fontSize: 17, fontWeight: FontWeight.bold),)),
    ],
  );
}

}