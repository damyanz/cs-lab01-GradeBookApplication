using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
            Name = name;
            IsWeighted = isWeighted;
            Students = new List<Student>();
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("At least 5 students needed.");
            } 
            int rank = 0;
            foreach (Student student in Students)
            {
                if (averageGrade > student.AverageGrade) {
                    rank++;
                } 
            }
            float average = (float)rank / (float)Students.Count * 100;
            
            if (average >= 80)
                return 'A';
            else if (average >= 60)
                return 'B';
            else if (average >= 40)
                return 'C';
            else if (average >= 20)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("At least 5 students needed.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("At least 5 students needed.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
