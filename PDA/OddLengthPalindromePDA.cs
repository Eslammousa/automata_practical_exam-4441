using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA
{
        public class OddLengthPalindromePDA
        {
            public bool IsPalindrome(string input)
            {
                int length = input.Length;

                if (length % 2 == 0)
                    return false;

                Stack<char> stack = new Stack<char>();
                int mid = length / 2;

                
                for (int i = 0; i < mid; i++)
                {
                    stack.Push(input[i]);
                }

               
                for (int i = mid + 1; i < length; i++)
                {
                    if (stack.Count == 0 || stack.Pop() != input[i])
                        return false;
                }

                
                return stack.Count == 0;
            }
        }
    }

