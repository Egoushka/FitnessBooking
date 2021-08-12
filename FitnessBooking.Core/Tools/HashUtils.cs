using FitnessBooking.Core.Interfaces.Singletons;
using System;
using System.Security.Cryptography;
using System.Text;

namespace FitnessBooking.Core.Tools
{
    public class HashUtils : IHashUtils
    {
        public string GetHash(string input)
        {
            StringBuilder answer = new StringBuilder();

            using (SHA256 hashAlgorithm = SHA256.Create())
            {
                byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

                for (int i = 0; i < data.Length; ++i)
                {
                    answer.Append(data[i].ToString("x2"));
                }
            }
            return answer.ToString();
        }

        public bool VerifyHash(string input, string hash)
        {
            var hashOfInput = GetHash(input);

            return StringComparer.OrdinalIgnoreCase.Compare(hashOfInput, hash) == 0;
        }
    }
}