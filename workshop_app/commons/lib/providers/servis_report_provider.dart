import 'package:commons/models/reparacija.dart';
import 'package:commons/models/servis_report.dart';
import 'package:commons/providers/base_provider.dart';

class ServisReportProvider extends BaseProvider<ServisReport> {
  
  ServisReportProvider() : super("ServisReport") {}

  @override
  ServisReport fromJson(data) {
    return ServisReport.fromJson(data);
  }
}
