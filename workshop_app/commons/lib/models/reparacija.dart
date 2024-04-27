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

  @JsonKey(includeToJson: false, includeFromJson: false)
  bool isExpanded = false;

  Reparacija() {}

  factory Reparacija.fromJson(Map<String, dynamic> json) {
    final reparacija = _$ReparacijaFromJson(json);

    reparacija.isExpanded = false;

    return reparacija;
  }

  Map<String, dynamic> toJson() => _$ReparacijaToJson(this);
}
