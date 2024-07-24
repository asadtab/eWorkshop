import 'package:commons/models/stanica_uredjaj.dart';
import 'package:commons/providers/base_provider.dart';

class StaniceUredjajProvider extends BaseProvider<StanicaUredjaj> {
  StaniceUredjajProvider() : super("StaniceUredjaj");

  @override
  StanicaUredjaj fromJson(data) {
    return StanicaUredjaj.fromJson(data);
  }
}
