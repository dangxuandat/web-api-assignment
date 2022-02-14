using System.Security.Cryptography;
using System.Text;

namespace web_api_assignment.Helpers
{
    public static class Helper
    {
        public static string HashPassword(string rawPassword)
        {
            //Create a SHA256
            using(SHA256 sha256 = SHA256.Create())
            {
                //ComputeHash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));

                //convert byte array to string
                StringBuilder builder = new StringBuilder();
                for(int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
