
INSERT INTO Label ('Name') VALUES ('Tag1');
INSERT INTO Label ('Name') VALUES ('Tag2');

INSERT INTO Payment ('Name') VALUES ('Payment1');
INSERT INTO Payment ('Name') VALUES ('Payment2');

INSERT INTO Expense ('Name', 'Value', 'Data', 'Incoming', 'LabelId', 'PaymentId') VALUES ('Expense1', 1, '2018-10-10', 0, 1, 1);
INSERT INTO Expense ('Name', 'Value', 'Data', 'Incoming', 'LabelId', 'PaymentId') VALUES ('Expense2', 2, '2018-10-11', 0, 1, 1);
INSERT INTO Expense ('Name', 'Value', 'Data', 'Incoming', 'LabelId', 'PaymentId') VALUES ('Expense3', 3, '2018-10-12', 1, 2, 2);