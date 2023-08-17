import 'package:flutter/material.dart';
import 'package:json_annotation/json_annotation.dart';

part 'stanica.g.dart';

@JsonSerializable()
class Stanica {
  int id = 0;
  String? naziv;

  Stanica();

  factory Stanica.fromJson(Map<String, dynamic> json) => _$StanicaFromJson(json);

  Map<String, dynamic> toJson() => _$StanicaToJson(this);
}
