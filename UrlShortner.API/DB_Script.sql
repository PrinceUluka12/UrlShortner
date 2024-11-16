CREATE TABLE UrlEntries (
    Id INT PRIMARY KEY IDENTITY,
    UserName NVARCHAR(100) NOT NULL UNIQUE,
    LongUrl NVARCHAR(MAX) NOT NULL,
    ShortUrl NVARCHAR(50) NOT NULL UNIQUE,
    ShortUrlLength INT NOT NULL,
    CreatedAt DATETIME NOT NULL
);