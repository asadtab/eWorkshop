import 'package:commons/models/statistika.dart';
import 'package:commons/providers/base_provider.dart';

class StatistikaProvider extends BaseProvider<Statistika> {
  StatistikaProvider() : super("Statistika") {}

  @override
  Statistika fromJson(data) {
    return Statistika.fromJson(data);
  }
}
