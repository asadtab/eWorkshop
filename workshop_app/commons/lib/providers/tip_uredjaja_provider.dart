import 'package:commons/models/tip_uredjaja.dart';

import 'base_provider.dart';

class TipUredjajaProvider extends BaseProvider<TipUredjaja> {
  TipUredjajaProvider() : super("TipUredjaja") {}

  @override
  TipUredjaja fromJson(data) {
    return TipUredjaja.fromJson(data);
  }
}
