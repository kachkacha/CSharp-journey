using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class udemy
    {

        //enter friend names untill their name length is less than 20 characters
        public void FriendTextCounter()
        {
            int counteri = 10;
            int lengthoftext = 0;
            do
            {
                Console.WriteLine("enter a name of a friend: ");
                string nameofafriend = Console.ReadLine();
                lengthoftext += nameofafriend.Length;
            } while (lengthoftext < 20);
            Console.WriteLine($"enough! {lengthoftext}");

            int counter = 0;
            string s = string.Empty;
            while (s == string.Empty)
            {
                Console.WriteLine("enter smth: ");
                s = Console.ReadLine();
                counter++;
            }

            Console.WriteLine($"that is all {counter}");
        }

        public void PrintEven()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"odd here");
                    continue;
                }
                Console.WriteLine(i);
            }
        }

        /* 
         Imagine you are a developer and get a job in which you need to create a program for a teacher. He needs a program written in c# that calculates the average score of his students. So he wants to be able to enter each score individually and then get the final average score once he enters -1.
        So the tool should check if the entry is a number and should add that to the sum. Finally once he is done entering scores, the program should write onto the console what the average score is.
        The numbers entered should only be between 0 and 20. Make sure the program doesn't crash if the teacher enters an incorrect value.
        Test your program thoroughly.
         */

        public void ScoreAverage()
        {
            int scores = 0, score = 0, count = -1;
            string num = "0";
            do
            {
                if (int.TryParse(num, out score) && score >= 0 && score <= 20)
                {
                    scores += score;
                    count++;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                Console.Write("Enter Score: ");
                num = Console.ReadLine();
            } while (num != "-1");

            Console.WriteLine($"Average Score is {(double)scores / count}");
        }


        // class human 
        public class Human
        {
            private string firstName;
            private string lastName;
            private string eyeColor;
            private int age;

            public Human()
            {
                Console.WriteLine("object created");
            }
            public Human(string firstName)
            {
                this.firstName = firstName;
            }

            public Human(string firstName, string lastName)
            {
                this.firstName = firstName;
                this.lastName = lastName;
            }

            public Human(string firstName, string lastName, string eyeColor)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.eyeColor = eyeColor;
            }
            public Human(string firstName, string lastName, int age)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.age = age;
            }

            public Human(string firstName, string lastName, string eyeColor, int age)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.eyeColor = eyeColor;
                this.age = age;
            }

            public void Introduction()
            {
                Console.WriteLine($"hello i am {firstName} {lastName}, {eyeColor} eyed, {age} years old");
            }
        }

        public class Phone
        {
            public string Company;
            public string Model;
            public string ReleaseDay;

            public Phone(string company = "unknown", string model = "unknown", string releaseDay = "unknown")
            {
                Company = company;
                Model = model;
                ReleaseDay = releaseDay;
            }

            public void Introduce()
            {
                Console.WriteLine("It is {0} created by {1}. It was released {2}.", Model, Company, ReleaseDay);
            }

        }

        class Members
        {

            // member - private fields
            private string name;
            private string jobTitle;
            private int age;
            private double salary;
            // member - public fields

            public int count;

            // member - properties exposes field safely - start with capital letter
            public string Name
            {
                get { return name; }
                set
                {
                    name = value;
                }
            }


            // public member method can be call from other classes
            public void Introduction(bool isFriend)
            {
                Console.WriteLine($"hi i am {name} i am {age} years old, i'm {jobTitle}");
                if (isFriend)
                {
                    sharePrivateInfo();
                }
            }

            // private member method can be called from inside the class only
            private void sharePrivateInfo()
            {
                Console.WriteLine($"my salary is {salary}");
            }


            // member constructor
            public Members()
            {
                name = "luffy";
                age = 17;
                jobTitle = "pirate";
                salary = 1_500_000_000;
            }


            // entry is created in the finalizing queue when finalizers are called
            // garbage collector invokes the process on that queue

            // member - finalizer - destructor
            ~Members()
            {
                // cleanup statements
                Console.WriteLine("Object is gone");
                Debug.Write("debug diagnostic");
            }


        }




        class Box
        {
            //member fields
            private int length = 3;
            public int height;
            private int width;
            private int volume;

            public int FrontSurace
            {
                get
                {
                    return this.length * this.height;
                }
            }


            public int Width { get; set; }
            public int Volume
            {
                get
                {
                    return this.length * this.height * this.width;
                }
            }

            public int Height
            {
                get { return height; }
                set
                {
                    if (value < 0)
                    {
                        value -= 1;
                    }
                    height = value;
                }
            }

            public Box(int length, int height, int width)
            {
                this.length = length;
                Height = height;
                this.width = width;
            }



            // setter method
            public void SetLength(int length)
            {
                if (length < 0)
                {
                    throw new ArgumentException("Length should be non negative");
                }
                this.length = length;
            }

            // getter method
            public int GetLength()
            {
                return this.length;
            }

            public int GetVolume()
            {
                return this.length * this.height * this.width;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"length - {length}; height - {Height}; width - {this.width}; volume - {Volume}");
            }


        }
    }
}
