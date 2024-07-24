import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/base_provider.dart';

class UredjajProvider extends BaseProvider<Uredjaj> {
  UredjajProvider() : super("Uredjaj");

  @override
  Uredjaj fromJson(data) {
    return Uredjaj.fromJson(data);
  }
}
