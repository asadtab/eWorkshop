import 'dart:convert';
import 'dart:io';

import 'package:commons/models/uredjaj.dart';
import 'package:flutter/material.dart';
import 'package:oauth2/oauth2.dart' as oauth2;
import 'package:uni_links/uni_links.dart';
import 'package:url_launcher/url_launcher.dart';

class IdsProvider extends ChangeNotifier {
  final authorizationEndpoint = Uri.parse("https://localhost:5443");
  final tokenEndpoint = Uri.parse("https://localhost:5443/connect/token");

  final identifier = 'flutter';

  final redirectUrl = Uri.parse('https://localhost:7189/callback');

  final credentialsFile = File('~/.myapp/credentials.json');

  Future<oauth2.Client> createClient() async {
    var exists = await credentialsFile.exists();

    if (exists) {
      var credentials = oauth2.Credentials.fromJson(await credentialsFile.readAsString());
      return oauth2.Client(credentials, identifier: identifier);
    }

    var grant = oauth2.AuthorizationCodeGrant(identifier, authorizationEndpoint, tokenEndpoint);

    List<String> scopes = ['openid', 'profile', 'offline_access', 'weatherapi.read', 'weatherapi.write'];

    var authorizationUrl = grant.getAuthorizationUrl(redirectUrl, scopes: scopes);

    await redirect(authorizationUrl);
    var responseUrl = await listen(redirectUrl);

    return await grant.handleAuthorizationResponse(responseUrl.queryParameters);
  }

  redirect(Uri authorizationUrl) async {
    if (await canLaunchUrl(authorizationUrl)) {
      await launchUrl(authorizationUrl, mode: LaunchMode.externalNonBrowserApplication);
    } else {
      throw Exception('Unable to launch authorization URL.');
    }
  }

  listen(Uri redirectUrl) async {
    return await uriLinkStream.firstWhere(
      (element) => element.toString().startsWith(
            redirectUrl.toString(),
          ),
    );
  }

  Future<List<Uredjaj>> getIds(oauth2.Client client) async {
    String uri = "https://localhost:7189/Uredjaj";

    final response = await client.get(Uri.parse(uri));

    if (response.statusCode < 400) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<Uredjaj>().toList();
    } else {
      throw Exception("Greska!");
    }
  }

  Uredjaj fromJson(data) {
    throw Exception("Override method");
  }
}
