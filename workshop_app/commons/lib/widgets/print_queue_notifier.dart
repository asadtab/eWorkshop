import 'package:flutter/material.dart';
import 'package:commons/models/servis_report.dart';

class PrintQueueNotifier extends ChangeNotifier {
  final Set<int> _selectedIds = {};
  final List<ServisReport> _queue = [];

  Set<int> get selectedIds => _selectedIds;
  List<ServisReport> get queue => List.unmodifiable(_queue);
  List<ServisReport> get selectedItems => List.unmodifiable(_queue);
  int get count => _queue.length;

  bool isSelected(int id) => _selectedIds.contains(id);

  void toggleSelection(ServisReport report) {
    final id = report.uredjaj.uredjajId!;

    if (_selectedIds.contains(id)) {
      _selectedIds.remove(id);
      _queue.removeWhere((x) => x.uredjaj.uredjajId == id);
    } else {
      _selectedIds.add(id);
      if (!_queue.any((x) => x.uredjaj.uredjajId == id)) {
        _queue.add(report);
      }
    }

    notifyListeners();
  }

  void addToQueue(ServisReport report) {
    final id = report.uredjaj.uredjajId!;
    if (!_queue.any((x) => x.uredjaj.uredjajId == id)) {
      _queue.add(report);
      _selectedIds.add(id);
      notifyListeners();
    }
  }

  void addSelectedToQueue(List<ServisReport> data) {
    for (final x in data) {
      final id = x.uredjaj.uredjajId!;
      if (_selectedIds.contains(id) &&
          !_queue.any((q) => q.uredjaj.uredjajId == id)) {
        _queue.add(x);
      }
    }
    notifyListeners();
  }

  void removeById(int id) {
    _selectedIds.remove(id);
    _queue.removeWhere((x) => x.uredjaj.uredjajId == id);
    notifyListeners();
  }

  void clearSelection() {
    _selectedIds.clear();
    notifyListeners();
  }

  void clearQueue() {
    _queue.clear();
    _selectedIds.clear();
    notifyListeners();
  }

  void clear() {
    clearQueue();
  }
}