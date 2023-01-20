using CSharpCalculator;

namespace UnitTesting
{
    [TestFixture]
    public class Addition
    {
        private Calculator _calculator;

        [OneTimeSetUp]
        public void Setup()
        {
            _calculator = new();
        }

        [TestCase("101", 10.5, 110.5)]
        [TestCase(-10.5, 10.5, 0)]
        [TestCase(100, 100, 200)]
        [TestCase(0, 0, 0)]
        [TestCase(-12, -12, -24)]
        [TestCase(double.MaxValue, double.MaxValue, double.PositiveInfinity)]
        public void IsAdditionCorrect(object firstInput, object secondInput, double expectedOutput)
        {
            Thread.Sleep(2000);
            Assert.That(_calculator.Add(firstInput, secondInput), Is.EqualTo(expectedOutput));
        }

        [TestCase("string", 5)]
        [TestCase(Double.NaN, 5)]
        [TestCase(" ", 5)]
        public void IsErrorReturned(object firstInput, object secondInput)
        {
            TestDelegate testDelegate = () => _calculator.Add(firstInput, secondInput);
            Assert.Throws<InvalidCastException>(testDelegate);
        }
    }
}