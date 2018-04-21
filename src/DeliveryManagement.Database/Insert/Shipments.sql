PRINT 'Insert Shipments'
GO

SET IDENTITY_INSERT [Shipments] ON

INSERT INTO [Shipments]
    ([ShipmentId], [TrackingNumber], [SenderName]    , [SenderAddress]    , [ReceiverName]    , [ReceiverAddress]    , [PackagesCount] , [Status] , [TruckId], [CreateDate], [ModifyDate])
VALUES
    (1           , NEWID()         , N'senderName1'  , N'senderAddress1'  , N'receiverName1'  , N'receiverAddress1'  , 1               , 1        , 1        ,  GETDATE()  , GETDATE()),
    (2           , NEWID()         , N'senderName2'  , N'senderAddress2'  , N'receiverName2'  , N'receiverAddress2'  , 2               , 1        , 1        ,  GETDATE()  , GETDATE()),
    (3           , NEWID()         , N'senderName3'  , N'senderAddress3'  , N'receiverName3'  , N'receiverAddress3'  , 3               , 1        , 1        ,  GETDATE()  , GETDATE()),
    (4           , NEWID()         , N'senderName4'  , N'senderAddress4'  , N'receiverName4'  , N'receiverAddress4'  , 4               , 1        , 1        ,  GETDATE()  , GETDATE()),
    (5           , NEWID()         , N'senderName5'  , N'senderAddress5'  , N'receiverName5'  , N'receiverAddress5'  , 5               , 1        , 1        ,  GETDATE()  , GETDATE()),
    (6           , NEWID()         , N'senderName6'  , N'senderAddress6'  , N'receiverName6'  , N'receiverAddress6'  , 6               , 1        , 1        ,  GETDATE()  , GETDATE()),
    (7           , NEWID()         , N'senderName7'  , N'senderAddress7'  , N'receiverName7'  , N'receiverAddress7'  , 7               , 1        , 1        ,  GETDATE()  , GETDATE()),
    (8           , NEWID()         , N'senderName8'  , N'senderAddress8'  , N'receiverName8'  , N'receiverAddress8'  , 8               , 1        , 1        ,  GETDATE()  , GETDATE()),
    (9           , NEWID()         , N'senderName9'  , N'senderAddress9'  , N'receiverName9'  , N'receiverAddress9'  , 9               , 1        , 1        ,  GETDATE()  , GETDATE()),
    (10          , NEWID()         , N'senderName10' , N'senderAddress10' , N'receiverName10' , N'receiverAddress10' , 10              , 1        , 1        ,  GETDATE()  , GETDATE()),
    (11          , NEWID()         , N'senderName11' , N'senderAddress11' , N'receiverName11' , N'receiverAddress11' , 11              , 2        , 1        ,  GETDATE()  , GETDATE()),
    (12          , NEWID()         , N'senderName12' , N'senderAddress12' , N'receiverName12' , N'receiverAddress12' , 12              , 2        , 1        ,  GETDATE()  , GETDATE()),
    (13          , NEWID()         , N'senderName13' , N'senderAddress13' , N'receiverName13' , N'receiverAddress13' , 13              , 2        , 1        ,  GETDATE()  , GETDATE()),
    (14          , NEWID()         , N'senderName14' , N'senderAddress14' , N'receiverName14' , N'receiverAddress14' , 14              , 2        , 1        ,  GETDATE()  , GETDATE()),
    (15          , NEWID()         , N'senderName15' , N'senderAddress15' , N'receiverName15' , N'receiverAddress15' , 15              , 2        , 1        ,  GETDATE()  , GETDATE()),
    (16          , NEWID()         , N'senderName16' , N'senderAddress16' , N'receiverName16' , N'receiverAddress16' , 16              , 2        , 1        ,  GETDATE()  , GETDATE()),
    (17          , NEWID()         , N'senderName17' , N'senderAddress17' , N'receiverName17' , N'receiverAddress17' , 17              , 2        , 1        ,  GETDATE()  , GETDATE()),
    (18          , NEWID()         , N'senderName18' , N'senderAddress18' , N'receiverName18' , N'receiverAddress18' , 18              , 2        , 1        ,  GETDATE()  , GETDATE()),
    (19          , NEWID()         , N'senderName19' , N'senderAddress19' , N'receiverName19' , N'receiverAddress19' , 19              , 2        , 1        ,  GETDATE()  , GETDATE()),
    (20          , NEWID()         , N'senderName20' , N'senderAddress20' , N'receiverName20' , N'receiverAddress20' , 20              , 2        , 1        ,  GETDATE()  , GETDATE()),
    (21          , NEWID()         , N'senderName21' , N'senderAddress21' , N'receiverName21' , N'receiverAddress21' , 21              , 3        , 1        ,  GETDATE()  , GETDATE()),
    (22          , NEWID()         , N'senderName22' , N'senderAddress22' , N'receiverName22' , N'receiverAddress22' , 22              , 3        , 1        ,  GETDATE()  , GETDATE()),
    (23          , NEWID()         , N'senderName23' , N'senderAddress23' , N'receiverName23' , N'receiverAddress23' , 23              , 3        , 1        ,  GETDATE()  , GETDATE()),
    (24          , NEWID()         , N'senderName24' , N'senderAddress24' , N'receiverName24' , N'receiverAddress24' , 24              , 3        , 1        ,  GETDATE()  , GETDATE()),
    (25          , NEWID()         , N'senderName25' , N'senderAddress25' , N'receiverName25' , N'receiverAddress25' , 25              , 3        , 1        ,  GETDATE()  , GETDATE()),
    (26          , NEWID()         , N'senderName26' , N'senderAddress26' , N'receiverName26' , N'receiverAddress26' , 26              , 3        , 1        ,  GETDATE()  , GETDATE()),
    (27          , NEWID()         , N'senderName27' , N'senderAddress27' , N'receiverName27' , N'receiverAddress27' , 27              , 3        , 1        ,  GETDATE()  , GETDATE()),
    (28          , NEWID()         , N'senderName28' , N'senderAddress28' , N'receiverName28' , N'receiverAddress28' , 28              , 3        , 1        ,  GETDATE()  , GETDATE()),
    (29          , NEWID()         , N'senderName29' , N'senderAddress29' , N'receiverName29' , N'receiverAddress29' , 29              , 3        , 1        ,  GETDATE()  , GETDATE()),
    (30          , NEWID()         , N'senderName30' , N'senderAddress30' , N'receiverName30' , N'receiverAddress30' , 30              , 3        , 1        ,  GETDATE()  , GETDATE())
GO

SET IDENTITY_INSERT [Shipments] OFF



