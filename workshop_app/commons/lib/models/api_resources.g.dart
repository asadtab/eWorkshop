// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'api_resources.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ApiResources _$ApiResourcesFromJson(Map<String, dynamic> json) => ApiResources()
  ..name = json['name'] as String?
  ..displayName = json['displayName'] as String?
  ..description = json['description'] as String?;

Map<String, dynamic> _$ApiResourcesToJson(ApiResources instance) =>
    <String, dynamic>{
      'name': instance.name,
      'displayName': instance.displayName,
      'description': instance.description,
    };
