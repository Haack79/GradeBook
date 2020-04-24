// Need this to use List here
using System;
using System.Collections.Generic;
namespace GradeBook
{
    public class Book 
    {
        public Book(string name) {
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
        public void AddGrade(double grade)
        {
            // add grade to grades 
            if(grade <= 100 && grade > 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        // 
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            // var grades = new List<double>() {12.3, 58.7, 88.0};
            foreach(var grade in grades) 
                {
                    // lowestGrade = Math.Min(num, lowestGrade);
                    result.Low = Math.Min(grade, result.Low);
                    result.High = Math.Max(grade, result.High); 
                    // highestGrade = Math.Max(num, highestGrade); 
                    result.Average += grade;
                }
                    result.Average /= grades.Count;
                    switch(result.Average)
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
        public string Name
        {
            get;
            set;        
        } 
        // readonly string category = "Science";
        // private string name;
        public const string CATEGORY = "Science";
    }
}