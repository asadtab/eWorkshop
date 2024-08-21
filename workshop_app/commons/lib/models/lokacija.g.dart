// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'lokacija.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Lokacija _$LokacijaFromJson(Map<String, dynamic> json) => Lokacija()
  ..lokacijaId = (json['lokacijaId'] as num).toInt()
  ..naziv = json['naziv'] as String?
  ..opis = json['opis'] as String?;

Map<String, dynamic> _$LokacijaToJson(Lokacija instance) => <String, dynamic>{
      'lokacijaId': instance.lokacijaId,
      'naziv': instance.naziv,
      'opis': instance.opis,
    };
