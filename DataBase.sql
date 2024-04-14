-- SQL Manager for SQL Server 4.4.1.49818
-- ---------------------------------------
-- Host      : (local)
-- Database  : Test
-- Version   : Microsoft SQL Server 2014 12.0.2000.8


--
-- Definition for table Countries : 
--

CREATE TABLE dbo.Countries (
  IATACode varchar(2) COLLATE Modern_Spanish_CI_AS NOT NULL,
  Name varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
  ID int IDENTITY(1, 1) NOT NULL,
  DIANCode varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
  CONSTRAINT PK_Countries PRIMARY KEY CLUSTERED (IATACode)
    WITH (
      PAD_INDEX = OFF, FILLFACTOR = 90, IGNORE_DUP_KEY = OFF,
      STATISTICS_NORECOMPUTE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table Cities : 
--

CREATE TABLE dbo.Cities (
  IATACode varchar(5) COLLATE Modern_Spanish_CI_AS NOT NULL,
  Name varchar(200) COLLATE Modern_Spanish_CI_AS NOT NULL,
  CountryIATACode varchar(2) COLLATE Modern_Spanish_CI_AS NOT NULL,
  StateName varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
  CONSTRAINT PK_Cities PRIMARY KEY CLUSTERED (IATACode)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table IdentificationDocuments : 
--

CREATE TABLE dbo.IdentificationDocuments (
  ID int IDENTITY(1, 1) NOT NULL,
  Name varchar(65) COLLATE Modern_Spanish_CI_AS NULL,
  CONSTRAINT PK_IdentificationDocuments PRIMARY KEY CLUSTERED (ID)
    WITH (
      PAD_INDEX = OFF, FILLFACTOR = 90, IGNORE_DUP_KEY = OFF,
      STATISTICS_NORECOMPUTE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table ThirdParties : 
--

CREATE TABLE dbo.ThirdParties (
  ID int IDENTITY(1, 1) NOT NULL,
  FirstName varchar(200) COLLATE Modern_Spanish_CI_AS NULL,
  LastName varchar(200) COLLATE Modern_Spanish_CI_AS NULL,
  DocumentTypeID int NOT NULL,
  DocumentNumber varchar(50) COLLATE Modern_Spanish_CI_AS NOT NULL,
  CityIataCode varchar(5) COLLATE Modern_Spanish_CI_AS NULL,
  PhoneNumber varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
  FaxNumber varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
  Address varchar(100) COLLATE Modern_Spanish_CI_AS NULL,
  MobilePhoneNumber varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
  Email varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
  CountryID int NULL,
  VerificationDigit int NULL,
  CONSTRAINT PK_ThirdParties PRIMARY KEY CLUSTERED (ID)
    WITH (
      PAD_INDEX = OFF, FILLFACTOR = 90, IGNORE_DUP_KEY = OFF,
      STATISTICS_NORECOMPUTE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for stored procedure PRC_Cities : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PRC_Cities] 
	(@MODO INT,
	@IATACode varchar(5) = NULL,
	@Name varchar(200) = NULL,
	@CountryIATACode varchar(2) = NULL,
	@StateName varchar(50) = NULL
)
AS BEGIN
IF @MODO=1
BEGIN
	IF EXISTS(Select * FROM [dbo].[Cities] WHERE IATACode =  @IATACode)
	BEGIN
		UPDATE [dbo].[Cities] SET 

		Name = @Name,
		CountryIATACode = @CountryIATACode,
		StateName = @StateName

		WHERE
		IATACode =  @IATACode
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[Cities] (
		Name,
		CountryIATACode,
		StateName
) VALUES (
		@Name,
		@CountryIATACode,
		@StateName
)

	END
	SELECT 	IATACode,
	Name,
	CountryIATACode,
	StateName

	FROM [dbo].[Cities]
END
IF @MODO=2
BEGIN
	SELECT 	IATACode,
	Name,
	CountryIATACode,
	StateName

	FROM [dbo].[Cities]
END
IF @MODO=3
BEGIN
	DELETE FROM [dbo].[Cities]
	WHERE 
	IATACode =  @IATACode
END

IF @MODO=4
BEGIN
	SELECT 	
    IATACode,
	Name
	FROM [dbo].[Cities]
    where CountryIATACode =  @CountryIATACode
END
END
GO

--
-- Definition for stored procedure PRC_Countries : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PRC_Countries] 
	(@MODO INT,
	@IATACode varchar(2) = NULL,
	@Name varchar(50) = NULL,
	@ID int = NULL,
	@DIANCode varchar(50) = NULL
)
AS BEGIN
IF @MODO=1
BEGIN
	IF EXISTS(Select * FROM [dbo].[Countries] WHERE IATACode =  @IATACode)
	BEGIN
		UPDATE [dbo].[Countries] SET 

		Name = @Name,
		DIANCode = @DIANCode

		WHERE
		IATACode =  @IATACode
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[Countries] (
		Name,
		DIANCode
) VALUES (
		@Name,
		@DIANCode
)

	END
	SELECT 	IATACode,
	Name,
	ID,
	DIANCode

	FROM [dbo].[Countries]
END
IF @MODO=2
BEGIN
	SELECT 	
    ID,
	Name
	FROM [dbo].[Countries]
END
IF @MODO=3
BEGIN
	DELETE FROM [dbo].[Countries]
	WHERE 
	IATACode =  @IATACode
END
IF @MODO=4
BEGIN
	SELECT 	
    C.IATACode,
	C.Name
	FROM [dbo].Countries
    INNER JOIN dbo.Cities C ON (C.CountryIATACode=[dbo].Countries.IATACode)
    where [dbo].Countries.ID =  @ID
END
END
GO

--
-- Definition for stored procedure PRC_IdentificationDocuments : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PRC_IdentificationDocuments] 
	(@MODO INT,
	@ID int = NULL,
	@Name varchar(65) = NULL
)
AS BEGIN
IF @MODO=1
BEGIN
	IF EXISTS(Select * FROM [dbo].[IdentificationDocuments] WHERE ID =  @ID)
	BEGIN
		UPDATE [dbo].[IdentificationDocuments] SET 

		Name = @Name

		WHERE
		ID =  @ID
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[IdentificationDocuments] (
		Name
) VALUES (
		@Name
)

	END
	SELECT 	ID,
	Name

	FROM [dbo].[IdentificationDocuments]
END
IF @MODO=2
BEGIN
	SELECT 	ID,
	Name

	FROM [dbo].[IdentificationDocuments]
END
IF @MODO=3
BEGIN
	DELETE FROM [dbo].[IdentificationDocuments]
	WHERE 
	ID =  @ID
END
END
GO

--
-- Definition for stored procedure PRC_ThirdParties : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PRC_ThirdParties] 
	(@MODO INT,
	@ID int = NULL,
	@FirstName varchar(200) = NULL,
	@LastName varchar(200) = NULL,
	@DocumentTypeID int = NULL,
	@DocumentNumber varchar(50) = NULL,
	@CityIataCode varchar(5) = NULL,
	@PhoneNumber varchar(50) = NULL,
	@FaxNumber varchar(50) = NULL,
	@Address varchar(100) = NULL,
	@MobilePhoneNumber varchar(50) = NULL,
	@Email varchar(50) = NULL,
	@CountryID int = NULL,
	@VerificationDigit int = NULL
)
AS BEGIN
IF @MODO=1
BEGIN
	IF EXISTS(Select * FROM [dbo].[ThirdParties] WHERE ID =  @ID)
	BEGIN
		UPDATE [dbo].[ThirdParties] SET 

		FirstName = @FirstName,
		LastName = @LastName,
		DocumentTypeID = @DocumentTypeID,
		DocumentNumber = @DocumentNumber,
		CityIataCode = @CityIataCode,
		PhoneNumber = @PhoneNumber,
		FaxNumber = @FaxNumber,
		Address = @Address,
		MobilePhoneNumber = @MobilePhoneNumber,
		Email = @Email,
		CountryID = @CountryID,
		VerificationDigit = @VerificationDigit

		WHERE
		ID =  @ID
	END
	ELSE
	BEGIN
    
    	IF (@DocumentTypeID=1)
        BEGIN 
        	DECLARE @PRIMEROS VARCHAR(3)
            SET @PRIMEROS=LEFT(@DocumentNumber,3)
            
            DECLARE @ULTIMOS VARCHAR(3)
            SET @ULTIMOS=RIGHT(@DocumentNumber,3)
            
            DECLARE @SUMA VARCHAR(4) 
            SET @SUMA=CAST(( CAST(@PRIMEROS AS INT)+CAST(@ULTIMOS AS INT)) AS VARCHAR(4))
            
            SET @VerificationDigit=CAST(RIGHT(@SUMA ,1) AS INT)
        END
       
    	IF (@DocumentTypeID=12)
        BEGIN   
        	DECLARE @NUMERO INT=0
            DECLARE @RESULTADO INT=0
            SET @NUMERO=CAST(@DocumentNumber AS INT)
            WHILE @NUMERO > 0  
            BEGIN  
                SET @RESULTADO = @RESULTADO+(@NUMERO % 10)
                SET @NUMERO = @NUMERO/10
            END
            
            SET @RESULTADO = @RESULTADO/2
            SET @VerificationDigit=RIGHT((CAST (@RESULTADO AS VARCHAR(3))),1)
            
        END    
    
    
		INSERT INTO [dbo].[ThirdParties] (
		FirstName,
		LastName,
		DocumentTypeID,
		DocumentNumber,
		CityIataCode,
		PhoneNumber,
		FaxNumber,
		Address,
		MobilePhoneNumber,
		Email,
		CountryID,
		VerificationDigit
) VALUES (
		@FirstName,
		@LastName,
		@DocumentTypeID,
		@DocumentNumber,
		@CityIataCode,
		@PhoneNumber,
		@FaxNumber,
		@Address,
		@MobilePhoneNumber,
		@Email,
		@CountryID,
		@VerificationDigit
)

	END
	SELECT 	ID,
	FirstName,
	LastName,
	DocumentTypeID,
	DocumentNumber,
	CityIataCode,
	PhoneNumber,
	FaxNumber,
	Address,
	MobilePhoneNumber,
	Email,
	CountryID,
	VerificationDigit

	FROM [dbo].[ThirdParties]
END
IF @MODO=2
BEGIN
	SELECT TP.ID,
	FirstName,
	LastName,
	IDOC.Name AS Document,
	DocumentNumber,
	CI.Name AS City,
	PhoneNumber,
	FaxNumber,
	Address,
	MobilePhoneNumber,
	Email,
	CO.Name AS Countri,
	VerificationDigit
	FROM [dbo].[ThirdParties] TP
    INNER JOIN DBO.Countries CO ON (CO.ID=TP.CountryID)
    INNER JOIN dbo.Cities CI ON (CI.IATACode=TP.CityIataCode)
    INNER JOIN DBO.IdentificationDocuments IDOC ON(IDOC.ID=TP.DocumentTypeID)
    
END
IF @MODO=3
BEGIN
	DELETE FROM [dbo].[ThirdParties]
	WHERE 
	ID =  @ID
END
END
GO

--
-- Data for table dbo.Cities  (LIMIT 0,500)
--

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'BER', N'Berlín', N'DE', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'BHZ', N'Belo Horizonte', N'BR', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'BRS', N'Bristol', N'GB', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'CDMX', N'Ciudad de México', N'MX', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'CHI', N'Chicago', N'US', N'Illinois')
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'GDL', N'Guadalajara', N'MX', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'GZB', N'Guangzhou', N'CN', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'HAM', N'Hamburgo', N'DE', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'HOU', N'Houston', N'US', N'Texas')
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'KYT', N'Kioto', N'JP', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'LAX', N'Los Ángeles', N'US', N'California')
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'LON', N'Londres', N'GB', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'LYO', N'Lyon', N'FR', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'MAN', N'Manchester', N'GB', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'MIA', N'Miami', N'US', N'Florida')
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'MRS', N'Marsella', N'FR', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'MTL', N'Montreal', N'CA', N'Quebec')
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'MTY', N'Monterrey', N'MX', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'MUN', N'Múnich', N'DE', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'NYC', N'Nueva York', N'US', N'Nueva York')
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'OSA', N'Osaka', N'JP', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'PAR', N'París', N'FR', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'PEK', N'Pekín', N'CN', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'RIO', N'Río de Janeiro', N'BR', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'SAO', N'São Paulo', N'BR', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'SHA', N'Shanghái', N'CN', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'TOK', N'Tokio', N'JP', NULL)
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'TOR', N'Toronto', N'CA', N'Ontario')
GO

INSERT INTO dbo.Cities (IATACode, Name, CountryIATACode, StateName)
VALUES 
  (N'VAN', N'Vancouver', N'CA', N'Columbia Británica')
GO

--
-- Data for table dbo.Countries  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.Countries ON
GO

INSERT INTO dbo.Countries (IATACode, Name, ID, DIANCode)
VALUES 
  (N'BR', N'Brasil', 10, N'BRA')
GO

INSERT INTO dbo.Countries (IATACode, Name, ID, DIANCode)
VALUES 
  (N'CA', N'Canadá', 3, N'CAN')
GO

INSERT INTO dbo.Countries (IATACode, Name, ID, DIANCode)
VALUES 
  (N'CN', N'China', 9, N'CHN')
GO

INSERT INTO dbo.Countries (IATACode, Name, ID, DIANCode)
VALUES 
  (N'DE', N'Alemania', 7, N'DEU')
GO

INSERT INTO dbo.Countries (IATACode, Name, ID, DIANCode)
VALUES 
  (N'FR', N'Francia', 6, N'FRA')
GO

INSERT INTO dbo.Countries (IATACode, Name, ID, DIANCode)
VALUES 
  (N'GB', N'Reino Unido', 5, N'GBR')
GO

INSERT INTO dbo.Countries (IATACode, Name, ID, DIANCode)
VALUES 
  (N'IN', N'India', 11, N'IND')
GO

INSERT INTO dbo.Countries (IATACode, Name, ID, DIANCode)
VALUES 
  (N'JP', N'Japón', 8, N'JPN')
GO

INSERT INTO dbo.Countries (IATACode, Name, ID, DIANCode)
VALUES 
  (N'MX', N'México', 4, N'MEX')
GO

INSERT INTO dbo.Countries (IATACode, Name, ID, DIANCode)
VALUES 
  (N'US', N'Estados Unidos', 2, N'USA')
GO

SET IDENTITY_INSERT dbo.Countries OFF
GO

--
-- Data for table dbo.IdentificationDocuments  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.IdentificationDocuments ON
GO

INSERT INTO dbo.IdentificationDocuments (ID, Name)
VALUES 
  (1, N'Cédula de Identidad')
GO

INSERT INTO dbo.IdentificationDocuments (ID, Name)
VALUES 
  (2, N'Pasaporte')
GO

INSERT INTO dbo.IdentificationDocuments (ID, Name)
VALUES 
  (3, N'Licencia de Conducir')
GO

INSERT INTO dbo.IdentificationDocuments (ID, Name)
VALUES 
  (4, N'Tarjeta de Identificación Nacional')
GO

INSERT INTO dbo.IdentificationDocuments (ID, Name)
VALUES 
  (5, N'Documento Nacional de Identidad (DNI)')
GO

INSERT INTO dbo.IdentificationDocuments (ID, Name)
VALUES 
  (6, N'Carné de Estudiante')
GO

INSERT INTO dbo.IdentificationDocuments (ID, Name)
VALUES 
  (7, N'Tarjeta de Residencia')
GO

INSERT INTO dbo.IdentificationDocuments (ID, Name)
VALUES 
  (8, N'Carné de Empleado')
GO

INSERT INTO dbo.IdentificationDocuments (ID, Name)
VALUES 
  (9, N'Documento de Identificación Personal (DIP)')
GO

INSERT INTO dbo.IdentificationDocuments (ID, Name)
VALUES 
  (10, N'Tarjeta Sanitaria')
GO

INSERT INTO dbo.IdentificationDocuments (ID, Name)
VALUES 
  (11, N'Tarjeta de Seguro Social')
GO

INSERT INTO dbo.IdentificationDocuments (ID, Name)
VALUES 
  (12, N'Número de Identificación Tributaria')
GO

SET IDENTITY_INSERT dbo.IdentificationDocuments OFF
GO

--
-- Data for table dbo.ThirdParties  (LIMIT 0,500)
--

SET IDENTITY_INSERT dbo.ThirdParties ON
GO

INSERT INTO dbo.ThirdParties (ID, FirstName, LastName, DocumentTypeID, DocumentNumber, CityIataCode, PhoneNumber, FaxNumber, Address, MobilePhoneNumber, Email, CountryID, VerificationDigit)
VALUES 
  (3, N'VICTOR', N'CUSI', 1, N'79135806', N'BHZ', N'123', N'1233', N'123331', N'12333333', N'12322222', 10, 7)
GO

INSERT INTO dbo.ThirdParties (ID, FirstName, LastName, DocumentTypeID, DocumentNumber, CityIataCode, PhoneNumber, FaxNumber, Address, MobilePhoneNumber, Email, CountryID, VerificationDigit)
VALUES 
  (4, N'VICTOR', N'CUSI', 12, N'123456789', N'BHZ', N'123', N'1233', N'123331', N'12333333', N'12322222', 10, 2)
GO

SET IDENTITY_INSERT dbo.ThirdParties OFF
GO

--
-- Definition for indices : 
--

ALTER TABLE dbo.ThirdParties
ADD CONSTRAINT IX_ThirdParties 
UNIQUE NONCLUSTERED (DocumentTypeID, DocumentNumber)
WITH (
  PAD_INDEX = OFF,
  FILLFACTOR = 90,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

--
-- Definition for foreign keys : 
--

ALTER TABLE dbo.Cities
ADD CONSTRAINT FK_Cities_Countries FOREIGN KEY (CountryIATACode) 
  REFERENCES dbo.Countries (IATACode) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.ThirdParties
WITH NOCHECK ADD CONSTRAINT FK_ThirdParties_Cities FOREIGN KEY (CityIataCode) 
  REFERENCES dbo.Cities (IATACode) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.ThirdParties
WITH NOCHECK ADD CONSTRAINT FK_ThirdParties_IdentificationDocuments FOREIGN KEY (DocumentTypeID) 
  REFERENCES dbo.IdentificationDocuments (ID) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

