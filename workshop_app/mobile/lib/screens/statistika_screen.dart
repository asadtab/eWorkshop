import 'package:commons/models/statistika.dart';
import 'package:commons/providers/statistika_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/helpers/bottom_bar.dart';
import 'package:workshop_app/helpers/common_widget.dart';
import 'package:workshop_app/helpers/master_screen.dart';

class StatistikaScreen extends StatefulWidget {
  const StatistikaScreen({super.key});

  @override
  State<StatistikaScreen> createState() => _StatistikaScreenState();
}

class _StatistikaScreenState extends State<StatistikaScreen> {
  late StatistikaProvider? statistikaProvider;
  Statistika? stat = null;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    statistikaProvider = context.read<StatistikaProvider>();

    _fetchData(null);
  }

  Future<void> _fetchData(Map<String, String>? map) async {
    try {
      var statistikaResponse = await statistikaProvider!.get(null, "Statistika/Uredjaji");

      setState(() {
        stat = statistikaResponse.first;
      });
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(CommonWidget.infoSnack(e.toString()));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Statistika"),
      ),
      drawer: DrawerWidget(),
      bottomNavigationBar: MyBottomBar(),
      body: Center(
        child: Container(
          child: Column(
            children: [
              Card(
                elevation: 4,
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(16),
                ),
                child: Padding(
                  padding: const EdgeInsets.all(16),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(
                        'Uređaji',
                        style: TextStyle(
                          fontSize: 20,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      SizedBox(height: 16),
                      _buildStatItem(context, 'Ukupno uređaja', stat?.uredjajiUkupno.toString() ?? ""),
                      _buildStatItem(context, 'Aktivni uređaji', stat?.aktivniUredjaji.toString() ?? ""),
                      _buildStatItem(context, 'Servisirani uređaji', stat?.servisiraniUredjaji.toString() ?? ""),
                      _buildStatItem(context, 'Poslani uređaji', stat?.poslaniUredjaji.toString() ?? ""),
                      _buildStatItem(context, 'Spremni uređaji', stat?.spremniUredjaji.toString() ?? ""),
                      _buildStatItem(context, 'Neaktivni uređaji', stat?.neaktivniUredjaji.toString() ?? ""),
                      SizedBox(height: 16),
                      Text(
                        'Radni zadaci',
                        style: TextStyle(
                          fontSize: 20,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      SizedBox(height: 16),
                      _buildStatItem(context, 'Ukupno radnih zadataka', stat?.radniZadaciUkupno.toString() ?? ""),
                      _buildStatItem(context, 'Aktivni radni zadaci', stat?.aktivniRadniZadaci.toString() ?? ""),
                      _buildStatItem(context, 'Završeni radni zadaci', stat?.zavrseniRadniZadaci.toString() ?? ""),
                      _buildStatItem(context, 'Neaktivni radni zadaci', stat?.neaktivniRadniZadaci.toString() ?? ""),
                      _buildStatItem(context, 'Fakturisani radni zadaci', stat?.fakturisaniRadniZadaci.toString() ?? ""),
                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildStatItem(BuildContext context, String title, String value) {
    return Padding(
      padding: const EdgeInsets.only(bottom: 8),
      child: Row(
        children: [
          Expanded(
            flex: 1,
            child: Text(
              title,
              style: TextStyle(
                fontSize: 16,
                color: Theme.of(context).textTheme.bodyText1!.color,
              ),
            ),
          ),
          Expanded(
            flex: 1,
            child: Text(
              value,
              style: TextStyle(
                fontSize: 16,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
        ],
      ),
    );
  }
}
