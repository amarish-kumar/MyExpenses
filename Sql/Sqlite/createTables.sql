-- https://sqliteonline.com/

DROP TABLE IF EXISTS Expense;
CREATE TABLE Expense (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Value REAL NOT NULL,
    Data DATE NOT NULL,

    Incoming INTEGER NOT NULL,

    LabelId INTEGER NULL,
    PaymentId INTEGER NULL,

    CreatedUserId INTEGER NULL,
    LastUpdateUserId INTEGER NULL,

    CONSTRAINT 'FK_Expense_Label' FOREIGN KEY ('LabelId') REFERENCES 'Label' ('Id') ON UPDATE CASCADE,
    CONSTRAINT 'FK_Expense_Payment' FOREIGN KEY ('PaymentId') REFERENCES 'Payment' ('Id') ON UPDATE CASCADE

    CONSTRAINT 'FK_Expense_CreatedUser' FOREIGN KEY ('CreatedUserId') REFERENCES 'User' ('Id') ON UPDATE CASCADE,
    CONSTRAINT 'FK_Expense_Payment' FOREIGN KEY ('LastUpdateUserId') REFERENCES 'User' ('Id') ON UPDATE CASCADE
);

DROP TABLE IF EXISTS Label;
CREATE TABLE Label (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text NOT NULL,

    CreatedUserId INTEGER NULL,
    LastUpdateUserId INTEGER NULL,

    CONSTRAINT 'FK_Expense_CreatedUser' FOREIGN KEY ('CreatedUserId') REFERENCES 'User' ('Id') ON UPDATE CASCADE,
    CONSTRAINT 'FK_Expense_Payment' FOREIGN KEY ('LastUpdateUserId') REFERENCES 'User' ('Id') ON UPDATE CASCADE
);

DROP TABLE IF EXISTS Payment;
CREATE TABLE Payment (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text NOT NULL,

    CreatedUserId INTEGER NULL,
    LastUpdateUserId INTEGER NULL,

    CONSTRAINT 'FK_Expense_CreatedUser' FOREIGN KEY ('CreatedUserId') REFERENCES 'User' ('Id') ON UPDATE CASCADE,
    CONSTRAINT 'FK_Expense_Payment' FOREIGN KEY ('LastUpdateUserId') REFERENCES 'User' ('Id') ON UPDATE CASCADE
);

DROP TABLE IF EXISTS User;
CREATE TABLE User (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text NOT NULL,
    Email text NOT NULL,
    PasswordHash text NOT NULL
);