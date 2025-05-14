public class DFA
{
    public Dictionary<int, Dictionary<char, int>> Transitions = new();
    public int StartState;
    public HashSet<int> AcceptStates = new();
}
