USE Bookish
GO

CREATE TABLE dbo.Books(
	[BookID] [int] IDENTITY(1, 1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[ISBN] [nvarchar](255) NOT NULL,
	[NumberOfCopies] [int] NOT NULL,

	CONSTRAINT [PK_books] PRIMARY KEY (BookID)
)

CREATE TABLE dbo.Users(
	[UserID] [int] IDENTITY(1, 1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password_hash] [nvarchar](255) NOT NULL,

	CONSTRAINT [PK_users] PRIMARY KEY (UserID)
)

CREATE TABLE dbo.Authors(
	[AuthorID] [int] IDENTITY(1, 1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,

	CONSTRAINT [PK_authors] PRIMARY KEY (AuthorID)
)

CREATE TABLE dbo.Loans(
	[LoanID] [int] IDENTITY(1, 1) NOT NULL,
	[BookID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[LoanDate] [date] NOT NULL,
	[DueDate] [date] NOT NULL,
	[ReturnDate] [date] NULL,

	CONSTRAINT [PK_loans] PRIMARY KEY (LoanID),
	CONSTRAINT [FK_Loans_Books] FOREIGN KEY (BookID) REFERENCES dbo.Books (BookID),
	CONSTRAINT [FK_Loans_Users] FOREIGN KEY (UserID) REFERENCES dbo.Users (UserID)
)

CREATE TABLE dbo.BooksAuthors(
	[BookID] [int] NOT NULL,
	[AuthorID] [int] NOT NULL,

	CONSTRAINT [PK_booksauthors] PRIMARY KEY (BookID, AuthorID),
	CONSTRAINT [FK_BooksAuthors_Books] FOREIGN KEY (BookID) REFERENCES dbo.Books (BookID),
	CONSTRAINT [FK_BooksAuthors_Authors] FOREIGN KEY (AuthorID) REFERENCES dbo.Authors (AuthorID)
)
