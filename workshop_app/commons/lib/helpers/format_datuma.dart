import 'package:intl/intl.dart';

class FormatirajDatum{
    static String formatiraj(DateTime datum){
      return DateFormat("dd.MM.yyyy").format(datum);
      //return datum.day.toString() + "." + datum.month.toString() + "." + datum.year.toString();
    }
}