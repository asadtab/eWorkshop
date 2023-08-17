import 'package:workshop_app/providers/base_provider.dart';

import '../model/lokacija.dart';
import '../model/stanica.dart';
import '../model/stanica_uredjaj.dart';

class StaniceProvider extends BaseProvider<Stanica> {
  StaniceProvider() : super("StaniceUredjaj");

  @override
  Stanica fromJson(data) {
    return Stanica.fromJson(data);
  }
}
