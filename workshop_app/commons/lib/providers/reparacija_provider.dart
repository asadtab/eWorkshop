import 'package:commons/models/reparacija.dart';
import 'package:commons/providers/base_provider.dart';

class ReparacijaProvider extends BaseProvider<Reparacija> {
  ReparacijaProvider() : super("Reparacija") {}

  @override
  Reparacija fromJson(data) {
    return Reparacija.fromJson(data);
  }
}
