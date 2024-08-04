import 'package:commons/models/radni_zadatak.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/radniZadaci_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_speed_dial/flutter_speed_dial.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/helpers/state_helper.dart';

import 'package:workshop_app/screens/uredjaji/lista_uredjaja.dart';

import '../../helpers/bottom_bar.dart';
import '../../helpers/common_widget.dart';
import '../../helpers/master_screen.dart';
import '../../helpers/statistika.dart';

class RadniZadatakDetaljiScreen extends StatefulWidget {
  static const String routeName = "/radniZadatakDetalji";
  List<RadniZadatakUredjaj>? radniZadatak = [];
  List<Uredjaj>? uredjajiLista = [];
  int RadniZadatakId = 0;

  RadniZadatakDetaljiScreen.zadaci(List<RadniZadatakUredjaj> zadaci) {
    radniZadatak = zadaci;
  }

  RadniZadatakDetaljiScreen.zadaciUredjaji(List<RadniZadatakUredjaj>? zadaci, int radniZadatakId) {
    radniZadatak = zadaci;
    RadniZadatakId = radniZadatakId;
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
  UredjajProvider? uredjajProvider = null;
  RadniZadatak? detalji;
  RadniZadatakUredjaj? uredjajiZadatak;
  RadniZadaciProvider? radniZadatakProvider = null;
  RadniZadaciUredjajProvider? radniZadatakUredjajProvider = null;
  RadniZadatak? radniZadatakDetalji = null;
  int radniZadatakId = 0;
  bool isLoading = true;
  String lokacija = "Nepoznato";
  String progres = "0";

  _RadniZadatakDetaljiScreenState.uredjaji(List<RadniZadatakUredjaj>? uredjaji, int? RadniZadatakId) {
    radniZadatak = uredjaji;

    if (RadniZadatakId != 0) {
      radniZadatakId = RadniZadatakId!;
    } else {
      radniZadatakId = uredjaji!.first.radniZadatakId!;
    }
  }

  @override
  void initState() {
    super.initState();

    uredjajProvider = context.read<UredjajProvider>();
    radniZadatakProvider = context.read<RadniZadaciProvider>();
    radniZadatakUredjajProvider = context.read<RadniZadaciUredjajProvider>();

    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    setState(() {
      isLoading = true;
    });

    var responseZadatak = await radniZadatakProvider!.get({'RadniZadatakId': radniZadatakId}, "RadniZadatak");
    var result = await radniZadatakUredjajProvider!.get({'RadniZadatakId': radniZadatakId}, "RadniZadatakUredjaj/Flutter");

    setState(() {
      radniZadatakDetalji = responseZadatak.first;

      if (result != null && result.length != 0) {
        radniZadatak = result;
        lokacija = radniZadatak!.first.lokacija!;
        //progres = radniZadatak!.first.progress.toString();
      }

      isLoading = false;
      radniZadatak = result;

      uredjaji.clear();

      for (var i = 0; i < radniZadatak!.length; i++) {
        var device = Uredjaj();
        device.godinaIzvedbe = radniZadatak![i].uredjajDatumIzvedbe;
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
              if (radniZadatakDetalji != null && radniZadatakDetalji!.stateMachine != "done" && radniZadatakDetalji!.stateMachine != "invoice")
                SpeedDialChild(
                    child: Icon(Icons.add),
                    label: 'Dodaj uređaj',
                    backgroundColor: Colors.blue,
                    onTap: () {
                      Navigator.pop(context);
                      Navigator.push(context, MaterialPageRoute(builder: (context) => UredjajiListScreen.add(radniZadatakDetalji!.radniZadatakId)));
                    }),
              if (radniZadatakDetalji != null &&
                  radniZadatakDetalji!.stateMachine != "idle" &&
                  radniZadatakDetalji!.stateMachine != "done" &&
                  radniZadatakDetalji!.stateMachine != "invoice")
                SpeedDialChild(
                    child: Icon(Icons.done),
                    label: 'Završi',
                    onTap: () {
                      zavrsiZadatak();
                    }),
              if (radniZadatakDetalji != null && radniZadatakDetalji!.stateMachine == "done" && radniZadatakDetalji!.stateMachine != "invoice")
                SpeedDialChild(
                    child: Icon(Icons.mark_email_read),
                    label: 'Fakturiši',
                    onTap: () async {
                      try {
                        await radniZadatakProvider!.update(radniZadatakId, null, "RadniZadatak/Fakturisi");

                        _fetchData(null);
                        ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Radni zadatak je uspješno fakturisan!"));
                        isDialOpen.value = false;
                        return;
                      } catch (e) {
                        ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
                      }
                      isDialOpen.value = false;
                      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Neuspješna akcija"));
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
                              CommonWidget.detaljiContainer("Id:"),
                              CommonWidget.detaljiContainer("Naziv:"),
                              CommonWidget.detaljiContainer("Datum kreiranja:"),
                              CommonWidget.detaljiContainer("Status:"),
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
                              CommonWidget.detaljiContainer(radniZadatakDetalji?.radniZadatakId.toString() ?? ''),
                              CommonWidget.detaljiContainer(radniZadatakDetalji?.naziv ?? ''),
                              CommonWidget.detaljiContainer(DateTime.parse(radniZadatakDetalji?.datum ?? "").day.toString() +
                                  "." +
                                  DateTime.parse(radniZadatakDetalji?.datum ?? "").month.toString() +
                                  "." +
                                  DateTime.parse(radniZadatakDetalji?.datum ?? "").year.toString()),
                              CommonWidget.detaljiContainer(StateHelper.nizZadatakRezultat(radniZadatakDetalji?.stateMachine ?? "")),
                              CommonWidget.detaljiContainer(radniZadatak == null ? '0' : radniZadatak!.length.toString()),
                              CommonWidget.detaljiContainer(Statistika.postotak(radniZadatak!).toString() + "%")
                            ],
                          )
                        ])),
              ),
            ),
            CommonWidget.dividerDetalji(),
            Container(padding: EdgeInsets.fromLTRB(20, 10, 0, 10), child: Text("Uređaji:", style: TextStyle(fontSize: 20))),
            Container(
                padding: EdgeInsets.fromLTRB(10, 0, 0, 50),
                height: 470,
                child: GridView(
                    gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                        crossAxisCount: 2, childAspectRatio: 1.3, mainAxisSpacing: 10, crossAxisSpacing: 10),
                    children: CommonWidget.list(context, uredjaji, uredjajProvider, radniZadatakId))),
          ]))),
        ));
  }

  void zavrsiZadatak() async {
    try {
      await radniZadatakProvider!.update(radniZadatakId, null, "RadniZadatak/Zavrsi");

      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack("Radni zadatak je završen!"));

      for (var uredjaj in radniZadatak!) {
        if (uredjaj.uredjajStatus == "task") {
          await uredjajProvider!.update(uredjaj.uredjajId, null, "Uredjaj/Aktiviraj-Ready-Vrati");
        }
      }

      _fetchData(null);
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
    }
  }
}
