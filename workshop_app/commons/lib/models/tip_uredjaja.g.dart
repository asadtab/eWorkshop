// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'tip_uredjaja.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TipUredjaja _$TipUredjajaFromJson(Map<String, dynamic> json) => TipUredjaja()
  ..tipUredjajaId = (json['tipUredjajaId'] as num).toInt()
  ..naziv = json['naziv'] as String?
  ..opis = json['opis'] as String?
  ..opisNaziv = json['opisNaziv'] as String?;

Map<String, dynamic> _$TipUredjajaToJson(TipUredjaja instance) =>
    <String, dynamic>{
      'tipUredjajaId': instance.tipUredjajaId,
      'naziv': instance.naziv,
      'opis': instance.opis,
      'opisNaziv': instance.opisNaziv,
    };
