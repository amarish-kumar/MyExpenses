
SET IDENTITY_INSERT [dbo].[Tags] ON
INSERT INTO [dbo].[Tags] ([Id], [Name]) VALUES (1, N'Tag1')
INSERT INTO [dbo].[Tags] ([Id], [Name]) VALUES (2, N'Tag2')
SET IDENTITY_INSERT [dbo].[Tags] OFF

SET IDENTITY_INSERT [dbo].[Expenses] ON
INSERT INTO [dbo].[Expenses] ([Id], [Name], [Value], [Data], [TagId]) VALUES (1, N'Test', 2, N'2017-10-10', 1)
INSERT INTO [dbo].[Expenses] ([Id], [Name], [Value], [Data], [TagId]) VALUES (2, N'Test2', 3, N'2017-10-10', 2)
SET IDENTITY_INSERT [dbo].[Expenses] OFF

