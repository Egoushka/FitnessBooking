using System;
using System.Security.Cryptography;
using System.Text;
using FitnessBooking.Core.Interfaces.Singletons;

namespace FitnessBooking.Core.Tools
{
    public class HashUtils : IHashUtils
    {
        public string GetHash(string input)
        {
            var answer = new StringBuilder();

            using (var hashAlgorithm = SHA256.Create())
            {
                var data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

                foreach (var item in data)
                {
                    answer.Append(item.ToString("x2"));
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