import 'dart:convert';
import 'dart:io';
import 'package:http/http.dart';
import 'package:flutter/material.dart';
import 'package:http/io_client.dart';
import 'package:oauth2/oauth2.dart' as oauth2;
import 'package:uni_links/uni_links.dart';
import 'package:url_launcher/url_launcher.dart';

abstract class BaseProvider<T> with ChangeNotifier {
  static String? _baseUrl;
  static String? _endpoint;
  static String? _endpointSecond;

  HttpClient client = new HttpClient();
  IOClient? http;

  //oauth2.Client clientIds;

  static String? authorizationHost = "https://b2b1-109-237-44-2.ngrok-free.app";
  final redirectUrl = Uri.parse("https://ee5e-109-237-44-2.ngrok-free.app/swagger/oauth2-redirect.html");

  final authorizationEndpoint = Uri.parse('$authorizationHost/connect/authorize');

  final tokenEndpoint = Uri.parse("$authorizationHost/connect/token");

  final identifier = 'flutter';

  final credentialsFile = File('~/.myapp/credentials.json');

  Future<oauth2.Client> createClient() async {
    var exists = await credentialsFile.exists();

    // If the OAuth2 credentials have already been saved from a previous run, we
    // just want to reload them.
    if (exists) {
      var credentials = oauth2.Credentials.fromJson(await credentialsFile.readAsString());
      return oauth2.Client(credentials, identifier: identifier);
    }

    // If we don't have OAuth2 credentials yet, we need to get the resource owner
    // to authorize us. We're assuming here that we're a command-line application.
    var grant = oauth2.AuthorizationCodeGrant(identifier, authorizationEndpoint, tokenEndpoint);

    // A URL on the authorization server (authorizationEndpoint with some additional
    // query parameters). Scopes and state can optionally be passed into this method.
    var authorizationUrl =
        grant.getAuthorizationUrl(redirectUrl, scopes: ["openid", "profile", "role", "weatherapi.read", "weatherapi.write", "offline_access"]);

    // Redirect the resource owner to the authorization URL. Once the resource
    // owner has authorized, they'll be redirected to `redirectUrl` with an
    // authorization code. The `redirect` should cause the browser to redirect to
    // another URL which should also have a listener.
    //
    // `redirect` and `listen` are not shown implemented here. See below for the
    // details.
    await redirect(authorizationUrl);
    var responseUrl = await listen(redirectUrl);

    if (responseUrl == null) {
      throw Exception("Response URL was null.");
    }

    // Once the user is redirected to `redirectUrl`, pass the query parameters to
    // the AuthorizationCodeGrant. It will validate them and extract the
    // authorization code to create a new Client.
    return await grant.handleAuthorizationResponse(responseUrl.queryParameters);
  }

  Future<void> redirect(Uri authorizationUrl) async {
    if (await canLaunchUrl(authorizationUrl)) {
      await launchUrl(authorizationUrl);
    } else {
      throw Exception("Unable to launch authorization URL");
    }
  }

  Future<Uri?> listen(Uri redirectUrl) async {
    return await uriLinkStream.firstWhere((element) => element.toString().startsWith(redirectUrl.toString()));
  }

  BaseProvider(String endpoint) {
    /*_baseUrl = const String.fromEnvironment("baseUrl",
        defaultValue: "https://0426-77-78-227-173.eu.ngrok.io/");*/

    _baseUrl = "https://bcfe-109-237-44-2.ngrok-free.app/";

    if (_baseUrl!.endsWith("/") == false) {
      _baseUrl = _baseUrl! + "/";
    }

    _endpoint = endpoint;

    //clientIds = oauth2.Client("");

    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);
  }

  Map<String, String> createHeaders() {
    String? username = "asad.admin";
    String? password = "asd";

    String basicAuth = "Basic ${base64Encode(utf8.encode('$username:$password'))}";

    var headers = {"Content-Type": "application/json", "Authorization": basicAuth};

    return headers;
  }

  Future<List<T>> getById(int id, [dynamic additionalData, String? endPoint]) async {
    if (endPoint != null) {
      _endpoint = endPoint;
    }

    var url = Uri.parse("$_baseUrl$_endpoint/$id");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<T>().toList();
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }

  Future<List<T>> get([dynamic search, String? endPoint]) async {
    if (endPoint != null) {
      _endpoint = endPoint;
    }

    var url = "$_baseUrl$_endpoint";
    String? moreThanOne;

    if (search != null && search.length > 0) {
      String queryString = getQueryString(
        search,
      );
      if (queryString.startsWith("&")) {
        moreThanOne = queryString.substring(1, queryString.length);
      }

      url = url + "?" + moreThanOne!;
    }

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();

    var response = await http!.get(uri, headers: headers);

    if (response.statusCode < 400) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<T>().toList();
    } else {
      throw Exception("Greska!");
    }
  }

  Future<T?> insert(dynamic request, String? endPoint) async {
    if (endPoint != null) {
      _endpoint = endPoint;
    }

    var url = "$_baseUrl$_endpoint";
    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var jsonRequest = jsonEncode(request);
    var response = await http!.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data) as T;
    } else {
      return null;
    }
  }

  Future<T?> update(int? id, [dynamic request, String? endPoint]) async {
    if (endPoint != null) {
      _endpoint = endPoint;
    }

    var uri;
    if (id == null) {
      var url = "$_baseUrl$_endpoint";
      uri = Uri.parse(url);
    } else {
      var url = "$_baseUrl$_endpoint/$id";
      uri = Uri.parse(url);
    }

    Map<String, String> headers = createHeaders();

    var response = await http!.put(uri, headers: headers, body: jsonEncode(request));

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data) as T;
    } else {
      return null;
    }
  }

  String getQueryString(Map params, {String prefix: '&', bool inRecursion: false}) {
    String query = '';
    params.forEach((key, value) {
      if (inRecursion) {
        if (key is int) {
          key = '[$key]';
        } else if (value is List || value is Map) {
          key = '.$key';
        } else {
          key = '.$key';
        }
      }
      if (value is String || value is int || value is double || value is bool) {
        var encoded = value;
        if (value is String) {
          encoded = Uri.encodeComponent(value);
        }
        query += '$prefix$key=$encoded';
      } else if (value is DateTime) {
        query += '$prefix$key=${(value as DateTime).toIso8601String()}';
      } else if (value is List || value is Map) {
        if (value is List) value = value.asMap();
        value.forEach((k, v) {
          query += getQueryString({k: v}, prefix: '$prefix$key', inRecursion: true);
        });
      }
    });
    return query;
  }

  T fromJson(data) {
    throw Exception("Override method");
  }

  bool isValidResponseCode(Response response) {
    if (response.statusCode == 200) {
      if (response.body != "") {
        return true;
      } else {
        return false;
      }
    } else if (response.statusCode == 204) {
      return true;
    } else if (response.statusCode == 400) {
      throw Exception("Bad request");
    } else if (response.statusCode == 401) {
      throw Exception("Unauthorized");
    } else if (response.statusCode == 403) {
      throw Exception("Forbidden");
    } else if (response.statusCode == 404) {
      throw Exception("Not found");
    } else if (response.statusCode == 500) {
      throw Exception("Internal server error");
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }
}
