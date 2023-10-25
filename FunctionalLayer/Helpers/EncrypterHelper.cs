using System.Security.Cryptography;
using System.Text;

namespace BilleteraVirtualSofttekBack.Helpers
{
    /// <summary>
    /// This class has methods that encrypt strings.
    /// </summary>
    public static class EncrypterHelper
    {
        /// <summary>
        /// This method is used to encrypt a string.
        /// </summary>
        /// <param name="password">A string.</param>
        /// <param name="secondParam">A string.</param>
        /// <returns>An encrypted string based on SHA256.</returns>
        public static string Encrypter(string password, string secondParam)
        {

            var salt = CreateSalt(secondParam);
            string saltAndPwd = String.Concat(password, salt);

            //Encryption algorithm
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = Array.Empty<byte>();
            StringBuilder sb = new StringBuilder();

            //Bytes array format
            stream = sha256.ComputeHash(encoding.GetBytes(saltAndPwd));

            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();

        }


        /// <summary>
        /// This metod generates a SALT based on a string parameter.
        /// </summary>
        /// <param name="dni">A string.</param>
        /// <returns>A randomly generated Salt string.</returns>
        private static string CreateSalt(string dni)
        {
            var salt = dni;
            byte[] saltBytes;
            string saltStr;
            saltBytes = ASCIIEncoding.ASCII.GetBytes(salt);
            long XORED = 0x00;

            foreach (var b in saltBytes)
            {
                XORED = XORED ^ b;
            }

            Random rng = new Random(Convert.ToInt32(XORED));
            saltStr = rng.Next().ToString();
            saltStr += rng.Next().ToString();
            saltStr += rng.Next().ToString();
            saltStr += rng.Next().ToString();

            return saltStr;
        }

    }
}
