/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

EXEC [dbo].[Register] 
    @Email = 'john.doe@example.com',
    @Password = 'Test1234=',
    @Username = 'JohnDoe';

EXEC [dbo].[Register] 
    @Email = 'jane.smith@example.com',
    @Password = 'Password123!',
    @Username = 'JaneSmith';

EXEC [dbo].[Register] 
    @Email = 'alice.brown@example.com',
    @Password = 'Password123!',
    @Username = 'AliceBrown';

EXEC [dbo].[Register] 
    @Email = 'bob.jones@example.com',
    @Password = 'Password123!',
    @Username = 'BobJones';

EXEC [dbo].[Register] 
    @Email = 'charlie.miller@example.com',
    @Password = 'Password123!',
    @Username = 'CharlieMiller';