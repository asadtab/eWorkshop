import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:commons/models/statistika.dart';
import 'package:commons/providers/statistika_provider.dart';
import 'package:equatable/equatable.dart';

part 'statistika_event.dart';
part 'statistika_state.dart';

class StatistikaBloc extends Bloc<StatistikaEvent, StatistikaState> {
  late StatistikaProvider? statistikaProvider;

  StatistikaBloc({this.statistikaProvider}) : super(StatistikaInitial()) {
    on<StatistikaEvent>((event, emit) {
      // TODO: implement event handler
    });

    on<StatistikaRefreshEvent>(statistikaRefreshEvent);
  }

  FutureOr<void> statistikaRefreshEvent(StatistikaRefreshEvent event, Emitter<StatistikaState> emit) async {
    var response = await statistikaProvider!.get(null, "Statistika/Uredjaji");

    emit(StatistikaInitial(statistika: response.first));
  }
}
