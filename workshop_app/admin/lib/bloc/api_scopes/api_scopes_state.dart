part of 'api_scopes_bloc.dart';

class ApiScopesState extends Equatable {
  const ApiScopesState();

  @override
  List<Object> get props => [];
}

class ApiScopesInitial extends ApiScopesState {}

class ApiScopesLoadingState extends ApiScopesState {}

class ApiScopesDataLoadedState extends ApiScopesState {
  final List<ApiScopes> apiScopes;

  ApiScopesDataLoadedState({required this.apiScopes});
}
