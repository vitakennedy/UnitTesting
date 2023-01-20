using CSharpCalculator;

namespace UnitTesting
{
    [TestFixture]
    public class Multiply
    {
        private Calculator _calculator;

        [OneTimeSetUp]
        public void Setup()
        {
            _calculator = new();
        }

        [TestCase("100", 50, 2)]
        [TestCase(100, 0, 0)]
        [TestCase(52.5, 5, 10.5)]
        [TestCase(-100, 100, -1)]
        [TestCase(-12, -12, 1)]
        [TestCase(double.MaxValue, double.MaxValue, double.PositiveInfinity)]
        public void CheckDivisionIsCorrect(double firstInput, double secondInput, object expectedOutput)
        {
            Assert.That(_calculator.Multiply(firstInput, secondInput), Is.EqualTo(expectedOutput));
        }

        [TestCase("string")]
        [TestCase("")]
        [TestCase(Double.NaN)]
        public void IsError(object firstInput)
        {
            TestDelegate testDelegate = () => _calculator.Abs(firstInput);
            Assert.Throws<NotFiniteNumberException>(testDelegate);
        }
    }
}