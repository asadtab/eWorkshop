import 'package:flutter/material.dart';
import 'package:json_annotation/json_annotation.dart';

part 'izvrseni_servis.g.dart';

@JsonSerializable()
class IzvrseniServis {
  int servisId = 0;
  int uredjajId = 0;
  String? naziv;
  String? vrijednost;
  String? tip;
  String? datum;
  String? servisirao;

  IzvrseniServis() {}

  factory IzvrseniServis.fromJson(Map<String, dynamic> json) =>
      _$IzvrseniServisFromJson(json);

  Map<String, dynamic> toJson() => _$IzvrseniServisToJson(this);
}
