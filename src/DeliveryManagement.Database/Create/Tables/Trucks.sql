PRINT 'Trucks'
GO

CREATE TABLE [dbo].[Trucks] (
    [TruckId]               INT                 NOT NULL IDENTITY,
    [TruckType]             INT                 NOT NULL,
    [OwnerName]             NVARCHAR (200)      NOT NULL,
    [OwnerPhone]            NVARCHAR (50)       NOT NULL,
    [OwnerEmail]            NVARCHAR (200)      NULL,
    [CreateDate]            DATETIME2           NOT NULL,
    [ModifyDate]            DATETIME2           NOT NULL,
    [Version]               ROWVERSION          NOT NULL,
    CONSTRAINT [PK_Trucks]             PRIMARY KEY ([TruckId]),
    CONSTRAINT [CHK_Trucks_TruckType]  CHECK       ([TruckType] IN (1, 2, 3))
);
GO