// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'komponenta.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Komponenta _$KomponentaFromJson(Map<String, dynamic> json) => Komponenta()
  ..komponentaId = (json['komponentaId'] as num).toInt()
  ..naziv = json['naziv'] as String?
  ..vrijednost = json['vrijednost'] as String?
  ..opis = json['opis'] as String?
  ..tip = json['tip'] as String?;

Map<String, dynamic> _$KomponentaToJson(Komponenta instance) =>
    <String, dynamic>{
      'komponentaId': instance.komponentaId,
      'naziv': instance.naziv,
      'vrijednost': instance.vrijednost,
      'opis': instance.opis,
      'tip': instance.tip,
    };
