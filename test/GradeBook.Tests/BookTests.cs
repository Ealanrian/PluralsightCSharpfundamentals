using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
           
            // arrange
            Book book = new Book("");

            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            //act
            var result = book.GetStatistics();
            //assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void TestInvalidAddGrade()
        {
            //arrange
            Book book = new Book("grades");
            book.AddGrade(10.0);
            book.AddGrade(105.0);
            book.AddGrade(-10.0);
            
            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(10.0, result.High); //105 should not be added
            Assert.Equal(10.0,result.Low); // -10 should not be added
        }
    }
}
