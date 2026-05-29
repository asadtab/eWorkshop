part of 'api_scopes_bloc.dart';

class ApiScopesEvent extends Equatable {
  const ApiScopesEvent();

  @override
  List<Object> get props => [];
}

class ApiScopeLoadDataEvent extends ApiScopesEvent {}

class ApiScopeClientLoadEvent extends ApiScopesEvent {
  late int clientId;

  ApiScopeClientLoadEvent({required this.clientId});
}

class ScopesAddEvent extends ApiScopesEvent {
  final Map<String, String> request;

  ScopesAddEvent({required this.request});
}

class ScopesSearchEvent extends ApiScopesEvent {
  final String? tip;
  final String? naziv;

  ScopesSearchEvent({this.naziv, this.tip});
}
