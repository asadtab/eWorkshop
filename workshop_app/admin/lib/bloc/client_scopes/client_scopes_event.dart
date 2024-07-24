part of 'client_scopes_bloc.dart';

class ClientScopesEvent extends Equatable {
  const ClientScopesEvent();

  @override
  List<Object> get props => [];
}

class ClientScopesIdEvent extends ClientScopesEvent {
  late int clientId;

  ClientScopesIdEvent({required this.clientId});
}

class ScopesAddEvent extends ClientScopesEvent {
  final Map<String, String> request;

  ScopesAddEvent({required this.request});
}
