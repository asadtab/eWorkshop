import 'dart:io';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/material.dart';
import 'package:workshop_app/providers/base_provider.dart';
import 'dart:convert';

import '../model/uredjaj.dart';

class UredjajiProvider extends BaseProvider<Uredjaj> {
  UredjajiProvider() : super("Uredjaj") {}

  @override
  Uredjaj fromJson(data) {
    return Uredjaj.fromJson(data);
  }
}
