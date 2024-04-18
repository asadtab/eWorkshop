import 'package:commons/models/api_scopes.dart';
import 'package:commons/providers/base_provider.dart';

class ApiScopesProvider extends BaseProvider<ApiScopes> {
  ApiScopesProvider() : super("Scopes") {}

  @override
  ApiScopes fromJson(data) {
    return ApiScopes.fromJson(data);
  }
}
