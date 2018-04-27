
INSERT INTO Label ('Name') VALUES ('Tag1');
INSERT INTO Label ('Name') VALUES ('Tag2');

INSERT INTO How ('Name') VALUES ('How1');
INSERT INTO How ('Name') VALUES ('How2');

INSERT INTO Expense ('Name', 'Value', 'Data', 'Incoming', 'Fixed', 'LabelId', 'HowId') VALUES ('Expense1', 1, '2018-10-10', 0, 0, 1, 1);
INSERT INTO Expense ('Name', 'Value', 'Data', 'Incoming', 'Fixed', 'LabelId', 'HowId') VALUES ('Expense2', 2, '2018-10-11', 0, 0, 1, 1);
INSERT INTO Expense ('Name', 'Value', 'Data', 'Incoming', 'Fixed', 'LabelId', 'HowId') VALUES ('Expense3', 3, '2018-10-12', 1, 1, 2, 2);