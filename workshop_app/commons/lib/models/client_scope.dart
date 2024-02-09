import 'package:json_annotation/json_annotation.dart';

part 'client_scope.g.dart';

@JsonSerializable()
class ClientScope {
  String? name;
  String? displayName;
  String? description;

  ClientScope();

  factory ClientScope.fromJson(Map<String, dynamic> json) => _$ClientScopeFromJson(json);

  Map<String, dynamic> toJson() => _$ClientScopeToJson(this);
}
