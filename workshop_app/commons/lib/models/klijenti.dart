import 'package:commons/models/client_grant_type.dart';
import 'package:json_annotation/json_annotation.dart';

part 'klijenti.g.dart';

@JsonSerializable()
class Klijenti {
  int? id;
  String? clientId;
  String? clientName;
  String? clientUri;
  String? protocolType;
  String? redirectUris;

  Klijenti();

  factory Klijenti.fromJson(Map<String, dynamic> json) => _$KlijentiFromJson(json);

  Map<String, dynamic> toJson() => _$KlijentiToJson(this);
}
