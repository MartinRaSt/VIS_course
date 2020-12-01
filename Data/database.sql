-- Script Date: 01.12.2020 23:59  - 
CREATE TABLE [Zamestnanec] (
  [Id] int IDENTITY (1,1) NOT NULL
);
GO
CREATE TABLE [Vypujcky] (
  [Id] int IDENTITY (1,1) NOT NULL
);
GO
CREATE TABLE [Uzivatele] (
  [Id] int IDENTITY (1,1) NOT NULL
, [Jmeno] nvarchar(50) NOT NULL
, [Prijmeni] nvarchar(50) NOT NULL
, [DatumNarozeni] datetime NULL
, [ClenemOd] datetime NULL
, [Spolehlivost] int NOT NULL
);
GO
CREATE TABLE [Knihy] (
  [Id] int IDENTITY (1,1) NOT NULL
);
GO
ALTER TABLE [Zamestnanec] ADD CONSTRAINT [PK__Zamestna__3214EC07DB479FE0] PRIMARY KEY ([Id]);
GO
ALTER TABLE [Vypujcky] ADD CONSTRAINT [PK__Vypujcky__3214EC072B94CA50] PRIMARY KEY ([Id]);
GO
ALTER TABLE [Uzivatele] ADD CONSTRAINT [PK__Uzivatel__3214EC070DA5CBAC] PRIMARY KEY ([Id]);
GO
ALTER TABLE [Knihy] ADD CONSTRAINT [PK__Knihy__3214EC07A83485BB] PRIMARY KEY ([Id]);
GO

