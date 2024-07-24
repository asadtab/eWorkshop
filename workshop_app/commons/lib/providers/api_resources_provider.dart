import 'package:commons/models/api_resources.dart';
import 'package:commons/providers/base_provider.dart';

class ApiResourcesProvider extends BaseProvider<ApiResources> {
  ApiResourcesProvider() : super("ApiResource") {}

  @override
  ApiResources fromJson(data) {
    return ApiResources.fromJson(data);
  }
}
