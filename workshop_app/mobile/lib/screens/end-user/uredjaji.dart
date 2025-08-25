import 'package:commons/models/korisnik.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/models/user.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/common_widget/device_card.dart';
import 'package:workshop_app/helpers/common_widget.dart';

class EndUredjaji extends StatefulWidget {
  late List<Uredjaj> uredjaji;
  late Korisnik korisnik;

  EndUredjaji({required this.uredjaji, required this.korisnik});

  @override
  State<EndUredjaji> createState() => _EndUredjajiState();
}

class _EndUredjajiState extends State<EndUredjaji> {
  List<Uredjaj> data = [];
  UredjajProvider? _uredjajiProvider = null;
  List<RadniZadatakUredjaj> uredjajRadniZadatak = [];
  RadniZadaciUredjajProvider? radniZadaciUredjajProvider = null;

    @override
  void initState() {
    super.initState();

    _uredjajiProvider = context.read<UredjajProvider>();
    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();

    var map = {'lokacija': widget.korisnik.radnaJedinica};

    _fetchData(map);
  }

   Future<void> _fetchData(Map<String, dynamic>? map) async {
    final response = await radniZadaciUredjajProvider?.get(map, "RadniZadatakUredjaj/Flutter");

    setState(() {
      uredjajRadniZadatak = response!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(appBar: AppBar(title: Text("Radna jedinica: ${widget.korisnik.radnaJedinica}", style: TextStyle(color: Colors.white)), backgroundColor: Color(0xFF4592AF), ), body: SafeArea(child: 
    SingleChildScrollView(
      scrollDirection: Axis.vertical,
      child: Column(
        children: 
          uredjajRadniZadatak.map((x)=> DeviceCard(x)).cast<Widget>().toList(),
        
      ),
    )));
  }
}