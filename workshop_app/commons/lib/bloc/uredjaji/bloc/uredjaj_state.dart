part of 'uredjaj_bloc.dart';

@immutable
abstract class UredjajState extends Equatable {
  @override
  // TODO: implement props
  List<Object?> get props => [];
}

class UredjajInitial extends UredjajState {}

class UredjajLoadingState extends UredjajState {}

class UredjajDataLoadedState extends UredjajState {
  final List<Uredjaj> data;

  UredjajDataLoadedState(this.data);
}

class UredjajLoadedState extends UredjajState {
  final Uredjaj data;

  UredjajLoadedState(this.data);
}

class UredjajAktivniState extends UredjajState {
  List<Uredjaj> aktivniUredjaji;

  UredjajAktivniState({required this.aktivniUredjaji});
}
