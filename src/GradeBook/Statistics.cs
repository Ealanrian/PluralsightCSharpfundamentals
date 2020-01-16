using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {

        public double Average
        {
            get
            {
                return sum / count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                char letter;
                switch (Average)
                {
                    case var d when d >= 90.0:
                        letter = 'A';
                        break;
                    case var d when d >= 80.0:
                        letter = 'B';
                        break;
                    case var d when d >= 70.0:
                        letter = 'C';
                        break;
                    case var d when d >= 60.0:
                        letter = 'D';
                        break;
                    default:
                        letter = 'F';
                        break;
                }
                return letter;
            }
        }

        public Statistics()
        {
            sum = 0.0;
            count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
        public void generateStatistics(List<double> grades)
        {
            foreach (double grade in grades)
            {
                Add(grade);
            }
        }

        public void Add(double grade)
        {
            High = Math.Max(grade, High);
            Low = Math.Min(grade, Low);
            sum += grade;
            count++;
        }
        private int count;
        private double sum;
    }
}