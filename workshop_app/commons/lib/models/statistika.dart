import 'package:json_annotation/json_annotation.dart';

part 'statistika.g.dart';

@JsonSerializable()
class Statistika {
  int? aktivniRadniZadaci;
  int? radniZadaciUkupno;
  int? fakturisaniRadniZadaci;
  int? zavrseniRadniZadaci;
  int? neaktivniRadniZadaci;
  int? servisiraniUredjaji;
  int? aktivniUredjaji;
  int? neaktivniUredjaji;
  int? poslaniUredjaji;
  int? uredjajiUkupno;
  int? spremniUredjaji;
  int? rezervniDijeloviUredjaji;
  int? radniZadaciUredjaji;
  int? korisniciUkupno;

  Statistika();

  factory Statistika.fromJson(Map<String, dynamic> json) => _$StatistikaFromJson(json);

  Map<String, dynamic> toJson() => _$StatistikaToJson(this);
}
