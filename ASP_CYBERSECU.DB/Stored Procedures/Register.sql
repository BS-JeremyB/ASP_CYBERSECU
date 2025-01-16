CREATE PROCEDURE [dbo].[Register]
	@Username NVARCHAR(255),
	@Email NVARCHAR(255),
	@Password NVARCHAR(25)
AS
BEGIN

	DECLARE @Salt VARCHAR(50)
	DECLARE @HashedPassword VARBINARY(64)
	DECLARE @Pepper VARCHAR(100)

	SET @Pepper = dbo.GetPepper()
	SET @Salt = CONVERT(VARCHAR(50),NEWID())
	SET @HashedPassword = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password, @Pepper))

	INSERT INTO [Utilisateur] (Username, Email, Password, Salt) OUTPUT inserted.Id VALUES (@Username, @Email, @HashedPassword, @Salt)

END