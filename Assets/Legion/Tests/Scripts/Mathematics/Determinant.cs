namespace Legion.Test
{
    using NUnit.Framework;

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
            float lowValue1 = 1.0E-15f;
            float lowValue2 = 1.0E-10f;
            Assert.AreEqual(Mathematics.Determinant.Compute(
                lowValue1, lowValue2, lowValue1, lowValue2), 0.0f);

            // Null result with medium values
            float mediumValue1 = 1.0f;
            float mediumValue2 = 100.0f;
            Assert.AreEqual(Mathematics.Determinant.Compute(
                mediumValue1, mediumValue2, mediumValue1, mediumValue2), 0.0f);

            // Null result with high values
            float highValue1 = 1.0E15f;
            float highValue2 = 1.0E10f;
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
            double lowValue1 = 1.0E-25d;
            double lowValue2 = 1.0E-15d;
            Assert.AreEqual(Mathematics.Determinant.Compute(
                lowValue1, lowValue2, lowValue1, lowValue2), 0.0d);

            // Null result with medium values
            double mediumValue1 = 1.0d;
            double mediumValue2 = 100.0d;
            Assert.AreEqual(Mathematics.Determinant.Compute(
                mediumValue1, mediumValue2, mediumValue1, mediumValue2), 0.0d);

            // Null result with high values
            double highValue1 = 1.0E25d;
            double highValue2 = 1.0E20d;
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
            float lowValue1 = 1.0E-15f;
            float lowValue2 = 1.0E-12f;
            float lowValue3 = 1.0E-10f;
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
            float highValue1 = 1.0E15f;
            float highValue2 = 1.0E12f;
            float highValue3 = 1.0E10f;
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
            double lowValue1 = 1.0E-25d;
            double lowValue2 = 1.0E-20d;
            double lowValue3 = 1.0E-15d;
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
            double highValue1 = 1.0E25d;
            double highValue2 = 1.0E20d;
            double highValue3 = 1.0E15d;
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
            float lowValue1 = 1.0E-20f;
            float lowValue2 = 1.0E-15f;
            float lowValue3 = 1.0E-10f;
            float lowValue4 = 1.0E-5f;
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
            float highValue1 = 1.0E20f;
            float highValue2 = 1.0E15f;
            float highValue3 = 1.0E10f;
            float highValue4 = 1.0E5f;
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
                1.75785579E-18f);
        }

        [Test]
        public void TestDoubleDeterminant4X4()
        {
            // Null result with low values
            double lowValue1 = 1.0E-25d;
            double lowValue2 = 1.0E-20d;
            double lowValue3 = 1.0E-15d;
            double lowValue4 = 1.0E-10d;
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
            double highValue1 = 1.0E-25d;
            double highValue2 = 1.0E20d;
            double highValue3 = 1.0E15d;
            double highValue4 = 1.0E10d;
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
                1.6837286049765792E-18d);
        }
    }
}
