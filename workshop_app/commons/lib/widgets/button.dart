import 'package:flutter/material.dart';

class MinimalisticButton extends StatelessWidget {
  final String text;
  final Function onPressed;
  final Icon? icons;

  void opcija() {}
  const MinimalisticButton({required this.text, required this.onPressed, this.icons});

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.all(8.0),
      child: ElevatedButton(
        onPressed: () {
          onPressed();
        },
        style: ButtonStyle(
          backgroundColor: MaterialStateProperty.all(Colors.grey[300]),
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
              color: Colors.black,
            ),
          )
        ]),
      ),
    );
  }
}
