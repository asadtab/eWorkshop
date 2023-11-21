part of 'uredjaji_lista_zadatak_bloc.dart';

class UredjajiListaZadatakEvent extends Equatable {
  const UredjajiListaZadatakEvent();

  @override
  List<Object> get props => [];
}

class UredjajiActiveZadatakEvent extends UredjajiListaZadatakEvent {}

class UredjajiLoadZadatakEvent extends UredjajiListaZadatakEvent {}
