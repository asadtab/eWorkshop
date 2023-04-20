import 'package:flutter/material.dart';
import 'package:json_annotation/json_annotation.dart';

part 'reparacija.g.dart';

@JsonSerializable()
class Reparacija {
  int uredjajId = 0;
  String? datum;

  String? napomena;

  Reparacija() {}

  factory Reparacija.fromJson(Map<String, dynamic> json) =>
      _$ReparacijaFromJson(json);

  Map<String, dynamic> toJson() => _$ReparacijaToJson(this);
}
