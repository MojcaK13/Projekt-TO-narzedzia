CREATE TABLE [dbo].[Wyniki]
(
	[NrWyniku] INT NOT NULL PRIMARY KEY, 
    [Data] DATE NULL, 
    [MiejsceZawodow] VARCHAR(MAX) NULL, 
    [RodzajStartu] INT NOT NULL, 
    [MiejsceZajete] INT NULL, 
    [Zawodnik] INT NOT NULL, 
    [IloscPudel] INT NULL, 
    [Czas] TIME NULL, 
    [RangaZawodow] VARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Wyniki_TypStartu] FOREIGN KEY ([RodzajStartu]) REFERENCES [TypStartu]([NrTypu]), 
    CONSTRAINT [FK_Wyniki_Zawodnik] FOREIGN KEY ([Zawodnik]) REFERENCES [Zawodnik]([NrZawodnika])
)
