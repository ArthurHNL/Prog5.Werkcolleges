/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
MERGE INTO Product AS Target 
USING (VALUES 
  (N'Appels', N'APPL', 10, 0.50 ), 
  (N'Peren', N'PEER', 99, 1.34 ),
  (N'Druiven', N'DRUIF', 2099, 0.05 )
) 
AS Source (ProductName,ProductCode,MinStock,Price) ON Target.ProductCode = Source.ProductCode 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT (ProductName,ProductCode,MinStock,Price) 
	VALUES (ProductName,ProductCode,MinStock,Price);

MERGE INTO Person AS Target 
USING (VALUES 
  (N'Kees', N'Kist', 1, N'19670828' ), 
  (N'Sjaak', N'Bonestaak', 1, N'20000213' ),
  (N'Annie', N'Druif', 0, N'19951103' )
) 
AS Source (Firstname,Lastname,Gender,Birthdate) ON Target.Lastname = Source.Lastname 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT (Firstname,Lastname,Gender,Birthdate) 
	VALUES (Firstname,Lastname,Gender,Birthdate);