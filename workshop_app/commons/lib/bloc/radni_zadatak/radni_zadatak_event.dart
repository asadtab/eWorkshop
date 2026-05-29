part of 'radni_zadatak_bloc.dart';

class RadniZadatakEvent extends Equatable {
  const RadniZadatakEvent();

  @override
  List<Object> get props => [];
}

class RadniZadatakSingleIdEvent extends RadniZadatakEvent {
  int id;
 
  RadniZadatakSingleIdEvent({required this.id});
}

class RadniZadatakAllEvent extends RadniZadatakEvent {
  String status;
 
  RadniZadatakAllEvent({required this.status});
}

class RadniZadatakRefreshListaEvent extends RadniZadatakEvent {

}