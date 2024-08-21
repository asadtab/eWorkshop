import 'package:json_annotation/json_annotation.dart';

part 'korisnik.g.dart';

@JsonSerializable()
class Korisnik {
  int? id;
  String? ime;
  String? prezime;
  String? email;
  String? userName;
  bool? status;
  String? radnaJedinica;
  List<String> uloge = [];

  Korisnik();

  factory Korisnik.fromJson(Map<String, dynamic> json) => _$KorisnikFromJson(json);

  Map<String, dynamic> toJson() => _$KorisnikToJson(this);
}
