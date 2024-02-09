part of 'uredjaj_bloc.dart';

@immutable
abstract class UredjajEvent extends Equatable {
  @override
  // TODO: implement props
  List<Object?> get props => throw UnimplementedError();
}

class LoadingEvent extends UredjajEvent {
  @override
  // TODO: implement props
  List<Object?> get props => throw UnimplementedError();
}

class UredjajFilterEvent extends UredjajEvent {
  String? status;
  String? tip;
  String? naziv;
  String? koda;
  String? opis;
  int? id;

  UredjajFilterEvent({this.status, this.id, this.koda, this.naziv, this.tip, this.opis});
}

class UredjajRefreshEvent extends UredjajEvent {
  int id;

  UredjajRefreshEvent({required this.id});
}

class UredjajAktivniEvent extends UredjajEvent {}
