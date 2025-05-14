using System;

class Program
{
    static void Main()
    {
        var regexConverter = new RegexToNFAConverter();
        var dfaConverter = new NFAtoDFAConverter();
        var simulator = new DFASimulator();

        Console.Write("Enter regex: ");
        string? regex = Console.ReadLine();

        var nfa = regexConverter.Convert(regex);
        var dfa = dfaConverter.Convert(nfa);

        string[] testInputs = { "abb", "aabb", "ab", "abbb", "babb" };

        foreach (var input in testInputs)
        {
            bool accepted = simulator.Simulate(dfa, input);
            Console.WriteLine($"'{input}' -> {(accepted ? "Accepted" : "Rejected")}");
        }
    }
}
