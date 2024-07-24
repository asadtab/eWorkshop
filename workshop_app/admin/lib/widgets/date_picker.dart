import 'package:flutter/material.dart';

class DateTimePickerWidget extends StatefulWidget {
  final Function(DateTime)? onDateTimeSelected;

  DateTimePickerWidget({Key? key, this.onDateTimeSelected}) : super(key: key);

  @override
  _DateTimePickerWidgetState createState() => _DateTimePickerWidgetState();
}

class _DateTimePickerWidgetState extends State<DateTimePickerWidget> {
  DateTime? _selectedDateTime;
  String? _errorText;

  Future<void> _selectDateTime(BuildContext context) async {
    final DateTime? pickedDate = await showDatePicker(
      context: context,
      initialDate: _selectedDateTime ?? DateTime.now(),
      firstDate: DateTime.now(),
      lastDate: DateTime(2101),
    );

    if (pickedDate != null) {
      final TimeOfDay? pickedTime = await showTimePicker(
        context: context,
        initialTime: TimeOfDay.fromDateTime(_selectedDateTime ?? DateTime.now()),
      );

      if (pickedTime != null) {
        final DateTime selectedDateTime = DateTime(
          pickedDate.year,
          pickedDate.month,
          pickedDate.day,
          pickedTime.hour,
          pickedTime.minute,
        );

        setState(() {
          _selectedDateTime = selectedDateTime;
          _errorText = null; // Clear error text when a valid date and time are selected
          widget.onDateTimeSelected?.call(selectedDateTime);
        });
      } else {
        // Set error text if time is not selected
        setState(() {
          _errorText = 'Odaberite vrijeme';
        });
      }
    } else {
      // Set error text if date is not selected
      setState(() {
        _errorText = 'Odaberite datum';
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        InkWell(
          onTap: () => _selectDateTime(context),
          child: InputDecorator(
            decoration: InputDecoration(
              labelText: 'Datum i vrijeme isteka',
              hintText: 'Tap to select date and time',
              border: OutlineInputBorder(),
              errorText: _errorText,
            ),
            child: Text(
              _selectedDateTime != null
                  ? "${_selectedDateTime!.toLocal().day}. ${_selectedDateTime!.toLocal().month}. ${_selectedDateTime!.toLocal().year}  ${_selectedDateTime!.toLocal().hour}:${_selectedDateTime!.toLocal().minute}  "
                  : 'Odaberite datum i vrijeme',
            ),
          ),
        ),
      ],
    );
  }
}
