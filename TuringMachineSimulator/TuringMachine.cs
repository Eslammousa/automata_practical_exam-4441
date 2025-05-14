namespace TuringMachineSimulator
{
    public class TuringMachine
    {
        public bool Recognize(string input)
        {
            int len = input.Length;

            // Total length must be divisible by 4
            if (len % 4 != 0) return false;

            int n = len / 4;

            string expected = new string('0', n) + new string('1', n) + new string('0', n) + new string('1', n);
            return input == expected;
        }
    }
}
