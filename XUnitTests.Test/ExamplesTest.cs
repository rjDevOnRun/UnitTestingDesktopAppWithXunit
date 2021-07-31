using DemoLibrary;
using Xunit;
using System.IO;
using System;

namespace XUnitTests.Test
{
    public class ExamplesTest
    {
        [Fact]
        public void ExampleLoadTextFile_ValidNameShouldPass()
        {
            string actual = Examples.ExampleLoadTextFile
                ("This is a valid file name");

            Assert.True(actual.Length > 0);
        }

        [Fact]
        // check if method throws filenotfoundexception
        // when passing 'file' paramenter
        public void ExampleLoadTextFile_InValidNameShouldFail()
        {
            Assert.Throws<ArgumentException>("file", 
                () => Examples.ExampleLoadTextFile("")
            );
        }
    }
}
