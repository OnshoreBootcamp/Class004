USE [master]
GO
/****** Object:  Database [MovieDB]    Script Date: 3/17/2014 10:21:46 AM ******/
CREATE DATABASE [MovieDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MovieDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\MovieDB.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MovieDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\MovieDB_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MovieDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MovieDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MovieDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MovieDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MovieDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MovieDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MovieDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MovieDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MovieDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MovieDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MovieDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MovieDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MovieDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MovieDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MovieDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MovieDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MovieDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MovieDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MovieDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MovieDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MovieDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MovieDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MovieDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MovieDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MovieDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MovieDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MovieDB] SET  MULTI_USER 
GO
ALTER DATABASE [MovieDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MovieDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MovieDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MovieDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [MovieDB]
GO
/****** Object:  StoredProcedure [dbo].[CreateAccount]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateAccount]
	@UserId INT
	,@MovieId INT
AS
BEGIN
	INSERT INTO Account
	VALUES (@UserId, @MovieId)
END



GO
/****** Object:  StoredProcedure [dbo].[CreateAddress]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateAddress]
	@Street VARCHAR(30)
	,@City VARCHAR(30)
	,@State VARCHAR(30)
	,@Zip VARCHAR(30)
AS
BEGIN
	INSERT INTO [Address]
	VALUES (@Street, @City, @State, @Zip)
END



GO
/****** Object:  StoredProcedure [dbo].[CreateGenre]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateGenre]
	@Genre VARCHAR(15)
AS
BEGIN
	INSERT INTO Genre
	VALUES (@Genre)
END



GO
/****** Object:  StoredProcedure [dbo].[CreateModel]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateModel]
	@Model VARCHAR(30)
AS
BEGIN
	INSERT INTO Model
	VALUES (@Model)
END

GO
/****** Object:  StoredProcedure [dbo].[CreateMovie]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateMovie]
	@Title VARCHAR(30)
	,@ReleaseDate DATETIME
	,@GenreId INT
AS
BEGIN
	INSERT INTO Movie
	VALUES (@Title, @ReleaseDate, @GenreId)
END



GO
/****** Object:  StoredProcedure [dbo].[CreatePerson]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreatePerson]
	@LastName VARCHAR(30)
	,@FirstName VARCHAR(30)
	,@Email VARCHAR(60)
AS
BEGIN
	INSERT INTO Person
	VALUES (@LastName, @FirstName, @Email)
END



GO
/****** Object:  StoredProcedure [dbo].[CreatePersonAddress]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreatePersonAddress]
	@PersonId INT
	,@AddressId INT
	,@TypeId INT
AS
BEGIN
	INSERT INTO PersonAddress
	VALUES (@PersonId, @AddressId, @TypeId)
END



GO
/****** Object:  StoredProcedure [dbo].[CreatePersonPhone]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreatePersonPhone]
	@PersonId INT
	,@PhoneId INT
	,@TypeId INT
AS
BEGIN
	INSERT INTO PersonPhone
	VALUES (@PersonId, @PhoneId, @TypeId)
END



GO
/****** Object:  StoredProcedure [dbo].[CreatePhone]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreatePhone]
	@Number VARCHAR(15)
AS
BEGIN
	INSERT INTO Phone
	VALUES (@Number)
END



GO
/****** Object:  StoredProcedure [dbo].[CreateSize]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateSize]
	@Size VARCHAR(30)
AS
BEGIN
	INSERT INTO Size
	VALUES (@Size)
END

GO
/****** Object:  StoredProcedure [dbo].[CreateType]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateType]
	@Type VARCHAR(20)
AS
BEGIN
	INSERT INTO [Type]
	VALUES (@Type)
END



GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateUser]
	@PersonAddressId INT
	,@PersonPhoneId INT
AS
BEGIN
	INSERT INTO [User]
	VALUES (@PersonAddressId, @PersonPhoneId)
END




GO
/****** Object:  StoredProcedure [dbo].[DeleteAccount]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteAccount]
	@Id INT
	
AS
BEGIN
	DELETE FROM Account
	WHERE id = @Id
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteMovieById]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteMovieById]
	@Id INT
AS
BEGIN
	DELETE FROM Movie
	WHERE id = @Id
END




GO
/****** Object:  StoredProcedure [dbo].[DeleteUserById]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUserById]
	@Id INT
AS
BEGIN
	DELETE FROM [User]
	WHERE id = @Id
END




GO
/****** Object:  StoredProcedure [dbo].[GetAccountById]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAccountById]
	@Id INT
AS
BEGIN
	SELECT *
	FROM Account
	WHERE id = @Id
END



GO
/****** Object:  StoredProcedure [dbo].[GetAccountId]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAccountId]
	@UserId INT
	,@MovieId INT
AS
BEGIN
	SELECT *
	FROM Account
	WHERE userId = @UserId AND movieId = @MovieId
END



GO
/****** Object:  StoredProcedure [dbo].[GetAddressById]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAddressById]
	@Id INT
AS
BEGIN
	SELECT *
	FROM [Address]
	WHERE id = @Id
END



GO
/****** Object:  StoredProcedure [dbo].[GetAddressId]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAddressId]
	@Street VARCHAR(30)
	,@City VARCHAR(30)
	,@State VARCHAR(30)
	,@Zip VARCHAR(30)
AS
BEGIN
	SELECT *
	FROM [Address]
	WHERE street = @Street AND city =  @City AND [state] =  @State AND	zip = @Zip
END



GO
/****** Object:  StoredProcedure [dbo].[GetAllAccounts]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllAccounts]
	
AS
BEGIN
	SELECT *
	FROM Account
END



GO
/****** Object:  StoredProcedure [dbo].[GetAllMovies]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllMovies]
	
AS
BEGIN
	SELECT id AS MovieId, title, releaseDate, genreId 
	FROM Movie
END




GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllUsers]
	
AS
BEGIN
	SELECT id AS UserId, personAddressId, personPhoneId
	FROM [User]
END



GO
/****** Object:  StoredProcedure [dbo].[GetGenreById]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetGenreById]
	@Id	INT
AS
BEGIN
	SELECT *
	FROM Genre
	WHERE id = @Id
END




GO
/****** Object:  StoredProcedure [dbo].[GetGenreIdByGenreName]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetGenreIdByGenreName]
	@Genre VARCHAR(15)
AS
BEGIN
	SELECT * 
	FROM Genre
	WHERE genre = @Genre
END




GO
/****** Object:  StoredProcedure [dbo].[GetModelById]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetModelById]
	@Id INT
AS
BEGIN
	SELECT *
	FROM Model
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[GetModelId]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetModelId]
	@Model VARCHAR(30)
AS
BEGIN
	SELECT *
	FROM Model
	WHERE model = @Model
END

GO
/****** Object:  StoredProcedure [dbo].[GetMovieById]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMovieById]
	@Id INT
AS
BEGIN
	SELECT m.id AS movieId, title, releaseDate, genreId, genre
	FROM Movie AS m
	JOIN Genre AS g
	ON m.genreId = g.id
	WHERE m.id = @Id
END




GO
/****** Object:  StoredProcedure [dbo].[GetMovieId]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMovieId]
	@Title VARCHAR(30)
	,@ReleaseDate DATETIME
	,@GenreId INT
AS
BEGIN
	SELECT *
	FROM Movie
	WHERE title = @Title AND releaseDate = @ReleaseDate AND genreId = @GenreId
END



GO
/****** Object:  StoredProcedure [dbo].[GetPersonAddressById]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPersonAddressById]
	@Id INT
AS
BEGIN
	SELECT *
	FROM PersonAddress
	WHERE id = @Id
END



GO
/****** Object:  StoredProcedure [dbo].[GetPersonAddressId]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPersonAddressId]
	@PersonId INT
	,@AddressId INT
	,@TypeId INT
AS
BEGIN
	SELECT *
	FROM PersonAddress
	WHERE personId = @PersonId AND addressId = @AddressId AND typeId = @TypeId
END



GO
/****** Object:  StoredProcedure [dbo].[GetPersonById]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPersonById]
	@Id INT
AS
BEGIN
	SELECT *
	FROM Person
	WHERE id = @Id
END



GO
/****** Object:  StoredProcedure [dbo].[GetPersonId]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPersonId]
	@LastName VARCHAR(30)
	,@FirstName VARCHAR(30)
	,@Email VARCHAR(30)
AS
BEGIN
	SELECT *
	FROM Person
	WHERE lastName = @LastName AND firstName = @FirstName AND email = @Email
END



GO
/****** Object:  StoredProcedure [dbo].[GetPersonPhoneById]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPersonPhoneById]
	@Id INT
AS
BEGIN
	SELECT *
	FROM PersonPhone
	WHERE id = @Id
END



GO
/****** Object:  StoredProcedure [dbo].[GetPersonPhoneId]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPersonPhoneId]
	@PersonId INT
	,@PhoneId INT
	,@TypeId INT
AS
BEGIN
	SELECT *
	FROM PersonPhone
	WHERE personId = @PersonId AND phoneId = @PhoneId AND typeId = @TypeId
END



GO
/****** Object:  StoredProcedure [dbo].[GetPhoneById]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPhoneById]
	@Id INT
AS
BEGIN
	SELECT *
	FROM Phone
	WHERE id = @Id
END



GO
/****** Object:  StoredProcedure [dbo].[GetPhoneIdByNumber]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPhoneIdByNumber]
	@Number VARCHAR(15)
AS
BEGIN
	SELECT *
	FROM Phone
	WHERE number = @Number
END



GO
/****** Object:  StoredProcedure [dbo].[GetSizeById]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSizeById]
	@Id INT
AS
BEGIN
	SELECT *
	FROM Size
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[GetSizeId]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSizeId]
	@Size VARCHAR(30)
AS
BEGIN
	SELECT *
	FROM Size
	WHERE size = @Size
END

GO
/****** Object:  StoredProcedure [dbo].[GetTypeById]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTypeById]
	@Id	INT
AS
BEGIN
	SELECT *
	FROM [Type]
	WHERE id = @Id
END



GO
/****** Object:  StoredProcedure [dbo].[GetTypeIdByTypeName]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTypeIdByTypeName]
	@Type VARCHAR(20)
AS
BEGIN
	SELECT * 
	FROM [Type]
	WHERE [type] = @Type
END



GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUser]
	@PersonAddressId INT
	,@PersonPhoneId INT
AS
BEGIN
	SELECT *
	FROM [User]
	WHERE personAddressId = @PersonAddressId AND personPhoneId = @PersonAddressId
END


GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserById]
	@Id INT
AS
BEGIN
	SELECT *
	FROM [User]
	WHERE id = @Id
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateAccount]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateAccount]
	@Id INT
	,@UserId INT
	,@MovieId INT
AS
BEGIN
	UPDATE Account
	SET userId = @UserId,
		movieId = @MovieId
	WHERE id = @Id
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateMovie]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateMovie]
	@Id INT
	,@Title VARCHAR(30)
	,@ReleaseDate DATETIME
	,@GenreId INT
AS
BEGIN
	UPDATE Movie
	SET title = @Title,
		releaseDate = @ReleaseDate,
		genreId = @GenreId
	WHERE id = @Id
END




GO
/****** Object:  StoredProcedure [dbo].[UpdatePersonAddress]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdatePersonAddress]
	@Id INT
	,@PersonId INT
	,@AddressId INT
	,@TypeId INT
AS
BEGIN
	UPDATE PersonAddress
	SET personId = @PersonId,
		addressId = @AddressId,
		typeId = @TypeId
	WHERE id = @Id
END



GO
/****** Object:  StoredProcedure [dbo].[UpdatePersonPhone]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdatePersonPhone]
	@Id INT
	,@PersonId INT
	,@PhoneId INT
	,@TypeId INT
AS
BEGIN
	UPDATE PersonPhone
	SET personId = @PersonId,
		phoneId = @PhoneId,
		typeId = @TypeId
	WHERE id = @Id
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateUser]
	@Id INT
	,@PersonAddressId INT
	,@PersonPhoneId INT
AS
BEGIN
	UPDATE [User]
	SET personAddressId = @PersonAddressId,
		personPhoneId = @PersonPhoneId
	WHERE id = @Id
END




GO
/****** Object:  Table [dbo].[Account]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[movieId] [int] NOT NULL,
	[userId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Address]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[street] [varchar](30) NOT NULL,
	[city] [varchar](30) NOT NULL,
	[state] [varchar](30) NOT NULL,
	[zip] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genre](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[genre] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Movie](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](30) NOT NULL,
	[releaseDate] [datetime] NOT NULL,
	[genreId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Person]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[lastName] [varchar](30) NOT NULL,
	[firstName] [varchar](30) NOT NULL,
	[email] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PersonAddress]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonAddress](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[personId] [int] NOT NULL,
	[addressId] [int] NOT NULL,
	[typeId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonPhone]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonPhone](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[personId] [int] NOT NULL,
	[phoneId] [int] NOT NULL,
	[typeId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Phone]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Phone](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[number] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Type]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/17/2014 10:21:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[personAddressId] [int] NOT NULL,
	[personPhoneId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([movieId])
REFERENCES [dbo].[Movie] ([id])
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD FOREIGN KEY([genreId])
REFERENCES [dbo].[Genre] ([id])
GO
ALTER TABLE [dbo].[PersonAddress]  WITH CHECK ADD FOREIGN KEY([addressId])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[PersonAddress]  WITH CHECK ADD FOREIGN KEY([personId])
REFERENCES [dbo].[Person] ([id])
GO
ALTER TABLE [dbo].[PersonAddress]  WITH CHECK ADD FOREIGN KEY([typeId])
REFERENCES [dbo].[Type] ([id])
GO
ALTER TABLE [dbo].[PersonPhone]  WITH CHECK ADD FOREIGN KEY([personId])
REFERENCES [dbo].[Person] ([id])
GO
ALTER TABLE [dbo].[PersonPhone]  WITH CHECK ADD FOREIGN KEY([phoneId])
REFERENCES [dbo].[Phone] ([id])
GO
ALTER TABLE [dbo].[PersonPhone]  WITH CHECK ADD FOREIGN KEY([typeId])
REFERENCES [dbo].[Type] ([id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([personAddressId])
REFERENCES [dbo].[PersonAddress] ([id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([personPhoneId])
REFERENCES [dbo].[PersonPhone] ([id])
GO
USE [master]
GO
ALTER DATABASE [MovieDB] SET  READ_WRITE 
GO
