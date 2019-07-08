
CREATE TABLE [Pracas] (
    [idPraca] int NOT NULL IDENTITY,
    [praca] nvarchar(max) NOT NULL,
	[sigla] nvarchar(3) NOT NULL,
	[estado] nvarchar(max) NOT NULL,
    CONSTRAINT [PKey_idPraca] PRIMARY KEY ([idPraca])
);
GO
