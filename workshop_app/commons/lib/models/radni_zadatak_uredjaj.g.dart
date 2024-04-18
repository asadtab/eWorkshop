// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'radni_zadatak_uredjaj.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

RadniZadatakUredjaj _$RadniZadatakUredjajFromJson(Map<String, dynamic> json) =>
    RadniZadatakUredjaj()
      ..uredjajId = json['uredjajId'] as int?
      ..radniZadatakId = json['radniZadatakId'] as int?
      ..radniZadatakNaziv = json['radniZadatakNaziv'] as String?
      ..radniZadatakStatus = json['radniZadatakStatus'] as String?
      ..radniZadatakDatum = json['radniZadatakDatum'] as String?
      ..koda = json['koda'] as String?
      ..serijskiBroj = json['serijskiBroj'] as String?
      ..uredjajStatus = json['uredjajStatus'] as String?
      ..uredjajDatumIzvedbe = json['uredjajDatumIzvedbe'] as String?
      ..tipNaziv = json['tipNaziv'] as String?
      ..tipOpis = json['tipOpis'] as String?
      ..lokacija = json['lokacija'] as String?;

Map<String, dynamic> _$RadniZadatakUredjajToJson(
        RadniZadatakUredjaj instance) =>
    <String, dynamic>{
      'uredjajId': instance.uredjajId,
      'radniZadatakId': instance.radniZadatakId,
      'radniZadatakNaziv': instance.radniZadatakNaziv,
      'radniZadatakStatus': instance.radniZadatakStatus,
      'radniZadatakDatum': instance.radniZadatakDatum,
      'koda': instance.koda,
      'serijskiBroj': instance.serijskiBroj,
      'uredjajStatus': instance.uredjajStatus,
      'uredjajDatumIzvedbe': instance.uredjajDatumIzvedbe,
      'tipNaziv': instance.tipNaziv,
      'tipOpis': instance.tipOpis,
      'lokacija': instance.lokacija,
    };
