select ulbroj, detalj from [step].dbo.ul
union
select EvBroj, [eWorkshop].dbo.Lokacija.LokacijaID, [eWorkshop].dbo.Lokacija.Naziv
from [eWorkshop].dbo.Uredjaj
inner join [eWorkshop].dbo.Lokacija on [eWorkshop].dbo.Lokacija.LokacijaID=[eWorkshop].dbo.Uredjaj.LokacijaID

select [step].dbo.ul.tip, ulbroj from [step].dbo.ul
inner join dbo.tip on dbo.tip.tip=dbo.ul.tip

insert into [eWorkshop].dbo.TipUredjaja(Naziv)
select tip
from [step].dbo.tip



alter table [eWorkshop].dbo.TipUredjaja
alter column Opis NVARCHAR(MAX) NULL;





insert into [eWorkshop].dbo.Lokacija(Naziv)
select distinct detalj 
from [step].dbo.ul

use eWorkshop

insert into [eWorkshop].dbo.Uredjaj(TipID, Koda, SerijskiBroj, GodinaIzvedbe,Kuciste,EvBroj)
select [eWorkshop].dbo.TipUredjaja.TipUredjajaID, [eWorkshop].dbo.TipUredjaja.Naziv,koda,serbr,izdanje,kuciste,ulbroj from [step].dbo.ul
inner join [eWorkshop].dbo.TipUredjaja on [eWorkshop].dbo.TipUredjaja.Naziv=[step].dbo.ul.tip
group by[eWorkshop].dbo.TipUredjaja.TipUredjajaID, [eWorkshop].dbo.TipUredjaja.Naziv,koda,serbr,izdanje,kuciste,ulbroj


--popunjavanje tabele uredjaji iz tabele ul stare 
WITH T AS (
    SELECT
        TipUredjajaID,
        Naziv,
        ROW_NUMBER() OVER (PARTITION BY Naziv ORDER BY TipUredjajaID) AS rn
    FROM eWorkshop.dbo.TipUredjaja
)
INSERT INTO eWorkshop.dbo.Uredjaj(TipID, Koda, SerijskiBroj, GodinaIzvedbe, Kuciste, EvBroj) 
SELECT
    t.TipUredjajaID,
    
    u.koda,
    u.serbr,
    u.izdanje,
    u.kuciste,
    u.ulbroj
FROM step.dbo.ul u
INNER JOIN T t
    ON t.Naziv = u.tip
   AND t.rn = 1;


--popunjavanje tabele LokacijaID iz tabele ul kolona detalj
WITH L AS (
    SELECT
        LokacijaID,
        Naziv,
        ROW_NUMBER() OVER (PARTITION BY Naziv ORDER BY LokacijaID) AS rn
    FROM eWorkshop.dbo.Lokacija
)
UPDATE u2
SET u2.LokacijaID = l.LokacijaID
FROM eWorkshop.dbo.Uredjaj u2
INNER JOIN step.dbo.ul u
    ON u.ulbroj = u2.EvBroj
INNER JOIN L l
    ON l.Naziv = u.detalj
   AND l.rn = 1;
GO

UPDATE eWorkshop.dbo.Uredjaj
SET Status = 'Active'
WHERE Status IS NULL;

UPDATE eWorkshop.dbo.Uredjaj
SET IsDeleted = 0
WHERE IsDeleted IS NULL;
GO


select ulbroj, datum, prijem, [eWorkshop].dbo.Uredjaj.UredjajID
from [step].dbo.ul
inner join [eWorkshop].dbo.Uredjaj on [eWorkshop].dbo.Uredjaj.EvBroj=[step].dbo.ul.ulbroj




INSERT INTO eWorkshop.dbo.Korisnici
(
    Ime,
    Prezime,
    UserName,
    NormalizedUserName,
    EmailConfirmed,
    PasswordHash,
    PhoneNumberConfirmed,
    TwoFactorEnabled,
    LockoutEnabled,
    AccessFailedCount
)
SELECT DISTINCT
    LEFT(primio, CHARINDEX(' ', primio + ' ') - 1) AS Ime,
    LTRIM(SUBSTRING(primio, CHARINDEX(' ', primio + ' ') + 1, 255)) AS Prezime,
    LOWER(
        LEFT(primio, CHARINDEX(' ', primio + ' ') - 1) + '.' +
        LTRIM(SUBSTRING(primio, CHARINDEX(' ', primio + ' ') + 1, 255))
    ) AS UserName,
    UPPER(
        LEFT(primio, CHARINDEX(' ', primio + ' ') - 1) + '.' +
        LTRIM(SUBSTRING(primio, CHARINDEX(' ', primio + ' ') + 1, 255))
    ) AS NormalizedUserName,
    1 AS EmailConfirmed,
    'AQAAAAEAACcQAAAAEJ2mdYc7NC/yjsPjQiQkIJBvoi5pQ60yqb6862DB17sMwxAqyLoMAjZfu7LMvbbOXQ==' AS PasswordHash,
    
    0 AS PhoneNumberConfirmed,
    0 AS TwoFactorEnabled,
    0 AS LockoutEnabled,
    0 AS AccessFailedCount
FROM step.dbo.ul
WHERE primio IS NOT NULL;

--Popunjavanje tabele Prijem
WITH K AS (
    SELECT
        Id AS KorisnikID,
        UserName,
        ROW_NUMBER() OVER (PARTITION BY UserName ORDER BY Id) AS rn
    FROM eWorkshop.dbo.Korisnici
)
INSERT INTO eWorkshop.dbo.Prijem
(
    UredjajID,
    KorisnikID,
    OpisStanja,
    Datum
)
SELECT
    u2.UredjajID,
    k.KorisnikID,
	
    u.prijem AS OpisStanja,
    u.datum AS Datum
FROM step.dbo.ul u
INNER JOIN eWorkshop.dbo.Uredjaj u2
    ON u2.EvBroj = u.ulbroj
INNER JOIN K k
    ON k.UserName = LOWER(
        LEFT(u.primio, CHARINDEX(' ', u.primio + ' ') - 1) + '.' +
        LTRIM(SUBSTRING(u.primio, CHARINDEX(' ', u.primio + ' ') + 1, 255))
    )
   AND k.rn = 1
WHERE u.primio IS NOT NULL
  AND u.detalj IS NOT NULL;
GO

WITH K AS (
    SELECT
        Id AS KorisnikID,
        UserName,
        ROW_NUMBER() OVER (PARTITION BY UserName ORDER BY Id) AS rn
    FROM eWorkshop.dbo.Korisnici
)
SELECT
    u.vrbroj AS VrBroj,
    u.tip,
    u.koda,
    u.serbr,
    u.datum,
    u.izdanje,
    u.detalj,
    u.lokacija,
    u.prijem AS Prijem,
    u.opis,
    u.primio AS Primio,
    u.serviser,
    u.datpoc,
    u.primio AS PunoImePrimio,
    LOWER(
        LEFT(u.primio, CHARINDEX(' ', u.primio + ' ') - 1) + '.' +
        LTRIM(SUBSTRING(u.primio, CHARINDEX(' ', u.primio + ' ') + 1, 255))
    ) AS UsernamePrimio
FROM step.dbo.ser as u
GO

WITH T AS (
    SELECT
        TipUredjajaID,
        Naziv,
        ROW_NUMBER() OVER (PARTITION BY Naziv ORDER BY TipUredjajaID) AS rn
    FROM eWorkshop.dbo.TipUredjaja
)
INSERT INTO eWorkshop.dbo.Uredjaj
(
    EvBroj,
    TipID,
    Koda,
    SerijskiBroj,
    GodinaIzvedbe,
    Kuciste
)
SELECT
    u.evbroj,
    t.TipUredjajaID,
    u.koda,
    u.serbr,
    u.izdanje,
    u.kuciste
FROM step.dbo.ser u
INNER JOIN T t
    ON t.Naziv = u.tip
   AND t.rn = 1
WHERE u.evbroj IS NOT NULL;

UPDATE eWorkshop.dbo.Uredjaj
SET Status = 'fix'
WHERE Status IS NULL;

select * from eWorkshop.dbo.Uredjaj

WITH L AS (
    SELECT
        LokacijaID,
        Naziv,
        ROW_NUMBER() OVER (PARTITION BY Naziv ORDER BY LokacijaID) AS rn
    FROM eWorkshop.dbo.Lokacija
)
SELECT
    u.EvBroj,
    s.detalj,
    l.LokacijaID,
    l.Naziv AS Lokacija
FROM eWorkshop.dbo.Uredjaj u
INNER JOIN step.dbo.ser s
    ON s.evbroj = u.EvBroj
INNER JOIN L l
    ON l.Naziv = s.detalj
   AND l.rn = 1;
GO

WITH L AS (
    SELECT
        LokacijaID,
        Naziv,
        ROW_NUMBER() OVER (PARTITION BY Naziv ORDER BY LokacijaID) AS rn
    FROM eWorkshop.dbo.Lokacija
)
UPDATE u
SET u.LokacijaID = l.LokacijaID
FROM eWorkshop.dbo.Uredjaj u
INNER JOIN step.dbo.ser s
    ON s.evbroj = u.EvBroj
INNER JOIN L l
    ON l.Naziv = s.detalj
   AND l.rn = 1;
GO

BACKUP DATABASE eWorkshop
TO DISK = '/var/opt/mssql/backup/eWorkshop_full.bak'
WITH INIT, COMPRESSION, STATS = 10;
GO

alter table [eWorkshop].dbo.Prijem
alter column KorisnikId int NULL;

alter table [eWorkshop].dbo.Prijem
alter column UredjajId int NULL;

alter table [eWorkshop].dbo.Servi
alter column UredjajId int NULL;

alter table [eWorkshop].dbo.Servi
alter column KorisnikID int NULL;

insert into eWorkshop.dbo.RadniZadatak(Naziv, StateMachine)
select distinct detalj, 'active'
from step.dbo.ser

WITH K AS (
    SELECT
        Id AS KorisnikID,
        UserName,
        ROW_NUMBER() OVER (PARTITION BY UserName ORDER BY Id) AS rn
    FROM eWorkshop.dbo.Korisnici
)
INSERT INTO eWorkshop.dbo.Prijem
(
    OpisStanja,
    Datum,
    UredjajID,
    KorisnikID
)
SELECT
    ISNULL(u.prijem, '') AS OpisStanja,
    ISNULL(u.datum, GETDATE()) AS Datum,
    u2.UredjajID,
    k.KorisnikID
FROM step.dbo.ser u
LEFT JOIN eWorkshop.dbo.Uredjaj u2
    ON u2.EvBroj = u.evbroj
LEFT JOIN K k
    ON k.UserName = LOWER(
        LEFT(u.primio, CHARINDEX(' ', u.primio + ' ') - 1) + '.' +
        LTRIM(SUBSTRING(u.primio, CHARINDEX(' ', u.primio + ' ') + 1, 255))
    )
   AND k.rn = 1;


WITH N AS (
    SELECT TOP (1000)
        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS n
    FROM sys.all_objects a
    CROSS JOIN sys.all_objects b
)
SELECT
    s.evbroj,
    s.datum,
    s.detalj,
    rz.RadniZadatakID,
    s.opis,
    s.serviser,
    s.vrbroj,
    x.n AS RedniBrojServisa
FROM step.dbo.ser s
LEFT JOIN eWorkshop.dbo.RadniZadatak rz
    ON rz.Naziv = s.detalj
CROSS APPLY (
    SELECT TOP (ISNULL(s.vrbroj, 0)) n
    FROM N
    ORDER BY n
) x
ORDER BY s.evbroj, x.n;
GO
GO

SELECT
    s.evbroj,
    s.datum,
    s.detalj,
    rz.RadniZadatakID,
    s.opis,
    s.serviser,
    s.vrbroj
FROM step.dbo.ser s
LEFT JOIN eWorkshop.dbo.RadniZadatak rz
    ON rz.Naziv = s.detalj
ORDER BY s.evbroj;
GO


WITH N AS (
    SELECT TOP (1000)
        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS n
    FROM sys.all_objects a
    CROSS JOIN sys.all_objects b
)

SELECT
    s.evbroj,
    s.datum,
    s.detalj,
    rz.RadniZadatakID,
    s.opis,
    s.serviser,
    s.vrbroj,
    x.n AS KopijaBroj
FROM step.dbo.ser s
LEFT JOIN eWorkshop.dbo.RadniZadatak rz
    ON rz.Naziv = s.detalj
CROSS APPLY (
    SELECT TOP (ISNULL(s.vrbroj, 0) + 1) n
    FROM N
    ORDER BY n
) x
ORDER BY s.evbroj, x.n;
GO

WITH N AS (
    SELECT TOP (1000)
        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS n
    FROM sys.all_objects a
    CROSS JOIN sys.all_objects b
),
K AS (
    SELECT
        Id,
        Ime,
        Prezime,
        ROW_NUMBER() OVER (
            PARTITION BY Ime, Prezime
            ORDER BY Id
        ) AS rn
    FROM eWorkshop.dbo.Korisnici
),
RZ AS (
    SELECT
        RadniZadatakID,
        Naziv,
        ROW_NUMBER() OVER (
            PARTITION BY Naziv
            ORDER BY RadniZadatakID
        ) AS rn
    FROM eWorkshop.dbo.RadniZadatak
)
SELECT
    k.Id,
    u.UredjajID,
    rz.RadniZadatakID,
    s.datum AS Datum,
    s.opis AS OpisServisa
FROM step.dbo.ser s
LEFT JOIN eWorkshop.dbo.Uredjaj u
    ON u.EvBroj = s.evbroj
LEFT JOIN RZ rz
    ON rz.Naziv = s.detalj
   AND rz.rn = 1
LEFT JOIN K k
    ON k.Ime + ' ' + k.Prezime = s.serviser
   AND k.rn = 1
CROSS APPLY (
    SELECT TOP (ISNULL(s.vrbroj, 0) + 1) n
    FROM N
    ORDER BY n
) x
ORDER BY s.evbroj, x.n;
GO

WITH N AS (
    SELECT TOP (1000)
        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS n
    FROM sys.all_objects a
    CROSS JOIN sys.all_objects b
),
K AS (
    SELECT
        Id,
        Ime,
        Prezime,
        ROW_NUMBER() OVER (
            PARTITION BY Ime, Prezime
            ORDER BY Id
        ) AS rn
    FROM eWorkshop.dbo.Korisnici
),
RZ AS (
    SELECT
        RadniZadatakID,
        Naziv,
        ROW_NUMBER() OVER (
            PARTITION BY Naziv
            ORDER BY RadniZadatakID
        ) AS rn
    FROM eWorkshop.dbo.RadniZadatak
)
INSERT INTO eWorkshop.dbo.Servi
(
    KorisnikID,
    UredjajID,
    RadniZadatakID,
    Datum,
    OpisServisa
)
SELECT
    k.Id AS KorisnikID,
    u.UredjajID,
    rz.RadniZadatakID,
    s.datum AS Datum,
    s.opis AS OpisServisa
FROM step.dbo.ser s
LEFT JOIN eWorkshop.dbo.Uredjaj u
    ON u.EvBroj = s.evbroj
LEFT JOIN RZ rz
    ON rz.Naziv = s.detalj
   AND rz.rn = 1
LEFT JOIN K k
    ON k.Ime + ' ' + k.Prezime = s.serviser
   AND k.rn = 1
CROSS APPLY (
    SELECT TOP (ISNULL(s.vrbroj, 0) + 1) n
    FROM N
    ORDER BY n
) x
ORDER BY s.evbroj, x.n;
GO

SELECT
    r.element AS Naziv,
    r.koda AS Vrijednost,
    r.vracena AS Opis,
    NULL AS Tip
FROM step.dbo.rep r;
GO

SELECT
    r.repId,
    r.element AS Naziv,
    CASE
        WHEN r.koda LIKE '%kom%' THEN
            TRY_CAST(LEFT(r.koda, PATINDEX('%[^0-9]%', r.koda + 'X') - 1) AS int)
        ELSE NULL
    END AS Kolicina,
    CASE
        WHEN r.koda LIKE '%kom%' THEN NULL
        WHEN r.koda LIKE '%uF%' OR r.koda LIKE '%V%' OR r.koda LIKE '%W%' OR r.koda LIKE '%kO%' OR r.koda LIKE '%Ω%'
            OR r.koda LIKE '%mA%' OR r.koda LIKE '%A%'
        THEN r.koda
        WHEN CHARINDEX(',', r.koda) > 0
        THEN LTRIM(RTRIM(LEFT(r.koda, CHARINDEX(',', r.koda) - 1)))
        ELSE NULL
    END AS Vrijednost,
    CASE
        WHEN r.koda LIKE '%kom%' THEN NULL
        WHEN r.koda LIKE '%uF%' OR r.koda LIKE '%V%' OR r.koda LIKE '%W%' OR r.koda LIKE '%kO%' OR r.koda LIKE '%Ω%'
            OR r.koda LIKE '%mA%' OR r.koda LIKE '%A%'
        THEN NULL
        WHEN CHARINDEX(',', r.koda) > 0
        THEN LTRIM(RTRIM(SUBSTRING(r.koda, CHARINDEX(',', r.koda) + 1, 255)))
        ELSE r.koda
    END AS Tip,
    r.vracena
FROM step.dbo.rep r;
GO

SELECT
    r.repId,
    r.element AS Naziv,
    CASE
        WHEN r.koda IS NULL OR LTRIM(RTRIM(r.koda)) = '' THEN NULL

        WHEN r.koda LIKE '%kom%' THEN NULL

        WHEN PATINDEX('%[0-9]V%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]O%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]µF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]UF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9].[0-9]W%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9],[0-9]W%', UPPER(r.koda)) > 0
        THEN LTRIM(RTRIM(
            CASE
                WHEN CHARINDEX(',', r.koda) > 0
                THEN LEFT(r.koda, CHARINDEX(',', r.koda) - 1)
                ELSE r.koda
            END
        ))

        ELSE NULL
    END AS Vrijednost,
    CASE
        WHEN r.koda IS NULL OR LTRIM(RTRIM(r.koda)) = '' THEN NULL
        WHEN r.koda LIKE '%kom%' THEN NULL

        WHEN PATINDEX('%[0-9]V%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]O%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]µF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]UF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9].[0-9]W%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9],[0-9]W%', UPPER(r.koda)) > 0
        THEN NULL

        ELSE LTRIM(RTRIM(r.koda))
    END AS Tip,
    r.vracena
FROM step.dbo.rep r;
GO

INSERT INTO eWorkshop.dbo.Komponente
(
    Naziv,
    Vrijednost,
    Tip,
    Opis
)
SELECT
    r.element AS Naziv,
    CASE
        WHEN r.koda IS NULL OR LTRIM(RTRIM(r.koda)) = '' THEN NULL
        WHEN r.koda LIKE '%kom%' THEN NULL

        WHEN PATINDEX('%[0-9]V%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]O%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]µF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]UF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9].[0-9]W%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9],[0-9]W%', UPPER(r.koda)) > 0
        THEN LTRIM(RTRIM(
            CASE
                WHEN CHARINDEX(',', r.koda) > 0
                THEN LEFT(r.koda, CHARINDEX(',', r.koda) - 1)
                ELSE r.koda
            END
        ))
        ELSE NULL
    END AS Vrijednost,
    CASE
        WHEN r.koda IS NULL OR LTRIM(RTRIM(r.koda)) = '' THEN NULL
        WHEN r.koda LIKE '%kom%' THEN NULL

        WHEN PATINDEX('%[0-9]V%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]O%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]µF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]UF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9].[0-9]W%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9],[0-9]W%', UPPER(r.koda)) > 0
        THEN NULL
        ELSE LTRIM(RTRIM(r.koda))
    END AS Tip,
    r.vracena AS Opis
FROM step.dbo.rep r;
GO



SELECT DISTINCT
    r.element AS Naziv,
    CASE
        WHEN r.koda IS NULL OR LTRIM(RTRIM(r.koda)) = '' THEN NULL
        WHEN r.koda LIKE '%kom%' THEN NULL
        WHEN PATINDEX('%[0-9]V%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]O%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]µF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]UF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9].[0-9]W%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9],[0-9]W%', UPPER(r.koda)) > 0
        THEN LTRIM(RTRIM(
            CASE
                WHEN CHARINDEX(',', r.koda) > 0
                THEN LEFT(r.koda, CHARINDEX(',', r.koda) - 1)
                ELSE r.koda
            END
        ))
        ELSE NULL
    END AS Vrijednost,
    CASE
        WHEN r.koda IS NULL OR LTRIM(RTRIM(r.koda)) = '' THEN NULL
        WHEN r.koda LIKE '%kom%' THEN NULL
        WHEN PATINDEX('%[0-9]V%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]O%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]µF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]UF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9].[0-9]W%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9],[0-9]W%', UPPER(r.koda)) > 0
        THEN NULL
        ELSE LTRIM(RTRIM(r.koda))
    END AS Tip,
    r.vracena AS Opis
FROM step.dbo.rep r
WHERE r.element IS NOT NULL
  AND LTRIM(RTRIM(r.element)) <> ''
ORDER BY r.element, Vrijednost, Tip;
GO

INSERT INTO eWorkshop.dbo.Komponente
(
    Naziv,
    Vrijednost,
    Tip,
    Opis
)
SELECT DISTINCT
    r.element AS Naziv,
    CASE
        WHEN r.koda IS NULL OR LTRIM(RTRIM(r.koda)) = '' THEN NULL
        WHEN r.koda LIKE '%kom%' THEN NULL
        WHEN PATINDEX('%[0-9]V%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]O%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]µF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]UF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9].[0-9]W%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9],[0-9]W%', UPPER(r.koda)) > 0
        THEN LTRIM(RTRIM(
            CASE
                WHEN CHARINDEX(',', r.koda) > 0
                THEN LEFT(r.koda, CHARINDEX(',', r.koda) - 1)
                ELSE r.koda
            END
        ))
        ELSE NULL
    END AS Vrijednost,
    CASE
        WHEN r.koda IS NULL OR LTRIM(RTRIM(r.koda)) = '' THEN NULL
        WHEN r.koda LIKE '%kom%' THEN NULL
        WHEN PATINDEX('%[0-9]V%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]O%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]µF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9]UF%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9].[0-9]W%', UPPER(r.koda)) > 0
          OR PATINDEX('%[0-9],[0-9]W%', UPPER(r.koda)) > 0
        THEN NULL
        ELSE LTRIM(RTRIM(r.koda))
    END AS Tip,
    r.vracena AS Opis
FROM step.dbo.rep r
WHERE r.element IS NOT NULL
  AND LTRIM(RTRIM(r.element)) <> '';
GO

WITH S1 AS (
    SELECT
        u.EvBroj,
        sv.ServisID,
        ROW_NUMBER() OVER (
            PARTITION BY u.EvBroj
            ORDER BY sv.Datum, sv.ServisID
        ) AS rn
    FROM eWorkshop.dbo.Uredjaj u
    INNER JOIN eWorkshop.dbo.Servi sv
        ON sv.UredjajID = u.UredjajID
),
C1 AS (
    SELECT
        k.KomponentaID,
        k.Naziv,
        k.Vrijednost,
        k.Tip,
        ROW_NUMBER() OVER (
            PARTITION BY k.Naziv
            ORDER BY k.KomponentaID
        ) AS rn
    FROM eWorkshop.dbo.Komponente k
)
SELECT
    r.repId,
    r.evbroj,
    s1.ServisID,
    c1.KomponentaID,
    c1.Naziv AS KomponentaNaziv,
    c1.Vrijednost AS KomponentaVrijednost,
    c1.Tip AS KomponentaTip
FROM step.dbo.rep r
INNER JOIN S1 s1
    ON s1.EvBroj = r.evbroj
   AND s1.rn = 1
INNER JOIN C1 c1
    ON c1.Naziv = r.element
   AND c1.rn = 1
ORDER BY r.repId;
GO

WITH SER1 AS (
    SELECT
        s.ServisID,
        s.UredjajID,
        u.EvBroj,
        s.Datum,
        ROW_NUMBER() OVER (
            PARTITION BY s.ServisID
            ORDER BY s.Datum DESC, s.ServisID DESC
        ) AS rn
    FROM eWorkshop.dbo.Servi s
    INNER JOIN eWorkshop.dbo.Uredjaj u
        ON u.UredjajID = s.UredjajID
),
REP1 AS (
    SELECT
        r.repId,
        r.evbroj,
        r.element,
        ROW_NUMBER() OVER (
            PARTITION BY r.evbroj, r.element
            ORDER BY r.repId
        ) AS rn
    FROM step.dbo.rep r
),
K1 AS (
    SELECT
        k.KomponentaID,
        k.Naziv,
        k.Vrijednost,
        k.Tip,
        ROW_NUMBER() OVER (
            PARTITION BY k.Naziv, ISNULL(k.Vrijednost, ''), ISNULL(k.Tip, '')
            ORDER BY k.KomponentaID
        ) AS rn
    FROM eWorkshop.dbo.Komponente k
)
SELECT
    ser1.ServisID,
    ser1.UredjajID,
    ser1.EvBroj AS UredjajEvBroj,
    rep1.repId,
    rep1.evbroj AS RepEvBroj,
    rep1.element,
    k1.KomponentaID,
    k1.Naziv AS KomponentaNaziv,
    k1.Vrijednost AS KomponentaVrijednost,
    k1.Tip AS KomponentaTip
FROM SER1 ser1
LEFT JOIN REP1 rep1
    ON rep1.evbroj = ser1.EvBroj
   AND rep1.rn = 1
LEFT JOIN K1 k1
    ON k1.Naziv = rep1.element
   AND k1.rn = 1
WHERE ser1.rn = 1
ORDER BY ser1.ServisID, rep1.repId;
GO

WITH SER1 AS (
    SELECT
        s.ServisID,
        s.UredjajID,
        u.EvBroj,
        s.Datum,
        ROW_NUMBER() OVER (
            PARTITION BY s.ServisID
            ORDER BY s.Datum DESC, s.ServisID DESC
        ) AS rn
    FROM eWorkshop.dbo.Servi s
    INNER JOIN eWorkshop.dbo.Uredjaj u
        ON u.UredjajID = s.UredjajID
),
REP1 AS (
    SELECT
        r.repId,
        r.evbroj,
        r.element,
        ROW_NUMBER() OVER (
            PARTITION BY r.evbroj, r.element
            ORDER BY r.repId
        ) AS rn
    FROM step.dbo.rep r
),
K1 AS (
    SELECT
        k.KomponentaID,
        k.Naziv,
        k.Vrijednost,
        k.Tip,
        ROW_NUMBER() OVER (
            PARTITION BY k.Naziv, ISNULL(k.Vrijednost, ''), ISNULL(k.Tip, '')
            ORDER BY k.KomponentaID
        ) AS rn
    FROM eWorkshop.dbo.Komponente k
)
INSERT INTO eWorkshop.dbo.IzvrseniServis
(
    KomponentaID,
    ServisID,
    Datum,
    KomponentaNaziv,
    KomponentaVrijednost,
    KomponentaTip
)
SELECT
    k1.KomponentaID,
    ser1.ServisID,
    ser1.Datum,
    k1.Naziv,
    k1.Vrijednost,
    k1.Tip
FROM SER1 ser1
INNER JOIN REP1 rep1
    ON rep1.evbroj = ser1.EvBroj
   AND rep1.rn = 1
INNER JOIN K1 k1
    ON k1.Naziv = rep1.element
   AND k1.rn = 1
WHERE ser1.rn = 1;
GO

WITH SER1 AS (
    SELECT
        s.ServisID,
        s.UredjajID,
        u.EvBroj,
        s.Datum,
        ROW_NUMBER() OVER (
            PARTITION BY s.ServisID
            ORDER BY s.Datum DESC, s.ServisID DESC
        ) AS rn
    FROM eWorkshop.dbo.Servi s
    INNER JOIN eWorkshop.dbo.Uredjaj u
        ON u.UredjajID = s.UredjajID
),
REP1 AS (
    SELECT
        r.repId,
        r.evbroj,
        r.element,
        ROW_NUMBER() OVER (
            PARTITION BY r.evbroj, r.element
            ORDER BY r.repId
        ) AS rn
    FROM step.dbo.rep r
),
K1 AS (
    SELECT
        k.KomponentaID,
        k.Naziv,
        k.Vrijednost,
        k.Tip,
        ROW_NUMBER() OVER (
            PARTITION BY k.Naziv, ISNULL(k.Vrijednost, ''), ISNULL(k.Tip, '')
            ORDER BY k.KomponentaID
        ) AS rn
    FROM eWorkshop.dbo.Komponente k
)
SELECT
    ser1.ServisID,
    ser1.UredjajID,
    ser1.EvBroj AS UredjajEvBroj,
    rep1.repId,
    rep1.evbroj AS RepEvBroj,
    rep1.element,
    k1.KomponentaID,
    k1.Naziv AS KomponentaNaziv,
    k1.Vrijednost AS KomponentaVrijednost,
    k1.Tip AS KomponentaTip
FROM SER1 ser1
LEFT JOIN REP1 rep1
    ON rep1.evbroj = ser1.EvBroj
   AND rep1.rn = 1
LEFT JOIN K1 k1
    ON k1.Naziv = rep1.element
   AND k1.rn = 1
WHERE ser1.rn = 1
ORDER BY ser1.ServisID, rep1.repId;
GO

WITH SER1 AS (
    SELECT
        s.ServisID,
        s.UredjajID,
        u.EvBroj,
        s.Datum,
        ROW_NUMBER() OVER (
            PARTITION BY s.ServisID
            ORDER BY s.Datum DESC, s.ServisID DESC
        ) AS rn
    FROM eWorkshop.dbo.Servi s
    INNER JOIN eWorkshop.dbo.Uredjaj u
        ON u.UredjajID = s.UredjajID
),
REP1 AS (
    SELECT
        r.repId,
        r.evbroj,
        r.element,
        ROW_NUMBER() OVER (
            PARTITION BY r.evbroj, r.element
            ORDER BY r.repId
        ) AS rn
    FROM step.dbo.rep r
),
K1 AS (
    SELECT
        k.KomponentaID,
        k.Naziv,
        k.Vrijednost,
        k.Tip,
        ROW_NUMBER() OVER (
            PARTITION BY k.Naziv, ISNULL(k.Vrijednost, ''), ISNULL(k.Tip, '')
            ORDER BY k.KomponentaID
        ) AS rn
    FROM eWorkshop.dbo.Komponente k
)
INSERT INTO eWorkshop.dbo.IzvrseniServis
(
    KomponentaID,
    ServisID,
    Datum,
    KomponentaNaziv,
    KomponentaVrijednost,
    KomponentaTip
)
SELECT
    k1.KomponentaID,
    ser1.ServisID,
    ser1.Datum,
    k1.Naziv,
    k1.Vrijednost,
    k1.Tip
FROM SER1 ser1
INNER JOIN REP1 rep1
    ON rep1.evbroj = ser1.EvBroj
   AND rep1.rn = 1
INNER JOIN K1 k1
    ON k1.Naziv = rep1.element
   AND k1.rn = 1
WHERE ser1.rn = 1;
GO

SELECT
    i.evbroj AS IzEvBroj,
    --i.evroj,
    i.tip,
    i.koda,
    i.serbr,
    i.datum,
    u.UredjajID,
    u.EvBroj AS UredjajEvBroj,
    CASE
        WHEN u.UredjajID IS NULL THEN 'NIJE MIGRIRANO'
        ELSE 'MIGRIRANO'
    END AS Status
FROM step.dbo.iz i
LEFT JOIN eWorkshop.dbo.Uredjaj u
    ON u.EvBroj = i.evbroj
ORDER BY i.evbroj;
GO

SELECT DISTINCT
    i.evbroj AS EvBroj,
    i.tip AS TipID,
    i.koda AS Koda,
    i.serbr AS SerijskiBroj,
    i.datum AS GodinaIzvedbe,
    'Active' AS Status,
    i.lokacija AS LokacijaID,
    0 AS IsDeleted,
    i.evbroj AS EvBroj2,
    i.kuciste AS Kuciste
FROM step.dbo.iz i
LEFT JOIN eWorkshop.dbo.Uredjaj u
    ON u.EvBroj = i.evbroj
WHERE u.UredjajID IS NULL
ORDER BY i.evbroj;
GO

SELECT
    i.evbroj,
    i.tip,
    i.koda,
    i.serbr,
    i.datum,
    i.lokacija AS IzLokacija,
    l.LokacijaID,
    l.Naziv AS LokacijaNaziv
FROM step.dbo.iz i
LEFT JOIN eWorkshop.dbo.Lokacija l
    ON l.Naziv = i.lokacija
ORDER BY i.evbroj;
GO

INSERT INTO eWorkshop.dbo.Uredjaj
(
    TipID,
    Koda,
    SerijskiBroj,
    GodinaIzvedbe,
    Status,
    LokacijaID,
    IsDeleted,
    EvBroj,
    Kuciste
)
SELECT DISTINCT
    i.tip,
    i.koda,
    i.serbr,
    CASE
        WHEN TRY_CONVERT(int, LEFT(CONVERT(varchar(20), i.datum, 120), 4)) IS NOT NULL
        THEN TRY_CONVERT(int, LEFT(CONVERT(varchar(20), i.datum, 120), 4))
        ELSE NULL
    END AS GodinaIzvedbe,
    'out' AS Status,
    l.LokacijaID,
    0 AS IsDeleted,
    i.evbroj,
    i.kuciste
FROM step.dbo.iz i
LEFT JOIN eWorkshop.dbo.Uredjaj u
    ON u.EvBroj = i.evbroj
LEFT JOIN eWorkshop.dbo.Lokacija l
    ON l.Naziv = i.lokacija
WHERE u.UredjajID IS NULL;
GO

BACKUP DATABASE eWorkshop
TO DISK = '/var/opt/mssql/backup/eWorkshop_full.bak'
WITH INIT, COMPRESSION, STATS = 10;
GO

WITH L1 AS (
    SELECT
        l.LokacijaID,
        l.Naziv,
        ROW_NUMBER() OVER (
            PARTITION BY l.Naziv
            ORDER BY l.LokacijaID
        ) AS rn
    FROM eWorkshop.dbo.Lokacija l
),
T1 AS (
    SELECT
        t.TipUredjajaID,
        t.Naziv,
        ROW_NUMBER() OVER (
            PARTITION BY t.Naziv
            ORDER BY t.TipUredjajaID
        ) AS rn
    FROM eWorkshop.dbo.TipUredjaja t
),
U1 AS (
    SELECT
        u.EvBroj,
        ROW_NUMBER() OVER (
            PARTITION BY u.EvBroj
            ORDER BY u.UredjajID
        ) AS rn
    FROM eWorkshop.dbo.Uredjaj u
)
SELECT
    i.evbroj,
    i.tip AS IzTip,
    t1.TipUredjajaID,
    i.koda,
    i.serbr,
    i.datum,
    l1.LokacijaID,
    i.kuciste
FROM step.dbo.iz i
LEFT JOIN U1 u1
    ON u1.EvBroj = i.evbroj
   AND u1.rn = 1
LEFT JOIN L1 l1
    ON l1.Naziv = i.lokacija
   AND l1.rn = 1
LEFT JOIN T1 t1
    ON t1.Naziv = i.tip
   AND t1.rn = 1
WHERE u1.EvBroj IS NULL
ORDER BY i.evbroj;
GO

WITH U0 AS (
    SELECT
        u.EvBroj,
        u.UredjajID,
        ROW_NUMBER() OVER (
            PARTITION BY u.EvBroj
            ORDER BY u.UredjajID
        ) AS rn
    FROM eWorkshop.dbo.Uredjaj u
),
L1 AS (
    SELECT
        l.LokacijaID,
        l.Naziv,
        ROW_NUMBER() OVER (
            PARTITION BY l.Naziv
            ORDER BY l.LokacijaID
        ) AS rn
    FROM eWorkshop.dbo.Lokacija l
),
T1 AS (
    SELECT
        t.TipUredjajaID,
        t.Naziv,
        ROW_NUMBER() OVER (
            PARTITION BY t.Naziv
            ORDER BY t.TipUredjajaID
        ) AS rn
    FROM eWorkshop.dbo.TipUredjaja t
)
SELECT
    i.evbroj,
    i.tip AS IzTip,
    t1.TipUredjajaID,
    i.koda,
    i.serbr,
    i.datum,
    l1.LokacijaID,
    i.kuciste,
    'out' AS Status
FROM step.dbo.iz i
LEFT JOIN U0 u0
    ON u0.EvBroj = i.evbroj
   AND u0.rn = 1
LEFT JOIN L1 l1
    ON l1.Naziv = i.lokacija
   AND l1.rn = 1
LEFT JOIN T1 t1
    ON t1.Naziv = i.tip
   AND t1.rn = 1
WHERE u0.EvBroj IS NULL
ORDER BY i.evbroj;
GO

WITH U0 AS (
    SELECT
        u.EvBroj,
        u.UredjajID,
        ROW_NUMBER() OVER (
            PARTITION BY u.EvBroj
            ORDER BY u.UredjajID
        ) AS rn
    FROM eWorkshop.dbo.Uredjaj u
),
L1 AS (
    SELECT
        l.LokacijaID,
        TRIM(l.Naziv) AS Naziv,
        ROW_NUMBER() OVER (
            PARTITION BY TRIM(l.Naziv)
            ORDER BY l.LokacijaID
        ) AS rn
    FROM eWorkshop.dbo.Lokacija l
),
T1 AS (
    SELECT
        t.TipUredjajaID,
        TRIM(t.Naziv) AS Naziv,
        ROW_NUMBER() OVER (
            PARTITION BY TRIM(t.Naziv)
            ORDER BY t.TipUredjajaID
        ) AS rn
    FROM eWorkshop.dbo.TipUredjaja t
)
SELECT
    i.evbroj,
    i.tip AS IzTip,
    t1.TipUredjajaID,
    i.koda,
    i.serbr,
    i.datum,
    l1.LokacijaID,
    i.kuciste,
    'out' AS Status
FROM step.dbo.iz i
LEFT JOIN U0 u0
    ON u0.EvBroj = i.evbroj
   AND u0.rn = 1
LEFT JOIN L1 l1
    ON TRIM(l1.Naziv) = TRIM(i.lokacija)
   AND l1.rn = 1
LEFT JOIN T1 t1
    ON TRIM(t1.Naziv) = TRIM(i.tip)
   AND t1.rn = 1
WHERE u0.EvBroj IS NULL
ORDER BY i.evbroj;
GO

WITH U0 AS (
    SELECT
        u.EvBroj,
        u.UredjajID,
        ROW_NUMBER() OVER (
            PARTITION BY u.EvBroj
            ORDER BY u.UredjajID
        ) AS rn
    FROM eWorkshop.dbo.Uredjaj u
),
L1 AS (
    SELECT
        l.LokacijaID,
        TRIM(l.Naziv) AS Naziv,
        ROW_NUMBER() OVER (
            PARTITION BY TRIM(l.Naziv)
            ORDER BY l.LokacijaID
        ) AS rn
    FROM eWorkshop.dbo.Lokacija l
),
T1 AS (
    SELECT
        t.TipUredjajaID,
        TRIM(t.Naziv) AS Naziv,
        ROW_NUMBER() OVER (
            PARTITION BY TRIM(t.Naziv)
            ORDER BY t.TipUredjajaID
        ) AS rn
    FROM eWorkshop.dbo.TipUredjaja t
)
INSERT INTO eWorkshop.dbo.Uredjaj
(
    TipID,
    Koda,
    SerijskiBroj,
    GodinaIzvedbe,
    Status,
    LokacijaID,
    IsDeleted,
    EvBroj,
    Kuciste
)
SELECT
    t1.TipUredjajaID,
    i.koda,
    i.serbr,
    CASE
        WHEN TRY_CONVERT(int, LEFT(CONVERT(varchar(20), i.datum, 120), 4)) IS NOT NULL
        THEN TRY_CONVERT(int, LEFT(CONVERT(varchar(20), i.datum, 120), 4))
        ELSE NULL
    END AS GodinaIzvedbe,
    'out' AS Status,
    l1.LokacijaID,
    0 AS IsDeleted,
    i.evbroj,
    i.kuciste
FROM step.dbo.iz i
LEFT JOIN U0 u0
    ON u0.EvBroj = i.evbroj
   AND u0.rn = 1
LEFT JOIN L1 l1
    ON l1.Naziv = TRIM(i.lokacija)
   AND l1.rn = 1
LEFT JOIN T1 t1
    ON t1.Naziv = TRIM(i.tip)
   AND t1.rn = 1
WHERE u0.EvBroj IS NULL;
GO



alter table [eWorkshop].dbo.Uredjaj 
alter column TipID int NULL;

SELECT
    u.UredjajID,
    u.TipID,
    u.Koda,
    u.SerijskiBroj,
    u.GodinaIzvedbe,
    u.Status,
    u.LokacijaID,
    u.IsDeleted,
    u.EvBroj,
    u.Kuciste,
    s.ServisID,
    s.Datum AS ServisDatum,
    es.IzvrseniServisID,
    es.KomponentaID,
    es.KomponentaNaziv,
    es.KomponentaVrijednost,
    es.KomponentaTip
    --es.Status AS IzvrseniStatus
FROM eWorkshop.dbo.Uredjaj u
INNER JOIN eWorkshop.dbo.Servi s
    ON s.UredjajID = u.UredjajID
LEFT JOIN eWorkshop.dbo.IzvrseniServis es
    ON es.ServisID = s.ServisID
ORDER BY u.UredjajID, s.ServisID, es.IzvrseniServisID;
GO

WITH Src AS (
    SELECT
        i.evbroj,
        i.vrbroj AS IzVrbroj,
        i.datum,
        i.opis,
        u.UredjajID,
        l.LokacijaID AS RadniZadatakID,
        ROW_NUMBER() OVER (
            PARTITION BY u.UredjajID
            ORDER BY i.vrbroj, i.datum, i.evbroj
        ) AS rn
    FROM step.dbo.iz i
    INNER JOIN eWorkshop.dbo.Uredjaj u
        ON u.EvBroj = i.evbroj
    LEFT JOIN eWorkshop.dbo.Lokacija l
        ON TRIM(l.Naziv) = TRIM(i.lokacija)
    WHERE u.Status = 'out'
)
INSERT INTO eWorkshop.dbo.Servi
(
    KorisnikID,
    UredjajID,
    RadniZadatakID,
    Datum,
    OpisServisa
)
SELECT
    3 AS KorisnikID,
    src.UredjajID,
    src.RadniZadatakID,
    
    src.datum,
    src.opis
FROM Src src;
GO

SELECT DISTINCT
    i.lokacija,
    rz.RadniZadatakID,
    rz.Naziv
FROM step.dbo.iz i
LEFT JOIN eWorkshop.dbo.RadniZadatak rz
    ON TRIM(rz.Naziv) = TRIM(i.lokacija)
ORDER BY i.lokacija;
GO

WITH R1 AS (
    SELECT
        r.*,
        ROW_NUMBER() OVER (
            PARTITION BY r.evbroj, r.element
            ORDER BY r.evbroj
        ) AS rn
    FROM step.dbo.rep r
),
K1 AS (
    SELECT
        k.KomponentaID,
        TRIM(k.Naziv) AS Naziv,
        k.Vrijednost,
        k.Tip,
        ROW_NUMBER() OVER (
            PARTITION BY TRIM(k.Naziv)
            ORDER BY k.KomponentaID
        ) AS rn
    FROM eWorkshop.dbo.Komponente k
),
S1 AS (
    SELECT
        s.ServisID,
        u.EvBroj,
        ROW_NUMBER() OVER (
            PARTITION BY u.EvBroj
            ORDER BY s.ServisID
        ) AS rn
    FROM eWorkshop.dbo.Servi s
    INNER JOIN eWorkshop.dbo.Uredjaj u
        ON u.UredjajID = s.UredjajID
)
SELECT
    r.evbroj,
    r.element,
    k1.KomponentaID,
    k1.Naziv AS KomponentaNaziv,
    k1.Vrijednost,
    k1.Tip,
    s1.ServisID
FROM R1 r
LEFT JOIN K1 k1
    ON k1.Naziv = TRIM(r.element)
   AND k1.rn = 1
LEFT JOIN S1 s1
    ON s1.EvBroj = r.evbroj
   AND s1.rn = 1
WHERE r.rn = 1
ORDER BY r.evbroj, r.element;
GO

WITH R1 AS (
    SELECT
        r.*,
        ROW_NUMBER() OVER (
            PARTITION BY r.evbroj, r.element
            ORDER BY r.evbroj
        ) AS rn
    FROM step.dbo.rep r
),
K1 AS (
    SELECT
        k.KomponentaID,
        TRIM(k.Naziv) AS Naziv,
        k.Vrijednost,
        k.Tip,
        ROW_NUMBER() OVER (
            PARTITION BY TRIM(k.Naziv)
            ORDER BY k.KomponentaID
        ) AS rn
    FROM eWorkshop.dbo.Komponente k
),
S1 AS (
    SELECT
        s.ServisID,
        u.EvBroj,
        ROW_NUMBER() OVER (
            PARTITION BY u.EvBroj
            ORDER BY s.ServisID
        ) AS rn
    FROM eWorkshop.dbo.Servi s
    INNER JOIN eWorkshop.dbo.Uredjaj u
        ON u.UredjajID = s.UredjajID
)
INSERT INTO eWorkshop.dbo.IzvrseniServis
(
    KomponentaID,
    ServisID,
    Datum,
    KomponentaNaziv,
    KomponentaVrijednost,
    KomponentaTip
)
SELECT
    k1.KomponentaID,
    s1.ServisID,
    NULL AS Datum,
    k1.Naziv AS KomponentaNaziv,
    k1.Vrijednost AS KomponentaVrijednost,
    k1.Tip AS KomponentaTip
FROM R1 r
LEFT JOIN K1 k1
    ON k1.Naziv = TRIM(r.element)
   AND k1.rn = 1
LEFT JOIN S1 s1
    ON s1.EvBroj = r.evbroj
   AND s1.rn = 1
WHERE r.rn = 1;
GO