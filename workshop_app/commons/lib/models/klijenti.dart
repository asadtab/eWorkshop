import 'package:json_annotation/json_annotation.dart';

part 'klijenti.g.dart';

@JsonSerializable()
class Klijenti {
  int? id;
  String? clientId;
  String? clientName;
  String? clientUri;
  String? protocolType;
  //String? allowedGrantTypes;
  String? redirectUris;
  List<String>? allowedGrantTypes;

  Klijenti();

  factory Klijenti.fromJson(Map<String, dynamic> json) => _$KlijentiFromJson(json);

  Map<String, dynamic> toJson() => _$KlijentiToJson(this);
}
