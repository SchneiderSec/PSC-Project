using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStats();
        string Name {get;}
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStats();
    }
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            Name = name;
            grades = new List<double>();
        }
        public override void AddGrade(double grade){
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
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
        
        public void AddLetterGrade(char letter){
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(90);
                    break;

                case 'C':
                    AddGrade(90);
                    break;

                default:
                    AddGrade(0);
                    break;
            }

        }

        public override Statistics GetStats()
        {
            var result = new Statistics(grades);
            return result;
        }

        public List<double> grades;
    }

    public class DiskBook : Book, IBook
    {
        List<double> grades = new List<double>();
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            grades.Add(grade);
            var FileLocation = $"GradeOutput/{Name}.txt";
            DateTime Date = DateTime.Now;
            using (StreamWriter sw = File.AppendText(FileLocation))
            {
                sw.WriteLine($"You entered the grade {grade} at {Date}.");
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStats()
        {
            var result = new Statistics(grades);
            return result;
        }
    }
}