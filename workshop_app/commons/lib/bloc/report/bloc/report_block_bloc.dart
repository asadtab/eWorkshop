import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:commons/models/servis_report.dart';
import 'package:commons/providers/servis_report_provider.dart';
import 'package:equatable/equatable.dart';

part 'report_block_event.dart';
part 'report_block_state.dart';

class ReportBlockBloc extends Bloc<ReportBlockEvent, ReportBlockState> {
  final ServisReportProvider servisReportProvider;


  ReportBlockBloc({required this.servisReportProvider}) : super(ReportBlockState()) {

    on<ReportEvent>(loadingReportEvent);

}

FutureOr<void> loadingReportEvent(ReportEvent event, Emitter<ReportBlockState> emit) async {
    emit(ReportLoadingState());

    try {
      var temp = await servisReportProvider.get({'Status' : event.status}, "ServisIzvrsen/ServisIzvrsenIzvjestaj");
      emit(ReportLoadedState(temp));
    } catch (e) {
      print(e);
    }
  }
}
