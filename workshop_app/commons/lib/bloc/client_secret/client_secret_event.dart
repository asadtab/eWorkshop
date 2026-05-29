part of 'client_secret_bloc.dart';

class ClientSecretEvent extends Equatable {
  const ClientSecretEvent();

  @override
  List<Object> get props => [];
}

class ClientSecretLoadDataEvent extends ClientSecretEvent {}

class ClientSecretIdEvent extends ClientSecretEvent {
  late int clientId;

  ClientSecretIdEvent({required this.clientId});
}
