using CSharpCalculator;

namespace MSTests
{
    [TestClass]
    public class Pow
    {
        private static Calculator _calculator;
        private static string stringValue;
        private static string power1;

        [ClassInitialize]
        public static void SetupInit(TestContext tc)
        {
            _calculator = new();
            stringValue = "2";
            power1 = "1";
        }

        [TestMethod]
        [DataRow(2, 2, 4)]
        [DataRow(2, -5, 0.03125)]
        [DataRow(2.5, 2.5, 22.54)]
        public void IsPowCalculationCorrect(object baseNumber, object power, double expectedOutput)
        {
          Assert.AreEqual(expectedOutput, _calculator.Pow(baseNumber, power));  
        }

        [TestMethod, ExpectedException(typeof(System.NotFiniteNumberException))]
        public void IsExceptionThrownForString()
        {
             _calculator.Pow(stringValue, power1);
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