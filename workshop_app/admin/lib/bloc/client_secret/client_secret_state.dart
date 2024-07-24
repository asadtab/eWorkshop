part of 'client_secret_bloc.dart';

class ClientSecretState extends Equatable {
  const ClientSecretState();

  @override
  List<Object> get props => [];
}

class ClientSecretInitial extends ClientSecretState {}

class ClientSecretLoadingState extends ClientSecretState {}

class ClientSecretDataLoadedState extends ClientSecretState {
  final List<ClientSecret> apiScopes;

  ClientSecretDataLoadedState({required this.apiScopes});
}
