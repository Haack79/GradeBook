using System;
using Xunit;
// xunit above needed for [Fact] attribute and testing, 
// attributes are methods in a class  to help do specific tasks,
// [Fact] here lets us run specific items we want to run tests on.
// order of Parametesr in ASSERT matter

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToAMethod()
        {
            WriteLogDelegate log;
            log = ReturnMessage;
            var result = log("Hello");
            Assert.Equal("Hello", result);
        }

        private string  ReturnMessage(string message)
        {
            return message;
        }
         
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            var upper = MakeUpperCase(name);
            Assert.Equal("SCOTT", upper);
        }
        private string MakeUpperCase(string parameter)
        {
           return parameter.ToUpper();
        }
        [Fact]
        public void test()
        {
            var x = GetInt();
            SetInt(x);
            Assert.Equal(3, x);
        }
        private void SetInt(int x) 
        {
            x = 42;
        }
        private int GetInt()
        {
            return 3; 
        }
        [Fact]
        public void CSharpIsPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name); 
        }
        // the ref says that what is in book1 is not a copy of the value that is in variable being passed along
        // but will get a reference to the memory location of where that variable is stored.
        private void GetBookSetName(ref Book book, string name)
        {
            // cause of ref here you can make changes to values in variable in book1
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            // book1 has a value that is a reference to object created in GetBook
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name); 
        }
        private void GetBookSetName(Book book, string name)
        {
            // this is denied access to  var book1 values
            book = new Book(name);
        }

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
