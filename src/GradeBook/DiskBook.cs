using System;
using System.Collections.Generic;
using System.IO;
namespace GradeBook
{
   // public delegate void GradeAddedDelegate(Object sender, EventArgs args);
  

    public class DiskBook : Book
    {

        public DiskBook(string name) : base(name)
        {
            
        }

        public override void AddGrade(char letter)
        {

           
        }

        public override void AddGrade(double grade) 
        {
           using( var sw = File.AppendText($"{Name}.txt")) 
           {
                 sw.WriteLine(grade);
                 if ( GradeAdded!= null) {
                    GradeAdded(this, new EventArgs());
                 }
           }

        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics() 
        {
            var result = new Statistics();
            using( var reader = File.OpenText($"{Name}.txt"))
            {
                while(true)
                {
                    var line = reader.ReadLine();
                    if(line == null) {
                        break;
                    }
                    var grade = double.Parse(line);
                    result.Add(grade);
                }
            }
            return result;
        }
    }
}