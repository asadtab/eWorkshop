import 'package:commons/models/korisnik.dart';
import 'package:commons/models/radni_zadatak_uredjaj.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/models/user.dart';
import 'package:commons/providers/auth_provider.dart';
import 'package:commons/providers/korisnici_provider.dart';
import 'package:commons/providers/radniZadaci_uredjaj_provider.dart';
import 'package:commons/providers/uredjaj_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/main.dart';
import 'package:workshop_app/screens/end-user/prijavi_smetnju.dart';
import 'package:workshop_app/screens/end-user/uredjaji.dart';
import 'package:workshop_app/screens/login_screen.dart';

class EndHomeScreen extends StatefulWidget {
static const String routeName = "/endHomeScreen";
  @override
  State<EndHomeScreen> createState() => _EndHomeScreenState();
}

class _EndHomeScreenState extends State<EndHomeScreen> {
  KorisniciProvider? korisniciProvider = null;
  RadniZadaciUredjajProvider? radniZadatakUredjajProvider = null;
  UredjajProvider? uredjajProvider = null;
  List<RadniZadatakUredjaj> uredjajiZadatak = [];
  List<Uredjaj> uredjaji = [];
  Korisnik? korisnik;

  bool isLoading = true;

  @override
  void initState() {
    super.initState();

    korisniciProvider = context.read<KorisniciProvider>();
    radniZadatakUredjajProvider = context.read<RadniZadaciUredjajProvider>();
    uredjajProvider = context.read<UredjajProvider>();

    _fetchData(null);
  }

   Future<void> _fetchData(Map<String, String>? map) async {
    setState(() {
      isLoading = true;
    });

    var korisnikResult = await korisniciProvider!.get({'KorisnickoIme': User.username}, "Korisnici");
    var result = await uredjajProvider!.get({'LokacijaNaziv': korisnikResult.first.radnaJedinica}, "Uredjaj");


    setState(() {
      uredjaji = result;
      korisnik = korisnikResult.first;
      isLoading = false;
    });
  }

      void logout(BuildContext context) {
    User.name = null;
    User.email = null;
    User.token = null;

    context.read<AuthProvider>().setLoggedIn(false);

    Navigator.pushReplacement(context, MaterialPageRoute(builder: (context) => MyHomePage(title: "SS-TK",)));
    
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(appBar: AppBar(title: Text("Radna jedinica:  ${korisnik?.radnaJedinica ?? ""}"), automaticallyImplyLeading: false,backgroundColor: Color(0xFF4592AF), ), body:
     SafeArea(child:
       
           Center(
             child: Padding(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    MenuItem(
                      title: 'Status relejnih uređaja na servisiranju',
                      icon: Icons.devices,
                      onTap: () {
                        Navigator.push(context, MaterialPageRoute(builder: (context) => EndUredjaji(uredjaji: uredjaji, korisnik:korisnik!)));
                      },
                    ),
                    SizedBox(height: 16),
                    MenuItem(
                      title: 'Prijavi smetnju',
                      icon: Icons.send,
                      onTap: () {
                        Navigator.push(context, MaterialPageRoute(builder: (context) => PrijaviSmetnju(korisnik: korisnik!)));
                      },
                    ),
                    SizedBox(height: 16),
                    MenuItem(
                      title: 'Logout',
                      icon: Icons.logout,
                      onTap: () {
                        logout(context);
                      },
                    ),
                  ],
                ),
              ),
           ),
         
     ),);
  }
}

class MenuItem extends StatelessWidget {
  final String title;
  final IconData icon;
  final VoidCallback onTap;

  const MenuItem({
    required this.title,
    required this.icon,
    required this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Container(
        padding: EdgeInsets.symmetric(horizontal: 20, vertical: 15),
        decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.circular(8),
          boxShadow: [
            BoxShadow(
              color: Colors.black12,
              blurRadius: 10,
              spreadRadius: 1,
              offset: Offset(0, 5),
            ),
          ],
        ),
        child: Row(
          children: [
            Icon(
              icon,
              color: Colors.blue,
              size: 30,
            ),
            SizedBox(width: 20),
            Expanded(
              child: Text(
                title,
                style: TextStyle(
                  fontSize: 18,
                  fontWeight: FontWeight.w500,
                ),
              ),
            ),
            Icon(
              Icons.arrow_forward_ios,
              color: Colors.grey,
              size: 20,
            ),
          ],
        ),
      ),
    );
  }
}