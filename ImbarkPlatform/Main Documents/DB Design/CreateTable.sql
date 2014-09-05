USE ImbarkPlatform
GO
IF EXISTS (SELECT TOP 1 * from sysobjects WHERE id = object_id(N'UserInfo') and type='U')
DROP TABLE UserInfo
GO
CREATE TABLE UserInfo(
	[UserId] int NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Nickname] nvarchar(32) NOT NULL,
	[Email] nvarchar(64) NOT NULL,
	[Password] nvarchar(32) NOT NULL,
	[IsActive] bit,
	[ActiveCode] nvarchar(64),
	[ActiveCodeExpireTime] datetime,
	[LastActiveTime] datetime,
	[Role] smallint)
GO