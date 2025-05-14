public class DFASimulator
{
    public bool Simulate(DFA dfa, string input)
    {
        int state = dfa.StartState;
        foreach (char c in input)
        {
            if (!dfa.Transitions[state].ContainsKey(c))
                return false;
            state = dfa.Transitions[state][c];
        }
        return dfa.AcceptStates.Contains(state);
    }
}
