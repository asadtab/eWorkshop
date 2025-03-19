class FormatirajDatum{
    static String formatiraj(DateTime datum){

      return datum.day.toString() + "." + datum.month.toString() + "." + datum.year.toString();
    }
}