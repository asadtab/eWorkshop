import 'package:commons/models/radni_zadatak.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/providers/radniZadaci_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../../common_widget/radni_zadaci.dart';
import '../../helpers/bottom_bar.dart';
import '../../helpers/common_widget.dart';
import '../../helpers/master_screen.dart';
import '../../helpers/state_helper.dart';
import 'dodaj_uredi_zadatak.dart';

class ListaZadataka extends StatefulWidget {
  static const routeName = "/radniZadaci";
  ListaZadataka({super.key});

  @override
  State<ListaZadataka> createState() => _ListaZadatakaState();
}

class _ListaZadatakaState extends State<ListaZadataka> {
  bool _isLoading = true;
  RadniZadaciUredjajProvider? _uredjajZadaci = null;
  RadniZadaciProvider? _zadaci = null;
  List<RadniZadatakUredjaj> uredjajiUZadatku = [];
  List<RadniZadatak> radniZadatak = [];

  String _selectedOption = 'Aktivni';

  _ListaZadatakaState() {}

  @override
  void initState() {
    super.initState();

    _uredjajZadaci = context.read<RadniZadaciUredjajProvider>();
    _zadaci = context.read<RadniZadaciProvider>();

    var map = {'StateMachine': 'active'};

    _fetchData(map);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    setState(() {
      _isLoading = true;
    });

    try {
      var responseZadaci = await _zadaci?.get(map, "RadniZadatak");

      var response = await _uredjajZadaci?.get(map, "RadniZadatakUredjaj/Flutter");

      setState(() {
        uredjajiUZadatku = response!;
        radniZadatak = responseZadaci!;
        _isLoading = false;
      });
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        drawer: DrawerWidget(),
        appBar: AppBar(
          title: Text(
            "Radni zadaci",
            style: TextStyle(fontWeight: FontWeight.bold),
          ),
        ),
        bottomNavigationBar: MyBottomBar(),
        floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
        floatingActionButton: FloatingActionButton(
          onPressed: () {
            Navigator.pushNamed(context, RadniZadatakDodajUredi.routeName);
          },
          child: Icon(Icons.add),
        ),
        body: SafeArea(
            child: SingleChildScrollView(
                child: Column(children: [
          Row(
            children: [Padding(padding: EdgeInsets.fromLTRB(20, 0, 0, 0), child: dropDown())],
          ),
          CommonWidget.dividerDetalji(),
          _isLoading
              ? Center(child: CircularProgressIndicator())
              : Container(
                  height: MediaQuery.of(context).size.height - 200,
                  child: GridView(
                    gridDelegate:
                        SliverGridDelegateWithFixedCrossAxisCount(crossAxisCount: 2, childAspectRatio: 0.5, mainAxisSpacing: 0, crossAxisSpacing: 0),
                    children: RadniZadatakCommon.zadatak(context, uredjajiUZadatku, radniZadatak),
                  ))
        ]))));
  }

  Widget dropDown() {
    return DropdownButton<String>(
      value: _selectedOption,
      icon: const Icon(Icons.arrow_downward),
      elevation: 16,
      style: const TextStyle(color: Colors.deepPurple),
      underline: Container(
        height: 2,
        color: Colors.blueGrey,
      ),
      onChanged: (String? newValue) {
        _fetchData({'StateMachine': StateHelper.nizZadatakStateSearch(newValue!)});

        setState(() {
          _selectedOption = newValue;
        });
      },
      items: StateHelper.nizZadatakStateOpis.map<DropdownMenuItem<String>>((String value) {
        return DropdownMenuItem<String>(
          value: value,
          child: Text(value),
        );
      }).toList(),
    );
  }
}
