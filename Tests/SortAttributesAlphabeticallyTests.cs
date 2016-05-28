using GeneratedCodeCleaner.Logic;
using Xunit;

namespace GeneratedCodeCleaner.Tests
{
    public class SortAttributesAlphabeticallyTests
    {
        [Fact]
        public void WhenPropertyHasMultipleNonSortedAttributes_ThenShouldSortAttributes()
        {
            // Arrange

            const string code =
@"using System;
using System.Diagnostics;

namespace HelloWorld 
{ 
    public class MyAwesomeModel
    {
        [Obsolete]
        [DebuggerStepThrough]
        [MonitoringDescription(""Nice"")]
        public string MyProperty {get;set;}
        public int MyProperty1 {get;set;}
    }
}";

            // Act

            var actual = CodeCleaner.Clean(code);

            // Assert

            const string expected =
@"using System;
using System.Diagnostics;

namespace HelloWorld 
{ 
    public class MyAwesomeModel
    {
        [DebuggerStepThrough]
        [MonitoringDescription(""Nice"")]
        [Obsolete]
        public string MyProperty {get;set;}
        public int MyProperty1 {get;set;}
    }
}";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenPropertyHasSameAttributeTypeMultipleTimes_ThenShouldSortAttributes()
        {
            // Arrange

            const string code =
@"using System;

namespace HelloWorld 
{ 
    public class MyAwesomeModel
    {
        [XmlElement(""AuditableEvent"", typeof (AuditableEventType))]
        [XmlElement(""Association"", typeof (AssociationType1))]
        public string MyProperty {get;set;}
        public int MyProperty1 {get;set;}
    }
}";

            // Act

            var actual = CodeCleaner.Clean(code);

            // Assert

            const string expected =
@"using System;

namespace HelloWorld 
{ 
    public class MyAwesomeModel
    {
        [XmlElement(""Association"", typeof (AssociationType1))]
        [XmlElement(""AuditableEvent"", typeof (AuditableEventType))]
        public string MyProperty {get;set;}
        public int MyProperty1 {get;set;}
    }
}";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenClassHasMultipleNonSortedAttributes_ThenShouldSortAttributes()
        {
            // Arrange

            const string code =
@"using System;

namespace HelloWorld 
{
    [Obsolete]
    [DebuggerStepThrough]
    [MonitoringDescription(""Nice"")]
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

namespace HelloWorld 
{
    [DebuggerStepThrough]
    [MonitoringDescription(""Nice"")]
    [Obsolete]
    public class MyAwesomeModel
    {
        public string MyProperty {get;set;}
        public int MyProperty1 {get;set;}
    }
}";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenEnumHasMultipleNonSortedAttributes_ThenShouldSortAttributes()
        {
            // Arrange

            const string code =
@"using System;

namespace HelloWorld 
{
    [Obsolete]
    [DebuggerStepThrough]
    [MonitoringDescription(""Nice"")]
    public enum MyAwesomeModel
    {
        And,
        Or
    }
}";

            // Act

            var actual = CodeCleaner.Clean(code);

            // Assert

            const string expected =
@"using System;

namespace HelloWorld 
{
    [DebuggerStepThrough]
    [MonitoringDescription(""Nice"")]
    [Obsolete]
    public enum MyAwesomeModel
    {
        And,
        Or
    }
}";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenBlankLineBeforeAndFirstAttributeListsIsMovedDown_ThenShouldKeepBlankLineBefore()
        {
            // Arrange

            const string code =
@"using System;

namespace Nehta.VendorLibrary.CDAPackage.EBXml
{
  public class CompoundFilterTypeLogicalOperator
  {

    [XmlElement(""PGPKeyID"", typeof (byte[]), DataType = ""base64Binary"")]
    [XmlAnyElement]
    public object[] Items {get;set;}
  }
}";

            // Act

            var actual = CodeCleaner.Clean(code);

            // Assert

            const string expected =
@"using System;

namespace Nehta.VendorLibrary.CDAPackage.EBXml
{
  public class CompoundFilterTypeLogicalOperator
  {

    [XmlAnyElement]
    [XmlElement(""PGPKeyID"", typeof (byte[]), DataType = ""base64Binary"")]
    public object[] Items {get;set;}
  }
}";
            Assert.Equal(expected, actual);
        }
    }
}