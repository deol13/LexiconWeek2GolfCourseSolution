using System;

namespace LexiconWeek2GolfCourse
{
    class Program
    {
        //I don't like setting variables that can and should be changed as "Global" in
        //this can of program where the entire program is in one class.
        //I see "maxNrOfSwings" in this kind of program as a global variable from C++.
        //Accessible from everywhere 

        //If the program were larger and spanned across multiple classes and they were treated just as objects then
        //it wouldn't be a problem because then they would be class memebers. 

        //Here maxNrOfSwings is const so it can't be changed from anywhere else thus its fine
        private const int MAXNROFSWINGS = 10;
        //private const double distanceFromGoalPlayerLose = 1000;
        private const double GRAVITY = 9.8;
        private const int MAXCUPDISTANCE = 5;
        private const int MINCUPDISTANCE = 1;
        private const int MAXDISTANCEFROMGOAL = 10;

        //public const string TooFarAwayFromGoalExceptionMessage = "Fail: The ball got too far away from the goal!";
        //public const string TooManySwingsExceptionMessage = "Fail: You made too many swings";

        static void Main(string[] args)
        {
            //So the rest are local variables that needs to be sent from one method to another
            // GolfCourse gCourse = new GolfCourse();
            Swing userSwing = new Swing();
            int nrOfSwings = 0;
            double[] distanceEachSwing = new double[MAXNROFSWINGS];
            bool continueToPlay = true;
            double latestSwingDistance = 0;



            double totalDistanceToCup = GolfCourse.SetCupLocation(MINCUPDISTANCE, MAXDISTANCEFROMGOAL);

            //Starting message
            Console.WriteLine("Welcome to a golf game!\n"
                + "In this golf game you are at the end of a course and know the distance to the goal.\n"
                + "You input your swing's angle and velocity to make the ball into the goal.\n"
                + "Angle is degrees from the ground up and velocity is m/s at the start of the ball's arc.\n"
                + "The program calculates how far you swing sent the ball, if you went far enough you win.\n"
                + "If you swinged too many times or is to far away from the goal you lose.\n"
                + "Between each swing you see how many swings you have done and the distance to the goal.\n"
                + "\nPress a key to start the game!");
            Console.ReadKey();

            try
            {
                //Game loop
                do
                {
                    Console.Clear();
                    GolfCourse.Display(nrOfSwings, totalDistanceToCup, MAXNROFSWINGS);

                    userSwing = GolfCourse.UserSwings();

                    latestSwingDistance = GolfCourse.CalcTheSwing(userSwing, GRAVITY);

                    distanceEachSwing[nrOfSwings] = latestSwingDistance;

                    totalDistanceToCup = GolfCourse.NewDistanceToCup(latestSwingDistance, totalDistanceToCup);

                    nrOfSwings++;

                    if (totalDistanceToCup == 0)
                    {
                        continueToPlay = false;
                        GolfCourse.UserWonDisplay(nrOfSwings, distanceEachSwing);
                    }
                    else
                    {
                        GolfCourse.IsBallTooFarAway(totalDistanceToCup, MAXDISTANCEFROMGOAL);
                        GolfCourse.HaveUserSwingedTooManyTimes(nrOfSwings, MAXNROFSWINGS);
                    }

                } while (continueToPlay);
            }
            catch (MyCustomException e)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
    }
}
