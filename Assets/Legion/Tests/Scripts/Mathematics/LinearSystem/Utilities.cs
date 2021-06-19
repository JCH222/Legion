namespace Legion.Test
{
    using NUnit.Framework;
	using Unity.Collections;

	public partial class Utilities
    {
        [Test]
        public void TestCheckIsSolvable()
        {
			#region Float Dimension 1
			Mathematics.LinearSystem.SolvingStatus status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(
                0.5f, -10.0f, out float fDenominator, out float fNumeratorA, 0.0f);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.VALID, status);
            Assert.AreEqual(0.5f, fDenominator);
            Assert.AreEqual(-10.0f, fNumeratorA);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(0.5f, -10.0f, out fDenominator, out fNumeratorA, 1.0f);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.INCOMPATIBLE, status);
            Assert.AreEqual(0.5f, fDenominator);
            Assert.AreEqual(-10.0f, fNumeratorA);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(0.5f, -10.0f, out fDenominator, out fNumeratorA, 30.0f);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.INDETERMINATE, status);
            Assert.AreEqual(0.5f, fDenominator);
            Assert.AreEqual(-10.0f, fNumeratorA);
            #endregion Float Dimension 1

            #region Double Dimension 1
            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(
                0.5d, -10.0d, out double dDenominator, out double dNumeratorA, 0.0d);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.VALID, status);
            Assert.AreEqual(0.5d, dDenominator);
            Assert.AreEqual(-10.0d, dNumeratorA);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(0.5d, -10.0d, out dDenominator, out dNumeratorA, 1.0d);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.INCOMPATIBLE, status);
            Assert.AreEqual(0.5d, dDenominator);
            Assert.AreEqual(-10.0d, dNumeratorA);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(0.5d, -10.0d, out dDenominator, out dNumeratorA, 30.0d);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.INDETERMINATE, status);
            Assert.AreEqual(0.5d, dDenominator);
            Assert.AreEqual(-10.0d, dNumeratorA);
            #endregion Double Dimension 1

            #region Float Dimension 2
            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(50.5f, -45.0f, 10.0f, -45.0f, 50.5f, 10.0f, 
                out fDenominator, out fNumeratorA, out float fNumeratorB, 0.0f);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.VALID, status);
            Assert.AreEqual(525.25f, fDenominator);
            Assert.AreEqual(955.0f, fNumeratorA);
            Assert.AreEqual(955.0f, fNumeratorB);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(2.5f, 2.5f, 10.0f, 2.5f, 2.5f, -10.0f,
                out fDenominator, out fNumeratorA, out fNumeratorB, 0.0f);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.INCOMPATIBLE, status);
            Assert.AreEqual(0.0f, fDenominator);
            Assert.AreEqual(50.0f, fNumeratorA);
            Assert.AreEqual(-50.0f, fNumeratorB);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(50.5f, 50.5f, 10.0f, 50.5f, 50.5f, 10.0f,
                out fDenominator, out fNumeratorA, out fNumeratorB, 0.0f);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.INDETERMINATE, status);
            Assert.AreEqual(0.0f, fDenominator);
            Assert.AreEqual(0.0f, fNumeratorA);
            Assert.AreEqual(0.0f, fNumeratorB);
            #endregion Float Dimension 2

            #region Double Dimension 2
            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(50.5d, -45.0d, 10.0d, -45.0d, 50.5d, 10.0d,
                out dDenominator, out dNumeratorA, out double dNumeratorB, 0.0d);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.VALID, status);
            Assert.AreEqual(525.25d, dDenominator);
            Assert.AreEqual(955.0d, dNumeratorA);
            Assert.AreEqual(955.0d, dNumeratorB);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(2.5d, 2.5d, 10.0d, 2.5d, 2.5d, -10.0d,
                out dDenominator, out dNumeratorA, out dNumeratorB, 0.0d);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.INCOMPATIBLE, status);
            Assert.AreEqual(0.0d, dDenominator);
            Assert.AreEqual(50.0d, dNumeratorA);
            Assert.AreEqual(-50.0d, dNumeratorB);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(50.5d, 50.5d, 10.0d, 50.5d, 50.5d, 10.0d,
                out dDenominator, out dNumeratorA, out dNumeratorB, 0.0d);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.INDETERMINATE, status);
            Assert.AreEqual(0.0d, dDenominator);
            Assert.AreEqual(0.0d, dNumeratorA);
            Assert.AreEqual(0.0d, dNumeratorB);
            #endregion Double Dimension 2

            #region Float Dimension 3
            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(50.5f, -45.5f, 0.5f, 10.0f, -45.5f, 50.5f, 0.5f, 
                10.0f, 0.5f, 0.5f, 50.5f, 100.0f, out fDenominator, out fNumeratorA, out fNumeratorB, out float fNumeratorC);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.VALID, status);
            Assert.AreEqual(24192.0f, fDenominator);
            Assert.AreEqual(43680.0f, fNumeratorA);
            Assert.AreEqual(43680.0f, fNumeratorB);
            Assert.AreEqual(47040.0f, fNumeratorC);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(50.5f, 50.5f, 0.5f, 10.0f, 50.5f, 50.5f, 0.5f,
                -10.0f, 0.5f, 0.5f, 50.5f, 0.0f, out fDenominator, out fNumeratorA, out fNumeratorB, out fNumeratorC);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.INCOMPATIBLE, status);
            Assert.AreEqual(0.0f, fDenominator);
            Assert.AreEqual(51000.0f, fNumeratorA);
            Assert.AreEqual(-51000.0f, fNumeratorB);
            Assert.AreEqual(0.0f, fNumeratorC);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(50.5f, 50.5f, 0.5f, 10.0f, 50.5f, 50.5f, 0.5f,
                10.0f, 0.5f, 0.5f, 50.5f, 10.0f, out fDenominator, out fNumeratorA, out fNumeratorB, out fNumeratorC);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.UNKNOWN, status);
            Assert.AreEqual(0.0f, fDenominator);
            Assert.AreEqual(0.0f, fNumeratorA);
            Assert.AreEqual(0.0f, fNumeratorB);
            Assert.AreEqual(0.0f, fNumeratorC);
            #endregion Float Dimension 3

            #region Double Dimension 3
            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(50.5d, -45.5d, 0.5d, 10.0d, -45.5d, 50.5d, 0.5d,
                10.0d, 0.5d, 0.5d, 50.5d, 100.0d, out dDenominator, out dNumeratorA, out dNumeratorB, out double dNumeratorC);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.VALID, status);
            Assert.AreEqual(24192.0d, dDenominator);
            Assert.AreEqual(43680.0d, dNumeratorA);
            Assert.AreEqual(43680.0d, dNumeratorB);
            Assert.AreEqual(47040.0d, dNumeratorC);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(50.5d, 50.5d, 0.5d, 10.0d, 50.5d, 50.5d, 0.5d,
                -10.0d, 0.5d, 0.5d, 50.5d, 0.0d, out dDenominator, out dNumeratorA, out dNumeratorB, out dNumeratorC);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.INCOMPATIBLE, status);
            Assert.AreEqual(0.0d, dDenominator);
            Assert.AreEqual(51000.0d, dNumeratorA);
            Assert.AreEqual(-51000.0d, dNumeratorB);
            Assert.AreEqual(0.0d, dNumeratorC);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(50.5d, 50.5d, 0.5d, 10.0d, 50.5d, 50.5d, 0.5d,
                10.0d, 0.5d, 0.5d, 50.5d, 10.0d, out dDenominator, out dNumeratorA, out dNumeratorB, out dNumeratorC);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.UNKNOWN, status);
            Assert.AreEqual(0.0d, dDenominator);
            Assert.AreEqual(0.0d, dNumeratorA);
            Assert.AreEqual(0.0d, dNumeratorB);
            Assert.AreEqual(0.0d, dNumeratorC);
            #endregion Double Dimension 3

            #region Float Dimension 4
            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(
                0.001272236f, 0.0004598264f, 0.0007484255f, -0.00006374379f, 25.0f,
                0.0004598264f, 0.001272236f, -0.00006374379f, 0.0007484255f, 25.0f,
                0.0007483774f, -0.00006352074f, 0.001271948f, 0.0004602892f, 25.0f,
                -0.00006352074f, 0.0007483774f, 0.0004602892f, 0.001271948f, 25.0f,
                out fDenominator, out fNumeratorA, out fNumeratorB, out fNumeratorC, 
                out float fNumeratorD);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.VALID, status);
            Assert.AreEqual(1.75785579E-18f, fDenominator);
            Assert.AreEqual(1.80505787E-14f, fNumeratorA);
            Assert.AreEqual(1.79730481E-14f, fNumeratorB);
            Assert.AreEqual(1.86151211E-14f, fNumeratorC);
            Assert.AreEqual(1.90561847E-14f, fNumeratorD);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(
                50.5f, -49.5f, 0.5f, 0.5f, 10.0f,
                -49.5f, 50.5f, 0.5f, 0.5f, 10.0f,
                0.5f, 0.5f, 50.5f, -49.5f, -10.0f,
                0.5f, 0.5f, -49.5f, 50.5f, 10.0f,
                out fDenominator, out fNumeratorA,
                out fNumeratorB, out fNumeratorC,
                out fNumeratorD);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.INCOMPATIBLE, status);
            Assert.AreEqual(0.0f, fDenominator);
            Assert.AreEqual(100000.0f, fNumeratorA);
            Assert.AreEqual(100000.0f, fNumeratorB);
            Assert.AreEqual(-100000.0f, fNumeratorC);
            Assert.AreEqual(-100000.0f, fNumeratorD);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(
                50.5f, -49.5f, 0.5f, 0.5f, 10.0f,
                -49.5f, 50.5f, 0.5f, 0.5f, 10.0f,
                0.5f, 0.5f, 50.5f, -49.5f, 10.0f,
                0.5f, 0.5f, -49.5f, 50.5f, 10.0f,
                out fDenominator, out fNumeratorA, 
                out fNumeratorB, out fNumeratorC,
                out fNumeratorD);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.UNKNOWN, status);
            Assert.AreEqual(0.0f, fDenominator);
            Assert.AreEqual(0.0f, fNumeratorA);
            Assert.AreEqual(0.0f, fNumeratorB);
            Assert.AreEqual(0.0f, fNumeratorC);
            Assert.AreEqual(0.0f, fNumeratorD);
            #endregion Float Dimension 4

            #region Double Dimension 4
            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(
                0.001272236d, 0.0004598264d, 0.0007484255d, -0.00006374379d, 25.0d,
                0.0004598264d, 0.001272236d, -0.00006374379d, 0.0007484255d, 25.0d,
                0.0007483774d, -0.00006352074d, 0.001271948d, 0.0004602892d, 25.0d,
                -0.00006352074d, 0.0007483774d, 0.0004602892d, 0.001271948d, 25.0d,
                out dDenominator, out dNumeratorA, out dNumeratorB, out dNumeratorC,
                out double dNumeratorD);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.VALID, status);
            Assert.AreEqual(1.6837286049765792E-18d, dDenominator);
            Assert.AreEqual(1.7418971607713834E-14d, dNumeratorA);
            Assert.AreEqual(1.7418971610857615E-14d, dNumeratorB);
            Assert.AreEqual(1.7413155895049476E-14d, dNumeratorC);
            Assert.AreEqual(1.7413155896290247E-14d, dNumeratorD);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(
                50.5d, -49.5d, 0.5d, 0.5d, 10.0d,
                -49.5d, 50.5d, 0.5d, 0.5d, 10.0d,
                0.5d, 0.5d, 50.5d, -49.5d, -10.0d,
                0.5d, 0.5d, -49.5d, 50.5d, 10.0d,
                out dDenominator, out dNumeratorA,
                out dNumeratorB, out dNumeratorC,
                out dNumeratorD);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.INCOMPATIBLE, status);
            Assert.AreEqual(0.0f, dDenominator);
            Assert.AreEqual(100000.0d, dNumeratorA);
            Assert.AreEqual(100000.0d, dNumeratorB);
            Assert.AreEqual(-100000.0d, dNumeratorC);
            Assert.AreEqual(-100000.0d, dNumeratorD);

            status = Mathematics.LinearSystem.Utilities.CheckIsSolvable(
                50.5d, -49.5d, 0.5d, 0.5d, 10.0d,
                -49.5d, 50.5d, 0.5d, 0.5d, 10.0d,
                0.5d, 0.5d, 50.5d, -49.5d, 10.0d,
                0.5d, 0.5d, -49.5d, 50.5d, 10.0d,
                out dDenominator, out dNumeratorA,
                out dNumeratorB, out dNumeratorC,
                out dNumeratorD);
            Assert.AreEqual(Mathematics.LinearSystem.SolvingStatus.UNKNOWN, status);
            Assert.AreEqual(0.0d, dDenominator);
            Assert.AreEqual(0.0d, dNumeratorA);
            Assert.AreEqual(0.0d, dNumeratorB);
            Assert.AreEqual(0.0d, dNumeratorC);
            Assert.AreEqual(0.0d, dNumeratorD);
            #endregion Double Dimension 4
        }

        [Test]
        public void TestIsDiagonallyDominant()
		{
            NativeArray<float> fCoefficients = new NativeArray<float>(9, Allocator.Persistent);
            fCoefficients[0] = 3.0f;
            fCoefficients[1] = -2.0f;
            fCoefficients[2] = 1.0f;
            fCoefficients[3] = 1.0f;
            fCoefficients[4] = -3.0f;
            fCoefficients[5] = 2.0f;
            fCoefficients[6] = -1.0f;
            fCoefficients[7] = 2.0f;
            fCoefficients[8] = 4.0f;
            bool isDiagonallyDominant = Mathematics.LinearSystem.Utilities.CheckIsDiagonallyDominant(3, in fCoefficients);
            Assert.AreEqual(true, isDiagonallyDominant);

            fCoefficients[0] = -2.0f;
            fCoefficients[1] = 2.0f;
            fCoefficients[2] = 1.0f;
            fCoefficients[3] = 1.0f;
            fCoefficients[4] = 3.0f;
            fCoefficients[5] = 2.0f;
            fCoefficients[6] = 1.0f;
            fCoefficients[7] = -2.0f;
            fCoefficients[8] = 0.0f;
            isDiagonallyDominant = Mathematics.LinearSystem.Utilities.CheckIsDiagonallyDominant(3, in fCoefficients);
            Assert.AreEqual(false, isDiagonallyDominant);

            fCoefficients[0] = -4.0f;
            fCoefficients[1] = 2.0f;
            fCoefficients[2] = 1.0f;
            fCoefficients[3] = 1.0f;
            fCoefficients[4] = 6.0f;
            fCoefficients[5] = 2.0f;
            fCoefficients[6] = 1.0f;
            fCoefficients[7] = -2.0f;
            fCoefficients[8] = 5.0f;
            isDiagonallyDominant = Mathematics.LinearSystem.Utilities.CheckIsDiagonallyDominant(3, in fCoefficients);
            Assert.AreEqual(true, isDiagonallyDominant);

            fCoefficients.Dispose();

            NativeArray<double> dCoefficients = new NativeArray<double>(9, Allocator.Persistent);
            dCoefficients[0] = 3.0d;
            dCoefficients[1] = -2.0d;
            dCoefficients[2] = 1.0d;
            dCoefficients[3] = 1.0d;
            dCoefficients[4] = -3.0d;
            dCoefficients[5] = 2.0d;
            dCoefficients[6] = -1.0d;
            dCoefficients[7] = 2.0d;
            dCoefficients[8] = 4.0d;
            isDiagonallyDominant = Mathematics.LinearSystem.Utilities.CheckIsDiagonallyDominant(3, in dCoefficients);
            Assert.AreEqual(true, isDiagonallyDominant);

            dCoefficients[0] = -2.0d;
            dCoefficients[1] = 2.0d;
            dCoefficients[2] = 1.0d;
            dCoefficients[3] = 1.0d;
            dCoefficients[4] = 3.0d;
            dCoefficients[5] = 2.0d;
            dCoefficients[6] = 1.0d;
            dCoefficients[7] = -2.0d;
            dCoefficients[8] = 0.0d;
            isDiagonallyDominant = Mathematics.LinearSystem.Utilities.CheckIsDiagonallyDominant(3, in dCoefficients);
            Assert.AreEqual(false, isDiagonallyDominant);

            dCoefficients[0] = -4.0d;
            dCoefficients[1] = 2.0d;
            dCoefficients[2] = 1.0d;
            dCoefficients[3] = 1.0d;
            dCoefficients[4] = 6.0d;
            dCoefficients[5] = 2.0d;
            dCoefficients[6] = 1.0d;
            dCoefficients[7] = -2.0d;
            dCoefficients[8] = 5.0d;
            isDiagonallyDominant = Mathematics.LinearSystem.Utilities.CheckIsDiagonallyDominant(3, in dCoefficients);
            Assert.AreEqual(true, isDiagonallyDominant);

            dCoefficients.Dispose();
        }
    }
}
