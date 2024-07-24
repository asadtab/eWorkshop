import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:commons/models/client_secret.dart';
import 'package:commons/providers/client_secret_provider.dart';
import 'package:equatable/equatable.dart';

part 'client_secret_event.dart';
part 'client_secret_state.dart';

class ClientSecretBloc extends Bloc<ClientSecretEvent, ClientSecretState> {
  late ClientSecretProvider clientSecretProvider;

  ClientSecretBloc({required this.clientSecretProvider}) : super(ClientSecretInitial()) {
    on<ClientSecretEvent>((event, emit) {
      // TODO: implement event handler
    });

    on<ClientSecretLoadDataEvent>(apiScopeLoadDataEvent);
    on<ClientSecretIdEvent>(clientSecretIdEvent);
  }

  FutureOr<void> apiScopeLoadDataEvent(ClientSecretLoadDataEvent event, Emitter<ClientSecretState> emit) async {
    emit(ClientSecretLoadingState());
  }

  FutureOr<void> clientSecretIdEvent(ClientSecretIdEvent event, Emitter<ClientSecretState> emit) async {
    emit(ClientSecretLoadingState());

    var request = await clientSecretProvider.get({'ClientId': event.clientId}, "ClientSecret");

    emit(ClientSecretDataLoadedState(apiScopes: request));
  }
}
