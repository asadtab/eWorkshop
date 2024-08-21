// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'korisnik.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Korisnik _$KorisnikFromJson(Map<String, dynamic> json) => Korisnik()
  ..id = (json['id'] as num?)?.toInt()
  ..ime = json['ime'] as String?
  ..prezime = json['prezime'] as String?
  ..email = json['email'] as String?
  ..userName = json['userName'] as String?
  ..status = json['status'] as bool?
  ..radnaJedinica = json['radnaJedinica'] as String?
  ..uloge = (json['uloge'] as List<dynamic>).map((e) => e as String).toList();

Map<String, dynamic> _$KorisnikToJson(Korisnik instance) => <String, dynamic>{
      'id': instance.id,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'email': instance.email,
      'userName': instance.userName,
      'status': instance.status,
      'radnaJedinica': instance.radnaJedinica,
      'uloge': instance.uloge,
    };
