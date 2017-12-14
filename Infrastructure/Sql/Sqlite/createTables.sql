-- https://sqliteonline.com/

DROP TABLE IF EXISTS Expense;
CREATE TABLE Expense (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text NOT NULL,
    Value real NOT NULL,
    Data date NOT NULL,

    Income integer NULL,
    SplitAmount integer NULL,

    ExpenseTagId INTEGER NULL,
    ExpenseHowId INTEGER NULL,
    ExpenseStatusId INTEGER NULL,

    CONSTRAINT `FK_Expense_ExpenseTag` FOREIGN KEY (`ExpenseTagId`) REFERENCES `ExpenseTag` (`Id`) ON UPDATE CASCADE,
    CONSTRAINT `FK_Expense_ExpenseHow` FOREIGN KEY (`ExpenseHowId`) REFERENCES `ExpenseHow` (`Id`) ON UPDATE CASCADE,
    CONSTRAINT `FK_Expense_ExpenseStatus` FOREIGN KEY (`ExpenseStatusId`) REFERENCES `ExpenseStatus` (`Id`) ON UPDATE CASCADE
);

DROP TABLE IF EXISTS ExpenseTag;
CREATE TABLE ExpenseTag (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text NOT NULL
);

DROP TABLE IF EXISTS ExpenseHow;
CREATE TABLE ExpenseHow (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text NOT NULL
);

DROP TABLE IF EXISTS ExpenseStatus;
CREATE TABLE ExpenseStatus (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text NOT NULL
);