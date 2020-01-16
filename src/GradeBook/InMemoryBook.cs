    using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(Object sender, EventArgs args);
  

    public class InMemoryBook : Book, IBook
    {

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
        }

        public override void AddGrade(char letter)
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

        public override void AddGrade(double grade) 
        {
            if(grade >= 0 && grade  <=100 )
            {
                grades.Add(grade);
                if(GradeAdded != null) 
                {
                    GradeAdded(this, new EventArgs());
                }
            } 
            else
            {
               throw new ArgumentException($"invalid {nameof(grade)}, should be between 0 and 100");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics() {
            var result = new Statistics();
            result.generateStatistics(grades);
            return result;
        }


        private List<double> grades;
        
      
        public const string CATEGORY = "Science";
    }
}