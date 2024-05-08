using BCrypt.Net;
namespace FoodForThoughtBusiness
{
	public class SecurityHelper
	{
	public static string GeneratePasswordHash(string password)
		{
			return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
		}
		public static bool VerifyPassword(string password, string passwordHash)
		{
            try
            {
                return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
            }
            catch (BCrypt.Net.SaltParseException)
            {
                // Password hash is in an invalid format
                Console.WriteLine("An error occurred: Invalid password hash format.");
                return false; // Return false to indicate verification failure
            }
            catch (Exception ex)
            {
                // Other exceptions
                Console.WriteLine("An error occurred during password verification: " + ex.Message);
                return false; // Return false to indicate verification failure
            }
        }
		public static string GetDBConnectionString()
		{
			string connString = "Server=(localdb)\\MSSQLLocalDB;Database=FoodForThought;Trusted_Connection = true;";
			return connString;
		}
	}
}
