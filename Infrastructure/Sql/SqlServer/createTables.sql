
DROP TABLE IF EXISTS Expenses;
CREATE TABLE [dbo].[Expenses] (
    [Id]    BIGINT NOT NULL IDENTITY(1,1),
    [Name]  TEXT   NOT NULL,
    [Value] REAL   NOT NULL,
    [Data]  DATE   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

DROP TABLE IF EXISTS Tags;
CREATE TABLE [dbo].[Tags] (
    [Id]   BIGINT NOT NULL IDENTITY(1,1),
    [Name] TEXT   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

DROP TABLE IF EXISTS Expenses_Tags;
CREATE TABLE [dbo].[Expenses_Tags]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ExpenseId] BIGINT NOT NULL, 
    [TagId] BIGINT NOT NULL, 
    CONSTRAINT [FK_Expenses_Tags_Expense] FOREIGN KEY ([ExpenseId]) REFERENCES [Expenses]([Id]),
	CONSTRAINT [FK_Expenses_Tags_Tag] FOREIGN KEY ([TagId]) REFERENCES [Tags]([Id])
)