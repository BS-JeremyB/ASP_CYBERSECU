CREATE PROCEDURE [dbo].[Login]
	@Email NVARCHAR(255),
	@Password NVARCHAR(25)
AS
BEGIN
	
	DECLARE @Pepper VARCHAR(100)

	SET @Pepper =  dbo.GetPepper()

	SELECT *
	FROM [Utilisateur]
	WHERE Email = @Email AND Password = HASHBYTES('SHA2_512', CONCAT(Salt, @Password, @Pepper))

END