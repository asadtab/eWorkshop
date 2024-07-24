import 'package:commons/models/komponenta.dart';
import 'package:commons/providers/base_provider.dart';

class KomponenteProvider extends BaseProvider<Komponenta> {
  KomponenteProvider() : super("Komponente");

  @override
  Komponenta fromJson(data) {
    return Komponenta.fromJson(data);
  }
}
