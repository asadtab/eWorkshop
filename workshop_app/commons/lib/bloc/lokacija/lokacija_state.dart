part of 'lokacija_bloc.dart';

class LokacijaState extends Equatable {
  const LokacijaState();

  @override
  List<Object> get props => [];
}

class LokacijaInitial extends LokacijaState {}

class LokacijaLoadingState extends LokacijaState {}

class LokacijaDataState extends LokacijaState {
  final List<Lokacija> lokacije;

  LokacijaDataState({required this.lokacije});
}
