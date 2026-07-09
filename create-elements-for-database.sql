USE Bookish
GO

INSERT INTO dbo.Authors (AuthorID, Name) VALUES
(1, 'Ion Creanga'), 
(2, 'Mihai Eminescu'),
(3, 'Liviu Rebreanu'),
(4, 'George Calinescu'),
(5, 'Nichita Stanescu');

INSERT INTO dbo.Books (BookID, Title, ISBN, NumberOfCopies) VALUES
(101, 'Carte 1', 9780132350884, 5),
(102, 'Carte 2', 9780134757599, 3),
(103, 'Carte 3', 9780135166307, 4),
(104, 'Carte 4', 9780066620732, 2);

INSERT INTO dbo.Users (UserID, Name, Email, Password_hash) VALUES
(1, 'Alex', 'alex@yahoo.ro', 'hash_super_sigur_1'),
(2, 'Andreea', 'andreea@yahoo.ro', 'hash_super_sigur_2'),
(3, 'Dan', 'dan@yahoo.ro', 'hash_super_sigur_3');

INSERT INTO dbo.BooksAuthors (BookID, AuthorID) VALUES (101, 1);
INSERT INTO dbo.BooksAuthors (BookID, AuthorID) VALUES (102, 2);
INSERT INTO dbo.BooksAuthors (BookID, AuthorID) VALUES (103, 4);
INSERT INTO dbo.BooksAuthors (BookID, AuthorID) VALUES (103, 5);
INSERT INTO dbo.BooksAuthors (BookID, AuthorID) VALUES (104, 3);

INSERT INTO dbo.Loans (LoanID, BookID, UserID, LoanDate, DueDate, ReturnDate) VALUES
(501, 101, 1, '2026-07-01', '2026-07-14', '2026-07-08');

INSERT INTO dbo.Loans (LoanID, BookID, UserID, LoanDate, DueDate, ReturnDate) VALUES
(502, 103, 2, '2026-07-05', '2026-07-19', NULL);

INSERT INTO dbo.Loans (LoanID, BookID, UserID, LoanDate, DueDate, ReturnDate) VALUES
(503, 102, 3, '2026-07-09', '2026-07-23', NULL);