part of 'radni_zadatak_uredjaj_block_bloc.dart';

class RadniZadatakUredjajState extends Equatable {
  const RadniZadatakUredjajState();

  @override
  List<Object> get props => [];
}

class RadniZadatakUredjajBlockInitial extends RadniZadatakUredjajState {}

class LoadingState extends RadniZadatakUredjajState {}

class DataLoadedState extends RadniZadatakUredjajState {
  final List<RadniZadatakUredjaj> data;

  DataLoadedState(this.data);

  @override
  get props => [data];
}

class RadniZadatakIdState extends RadniZadatakUredjajState {
  final List<RadniZadatakUredjaj> data;

  RadniZadatakIdState(this.data);

  @override
  get props => [data];
}
