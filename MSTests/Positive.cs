using CSharpCalculator;

namespace MSTests
{
    [TestClass]
    public class Positive
    {
        private static Calculator _calculator;
        private string stringValue;
        private int negativeNumber;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _calculator = new();
        }

        [TestInitialize]
        public void SetupTest()
        {
            negativeNumber = -5;
            stringValue = "Hello";
        }

        [TestMethod]
        [DataRow(4, true)]
        [DataRow(-1, false)]
        [DataRow(-0.09, false)]
        [DataRow(0.87, true)]
        [DataRow(-0, false)]
        public void IsNumberPositive(object input, bool expectedOutput)
        {
          Assert.AreEqual(expectedOutput, _calculator.isPositive(input));  
        }

     
        [TestMethod, ExpectedException(typeof(System.NotFiniteNumberException))]
        [DataRow("6")]
        [DataRow('6')]
        [DataRow(true)]
        [DataRow(null)]
        public void IsNotFiniteNumberExceptionThrownForString(object input)
        {
            _calculator.isPositive(stringValue);
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