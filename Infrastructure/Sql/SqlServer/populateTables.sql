
SET IDENTITY_INSERT [dbo].[Expenses] ON
INSERT INTO [dbo].[Expenses] ([Id], [Name], [Value], [Data]) VALUES (1, N'Test', 2, N'2017-10-10')
INSERT INTO [dbo].[Expenses] ([Id], [Name], [Value], [Data]) VALUES (2, N'Test2', 3, N'2017-10-10')
SET IDENTITY_INSERT [dbo].[Expenses] OFF

SET IDENTITY_INSERT [dbo].[Tags] ON
INSERT INTO [dbo].[Tags] ([Id], [Name]) VALUES (1, N'Tag1')
INSERT INTO [dbo].[Tags] ([Id], [Name]) VALUES (2, N'Tag2')
SET IDENTITY_INSERT [dbo].[Tags] OFF

SET IDENTITY_INSERT [dbo].[Expenses_Tags] ON
INSERT INTO [dbo].[Expenses_Tags] ([Id], [ExpenseId], [TagId]) VALUES (1, 1, 1)
INSERT INTO [dbo].[Expenses_Tags] ([Id], [ExpenseId], [TagId]) VALUES (2, 2, 2)
SET IDENTITY_INSERT [dbo].[Expenses_Tags] OFF