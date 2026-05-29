import 'package:flutter/material.dart';

class ReportsSelectionNotifier extends ChangeNotifier {
  final List<int> _selectedIds = [];

  List<int> get selectedIds => List.unmodifiable(_selectedIds);

  void toggle(int id) {
  if (_selectedIds.contains(id)) {
    _selectedIds.remove(id);
  } else {
    _selectedIds.add(id);
  }

  notifyListeners();
}

  bool isSelected(int id) {
  return _selectedIds.contains(id);
}

void clear() {
  _selectedIds.clear();
  notifyListeners();
}

int get count => _selectedIds.length;
}