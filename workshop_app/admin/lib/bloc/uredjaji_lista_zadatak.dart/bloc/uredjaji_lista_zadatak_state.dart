part of 'uredjaji_lista_zadatak_bloc.dart';

class UredjajiListaZadatakState extends Equatable {
  const UredjajiListaZadatakState();

  @override
  List<Object> get props => [];
}

class UredjajiListaZadatakInitial extends UredjajiListaZadatakState {}

class UredjajiActiveZadatakState extends UredjajiListaZadatakState {
  List<Uredjaj> uredjaji = [];

  UredjajiActiveZadatakState({required this.uredjaji});
}

class UredjajiLoadZadatakState extends UredjajiListaZadatakState {}
