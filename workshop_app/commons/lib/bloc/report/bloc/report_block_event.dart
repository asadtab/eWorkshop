part of 'report_block_bloc.dart';

 class ReportBlockEvent extends Equatable {
  const ReportBlockEvent();

  @override
  List<Object> get props => [];
}

class ReportEvent extends ReportBlockEvent{
  String? status;

  ReportEvent({this.status});
}

class ReportLoadingEvent extends ReportBlockEvent{

}