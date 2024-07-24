import 'package:json_annotation/json_annotation.dart';

part 'stanica_uredjaj.g.dart';

@JsonSerializable()
class StanicaUredjaj {
  int id = 0;
  String? naziv;
  int uredjajId = 0;
  String? koda;
  String? uredjajNaziv;
  String? uredjajTip;

  StanicaUredjaj();

  factory StanicaUredjaj.fromJson(Map<String, dynamic> json) => _$StanicaUredjajFromJson(json);

  Map<String, dynamic> toJson() => _$StanicaUredjajToJson(this);
}
