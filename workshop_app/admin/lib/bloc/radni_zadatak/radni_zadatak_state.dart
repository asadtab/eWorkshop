part of 'radni_zadatak_bloc.dart';

 class RadniZadatakState extends Equatable {
  const RadniZadatakState();
  
  @override
  List<Object> get props => [];
}

 class RadniZadatakInitial extends RadniZadatakState {}

 /*class ZadaciDataLoadedState extends RadniZadatakState{
    final List<RadniZadatak> datas;

  ZadaciDataLoadedState(this.data);

  @override
  get props => [datas];
 }*/

  class ZadatakDataLoadedState extends RadniZadatakState{
    final RadniZadatak data;

  ZadatakDataLoadedState(this.data);

  @override
  get props => [data];
 }
  class ZadaciDataLoadedState extends RadniZadatakState{
    final List<RadniZadatak> data;

  ZadaciDataLoadedState(this.data);

  @override
  get props => [data];
 }

 class ZadaciLoadingState extends RadniZadatakState{

 }

  class RadniZadatakRefreshListaState extends RadniZadatakState{

 }