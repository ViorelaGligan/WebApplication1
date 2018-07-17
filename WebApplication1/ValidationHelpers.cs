using System;
using System.Text;

namespace WebApplication1
{
    public static class ValidationHelpers
    {
        /// <summary>
        /// Validates IBAN checksum
        /// </summary>
        /// <param name="bankAccount">IBAN string</param>
        /// <returns>true/false</returns>
        public static bool ValidateIban(string bankAccount)
        {
            bankAccount = bankAccount.ToUpper(); 
            if (String.IsNullOrEmpty(bankAccount)) return false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(bankAccount, "^[A-Z0-9]")) return false;
            bankAccount = bankAccount.Replace(" ", string.Empty);
            string bank = bankAccount.Substring(4, bankAccount.Length - 4) + bankAccount.Substring(0, 4);
            int asciiShift = 55;
            StringBuilder sb = new StringBuilder();
            foreach (char c in bank)
            {
                int v;
                if (Char.IsLetter(c)) v = c - asciiShift;
                else v = int.Parse(c.ToString());
                sb.Append(v);
            }
            string checkSumString = sb.ToString();
            int checksum = int.Parse(checkSumString.Substring(0, 1));
            for (int i = 1; i < checkSumString.Length; i++)
            {
                int v = int.Parse(checkSumString.Substring(i, 1));
                checksum *= 10;
                checksum += v;
                checksum %= 97;
            }
            return checksum == 1;
        }
    }
}