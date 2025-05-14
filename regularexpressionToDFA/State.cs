using System.Collections.Generic;

public class State
{
    public int Id;
    public Dictionary<char, List<State>> Transitions = new();
    public List<State> EpsilonTransitions = new();
    public State(int id) => Id = id;
}
