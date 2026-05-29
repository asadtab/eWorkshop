import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:commons/models/uloge.dart';
import 'package:commons/providers/uloge_provider.dart';
import 'package:equatable/equatable.dart';

part 'uloge_event.dart';
part 'uloge_state.dart';

class UlogeBloc extends Bloc<UlogeEvent, UlogeState> {
  final UlogeProvider ulogeProvider;

  UlogeBloc({required this.ulogeProvider}) : super(UlogeInitial()) {
    on<UlogeEvent>((event, emit) {
      // TODO: implement event handler
    });
    on<UlogeRequest>(ulogeRequest);
    on<UlogeAdd>(ulogeAdd);
    on<UlogeSearch>(ulogeSearch);
  }

  FutureOr<void> ulogeRequest(UlogeRequest event, Emitter<UlogeState> emit) async {
    emit(UlogeReload());

    var request = await ulogeProvider.get(null, "Uloge");

    emit(UlogeData(ulogeData: request));
  }

  FutureOr<void> ulogeAdd(UlogeAdd event, Emitter<UlogeState> emit) async {
    var uloga = await ulogeProvider.insert({'name': event.nazivUloge}, "Uloge");
  }

  FutureOr<void> ulogeSearch(UlogeSearch event, Emitter<UlogeState> emit) async {
    emit(UlogeReload());

    var request = await ulogeProvider.get({'Naziv': event.nazivUloge}, "Uloge");

    emit(UlogeData(ulogeData: request));
  }
}
