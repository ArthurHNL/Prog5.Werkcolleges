CREATE TABLE [dbo].[Person] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Firstname] NVARCHAR (50)  NULL,
    [Lastname]  NVARCHAR (200) NOT NULL,
    [Gender]    INT            NOT NULL,
    [Birthdate] DATETIME       NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC)
);

