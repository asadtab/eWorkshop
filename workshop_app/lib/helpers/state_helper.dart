class StateHelper {
  static const List<String> nizNaziv = <String>[
    "idle",
    "active",
    "fix",
    "ready",
    "out",
    "parts",
    "task"
  ];
  //const List<String> listButton = <String>['One', 'Two', 'Three', 'Four'];
  static const List<String> nizOpis = <String>[
    "Idle",
    "Aktivni uređaji",
    "Servisirani uređaji",
    "Spremni uređaji",
    "Poslani uređaji",
    "Rezervni uređaji",
    "Radni zadatak"
  ];

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
