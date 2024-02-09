import 'package:json_annotation/json_annotation.dart';

part 'komponenta.g.dart';

@JsonSerializable()
class Komponenta {
  int komponentaId = 0;
  String? naziv;
  String? vrijednost;
  String? opis;
  String? tip;

  Komponenta();

  factory Komponenta.fromJson(Map<String, dynamic> json) => _$KomponentaFromJson(json);

  Map<String, dynamic> toJson() => _$KomponentaToJson(this);
}
