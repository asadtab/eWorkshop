import 'package:flutter/material.dart';

class MyTooltip{
static Widget buildTooltipIcon({
  required String text,
  required IconData icon,
  Color iconColor = Colors.black,
  Color textColor = Colors.white,
  Color backgroundColor = Colors.black87,
}) {
  return Tooltip(
    message: text,
    textStyle: TextStyle(color: textColor),
    decoration: BoxDecoration(
      color: backgroundColor,
      borderRadius: BorderRadius.circular(4),
    ),
    child: Icon(icon, color: iconColor),
  );
}}