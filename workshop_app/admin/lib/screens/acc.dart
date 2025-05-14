import 'package:admin/widgets/dodaj_korisnika.dart';
import 'package:admin/widgets/promjeni_password.dart';
import 'package:commons/models/korisnik.dart';
import 'package:commons/models/user.dart';
import 'package:commons/providers/korisnici_provider.dart';
import 'package:flutter/material.dart';
import 'package:url_launcher/url_launcher.dart';

class UserAccountScreen extends StatefulWidget {
  late Korisnik? korisnik;

  UserAccountScreen({this.korisnik});

  @override
  _UserAccountScreenState createState() => _UserAccountScreenState();
}

class _UserAccountScreenState extends State<UserAccountScreen> {
  late Korisnik _korisnik = Korisnik();
  List<Korisnik> korisnici = [];

  late KorisniciProvider korisniciProvider;

    Future<void> _fetchData(Map<String, String>? map) async {
    var users = await korisniciProvider.get(map, "Korisnici");

    setState(() {
      korisnici = users;
    });
  }

  @override
  void initState() {

    _korisnik.uloge = [];

    print(User.roles);

    if (widget.korisnik != null) {
      _korisnik = widget.korisnik!;
    } else {
      _korisnik.ime = User.name?.split(" ").first;
      _korisnik.prezime = User.name?.split(" ").last;
      _korisnik.userName = User.username;
      _korisnik.email = User.email;
      _korisnik.uloge = [];
      _korisnik.uloge = User.roles;
    }

    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Korisnički račun'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: ListView(
          children: [
            Card(
              elevation: 4.0,
              child: Padding(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'Korisnik',
                      style: TextStyle(
                        fontSize: 20.0,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    SizedBox(height: 10.0),
                    Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Row(
                          children: [
                            CircleAvatar(
                              radius: 40.0,
                            ),
                            SizedBox(width: 16.0),
                            Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Text(
                                  widget.korisnik != null
                                      ? '${widget.korisnik!.ime} ${widget.korisnik!.prezime}'
                                      : '${_korisnik.ime} ${_korisnik.prezime}',
                                  style: TextStyle(
                                    fontSize: 18.0,
                                    fontWeight: FontWeight.bold,
                                  ),
                                ),
                                Text(
                                  widget.korisnik != null ? widget.korisnik!.email! : _korisnik.email!,
                                  style: TextStyle(
                                    color: Colors.grey,
                                  ),
                                ),
                              ],
                            ),
                          ],
                        ),
                        GestureDetector(
           onTap: urediInformacije,
           
          child: MouseRegion(
            cursor: SystemMouseCursors.click,
            child: Text(
              "Uredi račun",
              style: TextStyle(
                color: Colors.blue,
                decoration: TextDecoration.underline,
                fontSize: 18,)),
          )),
              GestureDetector(
           onTap: promijeni_password,
           
          child: MouseRegion(
            cursor: SystemMouseCursors.click,
            child: Text(
              "Promjeni korisničku lozinku",
              style: TextStyle(
                color: Colors.blue,
                decoration: TextDecoration.underline,
                fontSize: 18,)),
          ))
                      ],
                    ),
                  ],
                ),
              ),
            ),
            SizedBox(height: 16.0),
            Card(
              elevation: 4.0,
              child: Padding(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'Korisnički račun',
                      style: TextStyle(
                        fontSize: 20.0,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    SizedBox(height: 10.0),
                    ListTile(
                      title: Text('Username'),
                      subtitle: Text(
                        widget.korisnik != null ? widget.korisnik!.userName! : _korisnik.userName ?? "",
                      ),
                    ),
                    ListTile(
                        title: Text('Uloge'),
                        subtitle: Text(_korisnik.uloge.join(', '))),
                    //subtitle: Text(User.roles.join(', ')))
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
  void urediInformacije(){
    showDialog(
                          context: context,
                          builder: (BuildContext context) => DodajKorisnikaDialog(_korisnik, korisnici),
                        ).then((onValue){
                          setState(() {
                            
                          });
                        });
  }

  void promijeni_password(){
    showDialog(
  context: context,
  builder: (context) => ChangePasswordDialog(userId: int.parse( User.id!)),
);
  }
}
