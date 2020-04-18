using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {   
            var book = new Book(); 
            // if(args.Length > 0) 
            // {
            //     // double x = 1.4;
            //     // var y = 22.5;

            // }
            // else
            // {
            //     Console.WriteLine("Hello!");

            // }
                var result = 0.0;
                var grades = new List<double>() {12.3, 58.7, 88.0};
                foreach(var num in grades) 
                {
                    result += num;
                }
                result /= grades.Count;
                Console.WriteLine($"{result:N3}, result here");
                // Console.WriteLine($"Hello {args[0]}!");
        }
    }
}
