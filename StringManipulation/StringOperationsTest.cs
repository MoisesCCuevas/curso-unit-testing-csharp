using Xunit;
using StringManipulation;
using Moq;
using Microsoft.Extensions.Logging;

namespace curso_de_csharp;

// all test classes should be public and end with Test

// estructure AAA (Arrange, Act, Assert)
// Arrange: set up the test, create the objects and set the values
// Act: call the method to be tested
// Assert: check the result of the method call

// F.I.R.S.T (Fast, Independent, Repeatable, Self-validating, Timely)
// Fast: the test should run quickly
// Independent: the test should not depend on other tests
// Repeatable: the test should produce the same result every time it is run
// Self-validating: the test should be able to check its own result
// Timely: the test should be written at the same time as the code it tests

public class StringOperationsTest {
    [Fact(Skip = "Justification for skipping the test")]
    public void ConcatenateStrings() {
        StringOperations stringOperations = new();
        var result = stringOperations.ConcatenateStrings("Hello", "World");
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public void IsPalindrome_True() {
        StringOperations stringOperations = new();
        var result = stringOperations.IsPalindrome("racecar");
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_False() {
        StringOperations stringOperations = new();
        var result = stringOperations.IsPalindrome("hello");
        Assert.False(result);
    }

    [Fact]
    public void RemoveWhitespace() {
        StringOperations stringOperations = new();
        var result = stringOperations.RemoveWhitespace("Hello World");
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal("HelloWorld", result);
    }

    [Fact]
    public void QuantintyInWords() {
        StringOperations stringOperations = new();
        var result = stringOperations.QuantintyInWords("cat", 10);
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.StartsWith("diez", result);
        Assert.Contains("cats", result);
        Assert.Equal("diez cats", result);
    }

    [Fact]
    public void GetStringLength_Exception() {
        StringOperations stringOperations = new();
        Assert.ThrowsAny<ArgumentNullException>(() => stringOperations.GetStringLength(null));
    }

    [Fact]
    public void GetStringLength() {
        StringOperations stringOperations = new();
        var result = stringOperations.GetStringLength("Hello World");
        Assert.NotNull(result);
        Assert.Equal(11, result);
    }

    [Fact]
    public void TruncateString_Exception() {
        StringOperations stringOperations = new();
        Assert.ThrowsAny<ArgumentOutOfRangeException>(() => stringOperations.TruncateString("Hello World", 0));
    }

    [Theory]
    [InlineData("V", 5)]
    [InlineData("IV", 4)]
    [InlineData("XLII", 42)]
    public void FromRomanToNumber(string number, int expected) {
        StringOperations stringOperations = new();
        var result = stringOperations.FromRomanToNumber(number);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CountOccurrences() {
        var mockLogger = new Mock<ILogger<StringOperations>>();
        StringOperations stringOperations = new(mockLogger.Object);
        var result = stringOperations.CountOccurrences("Hello World", 'l');
        Assert.Equal(3, result);
    }

    [Fact]
    public void ReadFile() {
        StringOperations stringOperations = new();
        var mockFile = new Mock<IFileReaderConector>();
        //mockFile.Setup(m => m.ReadString("test.txt")).Returns("Reading file content");
        mockFile.Setup(m => m.ReadString(It.IsAny<string>())).Returns("Reading file content");
        var result = stringOperations.ReadFile(mockFile.Object, "test2.txt");
        Assert.Equal("Reading file content", result);
    }
}