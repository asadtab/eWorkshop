import 'dart:async';

import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/uredjaj_provider.dart';

enum UredjajAction { Refresh, Aktivni, Neaktivni, Servisirani, Poslani, Spremni, Rezervni }

class UredjajiBloc {
  //List<Uredjaj> uredjajData = [];
  final _stateStreamController = StreamController<List<Uredjaj>>.broadcast();
  Stream<List<Uredjaj>> get uredjajStream => _stateStreamController.stream;
  StreamSink<List<Uredjaj>> get uredjajSink => _stateStreamController.sink;

  final _eventStreamController = StreamController<UredjajAction>();
  Stream<UredjajAction> get eventStream => _eventStreamController.stream;
  StreamSink<UredjajAction> get eventSink => _eventStreamController.sink;

  final _filterStreamController = StreamController<String>();
  Stream<String> get filterStream => _filterStreamController.stream;
  StreamSink<String> get filterSink => _filterStreamController.sink;

  final UredjajProvider? _uredjajiProvider;
  String? status;
  int? id;

  UredjajiBloc(this._uredjajiProvider, this.status, this.id) {
    Map<String, String> map = {};
    Map<String, String> mapRefresh = {};

/*    uredjajStream.listen((event) {
      if (event == UredjajAction.Refresh) {
        map = {'Status': 'active'};
        fetchUredjaji(map);
      }
    });*/

    eventStream.listen((event) {
      if (event == UredjajAction.Aktivni) {
        status = 'active';
        print("active");
      } else if (event == UredjajAction.Neaktivni) {
        status = 'idle';
        print("idle");
      } else if (event == UredjajAction.Poslani) {
        status = 'out';
        print("out");
      } else if (event == UredjajAction.Spremni) {
        status = 'ready';
        print("ready");
      } else if (event == UredjajAction.Servisirani) {
        status = 'fix';
        print("fix");
      } else if (event == UredjajAction.Rezervni) {
        status = 'parts';
        print("parts");
      } else if (event == UredjajAction.Refresh) {
        mapRefresh = {'UredjajId': id.toString()};
        print("refresh $id");
        getTrenutniUredjaj(map);
        return;
      }

      map = {'Status': status ?? ""};
      fetchUredjaji(map);
    });

    filterStream.listen((event) {
      map = {'Status': event};
      fetchUredjaji(map);
    });
  }

  fetchUredjaji(Map<String, String> map) async {
    final uredjajiData = await _uredjajiProvider!.get(map, "Uredjaj");

    uredjajSink.add(uredjajiData);
  }

  getTrenutniUredjaj(Map<String, String> map) async {
    final uredjajiData = await _uredjajiProvider!.get(map, "Uredjaj");

    uredjajSink.add(uredjajiData);
  }

  void dispose() {
    _stateStreamController.close();
    _filterStreamController.close();
  }
}
