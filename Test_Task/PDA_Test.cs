using PDA;

namespace Test_Task
{
    public class PDA_Test
    {
        private readonly OddLengthPalindromePDA _PDA;

        public PDA_Test()
        {
            _PDA = new OddLengthPalindromePDA();
        }

        [Fact]
        public void IsOddLengthPalindrome_ValidOddLengthPalindrome_ReturnsTrue()
        {
            // Arrange
            string input = "racecar";

            // Act
            bool result = _PDA.IsPalindrome(input);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsOddLengthPalindrome_SingleCharacter_ReturnsTrue()
        {
            // Arrange
            string input = "a";

            // Act
            bool result = _PDA.IsPalindrome(input);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsOddLengthPalindrome_EvenLengthPalindrome_ReturnsFalse()
        {
            // Arrange
            string input = "deed";

            // Act
            bool result = _PDA.IsPalindrome(input);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsOddLengthPalindrome_OddLengthNonPalindrome_ReturnsFalse()
        {
            // Arrange
            string input = "abcde";

            // Act
            bool result = _PDA.IsPalindrome(input);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsOddLengthPalindrome_EmptyString_ReturnsFalse()
        {
            // Arrange
            string input = "";

            // Act
            bool result = _PDA.IsPalindrome(input);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsOddLengthPalindrome_ThreeCharacterPalindrome_ReturnsTrue()
        {
            // Arrange
            string input = "aba";

            // Act
            bool result = _PDA.IsPalindrome(input);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsOddLengthPalindrome_MatchingOddLength_ReturnsTrue()
        {
            // Arrange
            string input = "abcba";

            // Act
            bool result = _PDA.IsPalindrome(input);

            // Assert
            Assert.True(result);
        }



    }
}
