using System;
using System.Collections.Generic;
using GradeBook;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("Kyra Marzo's Grades");
            book.GradeAdded += OnGradeAdded;
            CreateBook(book);
            var stats = book.GetStats();
            System.Console.WriteLine($"The average was {stats.Average}. Highest was {stats.High}. The lowest was {stats.Low}. The average letter grade was {stats.Letter}.");
        }

        private static void CreateBook(IBook book)
        {
            while (true)
            {
                System.Console.WriteLine("Please enter the grade the student received: ");
                var input = Console.ReadLine();
                if (input == "q" || input == "Q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception err)
                {
                    System.Console.WriteLine(err.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A grade was added.");            
        }

    }
}
