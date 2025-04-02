using Xunit;
using StringManipulation;

namespace curso_de_csharp;

// all test classes should be public and end with Test
public class StringOperationsTest {
  [Fact]
  public void ConcatenateStrings() {
    StringOperations stringOperations = new StringOperations();
    var result = stringOperations.ConcatenateStrings("Hello", "World");
    Assert.Equal("Hello World", result);
  }
}