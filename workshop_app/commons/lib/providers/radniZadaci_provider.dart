import '../models/radni_zadatak.dart';
import 'base_provider.dart';

class RadniZadaciProvider extends BaseProvider<RadniZadatak> {
  RadniZadaciProvider() : super("RadniZadatak");

  @override
  RadniZadatak fromJson(data) {
    return RadniZadatak.fromJson(data);
  }
}
