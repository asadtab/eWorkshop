import 'dart:convert';
import 'dart:io' as io;
import 'package:commons/models/constants/claims.dart';
import 'package:commons/models/user.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class AuthProvider extends ChangeNotifier {
  late String _baseUrl;
  bool _isLoggedIn = false;

  bool? get isLoggedIn => _isLoggedIn;

  User? _user;

  User? get user => _user;

  void setLoggedIn(bool value) {
    _isLoggedIn = value;
    notifyListeners();
  }

  setLogout() {
    _isLoggedIn = false;

    User.name = null;
    User.email = null;
    User.token = null;

    notifyListeners();
  }

    bool isMobile(){
    return !kIsWeb && (io.Platform.isAndroid || io.Platform.isIOS);
  }

  bool isDesktop() {
  return !kIsWeb && (io.Platform.isWindows || io.Platform.isLinux || io.Platform.isMacOS);
}

  AuthProvider() {
    if(isDesktop()){
    _baseUrl = const String.fromEnvironment("IdentityServerUrl", defaultValue: "http://localhost:5443/");
    }else if (isMobile()){
      _baseUrl = const String.fromEnvironment("IdentityServerUrl", defaultValue: "http://10.0.2.2:5443/");
      }
  }

  setUser(User user) {
    _user = user;
    notifyListeners();
  }

  clearUser() {
    _user = null;
    notifyListeners();
  }

  Future<String> login(String email, String password) async {
    var uri = Uri.parse('${_baseUrl}account/login?email=$email&password=$password');

    var response = await http.get(uri);

    if (_isValidResponse(response)) {
      return response.body;
    } else {
      throw Exception("Response is not valid");
    }
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
