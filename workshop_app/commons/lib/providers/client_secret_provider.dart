import 'package:commons/models/client_secret.dart';
import 'package:commons/providers/base_provider.dart';

class ClientSecretProvider extends BaseProvider<ClientSecret> {
  ClientSecretProvider() : super("Scopes ") {}

  @override
  ClientSecret fromJson(data) {
    return ClientSecret.fromJson(data);
  }
}
