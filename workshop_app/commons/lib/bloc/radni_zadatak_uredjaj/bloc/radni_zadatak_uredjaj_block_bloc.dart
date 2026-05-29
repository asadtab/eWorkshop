import 'dart:async';

//import 'package:admin/providers/radniZadaci_uredjaj_provider.dart';
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
    on<RadniZadatakIdEvent>(radniZadatakIdEvent);
  }

  FutureOr<void> loadingEvent(RadniZadatakLoadingEvent event, Emitter<RadniZadatakUredjajState> emit) async {
    print("pozvan loaidng event");
    emit(LoadingState());

    var data = await radniZadaciUredjajProvider.get({'StateMachine': 'active'}, "RadniZadatakUredjaj/Flutter");

    emit(DataLoadedState(data));
  }

  FutureOr<void> radniZadatakIdEvent(RadniZadatakIdEvent event, Emitter<RadniZadatakUredjajState> emit) async {
    var data = await radniZadaciUredjajProvider.get({'RadniZadatakId': event.id.toString()}, "RadniZadatakUredjaj/Flutter");

    emit(RadniZadatakIdState(data));
  }
}
