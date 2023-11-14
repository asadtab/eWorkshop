part of 'uredjaj_bloc.dart';

@immutable
abstract class UredjajState extends Equatable {}

class UredjajInitial extends UredjajState {
  @override
  // TODO: implement props
  List<Object?> get props => throw UnimplementedError();
}

class UredjajLoadingState extends UredjajState {
  @override
  // TODO: implement props
  List<Object?> get props => [];
}

class UredjajDataLoadedState extends UredjajState {
  final List<Uredjaj> data;

  UredjajDataLoadedState(this.data);

  @override
  // TODO: implement props
  List<Object?> get props => [data];
}

class UredjajLoadedState extends UredjajState {
  final Uredjaj data;

  UredjajLoadedState(this.data);

  @override
  // TODO: implement props
  List<Object?> get props => [data];
}
