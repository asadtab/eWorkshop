// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'api_scopes.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ApiScopes _$ApiScopesFromJson(Map<String, dynamic> json) => ApiScopes()
  ..id = json['id'] as int?
  ..name = json['name'] as String?
  ..displayName = json['displayName'] as String?
  ..description = json['description'] as String?;

Map<String, dynamic> _$ApiScopesToJson(ApiScopes instance) => <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'displayName': instance.displayName,
      'description': instance.description,
    };
