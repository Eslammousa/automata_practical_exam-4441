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

    public bool IsAccepted(List<char> tape)
    {
        int left = 0;
        int right = tape.Count - 1;

        // Count n zeros from start
        int countZeroStart = 0;
        while (left <= right && tape[left] == '0')
        {
            countZeroStart++;
            tape[left] = 'X'; 
            left++;
        }
        if (countZeroStart == 0) return false; 

        // Count n ones next
        int countOneFirst = 0;
        while (left <= right && tape[left] == '1')
        {
            countOneFirst++;
            tape[left] = 'Y';
            left++;
        }
        if (countOneFirst != countZeroStart) return false; // عدد

        // Count n zeros next
        int countZeroSecond = 0;
        while (left <= right && tape[left] == '0')
        {
            countZeroSecond++;
            tape[left] = 'Z';
            left++;
        }
        if (countZeroSecond != countZeroStart) return false; // عدد الأصفار هنا لازم يساوي الأول

        // Count n ones last
        int countOneSecond = 0;
        while (left <= right && tape[left] == '1')
        {
            countOneSecond++;
            tape[left] = 'W';
            left++;
        }
        if (countOneSecond != countZeroStart) return false; // لازم يساوي نفس العدد

        // تأكد إن السلسلة كلها متصفح عليها
        if (left <= right) return false; // إذا فيه أي رمز باقي مش محسوب => رفض

        return true;
    }
}
