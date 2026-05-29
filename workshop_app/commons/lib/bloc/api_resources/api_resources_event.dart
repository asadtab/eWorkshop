part of 'api_resources_bloc.dart';

class ApiResourcesEvent extends Equatable {
  const ApiResourcesEvent();

  @override
  List<Object> get props => [];
}

class ApiResourcesDataLoadEvent extends ApiResourcesEvent {}

class ApiResourcesSearchEvent extends ApiResourcesEvent {
  final String? tip;
  final String? naziv;

  ApiResourcesSearchEvent({this.naziv, this.tip});
}
