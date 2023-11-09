import 'dart:async';

import 'package:admin/bloc/uredjaji_bloc.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';

class ZadatakUredjajBloc {
  final _stateStreamController = StreamController<List<RadniZadatakUredjaj>>.broadcast();
  Stream<List<RadniZadatakUredjaj>> get zadatakUredjajStream => _stateStreamController.stream;
  StreamSink<List<RadniZadatakUredjaj>> get zadatakUredjajSink => _stateStreamController.sink;

  final _eventStreamController = StreamController<UredjajAction>();
  Stream<UredjajAction> get eventStream => _eventStreamController.stream;
  StreamSink<UredjajAction> get eventSink => _eventStreamController.sink;

  final RadniZadaciUredjajProvider? zadatakProvider;
  int? id;

  ZadatakUredjajBloc({this.id, this.zadatakProvider}) {
    Map<String, String>? map = {};

    if (id != null) map = {'RadniZadatakId': id.toString()};
    map = {'StateMachine': 'active'};

    eventStream.listen((event) {
      if (event == UredjajAction.Refresh) {
        fetchUredjajiUZadatku(map);
        print("pozvan bloc za zadatke");
      }
    });
  }

  fetchUredjajiUZadatku(Map<String, String>? map) async {
    final zadatakUredjajiData = await zadatakProvider!.get(map, "RadniZadatakUredjaj/Flutter");

    zadatakUredjajSink.add(zadatakUredjajiData);
  }

  void dispose() {
    _stateStreamController.close();
    _eventStreamController.close();
  }
}
