using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {   
            var book = new Book("Grade Book"); 
            book.AddGrade(29.33);
            book.AddGrade(88.23);
            book.ShowStatistics();
            // if(args.Length > 0) 
            // {
            //     // double x = 1.4;
            //     // var y = 22.5;

            // }
            // else
            // {
            //     Console.WriteLine("Hello!");

            // }
                // Console.WriteLine($"Hello {args[0]}!");
        }
    }
}
