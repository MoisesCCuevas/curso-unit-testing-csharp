using Xunit;
using StringManipulation;

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
    [Fact]
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
}