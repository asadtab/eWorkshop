part of 'uloge_bloc.dart';

class UlogeEvent extends Equatable {
  const UlogeEvent();

  @override
  List<Object> get props => [];
}

class UlogeLoading extends UlogeEvent {}

class UlogeRequest extends UlogeEvent {}

class UlogeSearch extends UlogeEvent {
  final String? nazivUloge;

  UlogeSearch({required this.nazivUloge});
}

class UlogeAdd extends UlogeEvent {
  final String? nazivUloge;

  UlogeAdd({required this.nazivUloge});
}
