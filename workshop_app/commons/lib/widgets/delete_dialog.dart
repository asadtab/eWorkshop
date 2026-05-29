import 'package:commons/models/uredjaj.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';

class DeleteDialog extends StatelessWidget {
  final Uredjaj uredjaj;
  final Future<void> Function(Uredjaj) onDelete;

  const DeleteDialog({
    required this.uredjaj,
    required this.onDelete,
  });

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text("Da li želite izbrisati uređaj?"),
      content: SizedBox(
        width: 400,
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          children: [
            MinimalisticButton(
              text: "Potvrdi",
              icons: const Icon(Icons.save, color: Colors.blueAccent),
              onPressed: () async {
                await onDelete(uredjaj);
                Navigator.pop(context);
                ScaffoldMessenger.of(context).showSnackBar(
                  CustomNotification.infoSnack("Uređaj je uspješno izbrisan"),
                );
              },
            ),
            MinimalisticButton(
              text: "Poništi",
              icons: const Icon(Icons.cancel, color: Colors.redAccent),
              onPressed: () => Navigator.pop(context),
            ),
          ],
        ),
      ),
    );
  }
}