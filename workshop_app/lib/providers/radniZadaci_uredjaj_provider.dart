import 'dart:io';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/material.dart';
import 'package:workshop_app/providers/base_provider.dart';
import 'dart:convert';

import '../model/radni_zadatak.dart';
import '../model/radni_zadatak_uredjaj.dart';

class RadniZadaciUredjajProvider extends BaseProvider<RadniZadatakUredjaj> {
  RadniZadaciUredjajProvider() : super("RadniZadatakUredjaj/Flutter") {}

  @override
  RadniZadatakUredjaj fromJson(data) {
    return RadniZadatakUredjaj.fromJson(data);
  }
}
