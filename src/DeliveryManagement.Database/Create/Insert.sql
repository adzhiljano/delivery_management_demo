USE [$(dbName)]
GO

PRINT NULL
PRINT '------ Inserting Data ------'
---------------------------------------------------------------
-- Inserts
---------------------------------------------------------------

-- Trucks
:r $(rootPath)\"..\Insert\Trucks.sql"

-- Shipments
:r $(rootPath)\"..\Insert\Shipments.sql"
