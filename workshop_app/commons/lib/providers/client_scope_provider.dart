import 'package:commons/models/client_scope.dart';
import 'package:commons/providers/base_provider.dart';

class ClientScopeProvider extends BaseProvider<ClientScope> {
  ClientScopeProvider() : super("Scopes") {}

  @override
  ClientScope fromJson(data) {
    return ClientScope.fromJson(data);
  }
}
