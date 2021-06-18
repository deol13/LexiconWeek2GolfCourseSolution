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
    public class UnitTest1
    {
        public GolfCourse course = new GolfCourse();

        [TestMethod]
        public void UserSwing_ShouldThrowFormatException_Letter()
        {
            string angle = "g";

            try
            {
                course.ParseUserInput(angle);
            }
            catch (System.FormatException e)
            {
                //Checks if the exception message is the same as second argument aka the string "Input string was not in a correct format."
                //If so then the method passes, if not then it shows the expected result wasn't achived aka the method tested on failed
                StringAssert.Contains(e.Message, "Input string was not in a correct format.");
                return;
            }

            //In this kind of test method, we expect an exception so if the test method reaches here, this test failed.
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void UserSwing_ShouldThrowFormatException_Symbol()
        {
            string velocity = ".";

            try
            {
                course.ParseUserInput(velocity);
            }
            catch (System.FormatException e)
            {
                StringAssert.Contains(e.Message, "Input string was not in a correct format.");
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void UserSwing_Success()
        {
            string angle = "6";
            string velocity = "10";

            try
            {
                course.ParseUserInput(angle);
                course.ParseUserInput(velocity);
            }
            catch (System.FormatException e)
            {
                StringAssert.Contains(e.Message, "Input string was not in a correct format.");
            }
        }

        [TestMethod]
        public void CalcTheSwing_ShouldReturnCorrectValue()
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
        public void NewDistanceToCup_ShouldReturnRightNewDistance()
        {
            double distanceToCup = 57.5;
            double currentSwingDistance = 42.9;

            double newDistance = distanceToCup - currentSwingDistance;

            double golfCourseNewDistance = course.NewDistanceToCup(currentSwingDistance, distanceToCup);

            Assert.AreEqual(newDistance, golfCourseNewDistance);
        }
        [TestMethod]
        public void NewDistanceToCup_ResultNegativ_ShouldStillReturnPositiv()
        {
            double distanceToCup = 57.5;
            double currentSwingDistance = 70;

            double newDistance = distanceToCup - currentSwingDistance;
            
            newDistance = newDistance * -1;

            double golfCourseNewDistance = course.NewDistanceToCup(currentSwingDistance, distanceToCup);

            Assert.AreEqual(newDistance, golfCourseNewDistance);
        }

        [TestMethod]
        public void IsBallTooFarAway_DoNotThrowException()
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
        public void IsBallTooFarAway_DoThrowException()
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
        public void HaveUserSwingedTooManyTimes_DoNotThrowException()
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
        public void HaveUserSwingedTooManyTimes_DoThrowException()
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

    }
}
