part of 'uloge_bloc.dart';

class UlogeState extends Equatable {
  const UlogeState();

  @override
  List<Object> get props => [];
}

class UlogeInitial extends UlogeState {}

class UlogeData extends UlogeState {
  final List<Uloge> ulogeData;

  UlogeData({required this.ulogeData});
}

class UlogeReload extends UlogeState {}
