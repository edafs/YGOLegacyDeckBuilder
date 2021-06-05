/*******************************
	CREATE A USER FOR THE DB
*******************************/

CREATE USER YgoDbUser
	IDENTIFIED BY 'SomeSecurePassword!';

/****************************
	CREATE THE MAIN TABLE
****************************/

CREATE TABLE CardCatalog(
	
	-- Card info
	CardID		INT NOT NULL,
	CardName	VARCHAR(75) NOT NULL,
	ImageUrl	VARCHAR(125) NOT NULL,
	
	-- Format Status
	Format_Sept2011		INT,
	Format_Edison		INT,

	CONSTRAINT PK_CardCatalog PRIMARY KEY (CardID)
);

GRANT INSERT ON CardCatalog TO YgoDbUser;
GRANT SELECT ON CardCatalog TO YgoDbUser;
GRANT UPDATE ON CardCatalog TO YgoDbUser;
GRANT DELETE ON CardCatalog TO YgoDbUser;

/****************************
	CREATE THE SET TABLE
****************************/

CREATE TABLE SetCatalog(
	SetId		INT NOT NULL,
	SetCode		VARCHAR(15) NOT NULL,
	SetName		VARCHAR(150) NOT NULL,
	ReleaseDate	DATETIME NOT NULL,
	CardCount	INT NOT NULL,

	CONSTRAINT PK_SetCatalog PRIMARY KEY (SetId)
);

GRANT INSERT ON SetCatalog TO YgoDbUser;
GRANT SELECT ON SetCatalog TO YgoDbUser;
GRANT UPDATE ON SetCatalog TO YgoDbUser;
GRANT DELETE ON SetCatalog TO YgoDbUser;

/******************************************
	CREATE THE LEGALITY STATUS TABLE
******************************************/

CREATE TABLE Restrictions(
	RestrictionID	INT NOT NULL,
    Title			VARCHAR(50) NOT NULL,
    Summary			VARCHAR (200) NOT NULL,
    
    CONSTRAINT PK_Restrictions PRIMARY KEY (RestrictionID)
);

GRANT INSERT ON Restrictions TO YgoDbUser;
GRANT SELECT ON Restrictions TO YgoDbUser;
GRANT UPDATE ON Restrictions TO YgoDbUser;
GRANT DELETE ON Restrictions TO YgoDbUser;