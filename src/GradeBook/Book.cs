    using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {

        public Book(string name) 
        {
            grades = new List<double>();
            Name = name;
        }

        public Book (string name, string category)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        {

            double grade = 0.0;
            switch (letter) {
                case 'A' :
                    grade = 90;
                break;
                case 'B' :
                    grade = 80;
                break;
                case 'C' : 
                    grade = 70;
                break;
                case 'D' :
                    grade = 60;
                break;
                case 'E' :
                    grade = 50;
                break;
                case 'F' :
                    grade = 40;
                break;
                default : 
                    grade = 0;
                break;
            }
            AddGrade(grade);
        }

        public void AddGrade(double grade) 
        {
            if(grade >= 0 && grade  <=100 )
            {
                grades.Add(grade);
            } 
            else
            {
               throw new ArgumentException($"invalid {nameof(grade)}, should be between 0 and 100");
            }
        }

        public Statistics GetStatistics() {
            var result = new Statistics();

            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for(var index = 0; index < grades.Count; index++)
            { 

                result.Average += grades[index];
                result.High = Math.Max(grades[index],result.High);
                result.Low = Math.Min(grades[index], result.Low);
            }
    

            result.Average /= grades.Count;
            switch ( result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
               default:
                    result.Letter = 'F';
                    break;
            }
            return result;
        }


        private List<double> grades;
        
        public string Name
        {
            get; 
            set;
        }

        public const string CATEGORY = "Science";
    }
}