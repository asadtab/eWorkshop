import 'package:json_annotation/json_annotation.dart';

part 'api_scopes.g.dart';

@JsonSerializable()
class ApiScopes {
  int? id;
  String? name;
  String? displayName;
  String? description;

  ApiScopes();

  factory ApiScopes.fromJson(Map<String, dynamic> json) => _$ApiScopesFromJson(json);

  Map<String, dynamic> toJson() => _$ApiScopesToJson(this);
}
