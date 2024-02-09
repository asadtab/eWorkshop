part of 'klijenti_bloc.dart';

class KlijentiEvent extends Equatable {
  const KlijentiEvent();

  @override
  List<Object> get props => [];
}

class KlijentiInitialDataEvent extends KlijentiEvent {}

class KlijentiAddEvent extends KlijentiEvent {
  late Map<String, Object> request;

  KlijentiAddEvent({required this.request});
}

class KlijentiUpdateEvent extends KlijentiEvent {
  late Klijenti klijent;

  KlijentiUpdateEvent({required this.klijent});
}

class KlijentiSearchEvent extends KlijentiEvent {
  final String? naziv;
  final String? id;

  KlijentiSearchEvent({this.naziv, this.id});
}
