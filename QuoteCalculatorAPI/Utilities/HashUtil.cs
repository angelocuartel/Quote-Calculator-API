using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace ExpenseComputerAPI.Utilities
{
    public static class HashUtil
    {
        public static string ComputeToSha256(string plainText)
        {
            using (var sha = SHA256.Create())
            {
                byte[] encodedText = Encoding.ASCII.GetBytes(plainText);

                var computedText = sha.ComputeHash(encodedText);

                StringBuilder builder = new StringBuilder();

                foreach (var item in computedText)
                {
                    builder.Append(item.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
