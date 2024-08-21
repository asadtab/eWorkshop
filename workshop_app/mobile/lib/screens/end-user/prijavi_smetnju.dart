import 'package:commons/models/korisnik.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class PrijaviSmetnju extends StatefulWidget {
  late Korisnik korisnik;

  PrijaviSmetnju({required this.korisnik});


  @override
  _PrijaviSmetnjuState createState() => _PrijaviSmetnjuState();
}

class _PrijaviSmetnjuState extends State<PrijaviSmetnju> {
  final TextEditingController _controller = TextEditingController();
  final TextEditingController _emailController = TextEditingController();
  final List<String> _emailAddresses = [];

  @override
  Widget build(BuildContext context) {
    return Scaffold(appBar: AppBar(title: Text("Radna jedinica: ${widget.korisnik.radnaJedinica}"), backgroundColor: Color(0xFF4592AF), ), body:
     SafeArea(child: Padding(
        padding: const EdgeInsets.all(16.0),
        child: SingleChildScrollView(
          child: Column(
            //mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text("Unesite email adrese za slanje (opcionalno)"),
                 Padding(
                   padding: const EdgeInsets.all(8.0),
                   child: Row(
                                   children: [
                    Expanded(
                      child: TextFormField(
                        controller: _emailController,
                        decoration: InputDecoration(
                          labelText: 'neko.primjer@adr.email',
                          border: OutlineInputBorder(),
                        ),
                        keyboardType: TextInputType.emailAddress,
                      ),
                    ),
                    IconButton(
                      icon: Icon(Icons.add),
                      onPressed: _onIconPressed,
                    ),
                                   ],
                                 ),
                 ),
              TextField(
                controller: _controller,
                maxLines: 10,
                decoration: InputDecoration(
                  hintText: 'Unesite opis smetnje',
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.all(Radius.circular(10.0)),
                  ),
                ),
              ),
              SizedBox(height: 20),
              ElevatedButton(
                onPressed: () {
                  String text = _controller.text;
                  posaljiEmail(text, _emailAddresses);
                },
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.blue,
                  padding: EdgeInsets.symmetric(horizontal: 50, vertical: 15),
                  textStyle: TextStyle(fontSize: 18, color: Colors.white),
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(10.0),
                  ),
                ),
                child: Text('Potvrdi', style: TextStyle(color: Colors.white),),
              )
              ,
              Padding(
                padding: const EdgeInsets.all(20.0),
                child: Column( 
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                           Text("Email adrese za slanje", style: TextStyle(fontSize: 20),),
                ..._emailAddresses.map((email) => Padding(
                  padding: const EdgeInsets.only(bottom: 8.0),
                  child: Text(
                    email,
                    style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
                  ),
                )),
                
                            ],
                          ),
              ),
            ],
          ),
        ),
      ),
    ));
  }
  
  void _onIconPressed() {
    if (_emailController.text.isNotEmpty) {
      setState(() {
        _emailAddresses.add(_emailController.text);
        _emailController.clear();
      });
    }
  }
  
  Future<String> posaljiEmail(String text, List<String> adrese)async {

    String link = "https://10.0.2.2:7439/MailPublisher?poruka=$text";
    
    for (var adr in adrese) {
      link +="&sendTo=$adr";
    }

    var uri = Uri.parse(link);

    var response = await http.get(uri);

    print(response.body);
    print(uri);
    

    if (_isValidResponse(response)) {
      return response.body;
    } else {
      throw Exception("Response is not valid");
    }
  }

    bool _isValidResponse(http.Response response) {
    if (response.statusCode < 299) {
      return true;
    } else if (response.statusCode == 500) {
      throw Exception("Neuspjelo slanje maila");
    } else {
      throw Exception("Serverska greška.");
    }
  }
  
  
}