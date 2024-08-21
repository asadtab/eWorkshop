// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'client_secret.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ClientSecret _$ClientSecretFromJson(Map<String, dynamic> json) => ClientSecret(
      value: json['value'] as String?,
      created: json['created'] as String?,
      description: json['description'] as String?,
      expiration: json['expiration'] as String?,
      type: json['type'] as String?,
    )..id = (json['id'] as num?)?.toInt();

Map<String, dynamic> _$ClientSecretToJson(ClientSecret instance) =>
    <String, dynamic>{
      'description': instance.description,
      'expiration': instance.expiration,
      'type': instance.type,
      'created': instance.created,
      'value': instance.value,
      'id': instance.id,
    };
