import 'package:json_annotation/json_annotation.dart';

part 'uredjaj.g.dart';

@JsonSerializable()
class Uredjaj {
  int? uredjajId;
  String? koda;
  String? serijskiBroj;
  String? godinaIzvedbe;
  String? status;
  String? tipNaziv;
  String? tipOpis;
  String? lokacijaNaziv;

  @JsonKey(includeToJson: false, includeFromJson: false)
  bool isSelected = false;

  Uredjaj() {}

  factory Uredjaj.fromJson(Map<String, dynamic> json) => _$UredjajFromJson(json);

  Map<String, dynamic> toJson() => _$UredjajToJson(this);
}
