// Need this to use List here
using System;
using System.IO; 
using System.Collections.Generic;
namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    // put this in it's own folder 
    // public class NamedObject
    // {
    //     public string Name
    //     {
    //         get;
    //         set;
    //     }
    // } 
//************************** InterFace ***********************************
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
//************************** book inherits from nameobj, and gets interface from Ibook ***********************************
    //below is base class : that is namedobject
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }
        public abstract event GradeAddedDelegate GradeAdded;

        // tells C# compiler anything that is a BookBase  should have
        // an abstract method AddGrade. but no implementation yet(don't know what it should do);
        // let derived types that inherit from this decide what it is.
        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
//************************** InMemoryBook save to Inmemory ***********************************
    public class InMemoryBook : Book
    {
        // need to add base keyword to acces NamedObjects method and pass it a string type variable.
        public InMemoryBook(string name) :base(name) 
        {
            // CATEGORY = "";
            grades = new List<double>();
            Name = name;
        }
        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;
                default:
                    AddGrade(0); 
                    break;
            }
        }
        //************************** InterFace ***********************************
        public class DiskBook : Book, IBook
        {
            public DiskBook(string name) : base(name)
            {
            }

            public override event GradeAddedDelegate GradeAdded;

            public override void AddGrade(double grade)
            
            {
               using(var writer = File.AppendText($"/Users/brianhaack/Documents/Projects/C#_programming/gradebook{Name}.txt"))
               {
               writer.WriteLine(grade); 
               if(GradeAdded != null) {
                   GradeAdded(this, new EventArgs());
               }
               }
            }

            public override Statistics GetStatistics()
            {
                var result = new Statistics();

                using(var reader = File.OpenText($"{Name}.txt"))
                {
                    var line = reader.ReadLine(); // reads line of characters from current stream and returns data as a stream.
                    while(line != null) // this runs till the line runs out and returns null at the end. 
                    {
                        var number = double.Parse(line);
                        result.Add(number);
                        line = reader.ReadLine();
                    }
                }

                return result; 
            }
        }
        public override void AddGrade(double grade)
        {
            // add grade to grades 
            if(grade <= 100 && grade > 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public override event GradeAddedDelegate GradeAdded;
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            // Moved to Statistics Class. 
            // result.Average = 0.0;
            // result.High = double.MinValue;
            // result.Low = double.MaxValue;
            // var grades = new List<double>() {12.3, 58.7, 88.0};
            var count = 0; 
            foreach(var grade in grades) 
                {
                    // lowestGrade = Math.Min(num, lowestGrade);
                    result.Add(grades[count]);
                    //following 2 Low, High need to be replicated. 
                    // result.Low = Math.Min(grade, result.Low);
                    // result.High = Math.Max(grade, result.High); 
                    // highestGrade = Math.Max(num, highestGrade); 
                    //result.Average += grade; -> this not needed cause done in Statistics Class
                    count++;
                }
                return result;
                    //result.Average /= grades.Count; not needed cause result.Average will give it.
                // switch moved to Statistics class 
                    // switch(result.Average)
                    // {
                    //     case var d when d >= 90.0:
                    //         result.Letter = 'A';
                    //         break;
                    //     case var d when d >= 80.0:
                    //         result.Letter = 'B';
                    //         break;
                    //     case var d when d >= 70.0:
                    //         result.Letter = 'C';
                    //         break;
                    //     case var d when d >= 60.0:
                    //         result.Letter = 'D';
                    //         break;
                    //     default:    
                    //         result.Letter = 'F';
                    //         break;
                    // }
                    // return result;
            // could add do while loop
            // Int32 index = 0; 
            // do
            // { 
            //     result.Low = Math.Min(grades[index], result.Low);
            //     index += 1; 
            // } while(index <  grades.Count)
        }

        // this is the field, data type storing data
        private List<double> grades;

        // readonly string category = "Science";
        // private string name;
        public const string CATEGORY = "Science";
    }
}