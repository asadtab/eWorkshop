import 'dart:async';
import 'package:bloc/bloc.dart';
import 'package:commons/providers/auth_provider.dart';
import 'package:equatable/equatable.dart';

part 'login_event.dart';
part 'login_state.dart';

class LoginBloc extends Bloc<LoginEvent, LoginState> {
  final AuthProvider authProvider;

  LoginBloc({required this.authProvider}) : super(LoginInitial()) {
    on<LoginButtonPressed>(loginButtonPressed);
  }

  @override
  LoginState get initialState => LoginInitial();

  @override
  Stream<LoginState> mapEventToState(LoginEvent event) async* {
    if (event is LoginButtonPressed) {
      yield LoginLoading();

      try {
        // Replace this with your actual authentication logic
        await Future.delayed(Duration(seconds: 2));

        yield LoginSuccess();
      } catch (error) {
        yield LoginFailure(error: 'Login failed');
      }
    }
  }

  FutureOr<void> loginButtonPressed(LoginButtonPressed event, Emitter<LoginState> emit) async {
    var login = await authProvider.login(event.username, event.password);
  }
}
