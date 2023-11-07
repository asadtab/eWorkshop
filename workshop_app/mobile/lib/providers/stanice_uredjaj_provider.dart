import 'package:workshop_app/providers/base_provider.dart';

import '../model/lokacija.dart';
import '../model/stanica.dart';
import '../model/stanica_uredjaj.dart';

class StaniceUredjajProvider extends BaseProvider<StanicaUredjaj> {
  StaniceUredjajProvider() : super("StaniceUredjaj");

  @override
  StanicaUredjaj fromJson(data) {
    return StanicaUredjaj.fromJson(data);
  }
}
