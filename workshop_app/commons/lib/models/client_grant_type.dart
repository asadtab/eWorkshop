import 'package:json_annotation/json_annotation.dart';

part 'client_grant_type.g.dart';

@JsonSerializable()
class ClientGrantType {
  int? id;
  String? grantType;

  ClientGrantType({this.grantType});

  factory ClientGrantType.fromJson(Map<String, dynamic> json) => _$ClientGrantTypeFromJson(json);

  Map<String, dynamic> toJson() => _$ClientGrantTypeToJson(this);
}
