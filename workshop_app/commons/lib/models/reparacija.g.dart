// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'reparacija.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Reparacija _$ReparacijaFromJson(Map<String, dynamic> json) => Reparacija()
  ..uredjajId = json['uredjajId'] as int
  ..datum = json['datum'] as String?
  ..datumString = json['datumString'] as String?
  ..servisId = json['servisId'] as int
  ..servisirao = json['servisirao'] as String?
  ..napomena = json['napomena'] as String?;

Map<String, dynamic> _$ReparacijaToJson(Reparacija instance) =>
    <String, dynamic>{
      'uredjajId': instance.uredjajId,
      'datum': instance.datum,
      'datumString': instance.datumString,
      'servisId': instance.servisId,
      'servisirao': instance.servisirao,
      'napomena': instance.napomena,
    };
