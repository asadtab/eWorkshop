import 'package:commons/models/lokacija.dart';
import 'package:commons/providers/base_provider.dart';

class LokacijaProvider extends BaseProvider<Lokacija> {
  LokacijaProvider() : super("Lokacija");

  @override
  Lokacija fromJson(data) {
    return Lokacija.fromJson(data);
  }
}
