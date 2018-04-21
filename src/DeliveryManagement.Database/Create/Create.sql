USE [$(dbName)]
GO

PRINT NULL
PRINT '------ Creating Tables ------'

---------------------------------------------------------------
-- Tables
---------------------------------------------------------------

-- Trucks
:r $(rootPath)"\Tables\Trucks.sql"

-- Shipments
:r $(rootPath)"\Tables\Shipments.sql"
