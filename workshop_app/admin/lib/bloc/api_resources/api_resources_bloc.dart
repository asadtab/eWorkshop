import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:commons/models/api_resources.dart';
import 'package:commons/providers/api_resources_provider.dart';
import 'package:equatable/equatable.dart';

part 'api_resources_event.dart';
part 'api_resources_state.dart';

class ApiResourcesBloc extends Bloc<ApiResourcesEvent, ApiResourcesState> {
  late ApiResourcesProvider apiResourcesProvider;

  ApiResourcesBloc({required this.apiResourcesProvider}) : super(ApiResourcesInitial()) {
    on<ApiResourcesEvent>((event, emit) {
      // TODO: implement event handler
    });

    on<ApiResourcesDataLoadEvent>(apiResourcesDataLoadEvent);
    on<ApiResourcesSearchEvent>(apiResourcesSearchEvent);
  }

  FutureOr<void> apiResourcesDataLoadEvent(ApiResourcesDataLoadEvent event, Emitter<ApiResourcesState> emit) async {
    emit(ApiResourcesLoadingState());

    var request = await apiResourcesProvider.get(null, "ApiResource");

    emit(ApiResourcesDataLoadedState(resources: request));
  }

  FutureOr<void> apiResourcesSearchEvent(ApiResourcesSearchEvent event, Emitter<ApiResourcesState> emit) async {
    emit(ApiResourcesLoadingState());

    var request = await apiResourcesProvider.get({'Name': event.tip, 'DisplayName': event.naziv}, "ApiResource");

    emit(ApiResourcesDataLoadedState(resources: request));
  }
}
