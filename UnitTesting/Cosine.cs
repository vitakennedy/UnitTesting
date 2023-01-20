using CSharpCalculator;

namespace UnitTesting
{
    [TestFixture]
    public class Cosine
    {
        private Calculator _calculator;

        [OneTimeSetUp]
        public void Setup()
        {
            _calculator = new();
        }

        [TestCase(70, 0.342020143325669)]
        [TestCase(0, 1)]
        [TestCase(90.0, 6.12303176911189E-17)]
        [TestCase(1, 0.9998477)]
        public void CheckCosineIsCorrect(double firstInput, double expectedOutput)
        {
            Assert.That(_calculator.Cos((firstInput * (Math.PI)) / 180), Is.EqualTo(expectedOutput).Within(0.1));
        }

        [TestCase("string")]
        public void IsErrorReturned(object firstInput)
        {
            TestDelegate testDelegate = () => _calculator.Cos(firstInput);
            Assert.Throws<NotFiniteNumberException>(testDelegate);
        }

        [TestCase(Double.NaN)]
        [TestCase(Double.PositiveInfinity)]
        [TestCase(Double.NegativeInfinity)]
        public void IsNuN(object firstInput)
        {
            Assert.IsNaN(_calculator.Cos(firstInput)); 
        }
    }
}