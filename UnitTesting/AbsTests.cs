using CSharpCalculator;

namespace UnitTesting
{
    [TestFixture]
    public class AbsTests
    {
        private Calculator _calculator;

        [OneTimeSetUp]
        public void Setup()
        {
            _calculator = new();
        }

        [TestCase(-10.5, 10.5)]
        [TestCase(100, 100)]
        [TestCase(0, 0)]
        [TestCase(-12, 12)]
        [TestCase("-1286787868", 1286787868)]
        [TestCase(true, 1)]
        [TestCase(null, 0)]
        public void CheckAbsoluteValueIsCorrect(object input, object expectedOutput)
        {
            Thread.Sleep(2000);
            Assert.That(_calculator.Abs(input), Is.EqualTo(expectedOutput));
        }

        [TestCase("string")]
        [TestCase("")]
        public void IsErrorReturnedWhenEnteringString(object firstInput)
        {
            TestDelegate testDelegate = () => _calculator.Abs(firstInput);
            Assert.Throws<NotFiniteNumberException>(testDelegate);
        }

        [Test]
        public void IsNan()
        {
            Assert.IsNaN(_calculator.Abs(Double.NaN));
        }

        [Test]
        public void IsNegativeInfinity()
        {
            Assert.That(_calculator.Abs(double.NegativeInfinity), Is.EqualTo(double.NegativeInfinity));
        }

        [Test]
        public void IsPositiveInfinity()
        {
            Assert.That(_calculator.Abs(double.PositiveInfinity), Is.EqualTo(double.PositiveInfinity));
        }
    }
}