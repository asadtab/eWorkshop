part of 'statistika_bloc.dart';

class StatistikaState extends Equatable {
  const StatistikaState();

  @override
  List<Object> get props => [];
}

class StatistikaInitial extends StatistikaState {
  late Statistika? statistika;

  StatistikaInitial({this.statistika});
}
