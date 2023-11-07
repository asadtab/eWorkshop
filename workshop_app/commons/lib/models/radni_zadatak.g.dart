// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'radni_zadatak.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

RadniZadatak _$RadniZadatakFromJson(Map<String, dynamic> json) => RadniZadatak()
  ..radniZadatakId = json['radniZadatakId'] as int
  ..naziv = json['naziv'] as String?
  ..datum = json['datum'] as String?
  ..stateMachine = json['stateMachine'] as String?;

Map<String, dynamic> _$RadniZadatakToJson(RadniZadatak instance) =>
    <String, dynamic>{
      'radniZadatakId': instance.radniZadatakId,
      'naziv': instance.naziv,
      'datum': instance.datum,
      'stateMachine': instance.stateMachine,
    };
