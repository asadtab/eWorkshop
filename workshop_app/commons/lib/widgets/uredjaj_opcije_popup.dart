import 'package:commons/models/uredjaj.dart';
import 'package:commons/widgets/delete_dialog.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';

class OpcijePupup extends StatelessWidget {   // bez _ prefiksa = public
  final Uredjaj uredjaj;
  final Future<void> Function(Uredjaj)? onDelete;

  const OpcijePupup({
    super.key,
    required this.uredjaj,
    this.onDelete,
  });

  @override
  Widget build(BuildContext context) {
    return PopupMenuButton<String>(
      onSelected: (_) => _handleDelete(context),
      itemBuilder: (_) => [
        const PopupMenuItem(value: 'delete', child: Text('Izbriši')),
      ],
    );
  }

  void _handleDelete(BuildContext context) {
    if (uredjaj.status != "idle") {
      ScaffoldMessenger.of(context).showSnackBar(
        CustomNotification.infoSnack("Samo neaktivni uređaji se mogu izbrisati."),
      );
      return;
    }
    showDialog(
      context: context,
      builder: (_) => DeleteDialog(uredjaj: uredjaj, onDelete: onDelete!),
    );
  }
} 