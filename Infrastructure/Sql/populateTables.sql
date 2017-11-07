
INSERT into Expenses ('Name', 'Value', 'Data') VALUES ('Expense1', 1, '2017-10-10');
INSERT into Expenses ('Name', 'Value', 'Data') VALUES ('Expense2', 2, '2017-10-10');

INSERT into Tags ('Name') VALUES ('Tag1');
INSERT into Tags ('Name') VALUES ('Tag2');

INSERT into Expenses_Tags ('ExpenseId', 'TagId') VALUES (1, 1);
INSERT into Expenses_Tags ('ExpenseId', 'TagId') VALUES (2, 2);