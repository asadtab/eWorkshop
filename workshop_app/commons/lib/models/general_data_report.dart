import 'package:commons/models/servis_report.dart';

class ReportGeneralData {
  String organ;
  String rukovodilac;
  String brojRadnogNaloga;
  String kontoBroj;
  String odobrio;
  String preuzeo;

  ReportGeneralData({
    this.organ = '',
    this.rukovodilac = 'Enes Memić, dipl.eng.el.',
    this.brojRadnogNaloga = '',
    this.kontoBroj = '',
    this.odobrio = '',
    this.preuzeo = '',
  });

  ReportGeneralData.fromServisReport(ServisReport r)
      : organ = r.nadzor ?? '',
        rukovodilac = "Enes Memić, dipl.eng.el",
        brojRadnogNaloga = r.brojRadnogNaloga ?? '',
        kontoBroj = r.kontoBroj ?? '',
        odobrio = r.odobrio ?? '',
        preuzeo = r.preuzeo ?? '';
}