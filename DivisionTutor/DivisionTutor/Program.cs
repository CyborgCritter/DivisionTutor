using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionTutor
{
    class Program
    {
        static TrimmerHeader myHeader = new TrimmerHeader();
        static Random myRand = new Random();
        static int problemSolution = 0;

        static void Main(string[] args)
        {
            int minimum = 0;
            int maximum = 0;
            string askIfUserWantContinue = "Press y to continue, or n to quit... ";

            // Initialize any object variables I want to change.  The assignment name must always be initialized.
            myHeader.StudentAssignment = "Division Tutor";
            
            do
            {
                // Print header before printing anything else.
                myHeader.ClearAndPrintHeader();

                minimum = GetMaxOrMin("minimum");

                do
                {
                    maximum = GetMaxOrMin("maximum");

                    if (maximum <= minimum)
                    {
                        Console.WriteLine("The maximum must be greater than the minumum.");
                    }
                } while (maximum <= minimum);

                GetDivisionProblem(minimum, maximum);
            } while (GetUserContinue(askIfUserWantContinue));
        }

        static int GetMaxOrMin(string maxOrMin)
        {
            //Get the users input for their desired maximum or minimum.

            bool isNumberEnteredValid = false;
            string usersEntry = "";
            int usersNumber = 0;

            do
            {
                Console.Write("Enter the {0} value to use for this problem... ", maxOrMin);

                usersEntry = Console.ReadLine();

                myHeader.ClearAndPrintHeader();

                isNumberEnteredValid = int.TryParse(usersEntry, out usersNumber);

                //Print an error message if the users entry was invalid.
                if (!isNumberEnteredValid)
                {
                    Console.WriteLine("That is not a valid entry for the {0}... ", maxOrMin);
                }
            } while (!isNumberEnteredValid);

            return usersNumber;
        }

        static void GetDivisionProblem(int minimum, int maximum)
        {
            // Get a division Problem for the user.
            int numerator = 1;
            int denominator = 1;

            numerator = GetRandomInteger(minimum, maximum);

            // Ensure that the denominator is not 0 and divides evenly with the numerator.
            do
            {
                do
                {
                    denominator = GetRandomInteger(minimum, maximum);
                } while (denominator == 0);
            } while (numerator % denominator != 0);

            problemSolution = numerator / denominator;

            GiveUserProblem(numerator, denominator);
        }

        static int GetRandomInteger(int minimum, int maximum)
        {
            // Get a random number in the users chosen range for the math problem.
            int randomNumber = 0;

            randomNumber = myRand.Next(minimum, maximum);

            return randomNumber;
        }

        static void GiveUserProblem(int numerator, int denominator)
        {
            //Display the problem to the user, and ask them to attempt to answer it.

            bool isValidEntry = false;
            bool tryAgain = false;
            int quotient = 0;
            string usersGuess = "";

            do
            {
                Console.Write("What is {0}/{1}... ", numerator, denominator);
                usersGuess = Console.ReadLine();

                isValidEntry = int.TryParse(usersGuess, out quotient);

                if (!isValidEntry || quotient != problemSolution)
                {
                    Console.WriteLine("\nI am sorry, that is not correct.");
                    tryAgain = GetUserContinue("Would you like to try again?\nPress 'y' to try again, or 'n' to quit this problem. ");
                    myHeader.ClearAndPrintHeader();
                }

                if (tryAgain == false)
                {
                    break;
                }
            }while(!isValidEntry || quotient != problemSolution);

            myHeader.ClearAndPrintHeader();

            if (quotient == problemSolution)
            {
                Console.WriteLine("Congratulations! You are correct.");
            }
            else
            {
                Console.WriteLine("I am sorry, but that was incorrect.");
            }

            Console.WriteLine("{0}/{1}={2}\n", numerator, denominator, problemSolution);
        }

        static bool GetUserContinue(string printToUser)
        {
            //Function to let the user choose if they want to continue or quite.

            bool userWantContinue = false;
            char userKeyPress = ' ';

            do
            {
                // continue checking for the user input, until the proper key is pressed.
                Console.Write(printToUser);

                // Use char.ToLower to only have to check for lowercase values.
                userKeyPress = char.ToLower(Console.ReadKey(true).KeyChar);

                if (userKeyPress != 'y' && userKeyPress != 'n')
                {
                    myHeader.ClearAndPrintHeader();
                    Console.WriteLine("That was not an available selection, please try again.");
                }

            } while (userKeyPress != 'y' && userKeyPress != 'n');

            if (userKeyPress == 'y')
            {
                userWantContinue = true;
            }
            else
            {
                userWantContinue = false;
            }

            return userWantContinue;
        }
    }
}
