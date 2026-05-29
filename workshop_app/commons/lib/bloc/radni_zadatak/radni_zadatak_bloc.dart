import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:commons/models/radni_zadatak.dart';
import 'package:commons/providers/radniZadaci_provider.dart';
import 'package:darq/darq.dart';
import 'package:equatable/equatable.dart';

part 'radni_zadatak_event.dart';
part 'radni_zadatak_state.dart';

class RadniZadatakBloc extends Bloc<RadniZadatakEvent, RadniZadatakState> {
  final RadniZadaciProvider radniZadatakProvider;

  RadniZadatakBloc({required this.radniZadatakProvider}) : super(RadniZadatakInitial()) {
    //on<RadniZadatakIdEvent>((event, emit) {});
    on<RadniZadatakSingleIdEvent>(zadatakLoaded);
    on<RadniZadatakAllEvent>(zadatakGetAll);
    on<RadniZadatakRefreshListaEvent>(RadniZadaciListaRefreshScreen);
  }

    FutureOr<void> zadatakLoaded(RadniZadatakSingleIdEvent event, Emitter<RadniZadatakState> emit) async {
    print("pozvan filter event");
    //emit(UredjajLoadingState());

    var filter = {'RadniZadatakId': event.id};

    var data = await radniZadatakProvider.get(filter, "RadniZadatak");

    emit(ZadatakDataLoadedState(data.first));
  }

  FutureOr<void> zadatakGetAll(RadniZadatakAllEvent event, Emitter<RadniZadatakState> emit) async {
    print("pozvan filter event");
    emit(ZadaciLoadingState());

    var filter = {'StateMachine': event.status};

    var data = await radniZadatakProvider.get(filter, "RadniZadatak");

    emit(ZadaciDataLoadedState(data));
  }

   FutureOr<void> RadniZadaciListaRefreshScreen(RadniZadatakRefreshListaEvent event, Emitter<RadniZadatakState> emit) async {
    emit(RadniZadatakRefreshListaState());
  }
}
