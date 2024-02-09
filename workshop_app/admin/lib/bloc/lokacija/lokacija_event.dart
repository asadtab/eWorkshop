part of 'lokacija_bloc.dart';

class LokacijaEvent extends Equatable {
  const LokacijaEvent();

  @override
  List<Object> get props => [];
}

class LokacijaAddEvent extends LokacijaEvent {
  final String naziv;

  LokacijaAddEvent({required this.naziv});
}

class LokacijaInitialEvent extends LokacijaEvent {}
