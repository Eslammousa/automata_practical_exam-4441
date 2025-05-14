using TuringMachineSimulator;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            InputHandler inputHandler = new InputHandler();
            string input = inputHandler.GetInput();

            TuringMachine machine = new TuringMachine();
            bool result = machine.Recognize(input);

            Console.WriteLine(result ? "Accepted by the Turing Machine." : "Rejected by the Turing Machine.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}