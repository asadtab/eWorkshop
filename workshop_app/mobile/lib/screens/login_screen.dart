import 'package:commons/widgets/notification.dart';
import 'package:flutter/material.dart';
import 'package:commons/providers/auth_provider.dart';
import 'package:provider/provider.dart';
import 'package:workshop_app/screens/home_screen.dart';

class LoginForm extends StatefulWidget {
  @override
  _LoginFormState createState() => _LoginFormState();
}

class _LoginFormState extends State<LoginForm> {
  final _formKey = GlobalKey<FormState>();

  final TextEditingController usernameController = TextEditingController();
  final TextEditingController passwordController = TextEditingController();

  late AuthProvider authProvider;

  @override
  void initState() {
    authProvider = context.read<AuthProvider>();

    usernameController.text = "asad.admin@tab.ba";
    passwordController.text = "Asad123!";

    // TODO: implement initState
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: WillPopScope(
          onWillPop: () async {
            return false;
          },
          child: Center(
              child: Form(
            key: _formKey,
            child: Card(
              child: Column(
                children: [
                  TextFormField(
                    controller: usernameController,
                    keyboardType: TextInputType.emailAddress,
                    decoration: InputDecoration(
                      labelText: 'Email',
                    ),
                    validator: (value) {
                      if (value!.isEmpty) {
                        return 'Unesite email adresu';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: passwordController,
                    obscureText: true,
                    decoration: InputDecoration(
                      labelText: 'Password',
                    ),
                    validator: (value) {
                      if (value!.isEmpty) {
                        return 'Unesite lozinku';
                      }
                      return null;
                    },
                  ),
                  SizedBox(height: 16.0),
                  ElevatedButton(
                    onPressed: () async {
                      try {
                        var token = await authProvider.login(usernameController.text, passwordController.text);
              
                        context.read<AuthProvider>().setLoggedIn(true);
              
                        setState(() {
                          authProvider.getUser(token);
                        });
              
                        if (context.read<AuthProvider>().isLoggedIn!) {
                          Navigator.pushReplacement(
                            context,
                            MaterialPageRoute(
                              builder: (context) => HomeScreen(),
                            ),
                          );
                        }
                      } catch (e) {
                        poruka("Login nije uspio " + e.toString() + " ");
                      }
                    },
                    child: Text('Login'),
                  ),
                ],
              ),
            ),
          )),
        ),
      ),
    );
  }

  void poruka(String poruka) {
    ScaffoldMessenger.of(context).showSnackBar(CustomNotification.infoSnack(poruka));
  }
}
