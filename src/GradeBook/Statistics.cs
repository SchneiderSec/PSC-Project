using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {

        public double Average;
        public double High;
        public double Low;
        public char Letter;
        List<double> grades;
        public Statistics(List<double> grades)
        {
            Average = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
            this.grades = grades;
            this.GetStats();
        }

        public void GetStats(){
            for(var i = 0; i < grades.Count; i++)
            {
                High = Math.Max(grades[i], High);
                Low = Math.Min(grades[i], Low);
                Average += grades[i];

            }
            Average = Average/grades.Count;
            switch(Average)
            {
                case var ARange when ARange >= 90.0:
                    Letter = 'A';
                    break;
                
                case var ARange when ARange >= 80.0:
                    Letter = 'B';
                    break;
                
                case var ARange when ARange >= 70.0:
                    Letter = 'C';
                    break;
                
                default:
                    Letter = 'F';
                    break;
            }
            // System.Console.WriteLine($"The average is {Average/grades.Count}%. The highest grade was {highGrade}%. The lowest grade was {lowGrade}%.");
        }
    }
}