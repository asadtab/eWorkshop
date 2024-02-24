import 'dart:io';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:open_file/open_file.dart';
import 'package:pdf/pdf.dart';
import 'package:pdf/widgets.dart' as pw;

class GenerisiPdf {
  static Future<void> generisiPdf(List<RadniZadatakUredjaj> data) async {
    List<RadniZadatakUredjaj> uredjaji = [];

    for (var uredjaj in data) {
      if (uredjaj.uredjajStatus == "fix" || uredjaj.uredjajStatus == "done" || uredjaj.uredjajStatus == "ready") {
        uredjaji.add(uredjaj);
      }
    }
    final pdf = pw.Document();

    pdf.addPage(
      pw.MultiPage(
        pageFormat: PdfPageFormat.a4,
        build: (pw.Context context) {
          return [
            _buildHeader(),
            _buildTable(context, uredjaji),
          ];
        },
        footer: (pw.Context context) => _buildFooter(context, uredjaji),
      ),
    );

    final output = Directory.systemTemp;
    final file = File("${output.path}/izvjestaj_asad.pdf");

    await file.writeAsBytes(await pdf.save());

    OpenFile.open(file.path, type: "application/pdf");

    //final file = File('example.pdf');
  }

  static pw.Widget _buildHeader() {
    return pw.Container(
      alignment: pw.Alignment.center,
      margin: pw.EdgeInsets.only(bottom: 20),
      child: pw.Text(
        'Uredjaji',
        style: pw.TextStyle(fontSize: 20, fontWeight: pw.FontWeight.bold),
      ),
    );
  }

  static pw.Widget _buildTable(pw.Context context, List<RadniZadatakUredjaj> uredjaji) {
    return pw.TableHelper.fromTextArray(
        context: context,
        headerDecoration: pw.BoxDecoration(
          color: PdfColors.grey500,
        ),
        headerHeight: 30,
        cellHeight: 30,
        cellAlignments: {
          0: pw.Alignment.centerLeft,
          1: pw.Alignment.center,
          2: pw.Alignment.center,
        },
        headerStyle: pw.TextStyle(
          color: PdfColors.white,
          fontWeight: pw.FontWeight.bold,
        ),
        rowDecoration: pw.BoxDecoration(
          border: pw.Border(
            bottom: pw.BorderSide(
              color: PdfColors.grey400,
              width: 1,
            ),
          ),
        ),
        headers: ['Ev.br.', 'Tip', 'Koda'],
        data: List<List<String>>.generate(
            uredjaji.length, (index) => [uredjaji[index].uredjajId.toString(), uredjaji[index].tipNaziv ?? "", uredjaji[index].koda ?? ""]));
  }

  static pw.Widget _buildFooter(pw.Context context, List<RadniZadatakUredjaj> dataList) {
    return pw.Container(
      alignment: pw.Alignment.center,
      margin: pw.EdgeInsets.only(top: 20),
      child: pw.Column(
        crossAxisAlignment: pw.CrossAxisAlignment.start,
        children: [
          _footerTable(dataList),
        ],
      ),
    );
  }

  static pw.Widget _footerTable(List<RadniZadatakUredjaj> dataList) {
    return pw.TableHelper.fromTextArray(
      headerDecoration: pw.BoxDecoration(
        color: PdfColors.grey500,
      ),
      headerHeight: 20,
      cellHeight: 20,
      cellAlignments: {
        0: pw.Alignment.centerLeft,
        1: pw.Alignment.center,
        2: pw.Alignment.center,
      },
      headerStyle: pw.TextStyle(
        color: PdfColors.white,
        fontWeight: pw.FontWeight.bold,
        fontSize: 12,
      ),
      rowDecoration: pw.BoxDecoration(
        border: pw.Border(
          bottom: pw.BorderSide(
            color: PdfColors.grey400,
            width: 1,
          ),
        ),
      ),
      headers: ['', 'Ime i prezime', 'Datum', 'Potpis'],
      data: [
        ['Predao', '', ''], // Replace '100' with your data
        ['Preuzeo', '', ''], // Replace 'Warehouse A' with your data
      ],
    );
  }
}
