import 'package:commons/models/korisnik.dart';
import 'package:commons/models/user.dart';
import 'package:flutter/material.dart';

class UserAccountScreen extends StatefulWidget {
  late Korisnik? korisnik;

  UserAccountScreen({this.korisnik});

  @override
  _UserAccountScreenState createState() => _UserAccountScreenState();
}

class _UserAccountScreenState extends State<UserAccountScreen> {
  late Korisnik _korisnik = Korisnik();

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
            // Add more Card widgets or customize the content as needed
          ],
        ),
      ),
    );
  }
}
