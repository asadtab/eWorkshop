import 'package:commons/models/korisnik.dart';
import 'package:commons/providers/base_provider.dart';

class KorisniciProvider extends BaseProvider<Korisnik> {
  KorisniciProvider() : super("Korisnici");

  @override
  Korisnik fromJson(data) {
    return Korisnik.fromJson(data);
  }
}
