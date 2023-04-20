import 'package:workshop_app/model/komponenta.dart';
import 'package:workshop_app/providers/base_provider.dart';

class KomponenteProvider extends BaseProvider<Komponenta> {
  KomponenteProvider() : super("Komponente");

  @override
  Komponenta fromJson(data) {
    return Komponenta.fromJson(data);
  }
}
