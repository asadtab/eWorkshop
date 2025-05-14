import 'package:admin/bloc/login/bloc/login_bloc.dart';
import 'package:admin/main.dart';
import 'package:commons/models/uredjaj.dart';
import 'package:commons/providers/auth_provider.dart';
import 'package:commons/widgets/button.dart';
import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:commons/providers/ids_provider.dart';

class LoginScreen extends StatefulWidget {
  const LoginScreen({super.key});

  @override
  State<LoginScreen> createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final TextEditingController usernameController = TextEditingController();
  final TextEditingController passwordController = TextEditingController();
  final _formKey = GlobalKey<FormState>();

  String? ime;
  AuthProvider? authProvider;
  late IdsProvider idsProvider;
  late Future<List<Uredjaj>> uredjajiList;

  @override
  initState() {
    authProvider = context.read<AuthProvider>();

    idsProvider = context.read<IdsProvider>();

    super.initState();
  }


  Uredjaj fromJson(data) {
    throw Exception("Override method");
  }

  void poruka(String poruka) {
    ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack(poruka));
  }

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<LoginBloc, LoginState>(
      listener: (context, state) {
        if (state is LoginSuccess) {
        } else if (state is LoginFailure) {
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content: Text(state.error),
              backgroundColor: Colors.red,
            ),
          );
        }
      },
      builder: (context, state) {
        return Form(
          key: _formKey,
          child: Center(
            child: Card(
              child: Container(
                width: 500,
                height: 500,
                child: Padding(
                  padding: EdgeInsets.all(20.0),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    crossAxisAlignment: CrossAxisAlignment.stretch,
                    children: [
                      SizedBox(height: 20.0),
                      TextFormField(
                        validator: (value) {
                          if (value == null || value.trim().isEmpty) {
              return 'Unesite korisničko ime';
            }
            return null;
                        },
                        controller: usernameController,
                        decoration: InputDecoration(
                          labelText: 'Korisničko ime',
                          border: OutlineInputBorder(),
                        ),
                      ),
                      SizedBox(height: 10.0),
                      TextFormField(
                        validator: (value) {
                          if (value == null || value.trim().isEmpty) {
              return 'Unesite lozinku';
            }
            return null;
                        },
                        controller: passwordController,
                        obscureText: true,
                        decoration: InputDecoration(
                         
                          labelText: 'Lozinka',
                          border: OutlineInputBorder(),
                        ),
                      ),
                      SizedBox(height: 20.0),
                      MinimalisticButton(
                        icons: Icon(
                          Icons.login,
                          color: Colors.black,
                        ),
                        text: "Login",
                        onPressed: () async {
                          try {
          
                            if (!_formKey.currentState!.validate()) {
            return;
          }
        
          
                            var token = await authProvider!.login(usernameController.text, passwordController.text);
          
                            context.read<AuthProvider>().setLoggedIn(true);
          
                            setState(() {
                              authProvider!.getUser(token);
                            });
          
                            if (context.read<AuthProvider>().isLoggedIn!) {
                              Navigator.pushReplacement(
                                context,
                                MaterialPageRoute(
                                  builder: (context) => MyHomePage(title: "Informacioni sistem za podršku rada servisne radionice"),
                                ),
                              );
                            }
                          } catch (e) {
                            poruka("Lozinka ili korisničko ime su pogrešni.");
                          }
                        },
                      ),
                      if (state is LoginLoading) CircularProgressIndicator(),
                    ],
                  ),
                ),
              ),
            ),
          ),
        );
      },
    );
  }
}
