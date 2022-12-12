using System;
using System.Collections.Generic;
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

            public Phone(string company = "unknown", string model = "unknown", string releaseDay = "unknown") {
                Company = company;
                Model = model;
                ReleaseDay = releaseDay;
            }

            public void Introduce()
            {
                Console.WriteLine("It is {0} created by {1}. It was released {2}.", Model, Company, ReleaseDay);
            }

        }

    }
}
