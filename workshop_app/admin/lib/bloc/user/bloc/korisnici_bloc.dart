import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:commons/models/korisnik.dart';
import 'package:commons/providers/korisnici_provider.dart';
import 'package:equatable/equatable.dart';

part 'korisnici_event.dart';
part 'korisnici_state.dart';

class KorisniciBloc extends Bloc<KorisniciEvent, KorisniciState> {
  final KorisniciProvider korisniciProvider;

  KorisniciBloc({required this.korisniciProvider}) : super(KorisniciInitial()) {
    on<KorisniciEvent>((event, emit) {
      // TODO: implement event handler
    });

    on<KorisniciAdd>(korisniciAdd);
    on<KorisniciLoad>(korisniciLoad);
    on<KorisniciSearch>(korisniciSearch);
    on<KorisniciByIdEvent>(korisniciByIdEvent);
  }

  FutureOr<void> korisniciAdd(KorisniciAdd event, Emitter<KorisniciState> emit) async {
    var request = {"email": event.email, "passwordHash": event.passwordHash, "ime": event.ime, "prezime": event.prezime, "uloge": event.uloge};

    await korisniciProvider.insert(request, "Account", true);
  }

  FutureOr<void> korisniciLoad(KorisniciLoad event, Emitter<KorisniciState> emit) async {
    emit(KorisniciLoadingState());

    var korisnici = await korisniciProvider.get(null, "Korisnici", true);

    emit(KorisniciRequest(data: korisnici));
  }

  FutureOr<void> korisniciSearch(KorisniciSearch event, Emitter<KorisniciState> emit) async {
    emit(KorisniciLoadingState());

    var request = {'KorisnikID': event.id, 'KorisnickoIme': event.userName, 'ImePrezime': event.imePrezime};

    var korisnici = await korisniciProvider.get(request, "Korisnici");

    emit(KorisniciRequest(data: korisnici));
  }

  FutureOr<void> korisniciByIdEvent(KorisniciByIdEvent event, Emitter<KorisniciState> emit) async {
    emit(KorisniciLoadingState());

    var request = {
      'KorisnikID': event.id,
    };

    var korisnik = await korisniciProvider.get(request, "Korisnici");

    emit(KorisniciByIdState(korisnik: korisnik.first));
  }
}
