import 'package:commons/helpers/status_icons.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/helpers/state_helper.dart';
import 'package:workshop_app/screens/uredjaji/uredjaj_detalji.dart';

class DeviceCard extends StatefulWidget {
  late RadniZadatakUredjaj? uredjaj;
   DeviceCard(this.uredjaj);

  @override
  State<DeviceCard> createState() => _DeviceCardState();
}

class _DeviceCardState extends State<DeviceCard> {

    List<Uredjaj> data = [];
  UredjajProvider? _uredjajiProvider = null;
late Uredjaj uredjaj;
      @override
  void initState() {
    super.initState();

    _uredjajiProvider = context.read<UredjajProvider>();

    var map = {'UredjajId': widget.uredjaj!.uredjajId};

    _fetchData(map);
  }

   Future<void> _fetchData(Map<String, dynamic>? map) async {
    final response = await _uredjajiProvider?.get(map, "Uredjaj");

    setState(() {
      uredjaj = response!.first;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      width: MediaQuery.of(context).size.width,
      child: Card(
        color: Color(0xFFCBE4DE),
        child: InkWell(
          onTap: () => Navigator.push(context, MaterialPageRoute(builder: (context) => UredjajDetaljiScreen.detalji(uredjaj))),
          child: Column(
                                        children: [
                                          Row(
                                            mainAxisAlignment:
                                                 MainAxisAlignment.spaceBetween,
                                            children: [
                                              Container(
                                                padding: const EdgeInsets.all(10),
                                                child: Text(widget.uredjaj?.uredjajId.toString() ?? "", style: TextStyle(fontSize: 17, fontWeight: FontWeight.bold)),
                                              ),
                                              //if (addZadatakActive && x.isSelected) Container(child: Icon(Icons.done)),
                                             // if (!addZadatakActive)
                                               Container(width: 100, child: buildIcon.buildStatusCellUredjaj(widget.uredjaj?.uredjajStatus ?? ""))
                                            ],
                                          ),
                                          Row(
                                            mainAxisAlignment: MainAxisAlignment.center,
                                            children: [
                                              Expanded(
                                                  child: Center(
                                                    child: Container(
                                                                                                  child: Text(
                                                    widget.uredjaj?.tipNaziv ?? "",
                                                    style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                                                                                                  ),
                                                                                                ),
                                                  ))
                                            ],
                                          ),
                                          Row(
                                            mainAxisAlignment: MainAxisAlignment.center,
                                            children: [
                                              Expanded(
                                                  child: Center(
                                                    child: Container(
                                                                                                  child: Text(
                                                                                                   widget.uredjaj?.tipOpis ?? "",
                                                    style: TextStyle(fontWeight: FontWeight.bold),
                                                                                                  ),
                                                                                                ),
                                                  ))
                                            ],
                                          ),
                                          Row(
                                            mainAxisAlignment: MainAxisAlignment.center,
                                            children: [
                                              Center(
                                                child: Container(
                                                  child: Text(
                                                    widget.uredjaj?.koda ?? "",
                                                    style: TextStyle(fontWeight: FontWeight.bold),
                                                  ),
                                                ),
                                              )
                                            ],
                                          ),
                                          Row(
                                            mainAxisAlignment: MainAxisAlignment.center,
                                            children: [
                                              Expanded(
                                                  child: Center(
                                                    child: Container(
                                                                                                  child: Text(
                                                    widget.uredjaj?.serijskiBroj ?? "",
                                                    style: TextStyle(fontWeight: FontWeight.bold),
                                                                                                  ),
                                                                                                ),
                                                  ))
                                            ],
                                          )
                                        ],
                                      ),
        ),
      ),
    );
  }
}