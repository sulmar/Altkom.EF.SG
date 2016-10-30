
-- Konfiguracja

sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO

-- utworzenie asembly

CREATE ASSEMBLY DAS from 'C:\Users\Student\Documents\visual studio 2013\Projects\SG.DAS\SG.DAS.StoredProcedures\bin\Debug\StoredProcedures.dll' WITH PERMISSION_SET = SAFE


go

-- tworzymy procedure

CREATE PROCEDURE PrintToday
AS
EXTERNAL NAME DAS.StoredProcedures.PrintToday

GO

-- przykladowe wywolanie

exec PrintToday

