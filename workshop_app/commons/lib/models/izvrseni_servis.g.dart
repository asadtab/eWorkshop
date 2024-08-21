// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'izvrseni_servis.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

IzvrseniServis _$IzvrseniServisFromJson(Map<String, dynamic> json) =>
    IzvrseniServis()
      ..servisId = (json['servisId'] as num).toInt()
      ..uredjajId = (json['uredjajId'] as num).toInt()
      ..naziv = json['naziv'] as String?
      ..vrijednost = json['vrijednost'] as String?
      ..tip = json['tip'] as String?
      ..datum = json['datum'] as String?
      ..servisirao = json['servisirao'] as String?
      ..komponentaId = (json['komponentaId'] as num).toInt();

Map<String, dynamic> _$IzvrseniServisToJson(IzvrseniServis instance) =>
    <String, dynamic>{
      'servisId': instance.servisId,
      'uredjajId': instance.uredjajId,
      'naziv': instance.naziv,
      'vrijednost': instance.vrijednost,
      'tip': instance.tip,
      'datum': instance.datum,
      'servisirao': instance.servisirao,
      'komponentaId': instance.komponentaId,
    };
