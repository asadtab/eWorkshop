import 'package:commons/models/komponenta.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:json_annotation/json_annotation.dart';

part 'servis_report.g.dart';

@JsonSerializable(explicitToJson: true)
class ServisReport {
  int radniZadatakId;
  DateTime datumPrijema;
  DateTime datumServisiranja;
  String brojRadnogNaloga;
  String kontoBroj;
  int evBroj;
  String tipUredjaja;
  String koda;
  String serijskiBroj;
  String opisKodPrijema;
  String opisAktivnostiServisiranja;
  String servisiraoIIspitao;
  String odobrio;
  String nadzor;
  int brojServisa;
  List<Komponenta> zamijenjeniElementi;
  String? preuzeo;
  DateTime? datumPreuzimanja;
  Uredjaj uredjaj;

  ServisReport({
    required this.radniZadatakId,
    required this.datumPrijema,
    required this.datumServisiranja,
    required this.brojRadnogNaloga,
    required this.kontoBroj,
    required this.evBroj,
    required this.tipUredjaja,
    required this.koda,
    required this.serijskiBroj,
    required this.opisKodPrijema,
    required this.opisAktivnostiServisiranja,
    required this.servisiraoIIspitao,
    required this.odobrio,
    required this.nadzor,
    required this.brojServisa,
    required this.zamijenjeniElementi,
    this.preuzeo,
    this.datumPreuzimanja,
    required this.uredjaj
  });

  factory ServisReport.fromJson(Map<String, dynamic> json) =>
      _$ServisReportFromJson(json);

  Map<String, dynamic> toJson() => _$ServisReportToJson(this);
}