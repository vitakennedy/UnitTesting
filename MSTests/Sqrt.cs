using CSharpCalculator;

namespace MSTests
{
    [TestClass]
    public class Sqrt
    {
        private static Calculator _calculator;
        private static int negativeNumber;

        [ClassInitialize]
        public static void SetupClass(TestContext tc)
        {
            _calculator = new();
            negativeNumber = -5;
        }
        
        [TestInitialize]
        public void SetupInit()
        {
 
        }

        [TestMethod]
        [DataRow(4, 2)]
        [DataRow(144, 12)]
        [DataRow(0.09, 0.3)]
        [DataRow(0, 0)]
        [DataRow("9", 3)]
        [DataRow(true, 1)]
        [DataRow(null, 0)]
        public void IsSqrtCalculationCorrect(object input, double expectedOutput)
        {
            Assert.AreEqual(expectedOutput, _calculator.Sqrt(input));  
        }

        [TestMethod]
        public void IsTheSquareRootOfTheNegativeNumberNaN()
        {
            Assert.IsTrue(Double.IsNaN(_calculator.Sqrt(negativeNumber)));
        }

        [TestMethod, ExpectedException(typeof(System.FormatException))]
        [DataRow("string")]
        public void IsNotFiniteNumberExceptionThrownForString(object input)
        {
            _calculator.Sqrt(input);
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