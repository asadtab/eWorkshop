import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:equatable/equatable.dart';

part 'uredjaji_lista_zadatak_event.dart';
part 'uredjaji_lista_zadatak_state.dart';

class UredjajiListaZadatakBloc extends Bloc<UredjajiListaZadatakEvent, UredjajiListaZadatakState> {
  final UredjajProvider uredjajiProvider;

  UredjajiListaZadatakBloc({required this.uredjajiProvider}) : super(UredjajiListaZadatakInitial()) {
    on<UredjajiListaZadatakEvent>((event, emit) {});
    on<UredjajiLoadZadatakEvent>(uredjajiLoadZadatakEvent);
  }

  FutureOr<void> uredjajiLoadZadatakEvent(UredjajiLoadZadatakEvent event, Emitter<UredjajiListaZadatakState> emit) async {
    emit(UredjajiLoadZadatakState());

    var data = await uredjajiProvider.get({'Status': 'active'}, "Uredjaj");

    emit(UredjajiActiveZadatakState(uredjaji: data));
  }
}
