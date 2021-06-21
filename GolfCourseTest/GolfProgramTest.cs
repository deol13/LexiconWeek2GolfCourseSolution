using Microsoft.VisualStudio.TestTools.UnitTesting;
using LexiconWeek2GolfCourse;
using System;

/// <summary>
/// https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019
/// Följde jag men kom ihåg när du skapar unit testern, ändra "Create new Solution" till "Add to Solution".
/// Då kommer Unit testern addas till solutionen som står i "Location" som nu ska ha ändras till program du vill testa på om du 
/// klickade på "add project" i projektet du vill testa 
/// 
/// I unit testern kommer du inte i åt Main method så ha inget du behöver unit testa där.
/// Jag kom inte åt static klasser heller.
/// Metoder som tar input från använder går inte bra att göra unit test på heller, så skapa mindre metoder med det du vill unit testa på
/// </summary>

namespace GolfCourseTest
{
    [TestClass]
    public class GolfProgramTest
    {
        public GolfCourse course = new GolfCourse();

        [TestMethod]
        public void CalcTheSwingTest_CorrectValue()
        {
            Swing swing = new Swing();
            swing.Angle = 45;
            swing.Velocity = 56;
            double gravity = 9.8;

            double angleInRadius = (Math.PI / 180) * swing.Angle;
            double distance = Math.Pow(swing.Velocity, 2) / gravity * Math.Sin(2 * angleInRadius);

            double golfCourseCalcDistance = course.CalcTheSwing(swing, gravity);

            //Checks so the result from the tested method is as expected
            Assert.AreEqual(distance, golfCourseCalcDistance);
        }

        [TestMethod]
        public void NewDistanceToCupTest_ValidNewDistance()
        {
            double distanceToCup = 57.5;
            double currentSwingDistance = 42.9;

            double newDistance = distanceToCup - currentSwingDistance;

            double golfCourseNewDistance = course.NewDistanceToCup(currentSwingDistance, distanceToCup);

            Assert.AreEqual(newDistance, golfCourseNewDistance);
        }
        [TestMethod]
        public void NewDistanceToCupTest_CalcNegativDistance_ReturnPositiv()
        {
            double distanceToCup = 57.5;
            double currentSwingDistance = 70;

            double newDistance = distanceToCup - currentSwingDistance;
            
            newDistance = newDistance * -1;

            double golfCourseNewDistance = course.NewDistanceToCup(currentSwingDistance, distanceToCup);

            Assert.AreEqual(newDistance, golfCourseNewDistance);
        }

        [TestMethod]
        public void IsBallTooFarAwayTest_NoThrowException()
        {
            try
            {
                course.IsBallTooFarAway(400, 500);
            }
            catch (MyCustomException e)
            {
                StringAssert.Contains(e.Message, course.TooFarAwayFromGoalExceptionMessage);
                return;
            }
        }
        [TestMethod]
        public void IsBallTooFarAwayTest_ThrowException()
        {
            try
            {
                course.IsBallTooFarAway(500, 400);
            }
            catch (MyCustomException e)
            {
                StringAssert.Contains(e.Message, course.TooFarAwayFromGoalExceptionMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
        
        [TestMethod]
        public void HaveUserSwingedTooManyTimesTest_NoThrowException()
        {
            try
            {
                course.HaveUserSwingedTooManyTimes(5, 10);
            }
            catch (MyCustomException e)
            {
                StringAssert.Contains(e.Message, course.TooManySwingsExceptionMessage);
                return;
            }
        }
        [TestMethod]
        public void HaveUserSwingedTooManyTimesTest_ThrowException()
        {
            try
            {
                course.HaveUserSwingedTooManyTimes(10, 10);
            }
            catch (MyCustomException e)
            {
                StringAssert.Contains(e.Message, course.TooManySwingsExceptionMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void GolfProgram_CheckIfUserWonTest_Won()
        {
            double totalDistanceToCup = 0;
            GolfCourse golfCourse = new GolfCourse();
            int nrOfSwings = 5;
            double[] distanceEachSwing = new double[] { 1, 2, 3, 4, 5};

            bool result = GolfProgram.CheckIfUserWon(totalDistanceToCup, golfCourse, nrOfSwings, distanceEachSwing);
            bool expectedResult = false;

            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void GolfProgram_CheckIfUserWonTest_didNotWin()
        {
            double totalDistanceToCup = 1;
            GolfCourse golfCourse = new GolfCourse();
            int nrOfSwings = 5;
            double[] distanceEachSwing = new double[] { 1, 2, 3, 4, 5 };

            bool result = GolfProgram.CheckIfUserWon(totalDistanceToCup, golfCourse, nrOfSwings, distanceEachSwing);
            bool expectedResult = true;

            Assert.AreEqual(expectedResult, result);
        }

    }
}
