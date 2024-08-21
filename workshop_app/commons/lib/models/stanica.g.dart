// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'stanica.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Stanica _$StanicaFromJson(Map<String, dynamic> json) => Stanica()
  ..id = (json['id'] as num).toInt()
  ..naziv = json['naziv'] as String?;

Map<String, dynamic> _$StanicaToJson(Stanica instance) => <String, dynamic>{
      'id': instance.id,
      'naziv': instance.naziv,
    };
