import 'package:json_annotation/json_annotation.dart';

part 'uredjaj.g.dart';

@JsonSerializable()
class Uredjaj {
  int? uredjajId;
  String? koda;
  String? serijskiBroj;
  String? datumIzvedbe;
  String? status;
  String? tipNaziv;
  String? tipOpis;
  String? lokacijaNaziv;

  @JsonKey(includeToJson: false)
  bool isSelected = false;

  Uredjaj() {}

  factory Uredjaj.fromJson(Map<String, dynamic> json) => _$UredjajFromJson(json);

  Map<String, dynamic> toJson() => _$UredjajToJson(this);
}
