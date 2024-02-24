import 'package:commons/models/client_grant_type.dart';
import 'package:commons/models/client_scope.dart';
import 'package:commons/models/client_secret.dart';

class KlijentRequest {
  int? id;
  String? clientId;
  String? clientName;
  String? clientUri;
  String? protocolType;
  String? redirectUris;
  List<ClientGrantType>? clientGrantTypes;
  List<ClientScope>? clientScope;
  List<ClientSecret>? clientSecret;
}
