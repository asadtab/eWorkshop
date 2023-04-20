import 'dart:io';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/material.dart';
import 'package:workshop_app/providers/base_provider.dart';
import 'dart:convert';

import '../model/radni_zadatak.dart';
import '../model/uredjaj.dart';

class RadniZadaciProvider extends BaseProvider<RadniZadatak> {
  RadniZadaciProvider() : super("RadniZadatak");

  @override
  RadniZadatak fromJson(data) {
    return RadniZadatak.fromJson(data);
  }
}
