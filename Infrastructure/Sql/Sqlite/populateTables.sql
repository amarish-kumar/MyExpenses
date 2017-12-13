
INSERT into Tags ('Name') VALUES ('Tag1');
INSERT into Tags ('Name') VALUES ('Tag2');

INSERT into Expenses ('Name', 'Value', 'Data', 'TagId') VALUES ('Expense1', 1, '2017-10-10', 1);
INSERT into Expenses ('Name', 'Value', 'Data', 'TagId') VALUES ('Expense2', 2, '2017-10-11', 2);
INSERT into Expenses ('Name', 'Value', 'Data', 'TagId') VALUES ('Expense3', 3, '2017-10-12', NULL);