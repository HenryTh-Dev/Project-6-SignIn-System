CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Firstname] VARCHAR(80) NOT NULL,
    [Lastname] VARCHAR(80) NOT NULL,
    [Email] VARCHAR(80) NOT NULL,
    [Snn] VARCHAR(8) NOT NULL,
    [Birthdate] CHAR(8) NOT NULL,
    [Password] VARCHAR(32) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO


CREATE UNIQUE INDEX [IX_Users_Email] ON [Users] ([Email]);
GO


