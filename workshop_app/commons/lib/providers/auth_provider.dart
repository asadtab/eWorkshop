import 'dart:convert';
import 'dart:io' as io;
import 'package:commons/models/constants/claims.dart';
import 'package:commons/models/token_model.dart';
import 'package:commons/models/user.dart';
import 'package:commons/providers/base_provider.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class AuthProvider extends BaseProvider<TokenModel> {
  late String _baseUrl;
  bool _isLoggedIn = false;


  bool? get isLoggedIn => _isLoggedIn;

  User? _user;

  AuthProvider():super("Korisnici/Login"){
         if(isDesktop()){
    _baseUrl = const String.fromEnvironment("baseUrl", defaultValue: "http://localhost:8080/");
    } else if (isMobile()){
      _baseUrl = const String.fromEnvironment("baseUrl", defaultValue: "http://10.0.2.2:8080");
    }


  }

    @override
    TokenModel fromJson(data) {
    return TokenModel.fromJson(data);
  }

  User? get user => _user;

  void setLoggedIn(bool value) {
    _isLoggedIn = value;
    //notifyListeners();
  }

  setLogout() {
    _isLoggedIn = false;

    User.name = null;
    User.email = null;
    User.token = null;

    //notifyListeners();
  }

    bool isMobile(){
    return !kIsWeb && (io.Platform.isAndroid || io.Platform.isIOS);
  }

  bool isDesktop() {
  return !kIsWeb && (io.Platform.isWindows || io.Platform.isLinux || io.Platform.isMacOS);
}

  /*AuthProvider(super.endpoint) {
    if(isDesktop()){
    _baseUrl = const String.fromEnvironment("IdentityServerUrl", defaultValue: "http://localhost:5443/");
    }else if (isMobile()){
      _baseUrl = const String.fromEnvironment("IdentityServerUrl", defaultValue: "http://10.0.2.2:5443/");
      }
  }*/

  setUser(User user) {
    _user = user;
    //notifyListeners();
  }

  clearUser() {
    _user = null;
    //notifyListeners();
  }

Future<TokenModel?> login(String username, String password) async {
  var url = "$_baseUrl/Korisnici/Login";
  var uri = Uri.parse(url);

  Map<String, String> headers = createHeaders();
  var jsonRequest = jsonEncode({
    'username': username,
    'password': password,
  });

  var response = await http.post(uri, headers: headers, body: jsonRequest);

  if (isValidResponseCode(response)) {
    print([response]);
    var data = jsonDecode(response.body);
    print(data);
    return TokenModel.fromJson(data);
  }

  return null;
}

  bool _isValidResponse(http.Response response) {
    getUser(response.body);


    if(isDesktop() && User.roles.first == "Pretplatnik"){
      throw Exception("Neispravni kredencijali za prijavu");
    }
    else if (response.statusCode < 299) {
      return true;
    } else if (response.statusCode == 401) {
      throw Exception("Neispravni kredencijali za prijavu.");
    } else {
      throw Exception("Serverska greška.");
    }
  }

  Map<String, dynamic> _decode(String token) {
    final splitToken = token.split(".");
    if (splitToken.length != 3) {
      throw const FormatException('Invalid token');
    }
    try {
      final payloadBase64 = splitToken[1];
      final normalizedPayload = base64.normalize(payloadBase64);
      final payloadString = utf8.decode(base64.decode(normalizedPayload));
      final decodedPayload = jsonDecode(payloadString);

      return decodedPayload;
    } catch (error) {
      throw const FormatException('Invalid payload');
    }
  }

  getUser(String tokenString) {
    final decodedToken = _decode(tokenString);

    User.id = decodedToken[Claims.id] as String;
    User.name = decodedToken[Claims.fullName] as String?;
    User.email = decodedToken[Claims.email] as String?;
    User.token = tokenString;
    User.username = decodedToken[Claims.username] as String?;

    var role = decodedToken[Claims.role];
    User.roles.clear();

    if (role is List<dynamic>) {
      User.roles = List<String>.from(decodedToken[Claims.role]);
    } else {
      User.roles.add(role);
    }

  }
}
