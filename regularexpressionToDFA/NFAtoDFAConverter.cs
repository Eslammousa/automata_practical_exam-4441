using System.Collections.Generic;
using System.Linq;

public class NFAtoDFAConverter
{
    public DFA Convert(NFA nfa)
    {
        Dictionary<HashSet<State>, int> dfaStates = new(new HashSetComparer());
        Queue<HashSet<State>> queue = new();
        DFA dfa = new();
        int dfaId = 0;

        var startSet = EpsilonClosure(new HashSet<State> { nfa.Start });
        dfaStates[startSet] = dfaId++;
        dfa.StartState = 0;
        queue.Enqueue(startSet);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int currentId = dfaStates[current];
            dfa.Transitions[currentId] = new();

            foreach (char symbol in "abcdefghijklmnopqrstuvwxyz")
            {
                var moveSet = Move(current, symbol);
                if (moveSet.Count == 0) continue;

                var closure = EpsilonClosure(moveSet);
                if (!dfaStates.ContainsKey(closure))
                {
                    dfaStates[closure] = dfaId++;
                    queue.Enqueue(closure);
                }

                dfa.Transitions[currentId][symbol] = dfaStates[closure];
            }
        }

        foreach (var (states, id) in dfaStates)
            if (states.Contains(nfa.End)) dfa.AcceptStates.Add(id);

        return dfa;
    }

    private HashSet<State> EpsilonClosure(HashSet<State> states)
    {
        Stack<State> stack = new(states);
        HashSet<State> result = new(states);

        while (stack.Count > 0)
        {
            var state = stack.Pop();
            foreach (var next in state.EpsilonTransitions)
            {
                if (!result.Contains(next))
                {
                    result.Add(next);
                    stack.Push(next);
                }
            }
        }

        return result;
    }

    private HashSet<State> Move(HashSet<State> states, char symbol)
    {
        HashSet<State> result = new();
        foreach (var state in states)
            if (state.Transitions.ContainsKey(symbol))
                result.UnionWith(state.Transitions[symbol]);

        return result;
    }

    private class HashSetComparer : IEqualityComparer<HashSet<State>>
    {
        public bool Equals(HashSet<State> x, HashSet<State> y) => x.SetEquals(y);
        public int GetHashCode(HashSet<State> obj) =>
            obj.Aggregate(0, (hash, state) => hash ^ state.Id.GetHashCode());
    }
}
