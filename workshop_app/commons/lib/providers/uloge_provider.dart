import 'package:commons/models/uloge.dart';
import 'package:commons/providers/base_provider.dart';

class UlogeProvider extends BaseProvider<Uloge> {
  UlogeProvider() : super("Uloge");

  @override
  Uloge fromJson(data) {
    return Uloge.fromJson(data);
  }
}
