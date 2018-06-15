
INSERT INTO User ('Name', 'Email', 'PasswordHash') VALUES ('Name1', 'name1@email.com', 'Test$!');
INSERT INTO User ('Name', 'Email', 'PasswordHash') VALUES ('Name2', 'name2@email.com', 'Test$!');

INSERT INTO Label ('Name', 'CreatedUserId', 'LastUpdateUserId') VALUES ('Tag1', 1, 2);
INSERT INTO Label ('Name', 'CreatedUserId', 'LastUpdateUserId') VALUES ('Tag2', 2, 1);

INSERT INTO Payment ('Name', 'CreatedUserId', 'LastUpdateUserId') VALUES ('Payment1', 1, 2);
INSERT INTO Payment ('Name', 'CreatedUserId', 'LastUpdateUserId') VALUES ('Payment2', 2, 1);

INSERT INTO Expense ('Name', 'Value', 'Data', 'Incoming', 'LabelId', 'PaymentId', 'CreatedUserId', 'LastUpdateUserId') VALUES ('Expense1', 1, '2018-10-10', 0, 1, 1, 1, 2);
INSERT INTO Expense ('Name', 'Value', 'Data', 'Incoming', 'LabelId', 'PaymentId', 'CreatedUserId', 'LastUpdateUserId') VALUES ('Expense2', 2, '2018-10-11', 0, 1, 1, 2, 1);
INSERT INTO Expense ('Name', 'Value', 'Data', 'Incoming', 'LabelId', 'PaymentId', 'CreatedUserId', 'LastUpdateUserId') VALUES ('Expense3', 3, '2018-10-12', 1, 2, 2, 1, 1);