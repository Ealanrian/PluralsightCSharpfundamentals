using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod() 
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += ReturnMessage1;
            var result = log("Hello!");
            Assert.Equal(3,count);
        }

        string ReturnMessage(String message) {
            count ++;
            return message;
        }

        string ReturnMessage1(String message) {
            count ++;
            return message.ToLower();
        }

        [Fact]
        public void Test1() {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42,x);
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
        public void CSharpCanPassByRef()
        {
           
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            //act
          
            //assert
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
           
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            //act
          
            //assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
           
            // arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            //act
          
            //assert
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Erik";
            var upper = MakeUppercase(name);
            Assert.Equal("Erik", name);
            Assert.Equal("ERIK", upper);
        }

        private string MakeUppercase(string parameter)
        {
           return parameter.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
           
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            //act
          
            //assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }
        
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
           
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;
            //act
          
            //assert
            Assert.Same(book1, book2);
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
