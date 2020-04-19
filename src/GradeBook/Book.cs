// Need this to use List here
using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Book 
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

        public void ShowStatistics()
        {
            var result = 0.0;
            var highestGrade = double.MinValue;
            var lowestGrade = double.MaxValue;
            var grades = new List<double>() {12.3, 58.7, 88.0};
            foreach(var num in grades) 
                {
                    lowestGrade = Math.Min(num, lowestGrade);
                    highestGrade = Math.Max(num, highestGrade); 
                    result += num;
                }
                    result /= grades.Count;
                    Console.WriteLine($"Avg : {result:N3}, here");
                    Console.WriteLine($"the lowest grade is {lowestGrade}");
                    Console.WriteLine($"the highest grade is {highestGrade}");
        }

        // this is the field, data type storing data
        private List<double> grades;
        private string name; 
    }
}