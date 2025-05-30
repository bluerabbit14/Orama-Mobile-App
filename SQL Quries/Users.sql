-- Users Table
CREATE TABLE Users (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    Email VARCHAR(255) NOT NULL UNIQUE,
    PhoneNumber INT,
    UserName VARCHAR(100),
    PasswordHash NVARCHAR(MAX) NOT NULL,
    Salt NVARCHAR(255),
    IsEmailVerified BIT NOT NULL DEFAULT 0,
    EmailVerificationToken VARCHAR(100),
    ResetPasswordToken VARCHAR(100),
    ResetTokenExpiry DATETIME,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    IsActive BIT NOT NULL DEFAULT 1,
    Role VARCHAR(50) NOT NULL DEFAULT 'User'
);

Select* from Users;