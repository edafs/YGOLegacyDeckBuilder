
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


/******************************************
	CREATE THE LEGALITY STATUS TABLE
******************************************/

CREATE TABLE Restrictions(
	RestrictionID	INT NOT NULL,
    Title			VARCHAR(50) NOT NULL,
    Summary			VARCHAR (200) NOT NULL,
    
    CONSTRAINT PK_Restrictions PRIMARY KEY (RestrictionID)
);