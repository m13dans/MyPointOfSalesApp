IF NOT EXISTS (
    SELECT * FROM sys.objects
    WHERE object_id = OBJECT_ID(N'[dbo].Kategories') AND type in (N'U'))

BEGIN
	CREATE TABLE Kategories (
        Id INT PRIMARY KEY IDENTITY(1, 1),
        NamaKategori VARCHAR(50) NOT NULL,
    )
END