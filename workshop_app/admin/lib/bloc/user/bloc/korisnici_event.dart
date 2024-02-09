part of 'korisnici_bloc.dart';

class KorisniciEvent extends Equatable {
  const KorisniciEvent();

  @override
  List<Object> get props => [];
}

class KorisniciAdd extends KorisniciEvent {
  final String? ime;
  final String? prezime;
  final String? passwordHash;
  final String? email;
  final List<String> uloge;

  KorisniciAdd({this.ime, this.prezime, this.passwordHash, this.email, required this.uloge});
}

class KorisniciLoad extends KorisniciEvent {}

class KorisniciByIdEvent extends KorisniciEvent {
  final int id;

  KorisniciByIdEvent({required this.id});
}

class KorisniciSearch extends KorisniciEvent {
  final String? userName;
  final String? imePrezime;
  final int? id;

  KorisniciSearch({required this.userName, required this.imePrezime, this.id});
}
