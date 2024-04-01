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
INSERT [dbo].[Allergies] ([AllergyId], [Name]) VALUES (1, N'Eggs')
GO
INSERT [dbo].[Allergies] ([AllergyId], [Name]) VALUES (2, N'Milk')
GO
INSERT [dbo].[Allergies] ([AllergyId], [Name]) VALUES (3, N'Soy')
GO
INSERT [dbo].[Allergies] ([AllergyId], [Name]) VALUES (4, N'Gluten')
GO
INSERT [dbo].[Allergies] ([AllergyId], [Name]) VALUES (5, N'Shellfish')
GO
INSERT [dbo].[Allergies] ([AllergyId], [Name]) VALUES (6, N'Nuts')
GO
INSERT [dbo].[Allergies] ([AllergyId], [Name]) VALUES (7, N'Fish')
GO
INSERT [dbo].[Allergies] ([AllergyId], [Name]) VALUES (8, N'Wheat')
GO
INSERT [dbo].[Allergies] ([AllergyId], [Name]) VALUES (9, N'Sesame')
GO
INSERT [dbo].[Allergies] ([AllergyId], [Name]) VALUES (10, N'None')
GO

