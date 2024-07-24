import 'package:json_annotation/json_annotation.dart';

part 'client_secret.g.dart';

@JsonSerializable()
class ClientSecret {
  String? description;
  String? expiration;
  String? type;
  String? created;
  String? value;
  int? id;

  ClientSecret({this.value, this.created, this.description, this.expiration, this.type});

  factory ClientSecret.fromJson(Map<String, dynamic> json) => _$ClientSecretFromJson(json);

  Map<String, dynamic> toJson() => _$ClientSecretToJson(this);
}
