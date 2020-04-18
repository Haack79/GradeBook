// Need this to use List here
using System.Collections.Generic;
namespace GradeBook
{
    class Book 
    {
        public void AddGrade(double grade)
        {
            // add grade to grades 
            grades.Add(grade);
        }
        // this is the field, data type storing data
        List<double> grades;
    }
}