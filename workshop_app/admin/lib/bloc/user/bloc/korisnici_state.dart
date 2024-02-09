part of 'korisnici_bloc.dart';

class KorisniciState extends Equatable {
  const KorisniciState();

  @override
  List<Object> get props => [];
}

class KorisniciInitial extends KorisniciState {}

class KorisniciLoadingState extends KorisniciState {}

class KorisniciByIdState extends KorisniciState {
  final Korisnik korisnik;

  KorisniciByIdState({required this.korisnik});
}

class KorisniciRequest extends KorisniciState {
  final List<Korisnik> data;

  KorisniciRequest({required this.data});
}
