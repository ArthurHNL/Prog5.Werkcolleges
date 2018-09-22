CREATE TABLE [dbo].[Product] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ProductName] NVARCHAR (150) NOT NULL,
    [ProductCode] NVARCHAR (5)   NOT NULL,
    [MinStock]    INT            NOT NULL,
    [Price]       DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Product]
    ON [dbo].[Product]([ProductCode] ASC);

