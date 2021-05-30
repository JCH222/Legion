namespace Legion.Test
{
    using NUnit.Framework;
	using Unity.Mathematics;

	public class Determinant
    {
        private static readonly float[] FloatDeterminant1x1Coefficients =
            new float[] { float.MinValue, -100.0f, 0.0f, 100.0f, float.MaxValue };
        private static readonly double[] DoubleDeterminant1x1Coefficients =
            new double[] { double.MinValue, -100.0d, 0.0d, 100.0d, double.MaxValue };

        [Test]
        public void TestFloatDeterminant1X1([ValueSource("FloatDeterminant1x1Coefficients")] float value)
        {
            Assert.AreEqual(Mathematics.Determinant.Compute(value), value);
        }

        [Test]
        public void TestDoubleDeterminant1X1([ValueSource("DoubleDeterminant1x1Coefficients")] double value)
        {
            Assert.AreEqual(Mathematics.Determinant.Compute(value), value);
        }

        [Test]
        public void TestFloatDeterminant2X2()
        {
            // Null result with low values
            float lowValue1 = math.pow(10.0f, -15.0f);
            float lowValue2 = math.pow(10.0f, -10.0f);
            Assert.AreEqual(Mathematics.Determinant.Compute(
                lowValue1, lowValue2, lowValue1, lowValue2), 0.0f);

            // Null result with medium values
            float mediumValue1 = 1.0f;
            float mediumValue2 = 100.0f;
            Assert.AreEqual(Mathematics.Determinant.Compute(
                mediumValue1, mediumValue2, mediumValue1, mediumValue2), 0.0f);

            // Null result with high values
            float highValue1 = math.pow(10.0f, 15.0f);
            float highValue2 = math.pow(10.0f, 10.0f);
            Assert.AreEqual(Mathematics.Determinant.Compute(
                highValue1, highValue2, highValue1, highValue2), 0.0f);

            // Random values
            Assert.AreEqual(Legion.Mathematics.Determinant.Compute(
                0.0004598264f, -0.00006374379f, 0.0004602892f, 0.001271948f),
                0.00000061421584793126799995f);
        }

        [Test]
        public void TestDoubleDeterminant2X2()
        {
            // Null result with low values
            double lowValue1 = math.pow(10.0d, -25.0d);
            double lowValue2 = math.pow(10.0d, -15.0d);
            Assert.AreEqual(Mathematics.Determinant.Compute(
                lowValue1, lowValue2, lowValue1, lowValue2), 0.0d);

            // Null result with medium values
            double mediumValue1 = 1.0d;
            double mediumValue2 = 100.0d;
            Assert.AreEqual(Mathematics.Determinant.Compute(
                mediumValue1, mediumValue2, mediumValue1, mediumValue2), 0.0d);

            // Null result with high values
            double highValue1 = math.pow(10.0d, 25.0d);
            double highValue2 = math.pow(10.0d, 20.0d);
            Assert.AreEqual(Mathematics.Determinant.Compute(
                highValue1, highValue2, highValue1, highValue2), 0.0d);

            // Random values
            Assert.AreEqual(Mathematics.Determinant.Compute(
                0.0004598264d, -0.00006374379d, 0.0004602892d, 0.001271948d),
                0.00000061421584793126791d);
        }

        [Test]
        public void TestFloatDeterminant3X3()
        {
            // Null result with low values
            float lowValue1 = math.pow(10.0f, -15.0f);
            float lowValue2 = math.pow(10.0f, -12.0f);
            float lowValue3 = math.pow(10.0f, -10.0f);
            Assert.AreEqual(Mathematics.Determinant.Compute(
                lowValue1, lowValue2, lowValue3,
                lowValue1, lowValue2, lowValue3,
                lowValue1, lowValue2, lowValue3), 0.0f);

            // Null result with medium values
            float mediumValue1 = 1.0f;
            float mediumValue2 = 10.0f;
            float mediumValue3 = 100.0f;
            Assert.AreEqual(Mathematics.Determinant.Compute(
                mediumValue1, mediumValue2, mediumValue3,
                mediumValue1, mediumValue2, mediumValue3,
                mediumValue1, mediumValue2, mediumValue3), 0.0f);

            // Null result with high values
            float highValue1 = math.pow(10.0f, 15.0f);
            float highValue2 = math.pow(10.0f, 12.0f);
            float highValue3 = math.pow(10.0f, 10.0f);
            Assert.AreEqual(Mathematics.Determinant.Compute(
                highValue1, highValue2, highValue3,
                highValue1, highValue2, highValue3,
                highValue1, highValue2, highValue3), 0.0f);

            // Random values
            Assert.AreEqual(Mathematics.Determinant.Compute(
                0.0004598264f, -0.00006374379f, 0.0004602892f,
                0.001271948f, 0.0004602892f, -0.00006352074f,
                0.0007484255f, 0.001272236f, 0.0004602892f),
                0.000000000761214092f);
        }

        [Test]
        public void TestDoubleDeterminant3X3()
        {
            // Null result with low values
            double lowValue1 = math.pow(10.0d, -25.0d);
            double lowValue2 = math.pow(10.0d, -20.0d);
            double lowValue3 = math.pow(10.0d, -15.0d);
            Assert.AreEqual(Mathematics.Determinant.Compute(
                lowValue1, lowValue2, lowValue3,
                lowValue1, lowValue2, lowValue3,
                lowValue1, lowValue2, lowValue3), 0.0d);

            // Null result with medium values
            double mediumValue1 = 1.0d;
            double mediumValue2 = 10.0d;
            double mediumValue3 = 100.0d;
            Assert.AreEqual(Mathematics.Determinant.Compute(
                mediumValue1, mediumValue2, mediumValue3,
                mediumValue1, mediumValue2, mediumValue3,
                mediumValue1, mediumValue2, mediumValue3), 0.0d); ;

            // Null result with high values
            double highValue1 = math.pow(10.0d, 25.0d);
            double highValue2 = math.pow(10.0d, 20.0d);
            double highValue3 = math.pow(10.0d, 15.0d);
            Assert.AreEqual(Mathematics.Determinant.Compute(
                highValue1, highValue2, highValue3,
                highValue1, highValue2, highValue3,
                highValue1, highValue2, highValue3), 0.0d);

            // Random values
            Assert.AreEqual(Mathematics.Determinant.Compute(
                0.0004598264d, -0.00006374379d, 0.0004602892d,
                0.001271948d, 0.0004602892d, -0.00006352074d,
                0.0007484255d, 0.001272236d, 0.0004602892d),
                0.00000000076121413149955871d);
        }

        [Test]
        public void TestFloatDeterminant4X4()
        {
            // Null result with low values
            float lowValue1 = math.pow(10.0f, -20.0f);
            float lowValue2 = math.pow(10.0f, -15.0f);
            float lowValue3 = math.pow(10.0f, -10.0f);
            float lowValue4 = math.pow(10.0f, -5.0f);
            Assert.AreEqual(Mathematics.Determinant.Compute(
                lowValue1, lowValue2, lowValue3, lowValue4,
                lowValue1, lowValue2, lowValue3, lowValue4,
                lowValue1, lowValue2, lowValue3, lowValue4,
                lowValue1, lowValue2, lowValue3, lowValue4), 0.0f);

            // Null result with medium values
            float mediumValue1 = 1.0f;
            float mediumValue2 = 10.0f;
            float mediumValue3 = 100.0f;
            float mediumValue4 = 1000.0f;
            Assert.AreEqual(Mathematics.Determinant.Compute(
                mediumValue1, mediumValue2, mediumValue3, mediumValue4,
                mediumValue1, mediumValue2, mediumValue3, mediumValue4,
                mediumValue1, mediumValue2, mediumValue3, mediumValue4,
                mediumValue1, mediumValue2, mediumValue3, mediumValue4), 0.0f);

            // Null result with high values
            float highValue1 = math.pow(10.0f, 20.0f);
            float highValue2 = math.pow(10.0f, 15.0f);
            float highValue3 = math.pow(10.0f, 10.0f);
            float highValue4 = math.pow(10.0f, 5.0f);
            Assert.AreEqual(Mathematics.Determinant.Compute(
                highValue1, highValue2, highValue3, highValue4,
                highValue1, highValue2, highValue3, highValue4,
                highValue1, highValue2, highValue3, highValue4,
                highValue1, highValue2, highValue3, highValue4), 0.0f);

            // Random values
            Assert.AreEqual(Mathematics.Determinant.Compute(
                0.001272236f, 0.0004598264f, 0.0007484255f, -0.00006374379f,
                0.0004598264f, 0.001272236f, -0.00006374379f, 0.0007484255f,
                0.0007483774f, -0.00006352074f, 0.001271948f, 0.0004602892f,
                -0.00006352074f, 0.0007483774f, 0.0004602892f, 0.001271948f),
                1.75785579f * math.pow(10.0f, -18.0f));
        }

        [Test]
        public void TestDoubleDeterminant4X4()
        {
            // Null result with low values
            double lowValue1 = math.pow(10.0d, -25.0d);
            double lowValue2 = math.pow(10.0d, -20.0d);
            double lowValue3 = math.pow(10.0d, -15.0d);
            double lowValue4 = math.pow(10.0d, -10.0d);
            Assert.AreEqual(Mathematics.Determinant.Compute(
                lowValue1, lowValue2, lowValue3, lowValue4,
                lowValue1, lowValue2, lowValue3, lowValue4,
                lowValue1, lowValue2, lowValue3, lowValue4,
                lowValue1, lowValue2, lowValue3, lowValue4), 0.0d);

            // Null result with medium values
            double mediumValue1 = 1.0d;
            double mediumValue2 = 10.0d;
            double mediumValue3 = 100.0d;
            double mediumValue4 = 1000.0d;
            Assert.AreEqual(Mathematics.Determinant.Compute(
                mediumValue1, mediumValue2, mediumValue3, mediumValue4,
                mediumValue1, mediumValue2, mediumValue3, mediumValue4,
                mediumValue1, mediumValue2, mediumValue3, mediumValue4,
                mediumValue1, mediumValue2, mediumValue3, mediumValue4), 0.0d);

            // Null result with high values
            double highValue1 = math.pow(10.0d, 25.0d);
            double highValue2 = math.pow(10.0d, 20.0d);
            double highValue3 = math.pow(10.0d, 15.0d);
            double highValue4 = math.pow(10.0d, 10.0d);
            Assert.AreEqual(Mathematics.Determinant.Compute(
                highValue1, highValue2, highValue3, highValue4,
                highValue1, highValue2, highValue3, highValue4,
                highValue1, highValue2, highValue3, highValue4,
                highValue1, highValue2, highValue3, highValue4), 0.0d);

            // Random values
            Assert.AreEqual(Mathematics.Determinant.Compute(
                0.001272236d, 0.0004598264d, 0.0007484255d, -0.00006374379d,
                0.0004598264d, 0.001272236d, -0.00006374379d, 0.0007484255d,
                0.0007483774d, -0.00006352074d, 0.001271948d, 0.0004602892d,
                -0.00006352074d, 0.0007483774d, 0.0004602892d, 0.001271948d),
                1.6837286049765792d * math.pow(10.0d, -18.0d));
        }
    }
}
