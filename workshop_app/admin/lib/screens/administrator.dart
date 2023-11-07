import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';

class AdministratorScreen extends StatefulWidget {
  const AdministratorScreen({super.key});

  @override
  State<AdministratorScreen> createState() => _AdministratorScreenState();
}

class _AdministratorScreenState extends State<AdministratorScreen> {
  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      body: Center(
        child: Text("Administrator"),
      ),
    );
  }
}
