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
				return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
		}
	}
}
