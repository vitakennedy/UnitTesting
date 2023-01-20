using CSharpCalculator;

namespace MSTests
{
    [TestClass]
    public class Sin
    {
        private static Calculator _calculator;
        private string stringValue = "Hello";

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _calculator = new();
        }

        [TestInitialize]
        public void SetupInit()
        {
           
        }

        [TestMethod]
        [DataRow(30, 0.5)]
        [DataRow(0, 0)]
        [DataRow(180, 0)]
        public void IsSinCalculationCorrect(double input, double expectedOutput)
        {
          Assert.AreEqual(expectedOutput, _calculator.Sin((input * (Math.PI)) / 180), 0.1);  
        }

        [TestMethod, ExpectedException(typeof(System.NotFiniteNumberException))]
        public void IsExceptionThrownForString()
        {
             _calculator.Sin(stringValue);
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