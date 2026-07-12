import 'dart:io';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/providers/izvrseni_servis_provider.dart' show IzvrseniServisProvider;
import 'package:flutter/cupertino.dart';
import 'package:flutter/services.dart';
import 'package:http/http.dart' as context;
import 'package:open_file/open_file.dart';
import 'package:pdf/pdf.dart';
import 'package:pdf/widgets.dart' as pw;

class ZamijenjeniElement {
  final int rbr;
  final String naziv;
  final String koda;

  ZamijenjeniElement({
    required this.rbr,
    required this.naziv,
    required this.koda,
  });
}

class ServisniIzvjestaj {
  final String nadzorniOrgan;
  final String rukovodilac;
  final String datumPocetka;
  final String datumZavrsetka;
  final String brojNaloga;
  final String kontoBr;
  final RadniZadatakUredjaj uredjaj;
  final String opisPrijema;
  final String opisServisa;
  final String opisPredaje;
  final List<ZamijenjeniElement> zamijenjeniElementi;
  final String servisiraoIme;
  final String servisiraoDatum;
  final String odobriloIme;
  final String nadzorIme;

  ServisniIzvjestaj({
    required this.nadzorniOrgan,
    required this.rukovodilac,
    required this.datumPocetka,
    required this.datumZavrsetka,
    required this.brojNaloga,
    required this.kontoBr,
    required this.uredjaj,
    required this.opisPrijema,
    required this.opisServisa,
    required this.opisPredaje,
    required this.zamijenjeniElementi,
    required this.servisiraoIme,
    required this.servisiraoDatum,
    required this.odobriloIme,
    required this.nadzorIme,
  });
}

class GenerisiPdf {
  static const PdfColor _border = PdfColors.black;
  static const PdfColor _labelGrey = PdfColor.fromInt(0xFF6B7280);

  static Future<void> generisiPdf(List<RadniZadatakUredjaj> data) async {
    


    final filtrirani = data
        .where((u) =>
            ['fix', 'done', 'ready', 'out', 'invoice']
                .contains(u.uredjajStatus))
        .toList();

    if (filtrirani.isEmpty) return;

    // ── Fontovi ──────────────────────────────────────────────────────────
    final fontRegular = pw.Font.ttf(
  await rootBundle.load('assets/fonts/Roboto-Regular.ttf'),
);
final fontBold = pw.Font.ttf(
  await rootBundle.load('assets/fonts/Roboto-Bold.ttf'),
);
    final theme = pw.ThemeData.withFont(
      base: fontRegular,
      bold: fontBold,
    );

    // ── Logo ─────────────────────────────────────────────────────────────
    final logoBytes = await rootBundle.load('assets/images/logo_step.png');
    final logoImage = pw.MemoryImage(logoBytes.buffer.asUint8List());

    final pdf = pw.Document(theme: theme);

    for (int i = 0; i < filtrirani.length; i++) {
      final u = filtrirani[i];
      final s = ServisniIzvjestaj(
        nadzorniOrgan: 'nadzor',
        rukovodilac: 'Enes Memić, dipl.el.ing.',
        datumPocetka: '12.11.2024',
        datumZavrsetka: '',
        brojNaloga: '123/456',
        kontoBr: '810-001',
        uredjaj: u,
        opisPrijema: 'Neispravna',
        opisServisa:
            "Kućišta osigurača, osigurači i signalne sijalice su pregledani i izvršena je izmjena istih ako su oštećeni(vidi zamijenjene elemente).Konektori uređaja su pregledani, očišćeni i izvršen je test uklapanja konektora u odgovarajućem mjestu u ramu. Namotaji releja su ispitani dovođenjem istosmjernog napona preko zaštitnog otpornika ili direktno na pojedine namotaje u zavisnosti od tipa ispitanog releja. Ostale komponente uređaja su ispitane i izvršena je izmjena istih u slučaju neispravnog rada.",
        opisPredaje:
            '-Bez fizičkih oštećenja,\n-Funkcionalno ispravna i plombirana.',
        zamijenjeniElementi: [
          ZamijenjeniElement(rbr: 1, naziv: 'Kondenzatorski sastav', koda: '1 kom'),
        ],
        servisiraoIme: 'Edin Šatrović, el.tehn.',
        servisiraoDatum: '',
        odobriloIme: 'Enes Memić, dipl.el.ing.',
        nadzorIme: '',
      );

      pdf.addPage(_buildPage(s, logoImage, i + 1, filtrirani.length));
    }

    final file = File('${Directory.systemTemp.path}/servisni_izvjestaj.pdf');
    await file.writeAsBytes(await pdf.save());
    OpenFile.open(file.path, type: 'application/pdf');
  }

  // ── Stranica ────────────────────────────────────────────────────────────
  static pw.Page _buildPage(
    ServisniIzvjestaj s,
    pw.MemoryImage logo,
    int pageNum,
    int totalPages,
  ) {
    return pw.Page(
      // ✅ Landscape A4 — kao u PHP (297x210)
      pageFormat: PdfPageFormat.a4.portrait,
      margin: const pw.EdgeInsets.fromLTRB(8, 8, 8, 20),
      build: (ctx) => pw.Column(
        crossAxisAlignment: pw.CrossAxisAlignment.stretch,
        children: [
          // ── 1. HEADER ─────────────────────────────────────────────────
          _buildHeader(s, logo, pageNum, totalPages),
          pw.SizedBox(height: 10),

          // ── 2. ORG CJELINA ────────────────────────────────────────────
       


          // ── 3. NADZORNI ORGAN + DATUMI ────────────────────────────────
          _buildNadzorRed(s),
          pw.SizedBox(height: 10),

          // ── 4. PODACI O SKLOPU ────────────────────────────────────────
          _sectionTitle('Podaci o sklopu koji se servisira - revitalizuje:'),
          pw.SizedBox(height: 5),
          _buildSklopTabela(s),
          pw.SizedBox(height: 10),

          // ── 5. OPIS PRIJEMA ───────────────────────────────────────────
          _sectionTitle('Opis stanja sklopa kod prijema:'),
          pw.SizedBox(height: 5),
          pw.Text(s.opisPrijema, style: pw.TextStyle(fontSize: 10)),
          pw.Spacer(),

          // ── 6. OPIS SERVISA ───────────────────────────────────────────
          _sectionTitle('Servisiranje - revitalizacija (opis aktivnosti):'),
          pw.SizedBox(height: 5),
          pw.Text(s.opisServisa, style: pw.TextStyle(fontSize: 10)),
          pw.SizedBox(height: 10),
          

          // ── 7. ZAMIJENJENI ELEMENTI ───────────────────────────────────
          _sectionTitle('Zamijenjeni elementi:'),
          pw.SizedBox(height: 5),
          _buildZamijenjeniTabela(s.zamijenjeniElementi),
          pw.SizedBox(height: 3),
          pw.Spacer(),

          // ── 8. OPIS PREDAJE ───────────────────────────────────────────
          _sectionTitle('Opis stanja sklopa kod predaje:'),
          pw.SizedBox(height: 2),
          pw.Text(s.opisPredaje, style: pw.TextStyle(fontSize: 10)),
          pw.SizedBox(height: 10),

          // ── 9. POTPISNA TABELA ────────────────────────────────────────
          _buildPotpisnaTabela(s),
          pw.SizedBox(height: 5),

          // ── 10. FOOTER ────────────────────────────────────────────────
          _buildFooter(),
        ],
      ),
    );
  }

  // ── Header: logo + naslov + broj + strana ──────────────────────────────
  static pw.Widget _buildHeader(
    ServisniIzvjestaj s,
    pw.MemoryImage logo,
    int pageNum,
    int totalPages,
  ) {
    return pw.Row(
      crossAxisAlignment: pw.CrossAxisAlignment.start,
      children: [
        // Logo (23mm širina kao u PHP)
        pw.SizedBox(
          width: 200,
          child: pw.Image(logo, height: 70),
        ),
        pw.SizedBox(width: 4),
        // Naslov (113mm)
        pw.Expanded(child:
        pw.Column(
          children: [pw.Text(
            'SERVISIRANJE - REVITALIZACIJA PROIZVODA',
            textAlign: pw.TextAlign.center,
            style: pw.TextStyle(fontSize: 12, fontWeight: pw.FontWeight.bold),
          ),
          pw.SizedBox(height: 10), 
          pw.Text(
      'ORGANIZACIONA CJELINA : SS I TK',
      textAlign: pw.TextAlign.center,
      style: pw.TextStyle(fontSize: 10, fontWeight: pw.FontWeight.bold),
    )
          
          ],
        )),
        pw.SizedBox(width: 4),
        // Broj dokumenta + strana
        pw.Column(
          crossAxisAlignment: pw.CrossAxisAlignment.end,
          children: [
            pw.Text(
              'BROJ: SS-TK-19/${s.uredjaj.uredjajId}',
              style: pw.TextStyle(fontSize: 8),
            ),
            pw.SizedBox(height: 10), 
            pw.Text(
              'STRANA: $pageNum / $totalPages',
              style: pw.TextStyle(fontSize: 8),
            ),
          ],
        ),
      ],
    );
  }

  // ── Org. cjelina ───────────────────────────────────────────────────────
  static pw.Widget _buildOrgCjelina(ServisniIzvjestaj s) {
    return pw.Text(
      'ORGANIZACIONA CJELINA : SS I TK',
      textAlign: pw.TextAlign.center,
      style: pw.TextStyle(fontSize: 10, fontWeight: pw.FontWeight.bold),
    );
  }

  // ── Nadzorni organ + rukovodilac + datumi + nalog + konto ──────────────
  // Replicira PHP: Cell(27,9) + Cell(50,9) + gap + MultiCell(23,4.5)×2 + gap + MultiCell(23,4.5) + gap + Cell(20,9)
static pw.Widget _buildNadzorRed(ServisniIzvjestaj s) {
  return pw.Row(
    mainAxisAlignment: pw.MainAxisAlignment.spaceBetween,
    children: [
      // ── LIJEVA TABELA: Nadzorni organ + Rukovodilac ──────────────────
      pw.Table(
        border: pw.TableBorder.all(color: _border, width: 0.5),
        columnWidths: const {
          0: pw.FixedColumnWidth(100),
          1: pw.FixedColumnWidth(150),
        },
        children: [
          pw.TableRow(
            children: [
              _tdBold('Nadzorni organ:'),
              _td(s.nadzorniOrgan),
            ],
          ),
          pw.TableRow(
            children: [
              _tdBold('Rukovodilac projekata:'),
              _td(s.rukovodilac),
            ],
          ),
        ],
      ),

      pw.SizedBox(width: 4),

      pw.Table(
        border: pw.TableBorder.all(color: _border, width: 0.5),
        columnWidths: const {
          0: pw.FixedColumnWidth(80),
          1: pw.FixedColumnWidth(80),
        },
        children: [
          pw.TableRow(
            children: [
              _th('Početak radova:'),
              _th('Završetak radova:'),]),
              pw.TableRow(
            children: [
              _td(s.datumPocetka),
              _td(s.datumZavrsetka),
              
              ])]
        ),
pw.SizedBox(width: 4),
      // ── DESNA TABELA: Datumi + Nalog + Konto ─────────────────────────
      pw.Table(
        border: pw.TableBorder.all(color: _border, width: 0.5),
        columnWidths: const {
          0: pw.FixedColumnWidth(80),
          1: pw.FixedColumnWidth(60),
        },
        
        children: [
          pw.TableRow(
            children: [
              _th('Br. radnog naloga:'),
              _th('KONTO BR.'),
            ],
          ),
          pw.TableRow(
            children: [
              _td(s.brojNaloga),
              _td(s.kontoBr),
            ],
          ),
        ],
      ),
    ],
  );
}

  // ── Sklop tabela: EV.BR / TIP / KODA / SER.BROJ ───────────────────────
  // PHP: Cell(10,5) + Cell(77,5) + Cell(45,5) + Cell(49,5) — header
  //      Cell(10,10) + Cell(77,10) + Cell(45,10) + Cell(49,10) — data
  static pw.Widget _buildSklopTabela(ServisniIzvjestaj s) {
    return pw.Table(
      border: pw.TableBorder.all(color: _border, width: 0.5),
      columnWidths: const {
        0: pw.FixedColumnWidth(10),
        1: pw.FixedColumnWidth(77),
        2: pw.FixedColumnWidth(45),
        3: pw.FixedColumnWidth(49),
      },
      children: [
        pw.TableRow(
          children: [
            _th('EV. BR.', fontSize: 7),
            _th('TIP'),
            _th('KODA'),
            _th('SER. BROJ'),
          ],
        ),
        pw.TableRow(
          children: [
            _tdBold(s.uredjaj.uredjajId.toString(), height: 10),
            _tdBold(s.uredjaj.tipNaziv ?? '', height: 10),
            _tdBold(s.uredjaj.koda ?? '', height: 10),
            _tdBold(s.uredjaj.serijskiBroj ?? '', height: 10),
          ],
        ),
      ],
    );
  }

  // ── Zamijenjeni elementi u parovima ────────────────────────────────────
  // PHP: Cell(10,7) + Cell(57,7) + Cell(21,7) + gap(5) + Cell(10,7) + Cell(57,7) + Cell(21,7)
  static pw.Widget _buildZamijenjeniTabela(List<ZamijenjeniElement> elementi) {
    final parovi = <pw.TableRow>[];

    // Header
    parovi.add(
      pw.TableRow(
        children: [
          _th('R.B.'),
          _th('NAZIV'),
          _th('KODA'),
          pw.SizedBox(width: 5), // gap kao u PHP
          _th('R.B.'),
          _th('NAZIV'),
          _th('KODA'),
        ],
      ),
    );

    // Redovi u parovima (lijevo + desno)
    for (int i = 0; i < elementi.length; i += 2) {
      final left = elementi[i];
      final right = i + 1 < elementi.length ? elementi[i + 1] : null;
      parovi.add(
        pw.TableRow(
          children: [
            _td(left.rbr.toString()),
            _td(left.naziv),
            _td(left.koda),
            pw.SizedBox(width: 5),
            _td(right?.rbr.toString() ?? ''),
            _td(right?.naziv ?? ''),
            _td(right?.koda ?? ''),
          ],
        ),
      );
    }

    return pw.Table(
      border: pw.TableBorder.all(color: _border, width: 0.5),
      columnWidths: const {
        0: pw.FixedColumnWidth(10),
        1: pw.FixedColumnWidth(57),
        2: pw.FixedColumnWidth(21),
        3: pw.FixedColumnWidth(5),  // prazan gap
        4: pw.FixedColumnWidth(10),
        5: pw.FixedColumnWidth(57),
        6: pw.FixedColumnWidth(21),
      },
      children: parovi,
    );
  }

  // ── Potpisna tabela ────────────────────────────────────────────────────
  // PHP: Cell(27,5) + Cell(60,5) + Cell(50,5) + Cell(44,5)
  static pw.Widget _buildPotpisnaTabela(ServisniIzvjestaj s) {
    return pw.Table(
      border: pw.TableBorder.all(color: _border, width: 0.5),
      columnWidths: const {
        0: pw.FixedColumnWidth(27),
        1: pw.FixedColumnWidth(60),
        2: pw.FixedColumnWidth(50),
        3: pw.FixedColumnWidth(44),
      },
      children: [
        // Header
        pw.TableRow(
          children: [
            _td(''),
            _th('IME I PREZIME'),
            _th('DATUM'),
            _th('POTPIS'),
          ],
        ),
        _potpisRed('Servisirao i ispitao:', s.servisiraoIme, s.servisiraoDatum),
        _potpisRed('Odobrio:', s.odobriloIme, ''),
        _potpisRed('Nadzor:', s.nadzorIme, ''),
        _potpisRed('Preuzeo:', '', ''),
      ],
    );
  }

  static pw.TableRow _potpisRed(String uloga, String ime, String datum) {
    return pw.TableRow(
      children: [
        pw.Padding(
          padding: const pw.EdgeInsets.symmetric(horizontal: 3, vertical: 3),
          child: pw.Text(uloga,
              style: pw.TextStyle(fontSize: 10, fontWeight: pw.FontWeight.bold)),
        ),
        _td(ime),
        _td(datum),
        _td(''),
      ],
    );
  }

  // ── Footer: Q-7.08.12 ─────────────────────────────────────────────────
  static pw.Widget _buildFooter() {
    return pw.Row(
      mainAxisAlignment: pw.MainAxisAlignment.spaceBetween,
      children: [
        pw.Text('Q-7.08.12',
            style: pw.TextStyle(fontSize: 9, color: _labelGrey)),
        pw.Text('Sarajevo, ${DateTime.now().year}',
            style: pw.TextStyle(fontSize: 9, color: _labelGrey)),
      ],
    );
  }

  // ── Helpers ────────────────────────────────────────────────────────────
  static pw.Widget _sectionTitle(String text) {
    return pw.Text(
      text,
      style: pw.TextStyle(fontSize: 11, fontWeight: pw.FontWeight.bold),
    );
  }



  static pw.Widget _th(String text, {double fontSize = 10}) {
    return pw.Padding(
      padding: const pw.EdgeInsets.symmetric(horizontal: 3, vertical: 3),
      child: pw.Text(
        text,
        textAlign: pw.TextAlign.center,
        style: pw.TextStyle(fontSize: fontSize, fontWeight: pw.FontWeight.bold),
      ),
    );
  }

  static pw.Widget _td(String text, {double fontSize = 10}) {
    return pw.Padding(
      padding: const pw.EdgeInsets.symmetric(horizontal: 3, vertical: 3),
      child: pw.Text(
        text,
        textAlign: pw.TextAlign.center,
        style: pw.TextStyle(fontSize: fontSize),
      ),
    );
  }



  static pw.Widget _tdBold(String text, {double height = 7, double fontSize = 10}) {
    return pw.Padding(
      padding: const pw.EdgeInsets.symmetric(horizontal: 3, vertical: 3),
      child: pw.Text(
        text,
        textAlign: pw.TextAlign.center,
        style: pw.TextStyle(fontSize: fontSize, fontWeight: pw.FontWeight.bold),
      ),
    );
  }
}