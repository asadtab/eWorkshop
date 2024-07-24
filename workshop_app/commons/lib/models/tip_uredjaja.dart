import 'package:json_annotation/json_annotation.dart';

part 'tip_uredjaja.g.dart';

@JsonSerializable()
class TipUredjaja {
  int tipUredjajaId = 0;
  String? naziv;
  String? opis;
  String? opisNaziv;

  TipUredjaja();

  factory TipUredjaja.fromJson(Map<String, dynamic> json) => _$TipUredjajaFromJson(json);

  Map<String, dynamic> toJson() => _$TipUredjajaToJson(this);
}
