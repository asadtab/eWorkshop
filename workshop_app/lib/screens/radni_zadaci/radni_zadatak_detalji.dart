import 'package:flutter/material.dart';
import 'package:flutter_speed_dial/flutter_speed_dial.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/model/radni_zadatak_uredjaj.dart';
import 'package:workshop_app/model/uredjaj.dart';
import 'package:workshop_app/providers/radniZadaci_provider.dart';
import 'package:workshop_app/screens/uredjaji/lista_uredjaja.dart';

import '../../helpers/bottom_bar.dart';
import '../../helpers/common_widget.dart';
import '../../helpers/master_screen.dart';
import '../../model/radni_zadatak.dart';
import '../../providers/radniZadaci_uredjaj_provider.dart';
import '../../providers/uredjaji_provider.dart';

class RadniZadatakDetaljiScreen extends StatefulWidget {
  static const String routeName = "/radniZadatakDetalji";
  List<RadniZadatakUredjaj>? radniZadatak = [];
  List<Uredjaj>? uredjajiLista = [];
  int RadniZadatakId = 0;

  RadniZadatakDetaljiScreen.zadaci(List<RadniZadatakUredjaj> zadaci) {
    radniZadatak = zadaci;
  }

  RadniZadatakDetaljiScreen.addUredjaj(int idZadatak) {
    RadniZadatakId = idZadatak;
  }

  RadniZadatakDetaljiScreen({super.key});

  @override
  State<RadniZadatakDetaljiScreen> createState() => _RadniZadatakDetaljiScreenState.uredjaji(radniZadatak, RadniZadatakId);
}

class _RadniZadatakDetaljiScreenState extends State<RadniZadatakDetaljiScreen> {
  List<RadniZadatakUredjaj>? radniZadatak = [];
  List<Uredjaj> uredjaji = [];
  final GlobalKey<ScaffoldState> _scaffoldKey = new GlobalKey<ScaffoldState>();
  UredjajiProvider? uredjajProvider = null;
  RadniZadatakUredjaj? detalji;
  RadniZadaciProvider? radniZadatakProvider = null;
  RadniZadaciUredjajProvider? radniZadatakUredjajProvider = null;
  RadniZadatak? radniZadatakDetalji = null;
  int radniZadatakId = 0;
  bool isLoading = true;

  _RadniZadatakDetaljiScreenState.uredjaji(List<RadniZadatakUredjaj>? uredjaji, [int? RadniZadatakId]) {
    radniZadatak = uredjaji;

    if (RadniZadatakId != 0) {
      radniZadatakId = RadniZadatakId!;
    } else {
      radniZadatakId = uredjaji!.first.radniZadatakId;
    }
  }

  @override
  void initState() {
    super.initState();

    uredjajProvider = context.read<UredjajiProvider>();
    radniZadatakProvider = context.read<RadniZadaciProvider>();
    radniZadatakUredjajProvider = context.read<RadniZadaciUredjajProvider>();

    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    setState(() {
      isLoading = true;
    });

    var result = await radniZadatakUredjajProvider!.get({'RadniZadatakId': radniZadatakId}, "RadniZadatakUredjaj/Flutter");

    setState(() {
      detalji = result.first;
      isLoading = false;
      radniZadatak = result;

      for (var i = 0; i < radniZadatak!.length; i++) {
        var device = Uredjaj();
        device.datumIzvedbe = radniZadatak![i].uredjajDatumIzvedbe;
        device.koda = radniZadatak![i].koda;
        device.lokacijaNaziv = radniZadatak![i].lokacija;
        device.serijskiBroj = radniZadatak![i].serijskiBroj;
        device.status = radniZadatak![i].uredjajStatus;
        device.tipNaziv = radniZadatak![i].tipNaziv;
        device.tipOpis = radniZadatak![i].tipOpis;
        device.uredjajId = radniZadatak![i].uredjajId;

        uredjaji.add(device);
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    ValueNotifier<bool> isDialOpen = ValueNotifier(false);
    return WillPopScope(
        onWillPop: () async {
          if (isDialOpen.value) {
            isDialOpen.value = false;
            return false;
          } else {
            return true;
          }
        },
        child: Scaffold(
          drawer: DrawerWidget(),
          bottomNavigationBar: MyBottomBar(),
          floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
          floatingActionButton: SpeedDial(
            animatedIcon: AnimatedIcons.menu_close,
            openCloseDial: isDialOpen,
            overlayColor: Colors.grey,
            overlayOpacity: 0.5,
            spacing: 15,
            spaceBetweenChildren: 15,
            closeManually: true,
            children: [
              if (detalji != null && detalji!.radniZadatakStatus != "done")
                SpeedDialChild(
                    child: Icon(Icons.add),
                    label: 'Dodaj uređaj',
                    backgroundColor: Colors.blue,
                    onTap: () {
                      Navigator.pop(context);
                      Navigator.push(context, MaterialPageRoute(builder: (context) => UredjajiListScreen.add(detalji!.radniZadatakId)));
                    }),
              if (detalji != null && detalji!.radniZadatakStatus == "done")
                SpeedDialChild(
                    child: Icon(Icons.airport_shuttle),
                    label: 'Isporuči',
                    onTap: () {
                      print('Copy Tapped');
                    }),
              SpeedDialChild(
                  child: Icon(Icons.done),
                  label: 'Završi',
                  onTap: () {
                    zavrsiZadatak();
                  }),
              if (detalji != null && detalji!.radniZadatakStatus == "done")
                SpeedDialChild(
                    child: Icon(Icons.mark_email_read),
                    label: 'Fakturiši',
                    onTap: () {
                      print('Copy Tapped');
                    })
            ],
          ),
          appBar: AppBar(title: (Text("Radni zadatak"))),
          body: SafeArea(
              child: SingleChildScrollView(
                  child: Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
            Container(
              child: Padding(
                padding: EdgeInsets.all(10),
                child: isLoading
                    ? Center(child: CircularProgressIndicator())
                    : Container(
                        decoration: BoxDecoration(),
                        child: Row(mainAxisAlignment: MainAxisAlignment.start, children: [
                          Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              CommonWidget.detaljiContainer("Naziv:"),
                              CommonWidget.detaljiContainer("Datum kreiranja:"),
                              CommonWidget.detaljiContainer("Status:"),
                              CommonWidget.detaljiContainer("Lokacija:"),
                              CommonWidget.detaljiContainer("Ukupno:"),
                              CommonWidget.detaljiContainer("Progres:"),
                              SizedBox(
                                width: 200,
                              ),
                            ],
                          ),
                          Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              CommonWidget.detaljiContainer(detalji?.radniZadatakNaziv ?? ''),
                              CommonWidget.detaljiContainer(detalji?.radniZadatakDatum ?? ''),
                              CommonWidget.detaljiContainer(detalji?.radniZadatakStatus ?? ''),
                              CommonWidget.detaljiContainer(detalji?.lokacija ?? ''),
                              CommonWidget.detaljiContainer(radniZadatak!.length.toString()),
                              CommonWidget.detaljiContainer(detalji?.progress.toString() ?? '')
                            ],
                          )
                        ])),
              ),
            ),
            CommonWidget.dividerDetalji(),
            Container(padding: EdgeInsets.fromLTRB(20, 10, 0, 10), child: Text("Uređaji:", style: TextStyle(fontSize: 20))),
            Container(
                padding: EdgeInsets.fromLTRB(10, 0, 0, 50),
                height: 500,
                child: GridView(
                    gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                        crossAxisCount: 2, childAspectRatio: 1.5, mainAxisSpacing: 10, crossAxisSpacing: 10),
                    children: CommonWidget.list(context, uredjaji, uredjajProvider, radniZadatakId))),
          ]))),
        ));
  }

  void zavrsiZadatak() async {
    try {
      await radniZadatakProvider!.update(radniZadatakId, null, "RadniZadatak/Zavrsi");
    } catch (e) {}
  }
}
