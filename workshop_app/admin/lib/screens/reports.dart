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
    super.initState();
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    final uredjajBloc = BlocProvider.of<UredjajBloc>(context);
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
        return StatefulBuilder(
          builder: (context, dialogSetState) {
            return AlertDialog(
              title: const Text('Odabir servisiranih uređaja za printanje'),
              content: SizedBox(
                width: 1400,
                height: 650,
                child: Column(
                  children: [
                    // ─── Filter row ─────────────────────────
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        DropdownUredjaj(
                          opcije: ["Spremni", "Poslani"],
                          value: dropdownvalue,
                          onChanged: (val) {
                            dialogSetState(() => dropdownvalue = val);
                            uredjajBloc.add(
                              UredjajFilterEvent(
                                status: StateHelper.nizSearch(val),
                              ),
                            );
                          },
                        ),
                        Consumer<PrintQueueNotifier>(
                          builder: (context, queue, _) {
                            return Row(
                              children: [
                                NotificationBadgeIcon(
                                  icon: Icons.print,
                                  count: queue.count,
                                  onTap: () {},
                                ),
                                const SizedBox(width: 12),
                                TextButton.icon(
                                  onPressed:
                                      queue.count == 0 ? null : queue.clear,
                                  icon: const Icon(Icons.delete_sweep),
                                  label: const Text('Obriši listu'),
                                ),
                              ],
                            );
                          },
                        ),
                      ],
                    ),
                    const SizedBox(height: 16),

                    // ─── Dvije tabele (lijevo/desno) ────────
                    Expanded(
                      child: BlocConsumer<UredjajBloc, UredjajState>(
                        bloc: uredjajBloc,
                        listener: (context, state) {},
                        builder: (context, state) {
                          if (state is UredjajLoadingState) {
                            return const Center(
                              child: CircularProgressIndicator(),
                            );
                          }

                          if (state is UredjajDataLoadedState) {
                            return Consumer<PrintQueueNotifier>(
                              builder: (context, queue, _) {
                                return Row(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    Expanded(
                                      child: _buildAvailableDevicesTable(
                                        context,
                                        state.data,
                                        queue,
                                      ),
                                    ),
                                    const SizedBox(width: 16),
                                    Expanded(
                                      child: _buildSelectedDevicesTable(
                                        context,
                                        queue,
                                      ),
                                    ),
                                  ],
                                );
                              },
                            );
                          }

                          return const SizedBox();
                        },
                      ),
                    ),
                  ],
                ),
              ),
              actions: [
                TextButton(
                  onPressed: () => Navigator.pop(dialogContext),
                  child: const Text('Otkaži'),
                ),
                Consumer<PrintQueueNotifier>(
                  builder: (context, queue, _) {
                    return TextButton(
                      onPressed: queue.count == 0
                          ? null
                          : () async {
                              final items = queue.selectedItems;

                              // TODO: Ovdje pozovi svoj servis za print
                              // await reportService.print(items);

                              // Nakon uspješnog printa očisti listu
                              queue.clear();

                              // Zatvori dialog
                              Navigator.pop(dialogContext);
                            },
                      child: const Text('Potvrdi'),
                    );
                  },
                ),
              ],
            );
          },
        );
      },
    );
  }

  // ─── Lijeva tabela: dostupni uređaji ─────────────────────────────────────

  Widget _buildAvailableDevicesTable(
    BuildContext context,
    List<Uredjaj> data,
    PrintQueueNotifier queue,
  ) {
    return Card(
      child: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          children: [
            const Text(
              'Lista uređaja',
              style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
            ),
            const SizedBox(height: 8),
            Expanded(
              child: SingleChildScrollView(
                scrollDirection: Axis.horizontal,
                child: SingleChildScrollView(
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
                    rows: data.map((x) {
                      final isSelected = queue.isSelected(x.uredjajId!);

                      return DataRow(
                        selected: isSelected,
                        onSelectChanged: (_) => queue.toggleSelection(x),
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
                    }).toList(),
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }

  // ─── Desna tabela: odabrani za printanje ─────────────────────────────────

  Widget _buildSelectedDevicesTable(
    BuildContext context,
    PrintQueueNotifier queue,
  ) {
    final selected = queue.selectedItems;

    return Card(
      child: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                const Text(
                  'Odabrani za printanje',
                  style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                ),
                Text('Ukupno: ${selected.length}'),
              ],
            ),
            const SizedBox(height: 8),
            Expanded(
              child: selected.isEmpty
                  ? const Center(
                      child: Text('Nema odabranih uređaja'),
                    )
                  : SingleChildScrollView(
                      scrollDirection: Axis.horizontal,
                      child: SingleChildScrollView(
                        child: DataTable(
                          columns: const [
                            DataColumn(label: Text('Id')),
                            DataColumn(label: Text('Tip')),
                           
                            
                            DataColumn(label: Text('Ukloni')),
                          ],
                          rows: selected.map((x) {
                            return DataRow(
                              cells: [
                                DataCell(Text(x.uredjajId.toString())),
                                DataCell(Text(x.tipNaziv ?? "")),
                               
                               
                                DataCell(
                                  IconButton(
                                    icon: const Icon(
                                      Icons.delete,
                                      color: Colors.red,
                                    ),
                                    onPressed: () {
                                      queue.removeById(x.uredjajId!);
                                    },
                                  ),
                                ),
                              ],
                            );
                          }).toList(),
                        ),
                      ),
                    ),
            ),
          ],
        ),
      ),
    );
  }

  // ─── Placeholder za print logiku (prilagodi svom servisu) ───────────────

  Future<void> _printSelected(List<Uredjaj> items) async {
    // TODO: Implementiraj stvarni poziv servisu za print
    // await reportService.print(items);
    await Future.delayed(const Duration(seconds: 1)); // simulacija
  }
}