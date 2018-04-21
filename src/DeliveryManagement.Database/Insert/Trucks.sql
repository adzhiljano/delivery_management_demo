PRINT 'Insert Trucks'
GO

SET IDENTITY_INSERT [Trucks] ON

INSERT INTO [Trucks]
    ([TruckId], [TruckType], [OwnerName]          , [OwnerPhone]        , [OwnerEmail]                                      , [CreateDate], [ModifyDate])
VALUES
    (1        , 1          , N'Atanas Dzhilyanov' , N'+359 888 064 797' , N'naskodzhil@gmail.com'                           ,  GETDATE()  , GETDATE())
GO

SET IDENTITY_INSERT [Trucks] OFF