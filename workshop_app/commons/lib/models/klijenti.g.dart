// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'klijenti.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Klijenti _$KlijentiFromJson(Map<String, dynamic> json) => Klijenti()
  ..id = json['id'] as int?
  ..clientId = json['clientId'] as String?
  ..clientName = json['clientName'] as String?
  ..clientUri = json['clientUri'] as String?
  ..protocolType = json['protocolType'] as String?
  ..redirectUris = json['redirectUris'] as String?;

Map<String, dynamic> _$KlijentiToJson(Klijenti instance) => <String, dynamic>{
      'id': instance.id,
      'clientId': instance.clientId,
      'clientName': instance.clientName,
      'clientUri': instance.clientUri,
      'protocolType': instance.protocolType,
      'redirectUris': instance.redirectUris,
    };
