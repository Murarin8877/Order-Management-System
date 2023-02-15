CREATE TABLE [dbo].[訂貨主檔] (
    [訂單編號] INT           NOT NULL,
    [客戶編號] NVARCHAR (10) NULL,
    [訂單日期] NVARCHAR (50) NULL,
    [商品總額] INT           NULL,
    CONSTRAINT [PK_訂貨主檔] PRIMARY KEY CLUSTERED ([訂單編號] ASC),
    CONSTRAINT [FK_訂貨主檔_客戶] FOREIGN KEY ([客戶編號]) REFERENCES [dbo].[客戶] ([客戶編號])
);