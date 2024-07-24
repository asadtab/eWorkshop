import 'package:json_annotation/json_annotation.dart';

part 'lokacija.g.dart';

@JsonSerializable()
class Lokacija {
  int lokacijaId = 0;
  String? naziv;
  String? opis;

  Lokacija();

  factory Lokacija.fromJson(Map<String, dynamic> json) => _$LokacijaFromJson(json);

  Map<String, dynamic> toJson() => _$LokacijaToJson(this);
}
