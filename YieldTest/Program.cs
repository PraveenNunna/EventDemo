using System;

namespace YieldTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            var e = new Employee { Id = 1, Name = "Praveen" };

            e.NameChanged += E_NameChanged1;
            e.Name = "Praveen Nunna";
            
            Console.ReadKey();
        }

        private static void E_NameChanged1(object sender, EmployeeArgs e)
        {
            Console.WriteLine("New event args called");
        }

        private static void E_Event(object sender, EventArgs e)
        {
        }

        private static void E_NameChanged(string newName)
        {
            Console.WriteLine(newName);
        }


        public static void PrintNewName(string newName)
        {
            Console.WriteLine("New name printed from method is: " + newName);
        }
    }


    public class Employee
    {
        private string _name;

        public int Id { get; set; }

        public event EventHandler<EmployeeArgs> NameChanged;

        public event EventHandler Event;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                OnNameChanged(value);
                _name = value;
            }
        }

        protected void OnNameChanged(string newName)
        {
            NameChanged?.Invoke(this, new EmployeeArgs());
        }
    }

    public class EmployeeArgs : EventArgs
    {
        public string EmpName { get; set; }

        public int Id { get; set; }
    }
}
