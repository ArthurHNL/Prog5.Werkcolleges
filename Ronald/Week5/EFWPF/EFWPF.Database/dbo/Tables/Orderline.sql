CREATE TABLE [dbo].[Orderline] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT            NOT NULL,
    [ProductId] INT            NOT NULL,
    [Quantity]  INT            NULL,
    [Price]     DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_Orderline] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Orderline_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_Orderline_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Orderline]
    ON [dbo].[Orderline]([OrderId] ASC, [ProductId] ASC);

