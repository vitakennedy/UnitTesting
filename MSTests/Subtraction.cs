using CSharpCalculator;

namespace MSTests
{
    [TestClass]
    public class Subtraction
    {
        private static Calculator _calculator;

        [ClassInitialize]
        public static void SetupClass(TestContext tc)
        {
             _calculator = new();
        }

        [TestInitialize]
        public void SetupTest()
        {

        }

        [TestMethod]
        [DataRow(4, 2, 2)]
        [DataRow(-5, -5, 0)]
        [DataRow(0.9, 3, -2.1)]
        [DataRow(0, 0, 0)]
        [DataRow("2", "2", 0)]
        [DataRow(false, true, -1)]
        [DataRow(null, true, -1)]
        public void IsSubtractionCorrect(object input1, object input2,  double expectedOutput)
        {
          Assert.AreEqual(expectedOutput, _calculator.Sub(input1, input2));  
        }

        [TestMethod, ExpectedException(typeof(System.NotFiniteNumberException))]
        [DataRow(2, "string")]
        [DataRow('6', 2)]
        public void IsNotFiniteNumberExceptionThrownForString(object input1, object input2)
        {
            _calculator.Sub(input1, input2);
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }
    }
}