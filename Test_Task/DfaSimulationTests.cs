namespace Test_Task
{
    public class DfaSimulationTests
    {
        private readonly RegexToNFAConverter _regexConverter = new();
        private readonly NFAtoDFAConverter _dfaConverter = new();
        private readonly DFASimulator _simulator = new();

        private DFA CompileRegex(string regex)
        {
            var nfa = _regexConverter.Convert(regex);
            return _dfaConverter.Convert(nfa);
        }

        [Theory]
        [InlineData("abb", true)]
        [InlineData("aabb", true)]
        [InlineData("ababb", true)]
        [InlineData("ab", false)]
        [InlineData("aab", false)]
        [InlineData("babb", true)]
        [InlineData("abba", false)]
        [InlineData("aaabb", true)]
        [InlineData("abbbb", false)]
        public void TestRegexSimulation(string input, bool expected)
        {
            string regex = "(a|b)*abb";
            var dfa = CompileRegex(regex);
            bool result = _simulator.Simulate(dfa, input);
            Assert.Equal(expected, result);
        }
    }
}
