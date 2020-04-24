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
        public void BookCAlculatesAnAvgGrade()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(89.9);
            book.AddGrade(72.25);
            book.AddGrade(90.01);
            // act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(84.05, result.Average, 2);
            Assert.Equal(90.01, result.High, 2);
            Assert.Equal(72.25, result.Low, 2);
            Assert.Equal('B', result.Letter); 
        }
    }
}
