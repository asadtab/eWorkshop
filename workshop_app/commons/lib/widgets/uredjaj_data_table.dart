import 'package:commons/helpers/status_icons.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/widgets/print_queue_notifier.dart';
import 'package:commons/widgets/uredjaj_opcije_popup.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class UredjajDataTable extends StatelessWidget {
  final List<Uredjaj> data;
  final Future<void> Function(Uredjaj) onDelete;
  final Future<void> Function(Uredjaj) onRowTap;
  final ValueChanged<List<Uredjaj>>? onSelectionChanged;
  final bool checkbox;
  final Set<int> selectedIds;

  const UredjajDataTable({
    super.key,
    required this.data,
    required this.onDelete,
    required this.onRowTap,
    this.onSelectionChanged,
    this.checkbox = false,
    required this.selectedIds,
  });

  @override
  Widget build(BuildContext context) {
    // ✅ context.watch ovdje — siguran je u build()
    final printQueue = context.watch<PrintQueueNotifier>();

    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Expanded(
          child: Card(
            color: const Color(0xFFf3f5fb),
            child: DataTable(
              showCheckboxColumn: checkbox,
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
              rows: data
                  .map((x) => _buildRow(context, x, printQueue))
                  .toList(),
            ),
          ),
        ),
      ],
    );
  }

  DataRow _buildRow(BuildContext context, Uredjaj x, PrintQueueNotifier printQueue) {
    final bool isSelected = selectedIds.contains(x.uredjajId);

    return DataRow(
      selected: isSelected,
      onSelectChanged: (value) async {
        if (isSelected) {
         // printQueue.ukloni(x);
        } else {
         // printQueue.dodaj(x);
        }
        onSelectionChanged?.call(
          data.where((u) => selectedIds.contains(u.uredjajId)).toList(),
        );
        await onRowTap(x);
      },
      cells: [
        DataCell(Text(x.uredjajId.toString())),
        DataCell(Text(x.tipNaziv ?? "")),
        DataCell(Text(x.tipOpis ?? "")),
        DataCell(Text(x.koda ?? "")),
        DataCell(Text(x.serijskiBroj ?? "")),
        DataCell(buildIcon.buildStatusCellUredjaj(x.status)),
        DataCell(Text(x.lokacijaNaziv ?? "")),
        DataCell(OpcijePupup(uredjaj: x, onDelete: onDelete)),
      ],
    );
  }
}