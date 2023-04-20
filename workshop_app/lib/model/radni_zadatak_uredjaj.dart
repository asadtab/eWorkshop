import 'package:flutter/material.dart';
import 'package:json_annotation/json_annotation.dart';

part 'radni_zadatak_uredjaj.g.dart';

@JsonSerializable()
class RadniZadatakUredjaj {
  int uredjajId = 0;
  int radniZadatakId = 0;
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
  double progress = 0;

  RadniZadatakUredjaj();

  factory RadniZadatakUredjaj.fromJson(Map<String, dynamic> json) =>
      _$RadniZadatakUredjajFromJson(json);

  Map<String, dynamic> toJson() => _$RadniZadatakUredjajToJson(this);
}
