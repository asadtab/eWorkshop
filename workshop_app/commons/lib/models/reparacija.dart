import 'package:flutter/material.dart';
import 'package:json_annotation/json_annotation.dart';

part 'reparacija.g.dart';

@JsonSerializable()
class Reparacija {
  int uredjajId = 0;
  String? datum;
  String? datumString;
  int servisId = 0;
  String? servisirao;

  String? napomena;

  @JsonKey(includeToJson: false)
  bool isExpanded = false;

  Reparacija() {}

  factory Reparacija.fromJson(Map<String, dynamic> json) => _$ReparacijaFromJson(json);

  Map<String, dynamic> toJson() => _$ReparacijaToJson(this);
}
