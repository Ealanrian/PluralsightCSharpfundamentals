using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {   
            var book = new Book("grade book");
            System.Console.WriteLine("input grades, press enter after each grade, press q to finish");
            var input = "";
            var done = false;

            while(!done) {
                input = Console.ReadLine();
                if (input.Equals("q")){
                   done = true;
                   continue;
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

            var stats = book.GetStatistics();
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.High:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }

}
