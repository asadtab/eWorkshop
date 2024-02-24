// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'client_grant_type.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ClientGrantType _$ClientGrantTypeFromJson(Map<String, dynamic> json) =>
    ClientGrantType(
      grantType: json['grantType'] as String?,
    )..id = json['id'] as int?;

Map<String, dynamic> _$ClientGrantTypeToJson(ClientGrantType instance) =>
    <String, dynamic>{
      'id': instance.id,
      'grantType': instance.grantType,
    };
