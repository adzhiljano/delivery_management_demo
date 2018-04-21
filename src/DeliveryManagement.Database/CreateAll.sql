SET QUOTED_IDENTIFIER ON
GO

PRINT NULL
PRINT '------ Creating DeliveryManagement ------'
:setvar rootPath ".\Create"
:r $(rootPath)"\CreateDB.sql"
:r $(rootPath)"\Create.sql"
:r $(rootPath)"\Insert.sql"
