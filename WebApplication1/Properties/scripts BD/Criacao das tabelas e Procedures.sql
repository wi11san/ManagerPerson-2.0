
CREATE TABLE [dbo].[Person] (
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(70) NOT NULL,
	[Email] VARCHAR(100) NOT NULL,
	[CPF] VARCHAR(15) NOT NULL UNIQUE,
	[Office] VARCHAR(100) NULL,
	[Salary] DECIMAL NULL,
	[Active] BIT NULL

	CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC),
);

go


-- Store Procedures na tabela de Person
CREATE PROCEDURE dbo.FindAllPeople
as
SELECT P.* FROM Person P
ORDER BY P.Id asc;
go


CREATE PROCEDURE dbo.FindPersonById
(
	@id int
)
AS
	SELECT P.* FROM Person P
    WHERE P.Id = @id;
go


CREATE PROCEDURE dbo.InsertPerson
(
	@name varchar(70),
	@email varchar(100),
	@CPF varchar(15),
	@office varchar(100),
	@salary decimal,
	@active bit
)
AS
	INSERT INTO [dbo].[Person] (Name, Email, CPF, Office, Salary, Active) VALUES
	(@name, @email, @CPF, @office, @salary, @active); 
	SELECT CAST(scope_identity() AS int);
go



CREATE PROCEDURE dbo.UpdatePerson
(
	@id int,
	@name varchar(70),
	@CPF varchar(15),
	@email varchar(100),
	@office varchar(100),
	@salary decimal,
	@active bit
)
AS 
	UPDATE [dbo].[Person] SET
	Name = @name,
	Email = @email,
	CPF = @CPF,
	Office = @office,
	Salary = @salary,
	Active = @active
	WHERE Id = @id
go

CREATE PROCEDURE dbo.DeletePerson
(
	@id int
)
AS
	DELETE FROM [dbo].[Person] WHERE Id = @id
go
	