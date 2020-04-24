using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {   
            var book = new Book("Grade Book");
            var done = false;
            while(!done) 
            {
                System.Console.WriteLine("Enter a grade or hit q to quit");
                var input = Console.ReadLine();
                if(input == "q")
                {
                    done = true;
                    continue;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade); 
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            var stats = book.GetStatistics();
            Console.WriteLine($"The book Name is {Book.CATEGORY}");
            Console.WriteLine($"The book Name is {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest avg of grades is {stats.Average:N2}");
            Console.WriteLine($"The lowest grade is {stats.Letter}");
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
