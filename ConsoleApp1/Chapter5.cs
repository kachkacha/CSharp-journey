using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Chapter5
    {
    }

    // Class types are fundamental constructs, it is basically a user defined blueprint
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
        public Motorcycle()
        {
            Console.WriteLine("In default constructor");
        }
        public Motorcycle(int intensity)
        : this(intensity, "")
        {
            Console.WriteLine("In constructor taking an int");
        }
        public Motorcycle(string name)
        : this(0, name)
        {
            Console.WriteLine("In constructor taking a string");
        }
        // This is the 'main' constructor that does all the real work.
        public Motorcycle(int intensity, string name)
        {
            Console.WriteLine("In main constructor");
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
    // properties can also have init instead of setter, which means you only will be able
    // to initialize it first and after that it will become readonly ( immutable )
    class Employee
    {
        private string _empName;
        private int _empId;
        private float _currPay;

        // error max just one of them can have acess modifier
        //public int Num { private get; private set; }
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
            => (Name, Age, Id, Pay) = (name, age, id, pay);
        // Updated DisplayStats() method now accounts for age.
        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", _empName);
            Console.WriteLine("ID: {0}", _empId);
            Console.WriteLine("Age: {0}", _empAge);
            Console.WriteLine("Pay: {0}", _currPay);
        }
    }

    // we can also use automatic properties, in this case private field is auto generated
    // for us, but we lose ability to implement any bussiness logic during setting or getting
    // the property, auto properties can also be initialized, they can be made readonlly by
    // omitting set, but we cannot omit get and make them writeonly. if we don't initialize
    // they will be equal to defaults for numbers 0, bolleans false, null for reference types
    class Car
    {
        // Automatic properties! No need to define backing fields.
        public string PetName { get; set; } = string.Empty;
        public int Speed { get; set; } = 0;
        public string Color { get; set; } // null by default
    }

    class Garage
    {
        // The hidden backing field is set to zero!
        public int NumberOfCars { get; set; }
        // The hidden backing field is set to null!
        public Car MyAuto { get; set; }
        // Must use constructors to override default
        // values assigned to hidden backing fields.
        public Garage() : this(new Car(), 1) { }
        public Garage(Car car, int number) => (MyAuto, NumberOfCars) = (car, number);
    }


    // these are the different ways to initialize objects. in object init syntax we can
    // use properties and public fields and assign them values to initialize them, also
    // even though we are using init syntax we still at first call the constructor and 
    // only then runs this init syntax and that is why if we use both constructor call
    // and init syntax at first constructor will return an object in which then init 
    // syntax will initialize written fields or properties
    class ObjectInitializationSyntax
    {
        public void ObjectInitializationSyntaxExample()
        {
            // Make a Point by setting each property manually.
            Point firstPoint = new Point();
            firstPoint.X = 10;
            firstPoint.Y = 10;

            // Or make a Point via a custom constructor.
            Point anotherPoint = new Point(20, 20);

            // Or make a Point using object init syntax.
            Point finalPoint = new Point { X = 30, Y = 30 , length = 30};

            // or make a Point using object init syntax alongside constructor
            Point finalFinalPoint = new Point(40, 40) { length = 40 };

            // one more example
            Rectangle myRect = new Rectangle
            {
                TopLeft = new Point { X = 10, Y = 10 , Color = PointColorEnum.Gold },
                BottomRight = new Point { X = 200, Y = 200 , Color = PointColorEnum.LightBlue }
            };
        }
    }

    enum PointColorEnum
    {
        LightBlue,
        BloodRed,
        Gold
    }

    class Point
    {
        public int length;
        public int X { get; set; }
        public int Y { get; set; }
        public PointColorEnum Color { get; set; } = PointColorEnum.BloodRed;
        public Point(int xVal, int yVal, PointColorEnum color = PointColorEnum.BloodRed) => (X, Y, Color) = (xVal, yVal, color);
        public Point() { }
        public void DisplayStats()
        {
            Console.WriteLine($"[{X}, {Y}]\nPoint is {Color}");
        }
    }

    class Rectangle
    {
        public Point TopLeft { get; set; } = new Point();
        public Point BottomRight { get; set; } = new Point();
        public void DisplayStats()
        {
            Console.WriteLine($"[TopLeft: {TopLeft.X}, {TopLeft.Y}, {TopLeft.Color} BottomRight: {BottomRight.X}, {BottomRight.Y}, {BottomRight.Color}]");
        }
    }

    // constants
    // we can use const keyword to define constants, fields or local variables defined
    // with const can't be changed afterwards that's why they must be assigned value at
    // declaration, their value must be known at compile time. constant fields are implicitely
    // static. we can use interpolation with const string as long as all string are also constants
    // readonly
    // readonly fields are like constants, their value can't be changed after assignment but the main
    // difference is that here field value can be unknown at compile time, that's why we can  
    // initialize readonly fields in constructors, but constants not. we can also define static readonly 
    // fields they need to be initialized at declaration or in static constructor;
    class MyMathClass
    {
        // Try to set PI in constructor?
        public const double constField = 3.14;
        public readonly double readonlyField;
        public static readonly double staticReadonlyField;

        static MyMathClass ()
        {
            staticReadonlyField = constField;
        }

        public MyMathClass(double readonlyField)
        {
            this.readonlyField = readonlyField;
            // Not possible- must assign at time of declaration.
            //PI = 3.14;
        }
    }

}
