import 'dart:async';

import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/uredjaj_provider.dart';

enum UredjajAction { Refresh }

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
  String status;

  UredjajiBloc(this._uredjajiProvider, this.status) {
    Map<String, String> map = {};

/*    uredjajStream.listen((event) {
      if (event == UredjajAction.Refresh) {
        map = {'Status': 'active'};
        fetchUredjaji(map);
      }
    });*/

    /*  eventStream.listen((event) {
      if (event == UredjajAction.Refresh) {
        map = {'Status': 'active'};
        fetchUredjaji(map);
      }
    });*/

    filterStream.listen((event) {
      map = {'Status': event};
      var uredjajiData = fetchUredjaji(map);

      List<Uredjaj> uredjajData = [];
      uredjajData = uredjajiData;

      uredjajSink.add(uredjajiData);
    });
  }

  fetchUredjaji(Map<String, String> map) async {
    final uredjajiData = await _uredjajiProvider!.get(map, "Uredjaj");
    return uredjajiData;
    //uredjajSink.add(uredjajiData);
  }

  void dispose() {
    _stateStreamController.close();
  }
}
