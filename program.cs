using System;
using System.Collections.Generic;
using System.Linq;

class Refactor
{
    static Dictionary<string , (decimal grade, string mark)> StudentInfo = new();
    const int TotalAssignments = 5;

   
    static void Main()
    {
        bool isRunning= true;
        while (isRunning)
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("A. Add new student");
            Console.WriteLine("B. Display all student grades");
            Console.WriteLine("C. Exit");
            Console.Write("Enter Option: ");

            string userOption = Console.ReadLine()?.Trim().ToUpper() ?? string.Empty;

            switch (userOption)
            {
                case "A":
                    AddStudent(StudentInfo);
                    break;

                case "B":
                    DisplayGrades(StudentInfo);
                    break;

                case "C":                  
                    isRunning = false;
                    Console.WriteLine("Program exited. Bye!");
                    break;

                default: 
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static string GetStudentName()
    {

        string name = string.Empty;
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Please type in Student name: ");
            name = Console.ReadLine()?.Trim() ?? string.Empty;
        };

        return name;
    }

    static List<int> GetStudentGrades()
    {

        List<int> studentGrades = new();    

        while (studentGrades.Count == 0)
        {   
            //FIX: check for less than 5 grades or more
            Console.Write("Please type in grades: ");
            string input = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(input))
                continue;
            

            studentGrades = input
                .Split(',')

                //FIX: tryParse should reject bad inputs but it quietly turns them into 0
                //check how it behaves 
                .Select(value =>
                {
                    int.TryParse(value, out int result);
                    return result;
                })
                .ToList();
        };

        return studentGrades;
    }

    static void AddStudent(Dictionary<string, (decimal grade, string mark)> studentGrades)
    {
        string studentName = GetStudentName();
        List<int> assignmentGrades = GetStudentGrades();
        decimal averageGrade = CalculateAverageGrade(assignmentGrades, TotalAssignments);
        string mark = GetGradeMark(averageGrade);

        studentGrades.Add(studentName, (averageGrade, mark));
        Console.WriteLine("Data Saved!");
    }

    static decimal CalculateAverageGrade(List<int> assignmentGrades, int totalAssignments)
    {
        decimal total = 0;
        foreach (int grade in assignmentGrades)
        {
            total += grade;
        }

        return total / totalAssignments;
    }

    static string GetGradeMark(decimal averageGrade)
    {
        return averageGrade switch
        {
            >= 100 => "A+",
            >= 93 and <= 99 => "A",
            >= 90 and <= 92 => "A-",

            >= 87 and <= 89 => "B+",
            >= 83 and <= 86 => "B",
            >= 80 and <= 82 => "B-",

            >= 77 and <= 79 => "C+",
            >= 73 and <= 76 => "C",
            >= 70 and <= 72 => "C-",

            >= 67 and <=69 => "D+",
            >= 63 and <= 66 => "D",
            >= 60 and <= 62 => "D-",
            
            _ => "F",
        };
    }

    static void DisplayGrades(Dictionary<string, (decimal, string)> StudentInfo)
    {
        if (StudentInfo.Count() == 0 )
            Console.WriteLine("No students records yet.");
        
        foreach(var (name, (grade, mark)) in StudentInfo)
        {
           Console.WriteLine($"Student: {name,-10} | Avg: {grade,5:F1} | Mark: {mark}");
        }

    }
}