CREATE TABLE UserLogins
(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    UserId UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Users(Id),
    Provider VARCHAR(100) NOT NULL, -- e.g., "Google", "Facebook"
    ProviderUserId VARCHAR(255) NOT NULL, -- ID from the provider
    CreatedAt DATETIME NOT NULL
);