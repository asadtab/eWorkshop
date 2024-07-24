part of 'radni_zadatak_uredjaj_block_bloc.dart';

class RadniZadatakUredjajEvent extends Equatable {
  const RadniZadatakUredjajEvent();

  @override
  List<Object> get props => [];
}

class RadniZadatakLoadingEvent extends RadniZadatakUredjajEvent {}

class RadniZadatakFilterEvent extends RadniZadatakUredjajEvent {
  String status;

  RadniZadatakFilterEvent({required this.status});
}

class RadniZadatakIdEvent extends RadniZadatakUredjajEvent {
  int id;

  RadniZadatakIdEvent({required this.id});
}
