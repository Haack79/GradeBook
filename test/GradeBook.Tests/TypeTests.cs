using System;
using Xunit;
// xunit above needed for [Fact] attribute and testing, 
// attributes are methods in a class  to help do specific tasks,
// [Fact] here lets us run specific items we want to run tests on.

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal(book1, book1); 
        }
        private void SetName(Book book, string name)
        {
            book.Name = name; 
        }
        [Fact]
        public void GetBookReturnsDiffObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        // remember Book below is the return type.  private is access modifier by default
        Book GetBook(string name)
        {
            return new Book(name); 
        }
    }
}
