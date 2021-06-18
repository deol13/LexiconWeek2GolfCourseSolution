using Microsoft.VisualStudio.TestTools.UnitTesting;
using LexiconWeek2GolfCourse;
using System;

namespace GolfCourseTest
{
    [TestClass]
    public class UnitTest1
    {
        public GolfCourse course = new GolfCourse();

        [TestMethod]
        public void TestUserSwing_ShouldThrowFormatException_Letter()
        {
            string angle = "g";

            //Assert.ThrowsException<System.FormatException>(() => course.ParseUserInput(angle));
            try
            {
                course.ParseUserInput(angle);
            }
            catch (System.FormatException e)
            {
                StringAssert.Contains(e.Message, "Input string was not in a correct format.");
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void TestUserSwing_ShouldThrowFormatException_Symbol()
        {
            string velocity = ".";

            //Assert.ThrowsException<System.FormatException>(() => course.ParseUserInput(velocity));
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
        public void TestUserSwing_Success()
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
        public void Test_CalcTheSwing_ShouldReturnCorrectValue()
        {
            Swing swing = new Swing();
            swing.Angle = 45;
            swing.Velocity = 56;
            double gravity = 9.8;

            double angleInRadius = (Math.PI / 180) * swing.Angle;
            double distance = Math.Pow(swing.Velocity, 2) / gravity * Math.Sin(2 * angleInRadius);

            double golfCourseCalcDistance = course.CalcTheSwing(swing, gravity);

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

    }
}
