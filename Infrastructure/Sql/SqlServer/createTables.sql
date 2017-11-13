-- Expenses
DROP TABLE IF EXISTS Expenses;
CREATE TABLE [dbo].[Expenses] (
    [Id]     BIGINT NOT NULL IDENTITY(1,1),
    [Name]   TEXT   NOT NULL,
    [Value]  REAL   NOT NULL,
    [Data]   DATE   NOT NULL,
    [UserId] BIGINT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
-- Tags
DROP TABLE IF EXISTS Tags;
CREATE TABLE [dbo].[Tags] (
    [Id]   BIGINT NOT NULL IDENTITY(1,1),
    [Name] TEXT   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
-- Expenses_Tags
DROP TABLE IF EXISTS Expenses_Tags;
CREATE TABLE [dbo].[Expenses_Tags]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ExpenseId] BIGINT NOT NULL, 
    [TagId] BIGINT NOT NULL, 
    CONSTRAINT [FK_Expenses_Tags_Expense] FOREIGN KEY ([ExpenseId]) REFERENCES [Expenses]([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_Expenses_Tags_Tag] FOREIGN KEY ([TagId]) REFERENCES [Tags]([Id]) ON DELETE CASCADE
)
-- Users
DROP TABLE IF EXISTS Users;
CREATE TABLE [dbo].[Users] (
    [Id]   BIGINT NOT NULL IDENTITY(1,1),
    [Name] TEXT   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
-- Projects
DROP TABLE IF EXISTS Projects;
CREATE TABLE [dbo].[Projects] (
    [Id]   BIGINT NOT NULL IDENTITY(1,1),
    [Name] TEXT   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
-- Projects_Users
DROP TABLE IF EXISTS Projects_Users;
CREATE TABLE [dbo].[Projects_Users] (
    [Id]   BIGINT NOT NULL IDENTITY(1,1),
    [ProjectId] BIGINT NOT NULL, 
    [UserId] BIGINT NOT NULL, 
    CONSTRAINT [FK_Projects_Users_Project] FOREIGN KEY ([ProjectId]) REFERENCES [Projects]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Projects_Users_User] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]) ON DELETE CASCADE
);