import 'package:admin/commons/app_bar.dart';
import 'package:commons/widgets/button.dart';
import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

class ServisirajScreen extends StatefulWidget {
  @override
  _ServisirajScreenState createState() => _ServisirajScreenState();
}

class _ServisirajScreenState extends State<ServisirajScreen> {
  String evidencijskiBroj = '123';
  String tip = 'Desktop';
  String koda = 'ABC123';
  String serijskiBroj = '456';
  String status = 'Active';
  String lokacija = 'Office';

  List<String> komponente = ['Komponenta A', 'Komponenta B', 'Komponenta C'];
  String selectedKomponenta = 'Komponenta A';

  TextEditingController nazivController = TextEditingController();
  TextEditingController kodaController = TextEditingController();
  TextEditingController vrijednostController = TextEditingController();
  TextEditingController opisController = TextEditingController();

  @override
  initState() {
    opisController.text =
        "Zamjenjeno je kućište uređaja i očišćeni su kontakti releja. Kućišta osigurača, osigurači i signalne sijalice su pregledani i izvršena je izmjena istih ako su oštećeni (vidi zamijenjene elemente). Natpisne letvice releja su zamjenjene novim. Konektori uređaja su pregledani, očišćeni i izvršen je test uklapanja konektora u odgovarajućem mjestu u ramu. Namotaji releja su ispitani dovođenjem istosmjernog napona preko zaštitnog otpornika ili direktno na pojedine namotaje u zavisnosti od tipa ispitanog releja. Ostale komponente uređaja su ispitane i izvršena je izmjena istih u slučaju neispravnog rada.";

    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: BarrApp(
        naslov: 'Servisiraj',
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text('Info o uređaju', style: TextStyle(fontSize: 20)),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Expanded(
                    child: Card(
                      elevation: 5,
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(15.0),
                      ),
                      child: Padding(
                        padding: const EdgeInsets.all(16.0),
                        child: Row(
                          crossAxisAlignment: CrossAxisAlignment.center,
                          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                          children: [
                            _buildInfoCard('Evidencijski broj', evidencijskiBroj),
                            _buildInfoCard('Tip', tip),
                            _buildInfoCard('Koda', koda),
                            _buildInfoCard('Serijski broj', serijskiBroj),
                            _buildInfoCard('Status', status),
                            _buildInfoCard('Lokacija', lokacija),
                          ],
                        ),
                      ),
                    ),
                  ),
                  SizedBox(width: 30),
                ],
              ),
              SizedBox(height: 20),
              Text('Dodaj komponentu', style: TextStyle(fontSize: 20)),
              Card(
                child: Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Container(width: 500, child: _buildTextField('Opis aktivnosti servisa', opisController, true)),
                      SizedBox(height: 10),
                      Column(
                        children: [
                          SizedBox(height: 10),
                          Container(
                            width: 300,
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                              children: [
                                _buildTextField('Naziv', nazivController, false),
                                _buildTextField('Koda', kodaController, false),
                                _buildTextField('Vrijednost/Količina', vrijednostController, false),
                                Container(width: 300, child: MinimalisticButton(onPressed: () {}, text: "Sačuvaj"))
                              ],
                            ),
                          ),
                        ],
                      ),
                      SizedBox(width: 10),
                      Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          _buildDropdownButton(),
                          SizedBox(height: 10),
                          ElevatedButton(
                            onPressed: () {
                              // Handle adding component logic
                            },
                            child: Text('Dodaj komponentu'),
                          ),
                        ],
                      ),
                    ],
                  ),
                ),
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  Card(
                    child: Column(
                      children: [
                        Text('Lista zamijenjenih komponenti', style: TextStyle(fontSize: 20)),
                        SizedBox(height: 10),
                        _buildDataTable(),
                      ],
                    ),
                  ),
                  MinimalisticButton(text: "Servisiraj", onPressed: () {})
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildInfoCard(String title, String value) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Text(
          title,
          style: TextStyle(
            fontSize: 14,
            fontWeight: FontWeight.bold,
            color: Colors.grey,
          ),
        ),
        SizedBox(height: 5),
        Text(
          value,
          style: TextStyle(
            fontSize: 16,
            fontWeight: FontWeight.normal,
          ),
        ),
      ],
    );
  }

  Widget _buildTextField(String placeholder, TextEditingController controller, bool rich) {
    return Container(
      margin: EdgeInsets.only(bottom: 10),
      child: TextField(
        maxLines: rich ? 10 : 1,
        textAlign: TextAlign.justify,
        controller: controller,
        decoration: InputDecoration(
          labelText: placeholder,
          border: OutlineInputBorder(),
        ),
      ),
    );
  }

  Widget _buildDropdownButton() {
    return DropdownButton<String>(
      value: selectedKomponenta,
      onChanged: (String? value) {
        setState(() {
          selectedKomponenta = value!;
        });
      },
      items: komponente.map<DropdownMenuItem<String>>((String value) {
        return DropdownMenuItem<String>(
          value: value,
          child: Text(value),
        );
      }).toList(),
      hint: Text('Prijedlog komponente'),
    );
  }

  Widget _buildDataTable() {
    // Replace with your actual data and logic for DataTable
    return DataTable(
      columns: [
        DataColumn(label: Text('#')),
        DataColumn(label: Text('Naziv')),
        DataColumn(label: Text('Vrijednost')),
        DataColumn(label: Text('Koda')),
        DataColumn(label: Text('ID')),
      ],
      rows: [
        DataRow(cells: [
          DataCell(Text('1')),
          DataCell(Text('Komponenta A')),
          DataCell(Text('Value A')),
          DataCell(Text('Koda A')),
          DataCell(Text('ID A')),
        ]),
        DataRow(cells: [
          DataCell(Text('1')),
          DataCell(Text('Komponenta A')),
          DataCell(Text('Value A')),
          DataCell(Text('Koda A')),
          DataCell(Text('ID A')),
        ]),
        DataRow(cells: [
          DataCell(Text('1')),
          DataCell(Text('Komponenta A')),
          DataCell(Text('Value A')),
          DataCell(Text('Koda A')),
          DataCell(Text('ID A')),
        ]),

        // Add more rows as needed
      ],
    );
  }
}
