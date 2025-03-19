import 'package:admin/bloc/user/bloc/korisnici_bloc.dart';
import 'package:admin/screens/acc.dart';
import 'package:admin/widgets/dodaj_korisnika.dart';
import 'package:commons/models/korisnik.dart';
import 'package:commons/providers/korisnici_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class KorisniciListScreen extends StatefulWidget {
  @override
  _KorisniciListScreenState createState() => _KorisniciListScreenState();
}

class _KorisniciListScreenState extends State<KorisniciListScreen> {
  TextEditingController _korisnickoImeController = TextEditingController();
  TextEditingController _imePrezimeController = TextEditingController();

  List<Korisnik> korisnici = [];

  late KorisniciProvider korisniciProvider;

  String _selected = "";

  @override
  void initState() {
    korisniciProvider = context.read<KorisniciProvider>();

    // TODO: implement initState
    super.initState();
    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    var users = await korisniciProvider.get(map, "Korisnici");

    setState(() {
      korisnici = users;
    });
  }

  @override
  Widget build(BuildContext context) {
    final KorisniciBloc korisniciBloc = BlocProvider.of<KorisniciBloc>(context);

    return Scaffold(
      body: SingleChildScrollView(
          child: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            // Input fields and buttons in a Row
            Card(
              child: Padding(
                padding: const EdgeInsets.all(8.0),
                child: Row(
                  children: [
                    Expanded(
                      child: TextField(
                        controller: _korisnickoImeController,
                        decoration: InputDecoration(labelText: 'Korisničko ime'),
                      ),
                    ),
                    SizedBox(width: 16),
                    Expanded(
                      child: TextField(
                        controller: _imePrezimeController,
                        decoration: InputDecoration(labelText: 'Ime i prezime'),
                      ),
                    ),
                    SizedBox(width: 16),
                    ElevatedButton(
                      onPressed: () {
                        korisniciBloc.add(KorisniciSearch(userName: _korisnickoImeController.text, imePrezime: _imePrezimeController.text));
                      },
                      child: Text('Prikaži'),
                    ),
                    SizedBox(width: 16),
                    ElevatedButton(
                      onPressed: () async {
                        korisniciBloc.add(KorisniciLoad());
                        showDialog(
                          context: context,
                          builder: (BuildContext context) => DodajKorisnikaDialog(null, korisnici),
                        ).then((value) {
                          korisniciBloc.add(KorisniciLoad());
                        });
                      },
                      child: Text('Dodaj novog korisnika'),
                    ),
                  ],
                ),
              ),
            ),
            SizedBox(height: 20),
            Text("Lista korisnika"),
            BlocConsumer<KorisniciBloc, KorisniciState>(
              bloc: korisniciBloc,
              listener: (context, state) {},
              builder: (context, state) {
                if (state is KorisniciLoadingState) {
                  return Center(child: CircularProgressIndicator());
                }
                if (state is KorisniciRequest) {
                  return Card(
                    child: Container(
                      width: 200,
                      child: DataTable(
                        showCheckboxColumn: false,
                        columns: [
                          DataColumn(label: Text('Ime i prezime')),
                          DataColumn(label: Text('Korisničko ime')),
                          DataColumn(label: Text('E-mail adresa')),
                          DataColumn(label: Text('Aktivan')),
                          DataColumn(label: Text('Opcije')),
                        ],
                        rows: state.data
                            .map(
                              (user) => DataRow(
                                cells: [
                                  DataCell(Text('${user.ime} ${user.prezime}')),
                                  DataCell(Text(user.userName ?? "")),
                                  DataCell(Text(user.email ?? "")),
                                  DataCell(Text(user.status! ? "Da" : "Ne")),
                                  DataCell(PopupMenuButton<String>(
                                    initialValue: _selected,
                                    onSelected: (izbor) {
                                      if (izbor == "delete") {
                                        showDialog(
                                            context: context,
                                            builder: (BuildContext context) {
                                              return AlertDialog(
                                                  title: Text("Da li želite izbrisati korisnika?"),
                                                  content: Container(
                                                      height: 170,
                                                      child: Row(children: [
                                                        MinimalisticButton(
                                                          text: "Potvrdi",
                                                          onPressed: () async {
                                                            var result = await korisniciProvider.delete(user.id, user, "Korisnici");

                                                            korisniciBloc.add(KorisniciLoad());

                                                            ScaffoldMessenger.of(context)
                                                                .showSnackBar(CustomNotification.infoSnack(result!["message"].toString()));

                                                            Navigator.of(context).pop();
                                                          },
                                                          icons: Icon(
                                                            Icons.save,
                                                            color: Colors.blueAccent,
                                                          ),
                                                        ),
                                                        MinimalisticButton(
                                                            text: "Poništi",
                                                            onPressed: () {
                                                              Navigator.of(context).pop();
                                                            },
                                                            icons: Icon(Icons.cancel, color: Colors.redAccent))
                                                      ])));
                                            });
                                      }
                                    },
                                    itemBuilder: (BuildContext context) => <PopupMenuEntry<String>>[
                                      PopupMenuItem<String>(
                                        child: Text('Izbriši'),
                                        value: 'delete',
                                      ),
                                    ],
                                  )),
                                ],
                                onSelectChanged: (isSelected) {
                                  if (isSelected!) {
                                    korisniciBloc.add(KorisniciByIdEvent(id: user.id!));
                                    //if (state is KorisniciByIdState) {user = state.data.first},
                                    Navigator.push(context, MaterialPageRoute(builder: (context) => UserAccountScreen(korisnik: user))).then((value) {
                                      korisniciBloc.add(KorisniciLoad());
                                    });
                                  }
                                },
                              ),
                            )
                            .toList(),
                      ),
                    ),
                  );
                }
                return Center(child: Text("Podaci ne postoje"));
              },
            ),
          ],
        ),
      )),
    );
  }
}
