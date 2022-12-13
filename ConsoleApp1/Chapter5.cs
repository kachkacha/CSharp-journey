using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Chapter5
    {
    }

    // Classes types are fundamental construct, it is basically a user defined blueprint
    // for creating objects (instances of the class), they have fields where their state
    // is stored and also methods / functions that are used for changing it's state.
    // classes use constructors for creating objects by default they have 0 parameter
    // constructor that initializes fields to default values, but we can define our own
    // after which default will be gone, constructors can also we overloaded
    // there is this keyword that can be used inside the class to refer to the current
    // instance, this can also be used to chain constructor call, we can additionally use
    // optional parameters and (ref out in) inside constructors
    class Motorcycle
    {
        public int driverIntensity;
        public string driverName;

        // Constructor chaining.
        public Motorcycle() { }

        public Motorcycle(int intensity) : this(intensity, "") { }

        public Motorcycle(string name) : this(0, name) { }

        // This is the 'master' constructor that does all the real work.
        public Motorcycle(int intensity, string name)
        {
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
            driverName = name;
        }
    }

    // we can use static keyword to define fields and mthods / functions at class level
    // which means we will be able to use them without creating an instance of the class
    // they are not attached to any of the created instance, for initializing static
    // fields we can use static constructors which wont have any parameters and which
    // will be run only once, we can also use static keyword for declaring classes
    // by doing so they will only be able to have static members and we won't be able to
    // create their instances. static keyword also can be used for importing stating classes
    class SavingsAccount
    {
        public double currBalance;
        public static double currInterestRate;
        public SavingsAccount(double balance)
        {
            currBalance = balance;
        }
        // A static constructor!
        static SavingsAccount()
        {
            Console.WriteLine("In static constructor!");
            currInterestRate = 0.04;
        }
    }

    // properties are very good tools for encapsulation they hide private fields behind the
    // curtains and give us getter to return fields valus and setters for changing field
    // values which both can contain some bussiness logic, we can make properties readonly
    // by omitting set option, and we can also make them writeonly by omitting get option
    class Employee
    {
        private string _empName;
        private int _empId;
        private float _currPay;

        public string Name
        {
            get { return _empName; }
            set
            {
                if (value.Length > 15)
                {
                    Console.WriteLine("Error! Name length exceeds 15 characters!");
                }
                else
                {
                    _empName = value;
                }
            }
        }
        // We could add additional business rules to the sets of these properties;
        // however, there is no need to do so for this example.
        public int Id
        {
            get => _empId;
            set => _empId = value;
        }
        public float Pay
        {
            get { return _currPay; }
            set { _currPay = value; }
        }

        // New field and property.
        private int _empAge;
        public int Age
        {
            get { return _empAge; }
            set { _empAge = value; }
        }

        // Updated constructors.
        public Employee() { }
        public Employee(string name, int id, float pay)
        : this(name, 0, id, pay) { }
        public Employee(string name, int age, int id, float pay)
        {
            _empName = name;
            _empId = id;
            _empAge = age;
            _currPay = pay;
        }
        // Updated DisplayStats() method now accounts for age.
        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", _empName);
            Console.WriteLine("ID: {0}", _empId);
            Console.WriteLine("Age: {0}", _empAge);
            Console.WriteLine("Pay: {0}", _currPay);
        }
    }


}
