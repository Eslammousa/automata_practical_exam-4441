using System;
using System.Collections.Generic;

public class RegexToNFAConverter
{
    private int stateId = 0;

    public NFA Convert(string regex)
    {
        string postfix = ToPostfix(regex);
        Stack<NFA> stack = new();

        foreach (char c in postfix)
        {
            if (c == '*')
            {
                var nfa = stack.Pop();
                var start = NewState();
                var end = NewState();
                start.EpsilonTransitions.Add(nfa.Start);
                start.EpsilonTransitions.Add(end);
                nfa.End.EpsilonTransitions.Add(nfa.Start);
                nfa.End.EpsilonTransitions.Add(end);
                stack.Push(new NFA { Start = start, End = end });
            }
            else if (c == '.')
            {
                var nfa2 = stack.Pop();
                var nfa1 = stack.Pop();
                nfa1.End.EpsilonTransitions.Add(nfa2.Start);
                stack.Push(new NFA { Start = nfa1.Start, End = nfa2.End });
            }
            else if (c == '|')
            {
                var nfa2 = stack.Pop();
                var nfa1 = stack.Pop();
                var start = NewState();
                var end = NewState();
                start.EpsilonTransitions.Add(nfa1.Start);
                start.EpsilonTransitions.Add(nfa2.Start);
                nfa1.End.EpsilonTransitions.Add(end);
                nfa2.End.EpsilonTransitions.Add(end);
                stack.Push(new NFA { Start = start, End = end });
            }
            else
            {
                var start = NewState();
                var end = NewState();
                start.Transitions[c] = new List<State> { end };
                stack.Push(new NFA { Start = start, End = end });
            }
        }

        return stack.Pop();
    }

    private State NewState() => new(stateId++);

    private string ToPostfix(string regex)
    {
        string output = "";
        Stack<char> stack = new();
        Dictionary<char, int> precedence = new() { ['|'] = 1, ['.'] = 2, ['*'] = 3 };
        string expanded = ExpandConcat(regex);

        foreach (char token in expanded)
        {
            if (token == '(') stack.Push(token);
            else if (token == ')')
            {
                while (stack.Peek() != '(')
                    output += stack.Pop();
                stack.Pop();
            }
            else if ("|.*".Contains(token))
            {
                while (stack.Count > 0 && stack.Peek() != '(' &&
                       precedence[token] <= precedence[stack.Peek()])
                    output += stack.Pop();
                stack.Push(token);
            }
            else output += token;
        }

        while (stack.Count > 0)
            output += stack.Pop();

        return output;
    }

    private string ExpandConcat(string regex)
    {
        string result = "";
        for (int i = 0; i < regex.Length; i++)
        {
            result += regex[i];
            if (i + 1 < regex.Length)
            {
                if ((Char.IsLetterOrDigit(regex[i]) || regex[i] == ')' || regex[i] == '*') &&
                    (Char.IsLetterOrDigit(regex[i + 1]) || regex[i + 1] == '('))
                    result += '.';
            }
        }
        return result;
    }
}
