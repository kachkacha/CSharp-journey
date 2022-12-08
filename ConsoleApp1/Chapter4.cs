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
            indexAndRange();
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

        public void ParamsArgumentModifier() {
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

     }
}
