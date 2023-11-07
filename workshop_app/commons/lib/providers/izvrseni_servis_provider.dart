import 'package:commons/models/izvrseni_servis.dart';
import 'package:commons/providers/base_provider.dart';

class IzvrseniServisProvider extends BaseProvider<IzvrseniServis> {
  IzvrseniServisProvider() : super("Reparacija/IzvrseniServis") {}

  @override
  IzvrseniServis fromJson(data) {
    return IzvrseniServis.fromJson(data);
  }
}
