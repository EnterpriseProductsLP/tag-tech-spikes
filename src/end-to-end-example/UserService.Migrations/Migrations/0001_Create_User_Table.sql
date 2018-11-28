CREATE TABLE dbo.[User]
	(
	Id bigint NOT NULL,
	FirstName varchar(100) NOT NULL,
	LastName varchar(100) NOT NULL,
	Password varchar(100) NOT NULL,
	Username varchar(100) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.[User] ADD CONSTRAINT
	PK_User PRIMARY KEY CLUSTERED 
	(
	UserId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
