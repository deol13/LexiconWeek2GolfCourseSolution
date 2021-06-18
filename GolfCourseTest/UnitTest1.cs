using Microsoft.VisualStudio.TestTools.UnitTesting;
using LexiconWeek2GolfCourse;

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
            catch(System.FormatException e)
            {
                StringAssert.Contains(e.Message, "Input string was not in a correct format.");
            }
        }


    }
}
