import 'package:commons/models/client_grant_type.dart';
import 'package:commons/providers/base_provider.dart';

class ClientGrantTypeProvider extends BaseProvider<ClientGrantType> {
  ClientGrantTypeProvider() : super("ClientGrantType") {}

  @override
  ClientGrantType fromJson(data) {
    return ClientGrantType.fromJson(data);
  }
}
