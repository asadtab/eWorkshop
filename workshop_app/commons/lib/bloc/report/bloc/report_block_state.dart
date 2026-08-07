part of 'report_block_bloc.dart';

 class ReportBlockState extends Equatable {
  const ReportBlockState();
  
  @override
  List<Object> get props => [];
}

 class ReportBlockInitial extends ReportBlockState {}

 class ReportLoadedState extends ReportBlockState{
    final List<ServisReport> data;

    ReportLoadedState(this.data);
 }

 class ReportLoadingState extends  ReportBlockState{}
