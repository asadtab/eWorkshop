import 'dart:convert';
import 'dart:io';
import 'package:commons/models/user.dart';
import 'package:http/http.dart';
import 'package:flutter/material.dart';
import 'package:http/io_client.dart';

abstract class BaseProvider<T> with ChangeNotifier {
  static String? _baseUrl;
  static String? _endpoint;

  HttpClient client = new HttpClient();
  IOClient? http;

  static final String? _ids = "http://localhost:5443/";

  final identifier = 'flutter';

  BaseProvider(String endpoint, [bool? ids]) {
    _baseUrl = const String.fromEnvironment("baseUrl", defaultValue: "http://localhost:7189/");

    if (_baseUrl!.endsWith("/") == false) {
      _baseUrl = _baseUrl! + "/";
    }

    _endpoint = endpoint;

    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);
  }

  Map<String, String> createHeaders() => {"Content-Type": "application/json", "Authorization": "Bearer ${User.token ?? ""}"};

  Future<List<T>> getById(int id, [dynamic additionalData, String? endPoint]) async {
    if (endPoint != null) {
      _endpoint = endPoint;
    }

    var url = Uri.parse("$_baseUrl$_endpoint/$id");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<T>();
      //return data.map((x) => fromJson(x)).cast<T>().toList();
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }

  Future<List<T>> get([dynamic search, String? endPoint, bool? rst]) async {
    if (endPoint != null) {
      _endpoint = endPoint;
    }

    if (rst != null && rst) {
      _baseUrl = "http://localhost:7189/";
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

    print(response.body);

    if (response.statusCode < 400) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<T>().toList();
    } else if (response.statusCode == 401) {
      throw Exception("Unauthorized!");
    } else {
      throw Exception("Greska!");
    }
  }

  Future<T?> insert(dynamic request, String? endPoint, [bool? ids]) async {
    if (endPoint != null) {
      _endpoint = endPoint;
    }

    if (ids != null && ids) {
      _baseUrl = _ids;
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

    print(response.body);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data) as T;
    } else {
      return null;
    }
  }

  Future<Map<String, dynamic>?> delete(int? id, [dynamic request, String? endPoint]) async {
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

    var response = await http!.delete(uri, headers: headers, body: jsonEncode(request));

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data;
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
