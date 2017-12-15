
INSERT INTO ExpenseTag ('Name') VALUES ('Tag1');
INSERT INTO ExpenseTag ('Name') VALUES ('Tag2');

INSERT INTO ExpenseHow ('Name') VALUES ('How1');
INSERT INTO ExpenseHow ('Name') VALUES ('How2');

INSERT INTO ExpenseStatus ('Name') VALUES ('Status1');
INSERT INTO ExpenseStatus ('Name') VALUES ('Status2');

INSERT INTO Expense ('Name', 'Value', 'Data', 'ExpenseTagId', 'ExpenseHowId', 'ExpenseStatusId') VALUES ('Expense1', 1, '2017-10-10', 1, 1, 1);
INSERT INTO Expense ('Name', 'Value', 'Data', 'ExpenseTagId', 'ExpenseHowId', 'ExpenseStatusId') VALUES ('Expense2', 2, '2017-10-11', 2, 1, 1);
INSERT INTO Expense ('Name', 'Value', 'Data', 'ExpenseTagId', 'ExpenseHowId', 'ExpenseStatusId') VALUES ('Expense3', 3, '2017-10-12', NULL, NULL, NULL);