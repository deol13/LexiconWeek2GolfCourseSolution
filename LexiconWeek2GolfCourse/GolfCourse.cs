using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconWeek2GolfCourse
{
    public class GolfCourse
    {

        public string TooFarAwayFromGoalExceptionMessage = "Fail: The ball got too far away from the goal!";
        public string TooManySwingsExceptionMessage = "Fail: You made too many swings";

        public int SetCupLocation(int minCupDistance, int maxCupDistance)
        {
            Random rng = new Random();
            
            return rng.Next(minCupDistance, maxCupDistance);
        }

        public void Display(int nrOfSwings, double distanceToCup, int maxNrOfSwings)
        {
            Console.WriteLine($"Number of swings made: {nrOfSwings}");
            Console.WriteLine($"Number of swings left: {maxNrOfSwings - nrOfSwings}");
            Console.WriteLine($"Distance to cup: {distanceToCup}");
        }

        public Swing UserSwings()
        {
            Swing userSwing = new Swing();
            string input = "";
            string[] whatShouldBeInputted = new string[2] { "angle", "velocity(m/s)" };
            double[] userInput = new double[2];
            int index = 0;

            while (index < 2)
            {
                try
                {
                    Console.Write($"Input {whatShouldBeInputted[index]}: ");
                    input = Console.ReadLine();
                    userInput[index] = ParseUserInput(input);
                    index++;
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Unable to parse {input} please try again with valid input!");
                    Console.ResetColor();
                }
            }

            userSwing.Angle = userInput[0];
            userSwing.Velocity = userInput[1];

            return userSwing;
        }

        public double ParseUserInput(string input)
        {
            return double.Parse(input ?? "");
        }

        public double CalcTheSwing(Swing userSwing, double gravity)
        {
            double angleInRadius = (Math.PI / 180) * userSwing.Angle;

            double distance = Math.Pow(userSwing.Velocity, 2) / gravity * Math.Sin(2 * angleInRadius);

            return distance;
        }

        public double NewDistanceToCup(double currentSwingDistance, double distanceToCup)
        {
            double newDistance = distanceToCup - currentSwingDistance;

            if (newDistance < 0)
            {
                newDistance = newDistance * -1;
            }

            return newDistance;
        }

        public void IsBallTooFarAway(double totalDistanceToCup, int maxDistanceeFfronGoal)
        {
            if (totalDistanceToCup > maxDistanceeFfronGoal)
            {
                throw new MyCustomException(TooFarAwayFromGoalExceptionMessage);
            }
        }

        public void HaveUserSwingedTooManyTimes(int nrOfSwings, int maxNrOfSwings)
        {
            if (nrOfSwings >= maxNrOfSwings)
            {
                throw new MyCustomException(TooManySwingsExceptionMessage);
            }
        }

        public void UserWonDisplay(int nrOfSwings, double[] eachSwing)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Congratulations you won, here's all your swings:");

            for (int i = 0; i < nrOfSwings; i++)
            {
                Console.WriteLine($"Swing {i + 1}: {eachSwing[i]}");
            }

            Console.ResetColor();
        }
    }
}
