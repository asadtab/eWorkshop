import 'package:workshop_app/providers/base_provider.dart';

import '../model/lokacija.dart';

class LokacijaProvider extends BaseProvider<Lokacija> {
  LokacijaProvider() : super("Lokacija");

  @override
  Lokacija fromJson(data) {
    return Lokacija.fromJson(data);
  }
}
