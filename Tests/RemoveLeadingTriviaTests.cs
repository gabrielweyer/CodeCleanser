using GeneratedCodeCleaner.Logic;
using Xunit;

namespace GeneratedCodeCleaner.Tests
{
    public class RemoveLeadingTriviaTests
    {
        [Fact]
        public void WhenHasLeadingTrivia_ThenShouldRemoveLeadingTrivia()
        {
            // Arrange

            const string code =
@"// Some comment

// More comment

using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 

namespace HelloWorld 
{ 
    public class MyAwesomeModel
    {
        public string MyProperty {get;set;}
        public int MyProperty1 {get;set;}
    }

}";

            // Act

            var actual = CodeCleaner.Clean(code);

            // Assert

            const string expected =
@"using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 

namespace HelloWorld 
{ 
    public class MyAwesomeModel
    {
        public string MyProperty {get;set;}
        public int MyProperty1 {get;set;}
    }

}";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenHasLeadingTriviaAndDoesntContainUsingStatementsOrNamespace_ThenShouldRemoveLeadingTrivia()
        {
            // Arrange

            const string code =
@"// Some comment

// More comment

public class MyAwesomeModel
{
    public string MyProperty {get;set;}
    public int MyProperty1 {get;set;}
}";

            // Act

            var actual = CodeCleaner.Clean(code);

            // Assert

            const string expected =
@"public class MyAwesomeModel
{
    public string MyProperty {get;set;}
    public int MyProperty1 {get;set;}
}";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenHasLeadingTriviaWithMultiLineCommentsAndDoesntContainUsingStatementsOrNamespace_ThenShouldRemoveLeadingTrivia()
        {
            // Arrange

            const string code =
@"
/* Some multiline comment
    haha
  Ok I'm done */


// More comment

public class MyAwesomeModel
{
    public string MyProperty {get;set;}
    public int MyProperty1 {get;set;}
}";

            // Act

            var actual = CodeCleaner.Clean(code);

            // Assert

            const string expected =
@"public class MyAwesomeModel
{
    public string MyProperty {get;set;}
    public int MyProperty1 {get;set;}
}";
            Assert.Equal(expected, actual);
        }
    }
}
