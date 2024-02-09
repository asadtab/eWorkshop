import 'package:commons/models/klijenti.dart';
import 'package:commons/providers/base_provider.dart';

class KlijentiProvider extends BaseProvider<Klijenti> {
  KlijentiProvider() : super("Client") {}

  @override
  Klijenti fromJson(data) {
    return Klijenti.fromJson(data);
  }
}
