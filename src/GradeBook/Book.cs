using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {

        public Book(string name) 
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade) {
            grades.Add(grade);
        }

        public Statistics GetStatistics() {
            var result = new Statistics();

            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach(var grade in grades) {
                result.Average += grade;
                result.High = Math.Max(grade,result.High);
                result.Low = Math.Min(grade, result.Low);
            }
            result.Average /= grades.Count;
            return result;
        }

        public void PrintStatistics()
         {

           /* Console.WriteLine($"The average grade is {averageGrade:N1}");
            Console.WriteLine($"The highest grade is {highGrade:N1}");
            Console.WriteLine($"The lowest grade is {lowGrade:N1}");*/
        }

        private List<double> grades;
        private string name;
    }
}