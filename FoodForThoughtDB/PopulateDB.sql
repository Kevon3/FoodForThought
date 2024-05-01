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
SET IDENTITY_INSERT [dbo].[Cuisine] ON 
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Cuisine]) VALUES (1, N'American')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Cuisine]) VALUES (2, N'Chinese')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Cuisine]) VALUES (3, N'Greek')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Cuisine]) VALUES (4, N'Indian')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Cuisine]) VALUES (5, N'Italian')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Cuisine]) VALUES (6, N'Japanese')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Cuisine]) VALUES (7, N'Korean')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Cuisine]) VALUES (8, N'Mexican')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Cuisine]) VALUES (9, N'Thai')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Cuisine]) VALUES (10, N'Vietnamese')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Cuisine]) VALUES (11, N'Soul')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Cuisine]) VALUES (12, N'Creole')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Cuisine]) VALUES (13, N'French')
GO
INSERT [dbo].[Cuisine] ([CuisineId], [Cuisine]) VALUES (14, N'Other')
GO
SET IDENTITY_INSERT [dbo].[Cuisine] OFF
GO
SET IDENTITY_INSERT [dbo].[Allergies] ON 
GO
INSERT [dbo].[Allergies] ([AllergyId], [AllergyName]) VALUES (1, N'Eggs')
GO
INSERT [dbo].[Allergies] ([AllergyId], [AllergyName]) VALUES (2, N'Milk')
GO
INSERT [dbo].[Allergies] ([AllergyId], [AllergyName]) VALUES (3, N'Soy')
GO
INSERT [dbo].[Allergies] ([AllergyId], [AllergyName]) VALUES (4, N'Gluten')
GO
INSERT [dbo].[Allergies] ([AllergyId], [AllergyName]) VALUES (5, N'Shellfish')
GO
INSERT [dbo].[Allergies] ([AllergyId], [AllergyName]) VALUES (6, N'Nuts')
GO
INSERT [dbo].[Allergies] ([AllergyId], [AllergyName]) VALUES (7, N'Fish')
GO
INSERT [dbo].[Allergies] ([AllergyId], [AllergyName]) VALUES (8, N'Wheat')
GO
INSERT [dbo].[Allergies] ([AllergyId], [AllergyName]) VALUES (9, N'Sesame')
GO
INSERT [dbo].[Allergies] ([AllergyId], [AllergyName]) VALUES (10, N'None')
GO
SET IDENTITY_INSERT [dbo].[Allergies] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 
GO
INSERT [dbo].[Person] ([UserId], [FirstName], [LastName], [Email], [Username], [Password], [url], [AllergyId]) VALUES (1, N't54', N't345', N'3t5', N'54t', N'$2a$13$jD7KT7EM7aOlURm0wYTPyeSngoo3Qs4imq./1RYRgMjEviUcgXmu6', NULL, NULL)
GO
INSERT [dbo].[Person] ([UserId], [FirstName], [LastName], [Email], [Username], [Password], [url], [AllergyId]) VALUES (2, N'Kevon', N'Harvey', N'd@gmail.com', N'Kevin', N'$2a$13$i8x9jq1FQ38ZKzPzoYrceOO0T0YRt/95syEzaLb.ePNs9dERPbzJm', NULL, NULL)
GO
INSERT [dbo].[Person] ([UserId], [FirstName], [LastName], [Email], [Username], [Password], [url], [AllergyId]) VALUES (3, N'Michael', N'Jackson', N'm1@yahoo.com', N'M24', N'$2a$13$0bRnZcmGv9Ugh.qRK3N7Oeq4QTmMnLQfO0Hp2z6BPmb2ncGrqwpBC', NULL, NULL)
GO
INSERT [dbo].[Person] ([UserId], [FirstName], [LastName], [Email], [Username], [Password], [url], [AllergyId]) VALUES (4, N'3', N'5', N'3@yahoo.com', N'2', N'$2a$13$142tyWzFHVDuwcK/rp4XuulXoy5g8fHsEJM5xe0BwlNx11wZL5R5u', NULL, NULL)
GO
INSERT [dbo].[Person] ([UserId], [FirstName], [LastName], [Email], [Username], [Password], [url], [AllergyId]) VALUES (5, N'h', N'h', N'h@gmail.com', N'h', N'$2a$13$b1WG02z9r6iixpKa8fsKJ.Uw/RMzQQSdHke1.pGzZe54yBMex3nWi', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Person] OFF
GO



