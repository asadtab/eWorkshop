import 'package:workshop_app/providers/base_provider.dart';

import '../model/komponenta.dart';

class KomponenteRecommendedProvider extends BaseProvider<Komponenta> {
  KomponenteRecommendedProvider() : super("ServisIzvrsen/Komponente");

  @override
  Komponenta fromJson(data) {
    return Komponenta.fromJson(data);
  }
}
