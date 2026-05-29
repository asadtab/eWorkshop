import 'package:flutter/material.dart';

import '../models/uredjaj.dart';

class PrintQueueNotifier extends ChangeNotifier {
  final Set<int> _selectedIds = {};
  final List<Uredjaj> _queue = [];

  Set<int> get selectedIds => _selectedIds;
  List<Uredjaj> get queue => List.unmodifiable(_queue);

  int get count => _queue.length;

  bool isSelected(int id) => _selectedIds.contains(id);

void toggleSelection(Uredjaj uredjaj) {
  final id = uredjaj.uredjajId!;
  if (_selectedIds.contains(id)) {
    _selectedIds.remove(id);
    _queue.removeWhere((x) => x.uredjajId == id); // ukloni iz queuea
  } else {
    _selectedIds.add(id);
    _queue.add(uredjaj); // odmah dodaj u queue
  }
  notifyListeners();
}

  void addToQueue(Uredjaj uredjaj) {
    if (!_queue.any((x) => x.uredjajId == uredjaj.uredjajId)) {
      _queue.add(uredjaj);
      notifyListeners();
    }
  }

  void addSelectedToQueue(List<Uredjaj> data) {
    for (final x in data) {
      if (_selectedIds.contains(x.uredjajId) &&
          !_queue.any((q) => q.uredjajId == x.uredjajId)) {
        _queue.add(x);
      }
    }
    notifyListeners();
  }

  void clearSelection() {
    _selectedIds.clear();
    notifyListeners();
  }

  void clearQueue() {
    _queue.clear();
    notifyListeners();
  }
}