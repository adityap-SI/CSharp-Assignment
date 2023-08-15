namespace ConsoleApp1
{
    class Student
    {
        private string name;
        private int age;
        private List<string> courseEnrollment;
        private List<int> grades;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public List<string> CourseEnrollment
        {
            get { return courseEnrollment; }
            set { courseEnrollment = value; }
        }

        public double GPA
        {
            get
            {
                if (grades.Count == 0)
                    return 0;

                int totalGrades = grades.Sum();
                return (double)totalGrades / grades.Count;
            }
        }

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
            courseEnrollment = new List<string>();
            grades = new List<int>();
        }

        public void AddGrade(int grade)
        {
            grades.Add(grade);
        }
    }

    class School
    {
        private List<Student> students;

        public School()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void DisplayStudents()
        {
            Console.WriteLine("List of Students:");
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, GPA: {student.GPA}");
            }
        }

        public double CalculateOverallGPA()
        {
            if (students.Count == 0)
                return 0;

            double totalGPA = students.Sum(student => student.GPA);
            return totalGPA / students.Count;
        }
    }

    class Program
    {
        static void Main()
        {
            School school = new School();

            while (true)
            {
                Console.WriteLine("Enter 1 to add a student");
                Console.WriteLine("Enter 2 to display the list of students");
                Console.WriteLine("Enter 3 to calculate the overall GPA of students");
                Console.WriteLine("Enter 4 to exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter the student's name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter the student's age:");
                        int age = Convert.ToInt32(Console.ReadLine());

                        Student student = new Student(name, age);

                        Console.WriteLine("Enter the number of courses the student is enrolled in:");
                        int numCourses = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < numCourses; i++)
                        {
                            Console.WriteLine($"Enter the name of course {i + 1}:");
                            string course = Console.ReadLine();
                            student.CourseEnrollment.Add(course);

                            Console.WriteLine($"Enter the grade for course {course} (A=4, B=3, C=2, D=1, F=0):");
                            int grade = Convert.ToInt32(Console.ReadLine());
                            student.AddGrade(grade);
                        }

                        school.AddStudent(student);
                        break;

                    case "2":
                        school.DisplayStudents();
                        break;

                    case "3":
                        double overallGPA = school.CalculateOverallGPA();
                        Console.WriteLine($"Overall GPA of students in the school: {overallGPA}");
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

}
