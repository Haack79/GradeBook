// Need this to use List here
using System;
using System.Collections.Generic;
namespace GradeBook
{
    public class Book 
    {
        public Book(string name) {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade)
        {
            // add grade to grades 
            grades.Add(grade);
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

                    return result;
        }

        // this is the field, data type storing data
        private List<double> grades;
        private string name; 
    }
}