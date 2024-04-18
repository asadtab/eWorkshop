class StateHelper {
  static const List<String> nizNaziv = <String>["idle", "active", "fix", "ready", "out", "parts", "task"];
  static const List<String> nizOpis = <String>["Neaktivni", "Aktivni", "Servisirani", "Spremni", "Poslani", "Rezervni", "Radni zadatak"];

  static const List<String> nizZadatakState = <String>["idle", "active", "done", "invoice"];

  static const List<String> nizZadatakStateOpis = <String>["Neaktivni", "Aktivni", "Završeni", "Fakturisano"];

  static String nizZadatakRezultat(String opisProvjera) {
    String rezultat = "Nepoznato";

    for (var i = 0; i < nizZadatakStateOpis.length; i++) {
      if (nizZadatakState[i] == opisProvjera) {
        rezultat = nizZadatakStateOpis[i];
      }
    }

    return rezultat;
  }

  static String nizZadatakStateSearch(String opisProvjera) {
    String rezultat = "Nepoznato";

    for (var i = 0; i < nizZadatakStateOpis.length; i++) {
      if (nizZadatakStateOpis[i] == opisProvjera) {
        rezultat = nizZadatakState[i];
      }
    }

    return rezultat;
  }

  static String nizRezultat(String opisProvjera) {
    String rezultat = "Nepoznato";

    for (var i = 0; i < nizOpis.length; i++) {
      if (nizNaziv[i] == opisProvjera) {
        rezultat = nizOpis[i];
      }
    }

    return rezultat;
  }

  static String nizSearch(String opisProvjera) {
    String rezultat = "Nepoznato";

    for (var i = 0; i < nizOpis.length; i++) {
      if (nizOpis[i] == opisProvjera) {
        rezultat = nizNaziv[i];
      }
    }

    return rezultat;
  }
}
