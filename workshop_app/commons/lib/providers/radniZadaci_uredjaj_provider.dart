import 'dart:io';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/material.dart';
import 'dart:convert';

import '../models/radni_zadatak_uredjaj.dart';
import 'base_provider.dart';

class RadniZadaciUredjajProvider extends BaseProvider<RadniZadatakUredjaj> {
  RadniZadaciUredjajProvider() : super("RadniZadatakUredjaj/Flutter") {}

  @override
  RadniZadatakUredjaj fromJson(data) {
    return RadniZadatakUredjaj.fromJson(data);
  }
}
