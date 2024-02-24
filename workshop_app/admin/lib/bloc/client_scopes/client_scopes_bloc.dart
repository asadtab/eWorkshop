import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';

part 'client_scopes_event.dart';
part 'client_scopes_state.dart';

class ClientScopesBloc extends Bloc<ClientScopesEvent, ClientScopesState> {
  ClientScopesBloc() : super(ClientScopesInitial()) {
    on<ClientScopesEvent>((event, emit) {
      // TODO: implement event handler
    });
    on<ClientScopesIdEvent>(clientScopesIdEvent);
    on<ScopesAddEvent>(scopesAddEvent);
  }

  FutureOr<void> clientScopesIdEvent(ClientScopesIdEvent event, Emitter<ClientScopesState> emit) async {}

  FutureOr<void> scopesAddEvent(ScopesAddEvent event, Emitter<ClientScopesState> emit) async {}
}
