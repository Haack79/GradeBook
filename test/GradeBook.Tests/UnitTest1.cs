using System;
using Xunit;
// xunit above needed for [Fact] attribute and testing, 
// attributes are methods in a class  to help do specific tasks,
// [Fact] here lets us run specific items we want to run tests on.

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookTests()
        {
            // arrange
            var book = new BookTests();
            // act

            //assert
            Assert.Equal();
        }
    }
}
