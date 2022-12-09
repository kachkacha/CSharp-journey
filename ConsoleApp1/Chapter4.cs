using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Chapter4
    {
        public void Run()
        {

        }

        public void ArrayInitialization()
        {
            // Create and fill an array of 3 Integers
            int[] myInts = new int[3];
            myInts[0] = 100;
            myInts[1] = 200;
            myInts[2] = 300;

            // Array initialization syntax using the new keyword.
            string[] stringArray = new string[] { "one", "two", "three" };

            // Array initialization syntax without using the new keyword.
            bool[] boolArray = { false, false, true };

            // Array initialization with new keyword and size.
            int[] intArray = new int[4] { 20, 22, 23, 0 };

            // Array initialization implicitely without writing type 
            var arr = new[] { 1, 10, 100, 1000 };
        }

        public void ArrayUsefulMembers()
        {
            int[] arr1 = { 20, 22, 23, 0 };
            int[] arr2 = new int[4];

            // element at specified index
            arr1.ElementAt(^2);

            //copy 1 array elements to other
            arr1.CopyTo(arr2, 2);

            //change elements to default values
            Array.Clear(arr1);

            arr2.Reverse();

            Array.Sort(arr2);

            //array length
            int arrLength = arr2.Length;

            //array dimensions
            int arrDimensions = arr2.Rank;

        }

        public void indexAndRange()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6 };

            //Index and Range are used for working with sequences (including arrays)
            Index index1 = 2;
            // ^ means from the end ( ^x equals arr.Length - x )
            Index index2 = ^2;

            Range r = index1..index2;

            // prints arrays from the indicated range, second index is exclusive
            foreach (var item in arr[r])
            {
                Console.WriteLine(item);
            }
        }

        // different ways of creating multidimentional arrays
        public void MultiDimentionalArray()
        {
            // rectangular array
            int[,] arr = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            // jugged array - each row with different sizes
            int[][] myJagArray = new int[5][];
            for (int i = 0; i < myJagArray.Length; i++)
            {
                myJagArray[i] = new int[i + 7];
            }

        }
        public int Add1(int x, int y)
        {
            return x + y;
        }
        //shortcut to write single-line statements, => is a lambda operator
        public int Add2(int x, int y) => x + y;

        // local function example
#nullable enable
        public static void Process(string?[] lines, string mark)
        {
            foreach (var line in lines)
            {
                if (IsValid(line))
                {
                    // Processing logic...
                }
            }
            bool IsValid([NotNullWhen(true)] string? line)
            {
                return !string.IsNullOrEmpty(line) && line.Length >= mark.Length;
            }
        }

        //static local functions cannot access parents variables
        public int AddWrapperWithStatic(int x, int y)
        {
            //Do some validation here
            return Add(x, y);

            static int Add(int x, int y)
            {
                return x + y;
            }

        }

        public void outParam()
        {
            // example for out parameters
            FillTheseValues(out int a, out string b, out bool c);

            // we can like this ignore last two variables, they will still be created and assigned
            // in called method but discarded afterwards
            FillTheseValues(out int a1, out _, out _);
        }

        public void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Enjoy your string.";
            c = true;
        }

        // parameters with in modifier are passed by reference but can not be modified
        public int AddReadOnly(in int x, in int y)
        {
            //Error CS8331 Cannot assign to variable 'in int' because it is a readonly variable
            //x = 10000;
            //y = 88888;
            int ans = x + y;
            return ans;
        }

        public void ParamsArgumentModifier()
        {
            double average;

            // Pass in a comma-delimited list of doubles...
            average = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);

            // ...or pass an array of doubles.
            double[] data = { 4.0, 3.2, 5.7 };
            average = CalculateAverage(data);

            // don't pass anything
            average = CalculateAverage();
        }

        // with params keyword we can send multiple parameters to method which during runtime will be converted to arrays
        // arguments with params keyword must be at the end of the list
        public double CalculateAverage(params double[] values)
        {
            double sum = 0;
            if (values.Length == 0)
            {
                return sum;
            }
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return (sum / values.Length);
        }

        // method parameters can have default values ( they must be known at compile time and be at the end of the list)
        // and we can call such methods by omitting default ones
        public void EnterLogData(string message, string owner = "Programmer")
        {

            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }


        public void DisplayFancyMessage(ConsoleColor textColor, ConsoleColor backgroundColor, string message)
        {
            // Store old colors to restore after message is printed.
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldbackgroundColor = Console.BackgroundColor;
            // Set new colors and print message.
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);
            // Restore previous colors.
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldbackgroundColor;
        }

        //named parameters
        public void NamedParams()
        {
            // This is OK, as positional args are listed before named args.
            DisplayFancyMessage(ConsoleColor.Blue, message: "Testing...", backgroundColor: ConsoleColor.White);

            // This is OK, all arguments are in the correct order
            DisplayFancyMessage(textColor: ConsoleColor.White, backgroundColor: ConsoleColor.Blue, "Testing...");
            // This is an ERROR, as positional args are listed after named args.
            //DisplayFancyMessage(message: "Testing...", backgroundColor: ConsoleColor.White, ConsoleColor.Blue);
        }


        // methods can be overloaded they must differ by parameter count or types
        // we can also overload with modifiers (out, ref, in) but can ony use one of them
        // if there also is method with optional parameter when compiler has multiple choises
        // it chooses the first signature
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Add(double x, double y)
        {
            return (int)(x + y);
        }
        public long Add(ref int x, ref int y)
        {
            return x + y;
        }

        // error because we already have overloaded method with ref modifier
        /* 
        public int Add(out int x, out int y)
        {
            return x + y;
        }
        */

        // oneliner to check parameter for null
        public void CheckForNull(string message, string owner = "Programmer")
        {
            ArgumentNullException.ThrowIfNull(message);
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }

        // enums named constants can be set to different values, if value is omitted
        // then it is increased by 1 from previous, it first value is omitted it is set to 0 
        // we can also specify with type to use for storage (byte, short, int, long)
        public enum EmpTypeEnum : short // size of this enum
        {
            Manager = 10,
            Grunt,// 11
            Contractor,// 12
            VicePresident = -9
        }

        // we can use System.Enum classes static method to get value type used for storing enum
        public void UnderlyingType()
        {
            EmpTypeEnum emp = EmpTypeEnum.Manager;
            Console.WriteLine(Enum.GetUnderlyingType(emp.GetType()));
            Console.WriteLine(Enum.GetUnderlyingType(typeof(EmpTypeEnum)));
        }

        // Enum.GetValues() example
        public void EvaluateEnum(Enum e)
        {
            // Get all name-value pairs for incoming parameter.
            Array enumData = Enum.GetValues(e.GetType());

            // Now show the string name and associated value, using the D format
            foreach (var item in enumData)
            {
                var typ = Enum.GetUnderlyingType(typeof(EmpTypeEnum));
                // does not work during n format specifier
                Console.WriteLine($"Name: {item}, Value: {item:d}");
            }
        }

        // structs are lightweight classes deerived from System.ValueType 
        // and they are allocated on stack
        // they can not extend anything and be base for others but can
        // implement interfaces, before using structures all fields should be
        // initialized 
        public struct Point
        {
            public int X;
            public int Y = 0;
            //Parameterless constructor
            public Point()
            {
                X = 0;
            }
            // A custom constructor.
            public Point(int xPos, int yPos)
            {
                X = xPos;
                Y = yPos;
            }

            public void Increment()
            {
                X++;
                Y++;
            }
        }

        /******* QUESTION WHAT IS DIFFERENCE BETWEEN READONLY AND CONSTANT? *************/

        // we can declare struct fields as readonly so that they will be immutable
        // or the whole struct can be declarded readonly after what all its fields
        // also should be readonly, we can also declare methods as readonly and inside
        // them fields will not change, also if it calls non readonly functioin fields
        // will be transfered with in modifiers so they will not change there
        public struct PointWithReadOnly
        {
            // Fields of the structure.
            public int X;
            public readonly int Y = 8;
            public readonly string Name;
            // Display the current position and name.
            public readonly void Display()
            {
                Console.WriteLine($"X = {X}, Y = {Y}, Name = {Name}");
            }
            // A custom constructor.
            public PointWithReadOnly(int xPos, int yPos, string name)
            {
                X = xPos;
                Y = yPos;
                Name = name;
            }
        }

        // ref structs can not implement interfaces, can not be fields to non ref structs
        // cannot be used in async methods, iterators, lambda expressions, or local functions
        // they don't implement IDisposable but you can use public void Dispose() method
        public ref struct DisposableRefStruct
        {
            public int X;
            public readonly int Y;
            public readonly void Display()
            {
                Console.WriteLine($"X = {X}, Y = {Y}");
            }
            // A custom constructor.
            public DisposableRefStruct(int xPos, int yPos)
            {
                X = xPos;
                Y = yPos;
                Console.WriteLine("Created!");
            }
            public void Dispose()
            {
                //clean up any resources here
                Console.WriteLine("Disposed!");
            }
        }
        
        // we create tuples simply by enclosing different types of variables in parentheses
        // there are couple of ways declaring tuples by assigning it to var, declaring tuple's
        // types on the left or additionally giving them names on the left or on the right side
        // of assignment, if describled on both sides then left is dominant, by default to access
        // tuples we can use Item1, Item2 and so on, tuples can contain other tuples
        public void TuplesMethod()
        {
            var tuples1 = ("a", 3, "c", (1, 2));
            (string, int p, string, (int, int)) tuples2 = ("a", 3, "c", tupli:(1, 2));
            var tuples3 = tuples1.ToTuple(); // class
            
            Console.WriteLine(tuples1.GetType());
            Console.WriteLine(tuples3.GetType());

            var (a, _, _) = RockPaperScissors(("rock", "paper", true)); // middle and last ones are discarded
            Console.WriteLine($"result: {a}, discarded others");

            var left = (a: 5, b: 10);
            (int? a, int? b) nullableMembers = (5, 10);
            Console.WriteLine(left == nullableMembers); // Also true converted type of left is (long, long)
            (long a, long b) longTuple = (5, 10);
            Console.WriteLine(left == longTuple); // Also true comparisons performed on (long, long) tuples
            (long a, int b) longFirst = (5, 10);
            (int a, long b) longSecond = (5, 10);
            Console.WriteLine(longFirst == longSecond); // Also true
        }

        // tuple as method parameter and return types using switch expression
        public (string a, string s, bool b) RockPaperScissors((string a, string b, bool c) tupli) {

            return tupli switch
            {
                ("rock", "paper", _) => ("Paper wins.", tupli.b, tupli.c),
                ("rock", "scissors", _) => ("Rock wins.", tupli.b, tupli.c),
                ("paper", "rock", _) => ("Paper wins.", tupli.b, tupli.c),
                ("paper", "scissors", _) => ("Scissors wins.", tupli.b, tupli.c),
                ("scissors", "rock", _) => ("Rock wins.", tupli.b, tupli.c),
                ("scissors", "paper", _) => ("Scissors wins.", tupli.b, tupli.c),
                (_, _, _) => ("Tie.", tupli.b, tupli.c),
            };
        }


    }
}
