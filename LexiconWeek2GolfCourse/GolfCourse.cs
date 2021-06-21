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
        
        public string Display(int nrOfSwings, double distanceToCup, int maxNrOfSwings)
        {
            string output = $"Number of swings made: {nrOfSwings}\nNumber of swings left: {maxNrOfSwings - nrOfSwings}\nDistance to cup: {distanceToCup}";
            return output;
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

        public void IsBallTooFarAway(double totalDistanceToCup, int maxDistanceeFronGoal)
        {
            if (totalDistanceToCup > maxDistanceeFronGoal)
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

        public string UserWonDisplay(int nrOfSwings, double[] eachSwing)
        {
            string output = "Congratulations you won, here's all your swings:\n";

            for (int i = 0; i < nrOfSwings; i++)
            {
                output = output + ($"Swing {i + 1}: {eachSwing[i]}\n");
            }

            return output;
        }
    }
}
