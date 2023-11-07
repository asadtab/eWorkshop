import 'package:workshop_app/providers/base_provider.dart';

import '../model/reparacija.dart';

class ReparacijaProvider extends BaseProvider<Reparacija> {
  ReparacijaProvider() : super("Reparacija") {}

  @override
  Reparacija fromJson(data) {
    return Reparacija.fromJson(data);
  }
}
