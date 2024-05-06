using System;
using System.Data;
using System.Xml;

namespace TheMathChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                //generate 5 numbers between 0 and 9
                int[] playerNumbers = GenerateRandomNumbers();
                int playerScore = 0; //initializing player's score



                Console.WriteLine("Welcome to The Math Challange");
                Console.WriteLine("Your numbers:");
                foreach (int num in playerNumbers)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine("\nArrange these numbers using +, -, *, /, and = to form a true equation.");
                //read user input (equation)
                Console.Write("Enter your equation:");
                string userInput = Console.ReadLine();

                {

                }
                // validating user input
                bool isTrue = evaluatingEquation(userInput, playerNumbers);
                if (isTrue)
                {
                    Console.WriteLine("Yup, You got it right!!!");
                    playerScore++;
                    //keep track of the score
                }
                else
                {
                    Console.WriteLine("Dearie, this is wrong, good luck next time");
                }
                Console.WriteLine($"Your current score: {playerScore}");

                Console.Write("Ready for another round? (y/n)");
                string playAgainInput = Console.ReadLine();
                playAgain = (playAgainInput.ToLower() == "y");
            }
            Console.WriteLine("Thank you for taking the Challenge");
        }
        //helper methods goes here
        static int[] GenerateRandomNumbers()
        {
            Random random = new Random();
            int[] randomNumbers = new int[5];
            for (int i = 0; i < 5; i++)
            {
                randomNumbers[i] = random.Next(10);
            }
            return randomNumbers;
        }

        static bool evaluatingEquation(string equation, int[] playerNumbers)
        {
            try
            {
                for (int i = 0; i < playerNumbers.Length; i++)
                {
                    equation = equation.Replace((i + 1).ToString(), playerNumbers[i].ToString());
                }
                DataTable dt = new DataTable();
                var result = dt.Compute(equation, "");

                return Convert.ToBoolean(result);
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
