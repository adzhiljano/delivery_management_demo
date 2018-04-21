PRINT 'Shipments'
GO

CREATE TABLE [dbo].[Shipments] (
    [ShipmentId]            INT                 NOT NULL IDENTITY,
    [TrackingNumber]        UNIQUEIDENTIFIER    NOT NULL UNIQUE,
    [SenderName]            NVARCHAR (200)      NOT NULL,
    [SenderAddress]         NVARCHAR (200)      NOT NULL,
    [ReceiverName]          NVARCHAR (200)      NOT NULL,
    [ReceiverAddress]       NVARCHAR (200)      NOT NULL,
    [PackagesCount]         INT                 NOT NULL,
    [Status]                INT                 NOT NULL,
    [HasDamagedPackages]    BIT                 NULL,
    [ReceiverFound]         BIT                 NULL,
    [Notes]                 NVARCHAR (500)      NULL,
    [TruckId]               INT                 NULL,
    [CreateDate]            DATETIME2           NOT NULL,
    [ModifyDate]            DATETIME2           NOT NULL,
    [Version]               ROWVERSION          NOT NULL,
    CONSTRAINT [PK_Shipments]            PRIMARY KEY ([ShipmentId]),
    CONSTRAINT [FK_Shipments_Trucks]     FOREIGN KEY ([TruckId])    REFERENCES [dbo].[Trucks] ([TruckId]),
);
GO