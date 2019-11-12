using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication_Create_user
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the username you want to create: ");
            string user = Console.ReadLine();
            Console.WriteLine("Welcome " +user+ "!!  Now You set your password:  ");
            string password= Console.ReadLine();
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("******************Login page*********************");
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("Enter your username");
            string userd = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string pwd = Console.ReadLine();

            if (userd == user && pwd == password)

            {
                Console.WriteLine("_______________**Hurray Login Succesful!!**______");
                Console.WriteLine("_________________________________________________");
                Console.WriteLine("NOW WE WILL USE OUR BRAND NEW CALCULATOR");             
                Console.WriteLine("Enter the first number: ");
                float num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the second number: ");
                float num2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Select the operation you want me to perform: ");
                Console.WriteLine("_________________________________________");
                Console.WriteLine("1: Multiplication");
                Console.WriteLine("2: Addition");
                Console.WriteLine("3: Subtraction");
                Console.WriteLine("4: Division");
                Console.WriteLine("__________________________________________");

                Console.WriteLine("Now please enter your choice from: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("The result is: " + (num1 * num2));
                    Console.Read();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("The result is: " + (num1 + num2));

                    Console.Read();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("The result is: " + (num1 - num2));

                    Console.Read();
                }
                else if (choice == 4)
                {
                    Console.WriteLine("The result is: " + (num1 / num2));

                    Console.Read();
                }

                else {

                    Console.WriteLine("Please Enter ur choice from the available list!!");
                }
            }
            else
            {
                Console.WriteLine("Login fail");
                Console.WriteLine("Please login with your credentials!! Try again Bye now!!");
                Console.ReadKey();
            }
        }
    }
}
