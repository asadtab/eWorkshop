part of 'api_resources_bloc.dart';

class ApiResourcesState extends Equatable {
  const ApiResourcesState();

  @override
  List<Object> get props => [];
}

class ApiResourcesInitial extends ApiResourcesState {}

class ApiResourcesLoadingState extends ApiResourcesState {}

class ApiResourcesDataLoadedState extends ApiResourcesState {
  final List<ApiResources> resources;

  ApiResourcesDataLoadedState({required this.resources});
}
