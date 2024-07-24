import 'package:json_annotation/json_annotation.dart';

part 'api_resources.g.dart';

@JsonSerializable()
class ApiResources {
  int? id;
  String? name;
  String? displayName;
  String? description;

  ApiResources();

  factory ApiResources.fromJson(Map<String, dynamic> json) => _$ApiResourcesFromJson(json);

  Map<String, dynamic> toJson() => _$ApiResourcesToJson(this);
}
