USE Bookish
GO

INSERT INTO dbo.Authors (Name) VALUES
('Ion Creanga'), 
('Mihai Eminescu'),
('Liviu Rebreanu'),
('George Calinescu'),
('Nichita Stanescu');

INSERT INTO dbo.Books (Title, ISBN, NumberOfCopies) VALUES
('Carte 1', '9780132350884', 5),
('Carte 2', '9780134757599', 3),
('Carte 3','9780135166307', 4),
('Carte 4', '9780066620732', 2);

INSERT INTO dbo.Users (Name, Email, Password_hash) VALUES
('Alex', 'alex@yahoo.ro', 'hash_super_sigur_1'),
('Andreea', 'andreea@yahoo.ro', 'hash_super_sigur_2'),
('Dan', 'dan@yahoo.ro', 'hash_super_sigur_3');

INSERT INTO dbo.BooksAuthors (BookID, AuthorID) VALUES (1, 1);
INSERT INTO dbo.BooksAuthors (BookID, AuthorID) VALUES (2, 2);
INSERT INTO dbo.BooksAuthors (BookID, AuthorID) VALUES (3, 4);
INSERT INTO dbo.BooksAuthors (BookID, AuthorID) VALUES (3, 5);
INSERT INTO dbo.BooksAuthors (BookID, AuthorID) VALUES (4, 3);

INSERT INTO dbo.Loans (BookID, UserID, LoanDate, DueDate, ReturnDate) VALUES
(1, 1, '2026-07-01', '2026-07-14', '2026-07-08');

INSERT INTO dbo.Loans (BookID, UserID, LoanDate, DueDate, ReturnDate) VALUES
(3, 2, '2026-07-05', '2026-07-19', NULL);

INSERT INTO dbo.Loans (BookID, UserID, LoanDate, DueDate, ReturnDate) VALUES
(2, 3, '2026-07-09', '2026-07-23', NULL);