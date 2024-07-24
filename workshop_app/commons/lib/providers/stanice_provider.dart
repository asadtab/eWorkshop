import 'package:commons/models/stanica.dart';
import 'package:commons/providers/base_provider.dart';

class StaniceProvider extends BaseProvider<Stanica> {
  StaniceProvider() : super("StaniceUredjaj");

  @override
  Stanica fromJson(data) {
    return Stanica.fromJson(data);
  }
}
