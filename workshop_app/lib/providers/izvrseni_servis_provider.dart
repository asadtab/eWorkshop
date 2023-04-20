import 'package:workshop_app/model/izvrseni_servis.dart';
import 'package:workshop_app/providers/base_provider.dart';

class IzvrseniServisProvider extends BaseProvider<IzvrseniServis> {
  IzvrseniServisProvider() : super("Reparacija/IzvrseniServis") {}

  @override
  IzvrseniServis fromJson(data) {
    return IzvrseniServis.fromJson(data);
  }
}
