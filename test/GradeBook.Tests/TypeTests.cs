using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        public delegate string WriteLogDelegate(string message);
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            var result = log("Hello!!");
            Assert.Equal("Hello!!", result);
        }

        public string ReturnMessage(string message)
        {
            return message;
        }



        [Fact]
        public void CheckAddGrade()
        {
            var book = new InMemoryBook("test");
            book.AddGrade(100);

            Assert.Contains(100, book.grades);        

        }

        [Fact]
        public void StringBehaveLikeValueTypes()
        {
            string test = "Hello";
            var upper = MakeUppercase(test);
            Assert.Equal("HELLO", upper);

        }

        private String MakeUppercase(string test)
        {
            return test.ToUpper();
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameWithRef(ref book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameWithRef(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpPassByVal()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }
        [Fact]
        public void TwoVarsOneRefSameObj()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
