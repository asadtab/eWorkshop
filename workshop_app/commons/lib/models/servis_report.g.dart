// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'servis_report.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ServisReport _$ServisReportFromJson(Map<String, dynamic> json) => ServisReport(
      radniZadatakId: (json['radniZadatakId'] as num).toInt(),
      datumPrijema: DateTime.parse(json['datumPrijema'] as String),
      datumServisiranja: DateTime.parse(json['datumServisiranja'] as String),
      brojRadnogNaloga: json['brojRadnogNaloga'] as String,
      kontoBroj: json['kontoBroj'] as String,
      evBroj: (json['evBroj'] as num).toInt(),
      tipUredjaja: json['tipUredjaja'] as String,
      koda: json['koda'] as String,
      serijskiBroj: json['serijskiBroj'] as String,
      opisKodPrijema: json['opisKodPrijema'] as String,
      opisAktivnostiServisiranja: json['opisAktivnostiServisiranja'] as String,
      servisiraoIIspitao: json['servisiraoIIspitao'] as String,
      odobrio: json['odobrio'] as String,
      nadzor: json['nadzor'] as String,
      brojServisa: (json['brojServisa'] as num).toInt(),
      zamijenjeniElementi: (json['zamijenjeniElementi'] as List<dynamic>)
          .map((e) => Komponenta.fromJson(e as Map<String, dynamic>))
          .toList(),
      preuzeo: json['preuzeo'] as String?,
      datumPreuzimanja: json['datumPreuzimanja'] == null
          ? null
          : DateTime.parse(json['datumPreuzimanja'] as String),
      uredjaj: Uredjaj.fromJson(json['uredjaj'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$ServisReportToJson(ServisReport instance) =>
    <String, dynamic>{
      'radniZadatakId': instance.radniZadatakId,
      'datumPrijema': instance.datumPrijema.toIso8601String(),
      'datumServisiranja': instance.datumServisiranja.toIso8601String(),
      'brojRadnogNaloga': instance.brojRadnogNaloga,
      'kontoBroj': instance.kontoBroj,
      'evBroj': instance.evBroj,
      'tipUredjaja': instance.tipUredjaja,
      'koda': instance.koda,
      'serijskiBroj': instance.serijskiBroj,
      'opisKodPrijema': instance.opisKodPrijema,
      'opisAktivnostiServisiranja': instance.opisAktivnostiServisiranja,
      'servisiraoIIspitao': instance.servisiraoIIspitao,
      'odobrio': instance.odobrio,
      'nadzor': instance.nadzor,
      'brojServisa': instance.brojServisa,
      'zamijenjeniElementi':
          instance.zamijenjeniElementi.map((e) => e.toJson()).toList(),
      'preuzeo': instance.preuzeo,
      'datumPreuzimanja': instance.datumPreuzimanja?.toIso8601String(),
      'uredjaj': instance.uredjaj.toJson(),
    };
