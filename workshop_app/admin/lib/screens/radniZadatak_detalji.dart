import 'package:admin/commons/app_bar.dart';
import 'package:admin/screens/uredjaj_detalji.dart';

import 'package:admin/widgets/status_icons.dart';
import 'package:admin/widgets/uredjaj_pdf.dart';
import 'package:commons/bloc/radni_zadatak/radni_zadatak_bloc.dart';
import 'package:commons/bloc/radni_zadatak_uredjaj/bloc/radni_zadatak_uredjaj_block_bloc.dart';
import 'package:commons/bloc/uredjaji_lista_zadatak.dart/bloc/uredjaji_lista_zadatak_bloc.dart';
import 'package:commons/helpers/format_datuma.dart';
import 'package:commons/helpers/state_helper.dart';
import 'package:commons/models/radni_zadatak.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/radniZadaci_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class RadnizadatakDetaljiScreen extends StatefulWidget {
  const RadnizadatakDetaljiScreen(
      {this.radniZadatak, this.radniZadatakUredjaj});

  final RadniZadatak? radniZadatak;
  final List<RadniZadatakUredjaj>? radniZadatakUredjaj;

  @override
  State<RadnizadatakDetaljiScreen> createState() =>
      _RadnizadatakDetaljiScreenState();
}

class _RadnizadatakDetaljiScreenState extends State<RadnizadatakDetaljiScreen> {

  RadniZadaciUredjajProvider? radniZadaciUredjajProvider = null;
  RadniZadaciProvider? radniZadaciProvider = null;
  List<RadniZadatakUredjaj> radniZadatakUredjaj = [];

  RadniZadatakBloc? radniZadatakBloc;
  RadniZadatakUredjajBloc? uredjajBloc;
   UredjajiListaZadatakBloc? uredjajBlocActive;
   

  @override
  void initState() {
    radniZadaciUredjajProvider = context.read<RadniZadaciUredjajProvider>();
    radniZadaciProvider = context.read<RadniZadaciProvider>();


    radniZadatakBloc = BlocProvider.of<RadniZadatakBloc>(context);
    radniZadatakBloc!.add(RadniZadatakSingleIdEvent(id: widget.radniZadatak!.radniZadatakId));

    uredjajBloc = BlocProvider.of<RadniZadatakUredjajBloc>(context);

    uredjajBlocActive = BlocProvider.of<UredjajiListaZadatakBloc>(context);

    _fetchData(null);
    super.initState();
  }

    Future<void> _fetchData(Map<String, String>? map) async {

      final responseUredjaji = await radniZadaciUredjajProvider!.get({'RadniZadatakId':widget.radniZadatak!.radniZadatakId}, "RadniZadatakUredjaj/Flutter");
  
      setState(() {
        this.radniZadatakUredjaj =  responseUredjaji;
      });

  }

  @override
  Widget build(BuildContext context) {

    final RadniZadatakBloc zadatakBloc = BlocProvider.of<RadniZadatakBloc>(context);


    return Scaffold(
        appBar: BarrApp(naslov: "Informacije o radnom zadatku"),
         body: BlocConsumer<RadniZadatakBloc, RadniZadatakState>(
          listenWhen: (previous, current) => current is ZadatakDataLoadedState,
          listener: (context, state) {
          },
          builder: (context, state) {
            if(state is ZadatakDataLoadedState){
              var zadatak = state.data;
            return 
                SingleChildScrollView(
                  scrollDirection: Axis.horizontal,
                  child: Row(  
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    children: [
                      Column(children: [
                        Card(
                                  color: Color(0xFFf3f5fb),
                                  elevation: 4.0,
                                  margin: EdgeInsets.all(16.0),
                                  child: Padding(
                                    padding: const EdgeInsets.all(16.0),
                                    child: Column(
                                      crossAxisAlignment: CrossAxisAlignment.start,
                                      children: [
                                        Text(
                                          'Radni zadatak',
                                          style: TextStyle(
                                            fontSize: 20,
                                            fontWeight: FontWeight.bold,
                                          ),
                                        ),
                                        SizedBox(height: 20),
                                        DataTable(
                                          columns: const [
                                            DataColumn(label: Text('ID')),
                                            DataColumn(label: Text('Naziv')),
                                            DataColumn(label: Text('Status')),
                                            DataColumn(label: Text('Datum kreiranja')),
                                            
                                          ],
                                          rows: [
                                            DataRow(
                                              cells: [
                                                DataCell(tekstInfo(zadatak.radniZadatakId.toString())),
                                                DataCell(
                                                    tekstInfo(zadatak.naziv ?? "")),
                                                DataCell(buildIcon.buildStatusCellZadatak(zadatak.stateMachine)),
                                                DataCell(tekstInfo(FormatirajDatum.formatiraj(DateTime.parse(zadatak.datum.toString())))),
                                               
                                              ],
                                            ),
                                          ],
                                        )
                                      ],
                                    ),
                                  ),
                                ),
                                Container(
                                  width: 350,
                                  child: Card(
                                    color: Color(0xFFf3f5fb),
                                  elevation: 4.0,
                                  margin: EdgeInsets.all(16.0),
                                    child: Padding(
                                      padding: const EdgeInsets.all(8.0),
                                      child: ListView(
                                        shrinkWrap: true,
                                        children: [
                                          if(
                                            zadatak.stateMachine == 'idle' )
                                          Text("Aktiviraj radni zadatak dodavanjem uređaja u sekciji 'Raspored uređaja'", style: TextStyle(fontWeight: FontWeight.bold, fontSize:15),),
                                          if(
                                            zadatak.stateMachine == 'done' ||
                                            zadatak.stateMachine == 'invoice' )
                                          MinimalisticButton(
                                        text: "Kreiraj izvještaj",
                                        icons: Icon(Icons.description, color: Colors.black),
                                        color: Color(0xFF64B5F6),
                                        textColor: Colors.black,
                                        onPressed: () {
                                          var uredjaji = radniZadatakUredjaj;
                              //.where((uredjaj) => uredjaj.radniZadatakStatus == "done" || uredjaj.radniZadatakStatus == "fix")
                              //.toList();

                              try {
                                GenerisiPdf.generisiPdf(uredjaji);
                              } catch (e) {
                                poruka(e.toString());
                              }
                                        },
                                      ),
                                      if(
                                            zadatak.stateMachine == 'active')
                                      MinimalisticButton(
                                        text: "Završi",
                                        icons: Icon(Icons.check_circle, color: Colors.black),
                                        color: Color(0xFF81C784),
                                        textColor: Colors.black,
                                        onPressed: 
                                           () async {
                            await zavrsiZadatak(zadatak);
                                        
                                        }),
            
                                      if(
                                            zadatak.stateMachine == 'done')
                                      MinimalisticButton(
                                        text: "Fakturiši",
                                        icons: Icon(Icons.receipt_long, color: Colors.black),
                                        color: Color(0xFFFFD54F),
                                        textColor: Colors.black,
                                        onPressed: ()async {
                                         await fakturisiZadatak(zadatak);
   
                                        },
                                      )],),
                                    ),
                                  ),
                                )
                                 ,
                  
                      ],),
                  
                      Column(children: [
                        
                        Container(
                          child: Card(
                            color: Color(0xFFf3f5fb),
                                  elevation: 4.0,
                                  margin: EdgeInsets.all(16.0),
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Padding(
                                  padding: const EdgeInsets.all(8.0),
                                  child: Text("Uređaji",style: TextStyle(
                                            fontSize: 20,
                                            fontWeight: FontWeight.bold,
                                          ) ,),
                                ),
                                DataTable(
                            showCheckboxColumn: false,
                            columns: [
                              DataColumn(label: Text('Id')),
                              DataColumn(label: Text('Tip')),
                              DataColumn(label: Text('Naziv')),
                              DataColumn(label: Text('Koda')),
                              DataColumn(label: Text('Ser. broj')),
                              DataColumn(label: Text('Status')),
                              DataColumn(label: Text('Lokacija')),
                              DataColumn(label: Text('Opcije')),
                            ],
                            rows: radniZadatakUredjaj
                                .map((x) => DataRow(
                                        onSelectChanged: (isSelected) async {
                                          
                                              if (isSelected!)
                                                {
                                                   Uredjaj noviUredjaj = x.toUredjaj();
                            
                                                  await Navigator.push(
                                                      context,
                                                      MaterialPageRoute(
                                                          builder: (context) => UredjajDetaljiScreen(
                                                                uredjaj: noviUredjaj,
                                                                context: context,
                                                              )));
                                                      //.then((value) => uredjajBloc.add(UredjajFilterEvent(status: StateHelper.nizSearch(dropdownvalue))))
                                                };
                                            },
                                        cells: [
                                          DataCell( Text(x.uredjajId.toString())),
                                          DataCell(Text(x.tipNaziv ?? "")),
                                          DataCell(Text(x.tipOpis ?? "")),
                                          DataCell(Text(x.koda ?? "")),
                                          DataCell(Text(x.serijskiBroj ?? "")),
                                          DataCell(buildIcon.buildStatusCellUredjaj(x.uredjajStatus)),
                            
                                          DataCell(Text(x.lokacija ?? "")),
                                          DataCell(PopupMenuButton<String>(
                                            //initialValue: selected,
                                            // Callback that sets the selected popup menu item.
                                            onSelected: (izbor) {
                                              if (x.uredjajStatus == "idle") {
                                                showDialog(
                                                    context: context,
                                                    builder: (BuildContext context) {
                                                      return AlertDialog(
                                                        title: Text("Da li želite ukloniti uređaj iz radnog zadatka"),
                                                        content: Row(mainAxisAlignment: MainAxisAlignment.spaceEvenly, children: [
                                                          MinimalisticButton(
                                                              text: "Potvrdi",
                                                              icons: Icon(Icons.save, color: Colors.blueAccent,),
                                                              onPressed: () async {
                                                                /*try {
                                                                  await _uredjajiProvider!.delete(x.uredjajId, x, "Uredjaj");
                                                                } catch (e) {}
                                                                uredjajBloc.add(UredjajFilterEvent(status: 'idle'));*/
                                                                Navigator.pop(context);
                                                                ScaffoldMessenger.of(context)
                                                    .showSnackBar(CustomNotification.infoSnack("Uređaj je uspješno izbrisan"));
                                                              }),
                                                          MinimalisticButton(
                                                            text: "Poništi",
                                                            icons: Icon(Icons.cancel, color: Colors.redAccent,),
                                                              onPressed: () async {Navigator.pop(context);})
                                                        ]),
                                                      );
                                                    });
                                              } else {
                                                ScaffoldMessenger.of(context)
                                                    .showSnackBar(CustomNotification.infoSnack("Samo neaktivni uređaji se mogu izbrisati."));
                                              }
                                            },
                                            itemBuilder: (BuildContext context) => <PopupMenuEntry<String>>[
                                              PopupMenuItem<String>(
                                                child: Text('Izbriši'),
                                                value: 'delete',
                                              ),
                                            ],
                                          )),
                                        ]))
                                .toList()),
                              ],
                            ),
                          ),
                        )
                      ],)
                      
                    ]),
                );} else {
                  return Text("Nema podataka");
                }
                  
                
                
          },
        ));
  }
   Text tekstInfo(String uredjaj) => Text(
        uredjaj,
        style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 17),
      );

        void poruka(String poruka) {
    ScaffoldMessenger.of(context)
        .showSnackBar(CustomNotification.infoSnack(poruka));
  }
  Future<RadniZadatak?> zavrsiZadatak(RadniZadatak zadatak) async {
    showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
              title: Text("Da li želite označiti zadatak završenim"),
              content: Container(
                  height: 100,
                  child: Container(
                      padding: EdgeInsets.fromLTRB(0, 29, 0, 0),
                      child: Row(
                          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                          children: [
                            MinimalisticButton(
                                text: "Potvrdi",
                                onPressed: () async {
                                  var temp;
                                  try {
                                    temp = await radniZadaciProvider!.update(
                                        widget.radniZadatak!.radniZadatakId,
                                        null,
                                        "RadniZadatak/Zavrsi");
                                  } catch (e) {
                                    poruka(e.toString());
                                  }
                                  poruka(
                                      "Radni zadatak '${(temp as RadniZadatak).naziv}' je završen. Uređaji koji nisu servisirani su ponovno aktivni.");
                                  uredjajBlocActive!
                                      .add(UredjajiLoadZadatakEvent());
                                  uredjajBloc!.add(RadniZadatakIdEvent(id: zadatak.radniZadatakId));
                                  radniZadatakBloc!.add(RadniZadatakSingleIdEvent(id: zadatak.radniZadatakId));

                                  var zadatakUredjaj =
                                      await radniZadaciUredjajProvider!.get(
                                          {'RadniZadatakId': widget.radniZadatak!.radniZadatakId},
                                          "RadniZadatakUredjaj/Flutter");

                                  var odabraniZadatakTemp =
                                      await radniZadaciProvider!.get(
                                          {'RadniZadatakId': widget.radniZadatak!.radniZadatakId},
                                          'RadniZadatak');

                                  //List<RadniZadatak>? responseZadatak = await idleActiveZadatak();
                                  Navigator.pop(context);

                                  setState(() {
                                    radniZadatakUredjaj = zadatakUredjaj;
                                    //radniZadatak = responseZadatak!;
                                    /*zadata =
                                        odabraniZadatakTemp.first;*/
                                    //dropdownvalue = 0;
                                  });
                                }),
                            ElevatedButton(
                                child: Text(
                                    style: TextStyle(color: Colors.white),
                                    "Poništi"),
                                style: ElevatedButton.styleFrom(
                                  backgroundColor:
                                      Color.fromARGB(255, 170, 70, 63),
                                  elevation: 2,
                                ),
                                onPressed: () {
                                  Navigator.pop(context);
                                })
                          ]))));
        });
    return null;
  }
                                           Future<RadniZadatak?> fakturisiZadatak(RadniZadatak zadatak) async {
    showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
              title: Text("Da li želite fakturisati zadatak"),
              content: Container(
                  height: 50,
                  child: Container(
                      padding: EdgeInsets.fromLTRB(0, 29, 0, 0),
                      child: Row(
                          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                          children: [
                            ElevatedButton(
                                child: Text("Potvrdi"),
                                style: ElevatedButton.styleFrom(
                                  elevation: 2,
                                ),
                                onPressed: () async {
                                  var temp;

                                  try {
                                    temp = await radniZadaciProvider!.update(
                                        zadatak.radniZadatakId,
                                        null,
                                        "RadniZadatak/Fakturisi");
                                  } catch (e) {
                                    poruka(e.toString());
                                  }

                                  poruka(
                                      "Radni zadatak '${(temp as RadniZadatak).naziv}' je fakturisan.");

                                  uredjajBlocActive!
                                      .add(UredjajiLoadZadatakEvent());
                                  uredjajBloc!.add(RadniZadatakLoadingEvent());

                                  radniZadatakBloc!.add(RadniZadatakSingleIdEvent(id: zadatak.radniZadatakId));

                                 /* var zadatakUredjaj =
                                      await radniZadaciUredjajProvider!.get(
                                          {'RadniZadatakId': odabraniZadatakId},
                                          "RadniZadatakUredjaj/Flutter");

                                  var odabraniZadatakTemp =
                                      await radniZadaciProvider!.get(
                                          {'RadniZadatakId': odabraniZadatakId},
                                          'RadniZadatak');*/

                                  //List<RadniZadatak>? responseZadatak = await idleActiveZadatak();
                                  Navigator.pop(context);

                                  setState(() {
                                    //radniZadatakUredjaj = zadatakUredjaj;
                                    //radniZadatak = responseZadatak!;
                                    
                                  });
                                }),
                            ElevatedButton(
                                child: Text("Poništi"),
                                style: ElevatedButton.styleFrom(
                                  backgroundColor:
                                      Color.fromARGB(255, 170, 70, 63),
                                  elevation: 2,
                                ),
                                onPressed: () {
                                  Navigator.pop(context);
                                })
                          ]))));
        });
    return null;
  }
}
