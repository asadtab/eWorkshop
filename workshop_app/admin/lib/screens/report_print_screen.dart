import 'package:admin/commons/app_bar.dart';
import 'package:admin/widgets/uredjaj_pdf.dart';
import 'package:commons/bloc/report/bloc/report_block_bloc.dart';
import 'package:commons/bloc/uredjaji/bloc/uredjaj_bloc.dart';
import 'package:commons/helpers/state_helper.dart';
import 'package:commons/models/general_data_report.dart';
import 'package:commons/models/servis_report.dart';
import 'package:commons/widgets/dropdown_uredjaj.dart';
import 'package:commons/widgets/notification_badge_icon.dart';
import 'package:commons/widgets/print_queue_notifier.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:provider/provider.dart';

class ReportPrintScreen extends StatefulWidget {
  const ReportPrintScreen({super.key});

  @override
  State<ReportPrintScreen> createState() => _ReportPrintScreenState();
}

class _ReportPrintScreenState extends State<ReportPrintScreen> {
  String dropdownvalue = "Spremni";
  ServisReport? reportHeaderData;
  ReportGeneralData? generalData;

 @override
  void initState() {
    super.initState();
    context.read<ReportBlockBloc>().add(
      ReportEvent(status: StateHelper.nizSearch(dropdownvalue)),
    );

    generalData = ReportGeneralData();
  }

  @override
  Widget build(BuildContext context) {
    final reportBloc = context.read<ReportBlockBloc>();

    return Scaffold(
      appBar: BarrApp(naslov: "Odabir servisiranih uređaja za printanje"),
      body: Padding(
        padding: const EdgeInsets.all(16),
        child: Column(
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                DropdownUredjaj(
                  opcije: const ["Spremni", "Poslani"],
                  value: dropdownvalue,
                  onChanged: (val) {
                    setState(() => dropdownvalue = val);
                    reportBloc.add(
                      ReportEvent(status: StateHelper.nizSearch(val)),
                    );
                  },
                ),
                Consumer<PrintQueueNotifier>(
                  builder: (context, queue, _) {
                    return Row(
                      children: [
 OutlinedButton.icon(
  onPressed: () async {
    final queue = context.read<PrintQueueNotifier>();

    if (queue.selectedItems.isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          content: Text('Prvo odaberite barem jedan izvještaj.'),
        ),
      );
      return;
    }

    final baseData = generalData ??
        ReportGeneralData.fromServisReport(queue.selectedItems.first);

    final edited = await _showGeneralDataDialog(context, data: generalData!);

    if (edited != null) {
      setState(() => generalData = edited);
    }
  },
  icon: const Icon(Icons.edit_document),
  label: const Text('Opći podaci'),
),
const SizedBox(width: 12),
OutlinedButton.icon(
  onPressed: () async {
    final queue = context.read<PrintQueueNotifier>();

    if (queue.selectedItems.isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          content: Text('Prvo odaberite barem jedan izvještaj.'),
        ),
      );
      return;
    }

    await _showDeviceDataDialog(context, items: queue.selectedItems);
    setState(() {});
  },
  icon: const Icon(Icons.build),
  label: const Text('Podaci o servisiranju'),
),
                        NotificationBadgeIcon(
                          icon: Icons.print,
                          count: queue.count,
                          onTap: () {},
                        ),
                        const SizedBox(width: 12),
                        TextButton.icon(
                          onPressed: queue.count == 0 ? null : queue.clear,
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
            Expanded(
              child: BlocConsumer<ReportBlockBloc, ReportBlockState>(
                listener: (context, state) {},
                builder: (context, state) {
                  if (state is ReportLoadingState) {
                    return const Center(child: CircularProgressIndicator());
                  }

                  if (state is ReportLoadedState) {
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
      bottomNavigationBar: SafeArea(
        child: Padding(
          padding: const EdgeInsets.all(16),
          child: Consumer<PrintQueueNotifier>(
            builder: (context, queue, _) {
              return Row(
                mainAxisAlignment: MainAxisAlignment.end,
                children: [
                  TextButton(
                    onPressed: () => Navigator.pop(context),
                    child: const Text('Otkaži'),
                  ),
                  const SizedBox(width: 8),
                  TextButton(
                    onPressed: queue.count == 0
                        ? null
                        : () async {
                            final items = queue.selectedItems;
                            final header = reportHeaderData ?? 
                                (items.isNotEmpty ? items.first : null);

                            if (header == null) {
                              ScaffoldMessenger.of(context).showSnackBar(
                                const SnackBar(
                                  content: Text(
                                    'Nema podataka za generisanje izvještaja.',
                                  ),
                                ),
                              );
                              return;
                            }

                            await GenerisiPdf.generisiPdf(items, generalData);
                            queue.clear();

                            if (mounted) {
                              Navigator.pop(context);
                            }
                          },
                    child: const Text('Potvrdi'),
                  ),
                ],
              );
            },
          ),
        ),
      ),
    );
  }

  Widget _buildAvailableDevicesTable(
    BuildContext context,
    List<ServisReport> data,
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
                      DataColumn(label: Text('Ev.Broj')),
                      DataColumn(label: Text('Tip')),
                      DataColumn(label: Text('Koda')),
                      DataColumn(label: Text('Ser. broj')),
                      DataColumn(label: Text('Datum prijema')),
                    ],
                    rows: data.map((x) {
                      final isSelected =
                          queue.isSelected(x.uredjaj!.uredjajId!);

                      return DataRow(
                        selected: isSelected,
                        onSelectChanged: (_) => queue.toggleSelection(x),
                        cells: [
                          DataCell(Text(x.evBroj.toString())),
                          DataCell(Text(x.tipUredjaja ?? "")),
                          DataCell(Text(x.koda ?? "")),
                          DataCell(Text(x.serijskiBroj ?? "")),
                          DataCell(Text(x.datumPrijema.toString() )),
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
                  ? const Center(child: Text('Nema odabranih uređaja'))
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
                                DataCell(Text(x.evBroj.toString())),
                                DataCell(Text(x.tipUredjaja ?? "")),
                                DataCell(
                                  IconButton(
                                    icon: const Icon(
                                      Icons.delete,
                                      color: Colors.red,
                                    ),
                                    onPressed: () {
                                      queue.removeById(x.uredjaj!.uredjajId!);
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

String _formatDate(DateTime? d) {
  if (d == null) return '';
  final day = d.day.toString().padLeft(2, '0');
  final month = d.month.toString().padLeft(2, '0');
  return '$day.$month.${d.year}';
}

Future<ReportGeneralData?> _showGeneralDataDialog(
  BuildContext context, {
  required ReportGeneralData data,
}) async {
  final organController = TextEditingController(text: data.organ);
  final rukovodilacController =
      TextEditingController(text: data.rukovodilac);
  final brojNalogaController =
      TextEditingController(text: data.brojRadnogNaloga);
  final kontoController = TextEditingController(text: data.kontoBroj);
  final odobrioController = TextEditingController(text: data.odobrio);
  final preuzeoController = TextEditingController(text: data.preuzeo);

  void saveGeneralDataTo(ReportGeneralData gen){
  gen.rukovodilac = 'Enes Memić, dipl.eng.el';
  gen.brojRadnogNaloga = brojNalogaController.text.trim();
  gen.odobrio = odobrioController.text.trim();
  gen.preuzeo = preuzeoController.text.trim();
  gen.kontoBroj = kontoController.text.trim();
  gen.organ = organController.text.trim();
  
}

  return showDialog<ReportGeneralData>(
    context: context,
    builder: (dialogContext) {
      return AlertDialog(
        title: const Text('Opći podaci izvještaja'),
        content: SizedBox(
          width: 600,
          child: SingleChildScrollView(
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                TextFormField(
                  controller: organController,
                  decoration: const InputDecoration(
                    labelText: 'Nadzorni organ',
                    border: OutlineInputBorder(),
                  ),
                ),
                const SizedBox(height: 12),
                TextFormField(
                  controller: rukovodilacController,
                  decoration: const InputDecoration(
                    labelText: 'Rukovodilac',
                    border: OutlineInputBorder(),
                  ),
                ),
                const SizedBox(height: 12),
                TextFormField(
                  controller: brojNalogaController,
                  decoration: const InputDecoration(
                    labelText: 'Broj radnog naloga',
                    border: OutlineInputBorder(),
                  ),
                ),
                const SizedBox(height: 12),
                TextFormField(
                  controller: kontoController,
                  decoration: const InputDecoration(
                    labelText: 'KONTO BR.',
                    border: OutlineInputBorder(),
                  ),
                ),
                const SizedBox(height: 12),
                TextFormField(
                  controller: odobrioController,
                  decoration: const InputDecoration(
                    labelText: 'Odobrio',
                    border: OutlineInputBorder(),
                  ),
                ),
                const SizedBox(height: 12),
                TextFormField(
                  controller: preuzeoController,
                  decoration: const InputDecoration(
                    labelText: 'Preuzeo',
                    border: OutlineInputBorder(),
                  ),
                ),
              ],
            ),
          ),
        ),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(dialogContext),
            child: const Text('Otkaži'),
          ),
          ElevatedButton(
            onPressed: () {
              data.organ = organController.text.trim();
              data.rukovodilac = rukovodilacController.text.trim();
              data.brojRadnogNaloga = brojNalogaController.text.trim();
              data.kontoBroj = kontoController.text.trim();
              data.odobrio = odobrioController.text.trim();
              data.preuzeo = preuzeoController.text.trim();
              saveGeneralDataTo(generalData!);
              Navigator.pop(dialogContext, data);
            },
            child: const Text('Sačuvaj'),
          ),
        ],
      );
    },
  );
}



Future<void> _showDeviceDataDialog(
  BuildContext context, {
  required List<ServisReport> items,
}) async {
  int currentIndex = 0;

  final nadzorController = TextEditingController();
  final servisiraoController = TextEditingController();
  final odobrioController = TextEditingController();
  final pageController = TextEditingController(text: '1');

  DateTime? datumPrijema;
  DateTime? datumServisiranja;

  void loadFrom(ServisReport r) {
    nadzorController.text = r.nadzor ?? '';
    servisiraoController.text = r.servisiraoIIspitao ?? '';
    odobrioController.text = r.odobrio ?? '';
    datumPrijema = r.datumPrijema;
    datumServisiranja = r.datumServisiranja;
    pageController.text = (currentIndex + 1).toString();
  }

  void saveTo(ServisReport r) {
    r.nadzor = nadzorController.text.trim();
    r.servisiraoIIspitao = servisiraoController.text.trim();
    r.odobrio = odobrioController.text.trim();
    if (datumPrijema != null) r.datumPrijema = datumPrijema!;
    if (datumServisiranja != null) r.datumServisiranja = datumServisiranja!;
  }

  loadFrom(items[currentIndex]);

  await showDialog(
    context: context,
    builder: (dialogContext) {
      return StatefulBuilder(
        builder: (context, setDialogState) {
          Future<void> pickDate({
            required DateTime? currentValue,
            required ValueChanged<DateTime?> onChanged,
          }) async {
            final picked = await showDatePicker(
              context: context,
              initialDate: currentValue ?? DateTime.now(),
              firstDate: DateTime(2000),
              lastDate: DateTime(2100),
            );
            if (picked != null) {
              setDialogState(() => onChanged(picked));
            }
          }

          Widget buildDateField({
            required String label,
            required DateTime? value,
            required VoidCallback onTap,
          }) {
            return TextFormField(
              readOnly: true,
              controller: TextEditingController(text: _formatDate(value)),
              decoration: InputDecoration(
                labelText: label,
                border: const OutlineInputBorder(),
                suffixIcon: const Icon(Icons.calendar_today),
              ),
              onTap: onTap,
            );
          }

          void goTo(int newIndex) {
            if (newIndex < 0 || newIndex >= items.length) return;
            saveTo(items[currentIndex]);
            setDialogState(() {
              currentIndex = newIndex;
              loadFrom(items[currentIndex]);
            });
          }

          final current = items[currentIndex];

          return AlertDialog(
            title: const Text('Podaci o servisiranju'),
            content: SizedBox(
              width: 700,
              child: SingleChildScrollView(
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    Row(
                      children: [
                        IconButton(
                          icon: const Icon(Icons.chevron_left),
                          onPressed: currentIndex == 0
                              ? null
                              : () => goTo(currentIndex - 1),
                        ),
                        Expanded(
                          child: DropdownButtonFormField<int>(
                            value: currentIndex,
                            decoration: const InputDecoration(
                              labelText: 'Ev.Broj uređaja',
                              border: OutlineInputBorder(),
                            ),
                            items: List.generate(items.length, (i) {
                              return DropdownMenuItem(
                                value: i,
                                child: Text(
                                  'Ev.Br: ${items[i].evBroj} — ${items[i].tipUredjaja ?? ""}',
                                ),
                              );
                            }),
                            onChanged: (v) {
                              if (v != null) goTo(v);
                            },
                          ),
                        ),
                        IconButton(
                          icon: const Icon(Icons.chevron_right),
                          onPressed: currentIndex == items.length - 1
                              ? null
                              : () => goTo(currentIndex + 1),
                        ),
                      ],
                    ),
                    const SizedBox(height: 8),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        const Text('Uređaj: '),
                        SizedBox(
                          width: 50,
                          child: TextField(
                            controller: pageController,
                            textAlign: TextAlign.center,
                            keyboardType: TextInputType.number,
                            decoration: const InputDecoration(
                              border: OutlineInputBorder(),
                              contentPadding: EdgeInsets.symmetric(
                                vertical: 4,
                              ),
                            ),
                            onSubmitted: (val) {
                              final page = int.tryParse(val);
                              if (page != null) {
                                goTo(page - 1);
                              }
                            },
                          ),
                        ),
                        Text(' / ${items.length}'),
                      ],
                    ),
                    const Divider(height: 24),
                    Text(
                      'Ser. broj: ${current.serijskiBroj ?? ""}  |  Koda: ${current.koda ?? ""}',
                      style: const TextStyle(fontWeight: FontWeight.bold),
                    ),
                    const SizedBox(height: 12),
                  
                    const SizedBox(height: 12),
                    TextFormField(
                      controller: servisiraoController,
                      decoration: const InputDecoration(
                        labelText: 'Servisirao i ispitao',
                        border: OutlineInputBorder(),
                      ),
                    ),
                    const SizedBox(height: 12),
                    TextFormField(
                      controller: odobrioController,
                      decoration: const InputDecoration(
                        labelText: 'Odobrio',
                        border: OutlineInputBorder(),
                      ),
                    ),
                    const SizedBox(height: 12),
                    buildDateField(
                      label: 'Datum prijema',
                      value: datumPrijema,
                      onTap: () => pickDate(
                        currentValue: datumPrijema,
                        onChanged: (v) => datumPrijema = v,
                      ),
                    ),
                    const SizedBox(height: 12),
                    buildDateField(
                      label: 'Datum servisiranja',
                      value: datumServisiranja,
                      onTap: () => pickDate(
                        currentValue: datumServisiranja,
                        onChanged: (v) => datumServisiranja = v,
                      ),
                    ),
                  ],
                ),
              ),
            ),
            actions: [
              TextButton(
                onPressed: () {
                  saveTo(items[currentIndex]);
                  Navigator.pop(dialogContext);
                },
                child: const Text('Zatvori'),
              ),
            ],
          );
        },
      );
    },
  );
}
}