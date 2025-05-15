using Xunit;
using System;
using Microsoft.VisualStudio.TestPlatform.TestHost;


public class TuringMachineTests
{
    Program _program = new Program();
    [Theory]
    [InlineData("0101", true)]
    [InlineData("00110011", true)]
    [InlineData("000111000111", true)]
    [InlineData("", false)]
    [InlineData("001101", false)]
    [InlineData("00011100011", false)]
    [InlineData("0110", false)]
    [InlineData("0", false)]
    [InlineData("1", false)]
    [InlineData("00", false)]
    [InlineData("01", false)]
    [InlineData("01010101", true)] // Multiple valid pairs
    public void SimulateTm_ShouldCorrectlyIdentifyPattern(string input, bool expected)
    {
        
        // Act
        bool result = _program.SimulateTm(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SimulateTm_ShouldHandleVeryLongStrings()
    {
        // Arrange
        string longValidInput = new string('0', 1000) + new string('1', 1000) + new string('0', 1000) + new string('1', 1000);
        string longInvalidInput = new string('0', 1001) + new string('1', 1000) + new string('0', 1000) + new string('1', 1000);

        // Act & Assert
        Assert.True(_program.SimulateTm(longValidInput));
        Assert.False(_program.SimulateTm(longInvalidInput));
    }

    [Fact]
    public void SimulateTm_ShouldRejectNullInput()
    {
        // Arrange
        string nullInput = null;

        // Act & Assert
        Assert.Throws<NullReferenceException>(() => _program.SimulateTm(nullInput));
    }

    [Theory]
    [InlineData("A0101")]
    public void SimulateTm_ShouldRejectNonBinaryStrings(string input)
    {
        // Act
        bool result = _program.SimulateTm(input);

        // Assert
        Assert.False(result);
    }
}