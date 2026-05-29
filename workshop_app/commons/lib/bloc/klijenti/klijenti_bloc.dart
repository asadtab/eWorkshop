import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:commons/models/klijenti.dart';
import 'package:commons/providers/klijenti_provider.dart';
import 'package:equatable/equatable.dart';

part 'klijenti_event.dart';
part 'klijenti_state.dart';

class KlijentiBloc extends Bloc<KlijentiEvent, KlijentiState> {
  late KlijentiProvider klijentiProvider;

  KlijentiBloc({required this.klijentiProvider}) : super(KlijentiInitialState()) {
    on<KlijentiEvent>((event, emit) {
      // TODO: implement event handler
    });

    on<KlijentiInitialDataEvent>(klijentiInitialDataEvent);
    on<KlijentiAddEvent>(klijentiAddEvent);
    on<KlijentiSearchEvent>(klijentiSearchEvent);
    on<KlijentiUpdateEvent>(klijentiUpdateEvent);
  }

  FutureOr<void> klijentiInitialDataEvent(KlijentiInitialDataEvent event, Emitter<KlijentiState> emit) async {
    emit(KlijentiLoadingState());

    var data = await klijentiProvider.get(null, "Client");

    emit(KlijentiDataLoaded(klijenti: data));
  }

  FutureOr<void> klijentiAddEvent(KlijentiAddEvent event, Emitter<KlijentiState> emit) async {
    await klijentiProvider.insert(event.request, "Client");
  }

  FutureOr<void> klijentiSearchEvent(KlijentiSearchEvent event, Emitter<KlijentiState> emit) async {
    emit(KlijentiLoadingState());

    var data = await klijentiProvider.get({'Naziv': event.naziv, 'Id': event.id}, "Client");

    emit(KlijentiDataLoaded(klijenti: data));
  }

  FutureOr<void> klijentiUpdateEvent(KlijentiUpdateEvent event, Emitter<KlijentiState> emit) async {
    await klijentiProvider.update(event.klijentId, event.klijent, "Client");
  }
}
