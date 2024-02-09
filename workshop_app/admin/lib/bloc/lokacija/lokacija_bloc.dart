import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:commons/models/lokacija.dart';
import 'package:commons/providers/lokacija_provider.dart';
import 'package:equatable/equatable.dart';

part 'lokacija_event.dart';
part 'lokacija_state.dart';

class LokacijaBloc extends Bloc<LokacijaEvent, LokacijaState> {
  late LokacijaProvider lokacijaProvider;

  LokacijaBloc({required this.lokacijaProvider}) : super(LokacijaInitial()) {
    on<LokacijaEvent>((event, emit) {
      // TODO: implement event handler
    });

    on<LokacijaAddEvent>(lokacijaAddEvent);
    on<LokacijaInitialEvent>(lokacijaInitialEvent);
  }

  FutureOr<void> lokacijaAddEvent(LokacijaAddEvent event, Emitter<LokacijaState> emit) async {
    emit(LokacijaLoadingState());

    var request = await lokacijaProvider.get(null, "Lokacija");

    emit(LokacijaDataState(lokacije: request));
  }

  FutureOr<void> lokacijaInitialEvent(LokacijaInitialEvent event, Emitter<LokacijaState> emit) async {
    emit(LokacijaLoadingState());

    var request = await lokacijaProvider.get(null, "Lokacija");

    emit(LokacijaDataState(lokacije: request));
  }
}
