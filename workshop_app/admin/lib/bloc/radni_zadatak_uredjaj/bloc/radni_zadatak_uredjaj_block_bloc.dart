import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:equatable/equatable.dart';

part 'radni_zadatak_uredjaj_block_event.dart';
part 'radni_zadatak_uredjaj_block_state.dart';

class RadniZadatakUredjajBloc extends Bloc<RadniZadatakUredjajEvent, RadniZadatakUredjajState> {
  final RadniZadaciUredjajProvider radniZadaciUredjajProvider;

  RadniZadatakUredjajBloc({required this.radniZadaciUredjajProvider}) : super(LoadingState()) {
    on<RadniZadatakLoadingEvent>(loadingEvent);
  }

  FutureOr<void> loadingEvent(RadniZadatakLoadingEvent event, Emitter<RadniZadatakUredjajState> emit) async {
    print("pozvan loaidng event");
    emit(LoadingState());

    var data = await radniZadaciUredjajProvider.get({'StateMachine': 'active'}, "RadniZadatakUredjaj/Flutter");

    emit(DataLoadedState(data));
  }
}
