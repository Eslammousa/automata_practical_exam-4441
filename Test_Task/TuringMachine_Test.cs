using System.Collections.Generic;
using Xunit;

namespace Test_Task
{
    public class TuringMachine_Test
    {
        TuringMachine turing = new TuringMachine();

        [Theory]
        [InlineData("0101", true)]         
        [InlineData("0011", false)]        
        [InlineData("010101", false)]       
        [InlineData("0", false)]           
        [InlineData("0110", false)]        
        [InlineData("", false)]            
        [InlineData("000111000111", true)]
        public void TestIsAccepted(string input, bool expected)
        {
            var tape = new List<char>(input);
            bool result = turing.IsAccepted(tape);
            Assert.Equal(expected, result);  // xUnit Assert
        }
    }
}