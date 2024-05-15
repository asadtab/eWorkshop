import 'dart:async';
import 'package:bloc/bloc.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';

part 'uredjaj_event.dart';
part 'uredjaj_state.dart';

class UredjajBloc extends Bloc<UredjajEvent, UredjajState> {
  final UredjajProvider uredjajiProvider;

  UredjajBloc({required this.uredjajiProvider}) : super(UredjajLoadingState()) {
    on<LoadingEvent>(loadingEvent);
    on<UredjajFilterEvent>(uredjajFilterEvent);
    on<UredjajRefreshEvent>(uredjajRefreshEvent);
    on<UredjajAktivniEvent>(uredjajAktivniZadaciEvent);
  }

  FutureOr<void> loadingEvent(LoadingEvent event, Emitter<UredjajState> emit) async {
    print("pozvan loaidng event");
    emit(UredjajLoadingState());

    try {
      var data = await uredjajiProvider.get({'Status': 'active'}, "Uredjaj");

      emit(UredjajDataLoadedState(data));
    } catch (e) {
      var exeption = e.toString();
      emit(UredjajLoadingState());
    }
  }

  FutureOr<void> uredjajFilterEvent(UredjajFilterEvent event, Emitter<UredjajState> emit) async {
    print("pozvan filter event");
    emit(UredjajLoadingState());

    var filter = {'UredjajId': event.id, 'Naziv': event.naziv, 'Koda': event.koda, 'Opis': event.opis, 'Status': event.status};

    var data = await uredjajiProvider.get(filter, "Uredjaj");

    emit(UredjajDataLoadedState(data));
  }

  FutureOr<void> uredjajRefreshEvent(UredjajRefreshEvent event, Emitter<UredjajState> emit) async {
    print("pozvan uredjaj filter event");
    emit(UredjajLoadingState());

    var data = await uredjajiProvider.get({'UredjajId': event.id}, "Uredjaj");

    emit(UredjajLoadedState(data.first));
  }

  FutureOr<void> uredjajAktivniZadaciEvent(UredjajAktivniEvent event, Emitter<UredjajState> emit) async {
    emit(UredjajLoadingState());

    var data = await uredjajiProvider.get({'Status': 'active'}, "Uredjaj");

    emit(UredjajAktivniState(aktivniUredjaji: data));
  }
}
