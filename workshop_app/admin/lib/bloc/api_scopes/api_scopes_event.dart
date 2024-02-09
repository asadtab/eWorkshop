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
