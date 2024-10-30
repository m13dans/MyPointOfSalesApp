IF NOT EXISTS (
    SELECT * FROM sys.objects
    WHERE object_id = OBJECT_ID(N'[dbo].Items') AND type in (N'U'))

BEGIN
	CREATE TABLE Items (
        Id INT PRIMARY KEY IDENTITY(1, 1),
        NamaBarang VARCHAR(255) NOT NULL,
        Harga MONEY,
        StokAwal INT,
        Kategori VARCHAR(255),
        UrlGambar VARCHAR(500)
    )
END