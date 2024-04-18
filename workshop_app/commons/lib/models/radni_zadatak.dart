import 'package:json_annotation/json_annotation.dart';

part 'radni_zadatak.g.dart';

@JsonSerializable()
class RadniZadatak {
  int radniZadatakId = 0;
  String? naziv;
  String? datum;
  String? stateMachine;

  RadniZadatak() {}

  factory RadniZadatak.fromJson(Map<String, dynamic> json) => _$RadniZadatakFromJson(json);

  Map<String, dynamic> toJson() => _$RadniZadatakToJson(this);
}
