import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:equatable/equatable.dart';
import 'package:http/http.dart';
import 'package:meta/meta.dart';

part 'uredjaj_event.dart';
part 'uredjaj_state.dart';

class UredjajBloc extends Bloc<UredjajEvent, UredjajState> {
  final UredjajProvider uredjajiProvider;

  UredjajBloc({required this.uredjajiProvider}) : super(UredjajLoadingState()) {
    on<LoadingEvent>(loadingEvent);
    on<UredjajFilterEvent>(uredjajFilterEvent);
    on<UredjajRefreshEvent>(uredjajRefreshEvent);
  }

  FutureOr<void> loadingEvent(LoadingEvent event, Emitter<UredjajState> emit) async {
    print("pozvan loaidng event");
    emit(UredjajLoadingState());

    var data = await uredjajiProvider.get({'Status': 'active'}, "Uredjaj");

    emit(UredjajDataLoadedState(data));
  }

  FutureOr<void> uredjajFilterEvent(UredjajFilterEvent event, Emitter<UredjajState> emit) async {
    print("pozvan filter event");
    emit(UredjajLoadingState());

    var data = await uredjajiProvider.get({'Status': event.status}, "Uredjaj");

    emit(UredjajDataLoadedState(data));
  }

  FutureOr<void> uredjajRefreshEvent(UredjajRefreshEvent event, Emitter<UredjajState> emit) async {
    print("pozvan uredjaj filter event");
    emit(UredjajLoadingState());

    var data = await uredjajiProvider.get({'UredjajId': event.id}, "Uredjaj");

    emit(UredjajLoadedState(data.first));
  }
}
