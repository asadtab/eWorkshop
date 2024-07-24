import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:commons/providers/api_scopes_provider.dart';
import 'package:equatable/equatable.dart';
import 'package:commons/models/api_scopes.dart';

part 'api_scopes_event.dart';
part 'api_scopes_state.dart';

class ApiScopesBloc extends Bloc<ApiScopesEvent, ApiScopesState> {
  late ApiScopesProvider apiScopesProvider;

  ApiScopesBloc({required this.apiScopesProvider}) : super(ApiScopesInitial()) {
    on<ApiScopesEvent>((event, emit) {
      // TODO: implement event handler
    });

    on<ApiScopeLoadDataEvent>(apiScopeLoadDataEvent);
    on<ApiScopeClientLoadEvent>(apiScopeClientLoadEvent);
    on<ScopesAddEvent>(scopesAddEvent);
    on<ScopesSearchEvent>(scopesSearchEvent);
  }

  FutureOr<void> apiScopeLoadDataEvent(ApiScopeLoadDataEvent event, Emitter<ApiScopesState> emit) async {
    emit(ApiScopesLoadingState());

    var request = await apiScopesProvider.get(null, "ApiScopes");

    emit(ApiScopesDataLoadedState(apiScopes: request));
  }

  FutureOr<void> apiScopeClientLoadEvent(ApiScopeClientLoadEvent event, Emitter<ApiScopesState> emit) async {
    emit(ApiScopesLoadingState());

    var request = await apiScopesProvider.get(null, "ApiScopes");

    emit(ApiScopesDataLoadedState(apiScopes: request));
  }

  FutureOr<void> scopesAddEvent(ScopesAddEvent event, Emitter<ApiScopesState> emit) async {
    await apiScopesProvider.insert(event.request, "ApiScopes");
  }

  FutureOr<void> scopesSearchEvent(ScopesSearchEvent event, Emitter<ApiScopesState> emit) async {
    emit(ApiScopesLoadingState());

    var request = await apiScopesProvider.get({'Name': event.tip, 'DisplayName': event.naziv}, "ApiScopes");

    emit(ApiScopesDataLoadedState(apiScopes: request));
  }
}
