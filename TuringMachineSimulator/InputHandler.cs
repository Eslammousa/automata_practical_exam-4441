namespace TuringMachineSimulator
{
    public class InputHandler
    {
        public string GetInput()
        {
            Console.Write("Enter a string (only 0s and 1s): ");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be empty.");

            foreach (char c in input)
            {
                if (c != '0' && c != '1')
                    throw new ArgumentException("Input must contain only 0s and 1s.");
            }

            return input;
        }
    }
}
