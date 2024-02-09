import 'package:advance_pdf_viewer/advance_pdf_viewer.dart';
import 'package:flutter/material.dart';
import 'package:flutter_pdfview/flutter_pdfview.dart';

import 'package:pdf/pdf.dart';
import 'package:pdf/widgets.dart' as pw;

class PdfViewer extends StatefulWidget {
  final String pdfAssetPath;

  PdfViewer({required this.pdfAssetPath});

  @override
  _PdfViewerState createState() => _PdfViewerState();
}

class _PdfViewerState extends State<PdfViewer> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text('Example'),
        ),
        body: PDFView(
          filePath: widget.pdfAssetPath,
          enableSwipe: true,
          swipeHorizontal: true,
          autoSpacing: false,
          pageFling: false,
          onRender: (pages) {
            // Do something when the PDF is rendered
            print("PDF rendered: $pages pages");
          },
          onError: (error) {
            // Handle error when loading PDF
            print("Error loading PDF: $error");
          },
        ));
  }
}
