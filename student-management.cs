class Student
{
    public int IndexNumber;
    public string Name;
    public double GPA;
    public int AdmissionYear;
    public string NIC;

    public Student Next; 
}

class StudentList
{
    private Student head = null;
    
    public void Insert(Student newStudent)
    {
        if (Search(newStudent.IndexNumber) != null)
        {
            Console.WriteLine("Error: Student with the same index already exists.");
            return;
        }

        if (head == null || newStudent.IndexNumber < head.IndexNumber)
        {
            newStudent.Next = head;
            head = newStudent;
            return;
        }

        Student current = head;
        while (current.Next != null && current.Next.IndexNumber < newStudent.IndexNumber)
        {
            current = current.Next;
        }

        newStudent.Next = current.Next;
        current.Next = newStudent;
    }
    
    public Student Search(int indexNumber)
    {
        Student current = head;
        while (current != null)
        {
            if (current.IndexNumber == indexNumber)
                return current;
            current = current.Next;
        }
        return null;
    }
    
    public bool Remove(int indexNumber)
    {
        if (head == null)
            return false;

        if (head.IndexNumber == indexNumber)
        {
            head = head.Next;
            return true;
        }

        Student current = head;
        while (current.Next != null && current.Next.IndexNumber != indexNumber)
        {
            current = current.Next;
        }

        if (current.Next == null)
            return false;

        current.Next = current.Next.Next;
        return true;
    }
    
    public void PrintAll()
    {
        if (head == null)
        {
            Console.WriteLine("No students in the list.");
            return;
        }

        Student current = head;
        while (current != null)
        {
            Console.WriteLine($"Index: {current.IndexNumber}\nName: {current.Name}\nGPA: {current.GPA}\nAdmission Year: {current.AdmissionYear}\nNIC: {current.NIC}");
            current = current.Next;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        StudentList list = new StudentList();
        int choice;

        do
        {
            Console.WriteLine("\n--- Student Management ---");
            Console.WriteLine("1. Insert Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Print All Students");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Student student = new Student();
                    Console.Write("Enter Index Number: ");
                    student.IndexNumber = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    student.Name = Console.ReadLine();
                    Console.Write("Enter GPA: ");
                    student.GPA = double.Parse(Console.ReadLine());
                    Console.Write("Enter Admission Year: ");
                    student.AdmissionYear = int.Parse(Console.ReadLine());
                    Console.Write("Enter NIC: ");
                    student.NIC = Console.ReadLine();

                    list.Insert(student);
                    break;

                case 2:
                    Console.Write("Enter Index Number to search: ");
                    int searchIndex = int.Parse(Console.ReadLine());
                    Student found = list.Search(searchIndex);
                    if (found != null)
                    {
                        Console.WriteLine($"Found: \nIndex: {found.IndexNumber}\nName: {found.Name}\nGPA: {found.GPA}\nAdmission Year: {found.AdmissionYear}\nNIC: {found.NIC}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case 3:
                    Console.Write("Enter Index Number to remove: ");
                    int removeIndex = int.Parse(Console.ReadLine());
                    if (list.Remove(removeIndex))
                        Console.WriteLine("Student removed.");
                    else
                        Console.WriteLine("Student not found.");
                    break;

                case 4:
                    list.PrintAll();
                    break;

                case 5:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 5);
    }
}
