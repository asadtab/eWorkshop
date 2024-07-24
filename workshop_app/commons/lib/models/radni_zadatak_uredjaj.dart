import 'package:json_annotation/json_annotation.dart';

part 'radni_zadatak_uredjaj.g.dart';

@JsonSerializable()
class RadniZadatakUredjaj {
  int? uredjajId;
  int? radniZadatakId;
  String? radniZadatakNaziv;
  String? radniZadatakStatus;
  String? radniZadatakDatum;
  String? koda;
  String? serijskiBroj;
  String? uredjajStatus;
  String? uredjajDatumIzvedbe;
  String? tipNaziv;
  String? tipOpis;
  String? lokacija;

  RadniZadatakUredjaj();

  factory RadniZadatakUredjaj.fromJson(Map<String, dynamic> json) => _$RadniZadatakUredjajFromJson(json);

  Map<String, dynamic> toJson() => _$RadniZadatakUredjajToJson(this);
}
