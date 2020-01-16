using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("grade book");
            book.GradeAdded += OnGradeAdded;
            System.Console.WriteLine("input grades, press enter after each grade, press q to finish");

            EnterGrades(book);

            var stats = book.GetStatistics();
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.High:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(Book book)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("q"))
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        static void OnGradeAdded(Object sender, EventArgs e) 
        {
            Console.WriteLine("grade added");
        }
    }

}
