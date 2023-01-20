using CSharpCalculator;

namespace MSTests
{
    [TestClass]
    public class Negative
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
        [DataRow(4, false)]
        [DataRow(-1, true)]
        [DataRow(0.09, false)]
        [DataRow(0, false)]
        [DataRow(-0.005, true)]
        [DataRow("-0.005", true)]
        [DataRow(true, false)]
        public void IsNumberNegative(object input, bool expectedOutput)
        {
          Assert.AreEqual(expectedOutput, _calculator.isNegative(input));  
        }

        [TestMethod, ExpectedException(typeof(System.NotFiniteNumberException))]
        [DataRow("string")]
        [DataRow('6')]
        public void IsNotFiniteNumberExceptionThrownForString(object input)
        {
            _calculator.isNegative(input);
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