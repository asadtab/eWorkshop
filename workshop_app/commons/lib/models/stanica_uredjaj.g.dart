// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'stanica_uredjaj.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

StanicaUredjaj _$StanicaUredjajFromJson(Map<String, dynamic> json) =>
    StanicaUredjaj()
      ..id = json['id'] as int
      ..naziv = json['naziv'] as String?
      ..uredjajId = json['uredjajId'] as int
      ..koda = json['koda'] as String?
      ..uredjajNaziv = json['uredjajNaziv'] as String?
      ..uredjajTip = json['uredjajTip'] as String?;

Map<String, dynamic> _$StanicaUredjajToJson(StanicaUredjaj instance) =>
    <String, dynamic>{
      'id': instance.id,
      'naziv': instance.naziv,
      'uredjajId': instance.uredjajId,
      'koda': instance.koda,
      'uredjajNaziv': instance.uredjajNaziv,
      'uredjajTip': instance.uredjajTip,
    };
