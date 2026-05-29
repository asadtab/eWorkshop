part of 'klijenti_bloc.dart';

class KlijentiState extends Equatable {
  const KlijentiState();

  @override
  List<Object> get props => [];
}

class KlijentiInitialState extends KlijentiState {}

class KlijentiDataLoaded extends KlijentiState {
  final List<Klijenti> klijenti;

  KlijentiDataLoaded({required this.klijenti});
}

class KlijentiLoadingState extends KlijentiState {}
