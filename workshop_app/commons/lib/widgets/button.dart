import 'package:flutter/material.dart';

class MinimalisticButton extends StatelessWidget {
  final String text;
  final Function onPressed;
  final Icon? icons;
  final Color? color;
  final Color? textColor;

  void opcija() {}
  const MinimalisticButton({required this.text, required this.onPressed, this.icons, this.color, this.textColor});

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.all(8.0),
      child: ElevatedButton(
        onPressed: () {
          onPressed();
        },
        style: ButtonStyle(
          backgroundColor: color == null ? MaterialStateProperty.all(Colors.grey[300]): MaterialStateProperty.all(color),
          padding: MaterialStateProperty.all(EdgeInsets.symmetric(horizontal: 16.0, vertical: 8.0)),
        ),
        child: Row(mainAxisSize: MainAxisSize.min, mainAxisAlignment: MainAxisAlignment.spaceBetween, children: [
          if (icons != null) icons!,
          SizedBox(
            width: 8,
          ),
          Text(
            text,
            style: TextStyle(
              fontSize: 16.0,
              color: textColor == null ? Colors.black: textColor,
            ),
          )
        ]),
      ),
    );
  }
}
