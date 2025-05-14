using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a string to check if it's an odd-length palindrome: ");
            string? input = Console.ReadLine();

            OddLengthPalindromePDA pda = new OddLengthPalindromePDA();

            if (pda.IsPalindrome(input))
                Console.WriteLine("Accepted by PDA: It's an odd-length palindrome.");
            else
                Console.WriteLine("Rejected by PDA.");
        }
    }

}
