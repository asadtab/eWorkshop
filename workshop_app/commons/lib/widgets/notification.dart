import 'package:flutter/material.dart';

class CustomNotification {
  static SnackBar infoSnack(String? poruka) {
    return SnackBar(
      content: Container(alignment: Alignment.topLeft, child: Text(poruka.toString())),
      action: SnackBarAction(
        label: 'OK',
        onPressed: () {
          // Code to execute.
        },
      ),
      behavior: SnackBarBehavior.floating,
    );
  }
}
