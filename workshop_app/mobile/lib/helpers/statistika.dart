import 'package:commons/models/radni_zadatak_uredjaj.dart';

class Statistika {
  static double postotak(List<RadniZadatakUredjaj> uredjaji) {
    int brojac = 0;
    double progres = 0;

    for (var i = 0; i < uredjaji.length; i++) {
      if (uredjaji[i].uredjajStatus == "fix" || uredjaji[i].uredjajStatus == "ready" || uredjaji[i].uredjajStatus == "out") {
        brojac++;
      }

      progres = brojac / uredjaji.length;
    }

    return (progres * 100).truncateToDouble();
  }
}
