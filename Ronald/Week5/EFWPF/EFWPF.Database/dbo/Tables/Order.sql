CREATE TABLE [dbo].[Order] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [OrderNumber] INT NOT NULL,
    [PersonId]    INT NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);






GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Order]
    ON [dbo].[Order]([OrderNumber] ASC);

