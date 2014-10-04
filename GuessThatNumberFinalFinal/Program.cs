using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    class Program
    {
        //Declared all the variables outside of main, so that they are visible in the GuessThatNumber method also
        public static int score = 100;
        public static Random rng = new Random();
        public static int compNum = rng.Next(1, 101);
        //flag to indicate when to exit the loop
        public static bool flag = false;
        public static string name;
        public static int noOfGuesses = 0;

        static void Main(string[] args)
        {
            Greet();
            Console.WriteLine("\nPress Enter to play game");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Guess a number: ");
            GuessThatNumber(int.Parse(Console.ReadLine()));

            //Console.WriteLine("Press Enter to see high scores");
            //Console.ReadKey();
            

            //AddScoreToDB();
            //DisplayHighScores();
        }

        static void Greet()
        {
            Console.Write("Enter Your name:");
            name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("\nWelcome to Guess That Number, " +name);
            Console.WriteLine("\ntype \"HELP\" for the introduction \n Or Press enter to skip the introduction:");
            string temp = Console.ReadLine();

            if (temp == "")
                return;
            else if (temp.ToLower() == "help")
            {
                Console.WriteLine(@"
Computer picks a random number between 1 and 100.
You need to guess 
the number in least possible guesses.
After each guess, computer tells you:
Either your guess is too high
Or your guess is too low.

Enjoy playing Guess That Number");

            }
        }

        static void GuessThatNumber(int userNum)
        {

            while (flag == false)
            {
                noOfGuesses++;
                score--;
                if (userNum == compNum)
                {
                    Console.Clear();
                    Console.WriteLine("Congratulations! " +name +" You guessed correctly");
                    Console.WriteLine("It took you " + noOfGuesses + " guesses");
                    Console.WriteLine("Your Score is: " + score);
                    flag = true;
                }
                else if (userNum > compNum)
                {
                    Console.WriteLine("Your guess is too high. Try again");
                    GuessThatNumber(int.Parse(Console.ReadLine()));
                }
                else
                {
                    Console.WriteLine("Your guess is too low. Try again");
                    GuessThatNumber(int.Parse(Console.ReadLine()));
                }
            }
            
        }

        //Add Score to the data base
        //static void AddScoreToDB()
        //{
        //    Console.WriteLine("Guess That Number High Scores");
        //    Console.WriteLine("==============================");

        //    GuessThatNumberFinalFinal.JayaEntities db = new GuessThatNumberFinalFinal.JayaEntities();
        //    GuessThatNumberFinalFinal.HighScore cureentScore = new GuessThatNumberFinalFinal.HighScore();

        //    cureentScore.Score = score;
        //    cureentScore.Name = name;
        //    cureentScore.Game = "Guess That Number";
        //    cureentScore.DateCreated = DateTime.Now;

        //    //add to data base
        //    db.HighScores.Add(cureentScore);

        //    //commit to data base
        //    db.SaveChanges();
        //}

        ////Display high scores from the data base
        //static void DisplayHighScores()
        //{
        //    //create a DB connection
        //    GuessThatNumberFinalFinal.JayaEntities db = new GuessThatNumberFinalFinal.JayaEntities();

        //    List<GuessThatNumberFinalFinal.HighScore> highScoreList = db.HighScores.Where(x => x.Game == "Guess That Number").OrderByDescending(x => x.Score).Take(10).ToList();

        //    foreach (var item in highScoreList)
        //    {
        //        Console.WriteLine(item.Name + " " + item.Score);
        //    }

        //}
    }
}
