import 'package:admin/commons/app_bar.dart';
import 'package:admin/widgets/status_icons.dart';
import 'package:commons/bloc/uredjaji/bloc/uredjaj_bloc.dart';
import 'package:commons/helpers/state_helper.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/dropdown_uredjaj.dart';
import 'package:commons/widgets/notification_badge_icon.dart';
import 'package:commons/widgets/print_queue_notifier.dart';
import 'package:commons/widgets/tooltip.dart';
import 'package:commons/widgets/uredjaj_opcije_popup.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:provider/provider.dart';


class ReportsScreen extends StatefulWidget {
  const ReportsScreen({super.key});

  @override
  State<ReportsScreen> createState() => _ReportsScreenState();
}


class _ReportsScreenState extends State<ReportsScreen> {

  UredjajProvider? uredjajProvider;


  String dropdownvalue = "Spremni";

  @override
  void initState() {
    uredjajProvider = context.read<UredjajProvider>();

    _fetchData(null);
    // TODO: implement initState
    super.initState();
  }

   Future<void> _fetchData(Map<String, String>? map) async {
    
    setState(() {
    });
  }

  @override
  Widget build(BuildContext context) {
    final uredjajBloc = BlocProvider.of<UredjajBloc>(context);
    // Čitamo notifier — ne sluša rebuild jer 'read' ne subscribeuje
    final printQueue = context.read<PrintQueueNotifier>();

    return Scaffold(
      appBar: BarrApp(naslov: "Izvještaji"),
      body: Row(
        children: [
          Column(
            children: [

              // ─── Dugme za otvaranje dijaloga ───────────────
              SizedBox(
                height: 70,
                child: MinimalisticButton(
                  text: "Kreiraj izvještaj",
                  textColor: Colors.white,
                  color: const Color(0xFFae8765),
                  onPressed: () => _openDialog(context, uredjajBloc),
                ),
              ),

              // ─── Prikaz trenutnog state-a bloca ───────────
              BlocConsumer<UredjajBloc, UredjajState>(
                listener: (context, state) {},
                builder: (context, state) {
                  if (state is UredjajDataLoadedState) {
                    return Text("Učitano: ${state.data.length} uređaja");
                  }
                  return const CircularProgressIndicator();
                },
              ),

            ],
          ),
        ],
      ),
    );
  }


  // ─── Dialog ──────────────────────────────────────────────────────────────

  void _openDialog(BuildContext context, UredjajBloc uredjajBloc) {
    showDialog(
      context: context,
      builder: (BuildContext dialogContext) {
        // StatefulBuilder daje lokalni setState samo za sadržaj dijaloga.
        // PrintQueueNotifier dolazi iz globalnog providera (iznad MyApp),
        // pa Consumer unutar dialoga i dalje može slušati njegove promjene.
        return StatefulBuilder(
          builder: (context, dialogSetState) {
            return AlertDialog(
              title: const Text('Odabir servisiranih uređaja za printanje'),
              content: SizedBox(
                width: 1100,
                child: SingleChildScrollView(
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [

                      // ─── Filter row ─────────────────────────
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          
                          DropdownUredjaj(
                            opcije: ["Spremni", "Poslani"],
                            value: dropdownvalue,
                            onChanged: (val) {
                              // dialogSetState ažurira dropdown odmah
                              dialogSetState(() => dropdownvalue = val);
                              uredjajBloc.add(
                                UredjajFilterEvent(
                                  status: StateHelper.nizSearch(val),
                                ),
                              );
                            },
                          ),
                          

                          // ─── Print badge ─────────────────────
                          // Consumer sluša globalni PrintQueueNotifier;
                          // rebuilda se samo ovaj mali widget kad se count promijeni.
                          Consumer<PrintQueueNotifier>(
                            builder: (context, queue, _) {
                              return NotificationBadgeIcon(
                                icon: Icons.print,
                                count: queue.count,
                                onTap: () {},
                              );
                            },
                          ),
                        ],
                      ),

                      // ─── Tabela ────────────────────────────────
                      BlocConsumer<UredjajBloc, UredjajState>(
                        bloc: uredjajBloc,
                        listener: (context, state) {},
                        builder: (context, state) {
                          if (state is UredjajLoadingState) {
                            return const Center(
                              child: CircularProgressIndicator(),
                            );
                          }

                          if (state is UredjajDataLoadedState) {
                            // Consumer ovdje sluša selekciju iz notifiera.
                            // Kada se toggleSelection pozove, notifier javi
                            // notifyListeners() i samo ovaj Consumer se rebuilda —
                            // ne cijeli dialog, ne cijeli screen.
                            
                            return Consumer<PrintQueueNotifier>(
                              builder: (context, queue, _) {
                                return SingleChildScrollView(
                                  scrollDirection: Axis.horizontal,
                                  child: DataTable(
                                    showCheckboxColumn: true,
                                    columns: const [
                                      DataColumn(label: Text('Id')),
                                      DataColumn(label: Text('Tip')),
                                      DataColumn(label: Text('Naziv')),
                                      DataColumn(label: Text('Koda')),
                                      DataColumn(label: Text('Ser. broj')),
                                      DataColumn(label: Text('Status')),
                                      DataColumn(label: Text('Lokacija')),
                                      DataColumn(label: Text('Opcije')),
                                    ],
                                    rows: state.data.map((x) {
                                      return _buildRow(context, x, queue);
                                    }).toList(),
                                  ),
                                );
                              },
                            );
                          }

                          return const SizedBox();
                        },
                      ),

                    ],
                  ),
                ),
              ),
              actions: [
                TextButton(
                  onPressed: () => Navigator.pop(context),
                  child: const Text('Otkaži'),
                ),
                TextButton(
                  onPressed: () {
                 
                    Navigator.pop(context);
                  },
                  child: const Text('Potvrdi'),
                ),
              ],
            );
          },
        );
      },
    );
  }


  // ─── Izgradnja jednog DataRow-a ──────────────────────────────────────────

  DataRow _buildRow(
    BuildContext context,
    Uredjaj x,
    PrintQueueNotifier queue,
  ) {
    final isSelected = queue.isSelected(x.uredjajId!);

    return DataRow(
      selected: isSelected,
      // onSelectChanged poziva toggleSelection na notifieru.
      // Notifier zove notifyListeners() koji osvježi Consumer iznad,
      // pa se DataTable rebuilda sa novim isSelected vrijednostima.
      onSelectChanged: (_) {
        queue.toggleSelection(x);
      },
      cells: [
        DataCell(Text(x.uredjajId.toString())),
        DataCell(Text(x.tipNaziv ?? "")),
        DataCell(Text(x.tipOpis ?? "")),
        DataCell(Text(x.koda ?? "")),
        DataCell(Text(x.serijskiBroj ?? "")),
        DataCell(buildIcon.buildStatusCellUredjaj(x.status)),
        DataCell(Text(x.lokacijaNaziv ?? "")),
        DataCell(OpcijePupup(uredjaj: x)),
      ],
    );
  }
}