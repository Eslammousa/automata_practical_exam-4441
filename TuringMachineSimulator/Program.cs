using System;
using System.Collections.Generic;

public class TuringMachine
{
   public static void Main()
    {
        TuringMachine turing = new TuringMachine();
        Console.Write("Enter input string (only 0s and 1s): ");
        var input = Console.ReadLine();
        var tape = new List<char>(input);

        if (turing.IsAccepted(tape))
            Console.WriteLine("Accepted");
        else
            Console.WriteLine("Rejected");
    }

    public  bool IsAccepted(List<char> tape)
    {
        int steps = 0;
        while (true)
        {
            int i = 0;

            while (i < tape.Count && tape[i] != '0') i++;
            if (i == tape.Count) break;
            tape[i] = 'X';

            i++;
            while (i < tape.Count && tape[i] != '1') i++;
            if (i == tape.Count) return false;
            tape[i] = 'Y';

            i++;
            while (i < tape.Count && tape[i] != '0') i++;
            if (i == tape.Count) return false;
            tape[i] = 'Z';

            i++;
            while (i < tape.Count && tape[i] != '1') i++;
            if (i == tape.Count) return false;
            tape[i] = 'W';

            steps++;
        }

        foreach (char c in tape)
        {
            if (c != 'X' && c != 'Y' && c != 'Z' && c != 'W')
                return false;
        }

        return steps > 0;
    }
}