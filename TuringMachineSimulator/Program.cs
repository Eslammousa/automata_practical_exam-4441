using System;
using System.Collections.Generic;

public class Program
{
    public bool SimulateTm(string inputStr)
    {
        List<char> tape = new List<char>(inputStr.ToCharArray());
        int head = 0;

        Func<char, char, int, int> findAndMark = (symbol, mark, start) => {
            head = start;
            while (head < tape.Count)
            {
                if (tape[head] == symbol)
                {
                    tape[head] = mark;
                    return head;
                }
                head++;
            }
            return -1;
        };

        Action moveToStart = () => head = 0;

        while (true)
        {
            moveToStart();

            // Step 1: Find 0 and mark it X
            int i1 = findAndMark('0', 'X', 0);
            if (i1 == -1) break;  // No more 0s to match

            // Step 2: Find 1 and mark it Y
            int i2 = findAndMark('1', 'Y', i1 + 1);
            if (i2 == -1) return false;

            // Step 3: Find second 0 and mark it X
            int i3 = findAndMark('0', 'X', i2 + 1);
            if (i3 == -1) return false;

            // Step 4: Find second 1 and mark it Y
            int i4 = findAndMark('1', 'Y', i3 + 1);
            if (i4 == -1) return false;
        }

        if (tape.Count == 0) return false;
        foreach (char c in tape)
        {
            if (c != 'X' && c != 'Y') return false;
        }

        return true;
    }

 

    public static void Main(string[] args)
    {
        Program program = new Program();
        Console.Write("Enter a binary string to check: ");
        string? userInput = Console.ReadLine();

        if (program.SimulateTm(userInput))
        {
            Console.WriteLine("Accepted.");
        }
        else
        {
            Console.WriteLine("Rejected.");
        }
    }
}