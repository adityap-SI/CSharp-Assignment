namespace Student_Grade
{
    class Student
    {
        public string Name { get; }
        private double[] grades;

        public Student(string name, int numOfGrades)
        {
            Name = name;
            grades = new double[numOfGrades];
        }

        public void SetGrades()
        {
            for (int i = 0; i < grades.Length; i++)
            {
                bool validInput = false;
                double grade = 0;

                while (!validInput)
                {
                    Console.Write($"Enter grade {i + 1}: ");
                    string input = Console.ReadLine();

                    if (double.TryParse(input, out grade))
                    {
                        if (grade >= 0 && grade <= 100)
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid grade. Grades must be between 0 and 100.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid numeric grade.");
                    }
                }

                grades[i] = grade;
            }
        }

        public double CalculateAverageGrade()
        {
            double totalGrade = 0;

            foreach (double grade in grades)
            {
                totalGrade += grade;
            }

            return totalGrade / grades.Length;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Student Grading System");
            Console.WriteLine("----------------------");

            Console.Write("Enter the name of the student: ");
            string name = Console.ReadLine();

            Console.Write("Enter the number of grades to be entered: ");
            int numOfGrades = 0;

            while (numOfGrades <= 0)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int tempNumOfGrades) && tempNumOfGrades > 0)
                {
                    numOfGrades = tempNumOfGrades;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer for the number of grades.");
                }
            }

            Student student = new Student(name, numOfGrades);
            student.SetGrades();

            double averageGrade = student.CalculateAverageGrade();

            Console.WriteLine($"Average grade for {student.Name}: {averageGrade:F2}");
        }
    }

}
