using TuringMachineSimulator;

namespace Test_Task
{
    public class TuringMachine_Test
    {

        private readonly InputHandler _inputHandler;
        private readonly TuringMachine _turingMachine;

        public TuringMachine_Test()
        {
            _inputHandler = new InputHandler();
            _turingMachine = new TuringMachine();
        }

        [Fact]
        public void GetInput_EmptyInput_ThrowsArgumentException()
        {
            // Arrange
            var consoleInput = "";
            Console.SetIn(new System.IO.StringReader(consoleInput));

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _inputHandler.GetInput());
            Assert.Equal("Input cannot be empty.", exception.Message);
        }

        [Fact]
        public void GetInput_NonBinaryInput_ThrowsArgumentException()
        {
            // Arrange
            var consoleInput = "0102";
            Console.SetIn(new System.IO.StringReader(consoleInput));

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _inputHandler.GetInput());
            Assert.Equal("Input must contain only 0s and 1s.", exception.Message);
        }

        [Fact]
        public void GetInput_ValidBinaryInput_ReturnsInput()
        {
            // Arrange
            var consoleInput = "0101";
            Console.SetIn(new System.IO.StringReader(consoleInput));

            // Act
            var result = _inputHandler.GetInput();

            // Assert
            Assert.Equal("0101", result);
        }


        [Theory]
        [InlineData("01")] // Length 2
        [InlineData("00001111")] // Length 8, but wrong pattern
        [InlineData("010")] // Length 3
        public void Recognize_LengthNotDivisibleByFour_ReturnsFalse(string input)
        {
            // Act
            var result = _turingMachine.Recognize(input);

            // Assert
            Assert.False(result);
        }


        [Theory]
        [InlineData("1100")] // Wrong pattern, n=1, expected "0111"
        [InlineData("00111100")] // Wrong pattern, n=2, expected "00110011"
        [InlineData("000111111000")] // Wrong pattern, n=3, expected "000111000111"
        public void Recognize_WrongPattern_ReturnsFalse(string input)
        {
            // Act
            var result = _turingMachine.Recognize(input);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("0101")] // 0^1 1^1 0^1 1^1
        [InlineData("00110011")] // 0^2 1^2 0^2 1^2
        [InlineData("000111000111")] // 0^3 1^3 0^3 1^3
        public void Recognize_CorrectPattern_ReturnsTrue(string expected)
        {
            // Act
            var result = _turingMachine.Recognize(expected);

            // Assert
            Assert.True(result);
        }
    }
}
