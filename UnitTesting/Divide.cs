using CSharpCalculator;

namespace UnitTesting
{
    [TestFixture]
    public class Divide
    {
        private Calculator _calculator;

        [OneTimeSetUp]
        public void Setup()
        {
            _calculator = new();
        }

        [TestCase("100", 50, 2)]
        [TestCase(52.5, 5, 10.5)]
        [TestCase(-100, 100, -1)]
        [TestCase(-12, -12, 1)]
        public void CheckDivisionIsCorrect(double firstInput, double secondInput, object expectedOutput)
        {
            Assert.That(_calculator.Divide(firstInput, secondInput), Is.EqualTo(expectedOutput));
        }

        [TestCase(Double.NaN)]
        [TestCase(Double.PositiveInfinity)]
        [TestCase(Double.NegativeInfinity)]
        public void IsErrorReturned(double firstInput)
        {
            TestDelegate testDelegate = () => _calculator.Divide(firstInput, 5);
            Assert.Throws<NotFiniteNumberException>(testDelegate);
        }

        [TestCase("string")]
        public void IsErrorReturnedWhenEnterString(double firstInput)
        {
            TestDelegate testDelegate = () => _calculator.Divide(firstInput, 5);
            Assert.Throws<FormatException>(testDelegate);
        }

        [Test]
        public void IsErrorReturnedWhenDivideByZero()
        {
            TestDelegate testDelegate = () => _calculator.Divide(100, 0);
            Assert.Throws<DivideByZeroException>(testDelegate);
        }
    }
}