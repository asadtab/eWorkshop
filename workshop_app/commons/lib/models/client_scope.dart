import 'package:json_annotation/json_annotation.dart';

part 'client_scope.g.dart';

@JsonSerializable()
class ClientScope {
  String? scope;

  ClientScope({this.scope});

  factory ClientScope.fromJson(Map<String, dynamic> json) => _$ClientScopeFromJson(json);

  Map<String, dynamic> toJson() => _$ClientScopeToJson(this);
}
