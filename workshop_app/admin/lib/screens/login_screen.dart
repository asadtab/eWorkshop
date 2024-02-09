import 'package:admin/bloc/login/bloc/login_bloc.dart';
import 'package:admin/commons/app_bar.dart';
import 'package:admin/screens/login.dart';
import 'package:commons/providers/auth_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class LoginMainScreen extends StatefulWidget {
  const LoginMainScreen({super.key});

  @override
  State<LoginMainScreen> createState() => _LoginMainScreenState();
}

class _LoginMainScreenState extends State<LoginMainScreen> {
  late AuthProvider authProvider;

  @override
  void initState() {
    authProvider = context.read<AuthProvider>();

    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: BarrApp(naslov: "Login"),
      body: BlocProvider(
        create: (context) => LoginBloc(authProvider: authProvider),
        child: LoginScreen(),
      ),
    );
  }
}
