// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'uredjaj.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Uredjaj _$UredjajFromJson(Map<String, dynamic> json) => Uredjaj(
      uredjajId: (json['uredjajId'] as num?)?.toInt(),
      godinaIzvedbe: json['godinaIzvedbe'] as String?,
      koda: json['koda'] as String?,
      lokacijaNaziv: json['lokacijaNaziv'] as String?,
      serijskiBroj: json['serijskiBroj'] as String?,
      status: json['status'] as String?,
      tipNaziv: json['tipNaziv'] as String?,
      tipOpis: json['tipOpis'] as String?,
    );

Map<String, dynamic> _$UredjajToJson(Uredjaj instance) => <String, dynamic>{
      'uredjajId': instance.uredjajId,
      'koda': instance.koda,
      'serijskiBroj': instance.serijskiBroj,
      'godinaIzvedbe': instance.godinaIzvedbe,
      'status': instance.status,
      'tipNaziv': instance.tipNaziv,
      'tipOpis': instance.tipOpis,
      'lokacijaNaziv': instance.lokacijaNaziv,
    };
