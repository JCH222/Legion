namespace Legion.Test
{
    using Legion.Mathematics.LinearSystem;
    using NUnit.Framework;
    using Unity.Collections;

    public class IterativeSolver
    {
        [Test]
        public void TestSolveJacobi1()
        {
            // Example : speed reduction impulse

            float fMass = 2.0f;
            float fDeltaSpeed = -10.0f;

            NativeArray<float> fCoefficients = new NativeArray<float>(1, Allocator.Persistent);
            fCoefficients[0] = 1.0f / fMass;

            NativeArray<float> fResults = new NativeArray<float>(1, Allocator.Persistent);
            fResults[0] = fDeltaSpeed;

            NativeArray<float> fVariables = new NativeArray<float>(1, Allocator.Persistent);
            fVariables[0] = 0.0f;

            NativeArray<float> fErrors = new NativeArray<float>(1, Allocator.Persistent);
            fErrors[0] = float.NaN;

            NativeArray<float> fBuffer = new NativeArray<float>(1, Allocator.Persistent);
            fBuffer[0] = float.NaN;

            NativeArray<float> fInverseDiagonalCoefficients = new NativeArray<float>(1, Allocator.Persistent);
            fInverseDiagonalCoefficients[0] = float.NaN;

            ConvergenceCondition convergenceCondition = new ConvergenceCondition()
            {
                MaxIterationNb = 1,
                MaxResidual = 0.0f
            };
            SolvingStatus status = Mathematics.LinearSystem.IterativeSolver.SolveWithJacobi(1, in fCoefficients, in fResults,
                ref fVariables, ref fErrors, ref fBuffer, ref fInverseDiagonalCoefficients, convergenceCondition);
            Assert.AreEqual(SolvingStatus.VALID, status);
            Assert.AreEqual(0.0f, fErrors[0]);
            Assert.AreEqual(-20.0f, fVariables[0]);

            convergenceCondition = new ConvergenceCondition()
            {
                MaxIterationNb = 2,
                MaxResidual = 0.0f
            };
            status = Mathematics.LinearSystem.IterativeSolver.SolveWithJacobi(1, in fCoefficients, in fResults, 
                ref fVariables, ref fErrors, ref fBuffer, ref fInverseDiagonalCoefficients, convergenceCondition);
            Assert.AreEqual(SolvingStatus.VALID, status);
            Assert.AreEqual(0.0f, fErrors[0]);
            Assert.AreEqual(-20.0f, fVariables[0]);

            fCoefficients.Dispose();
            fResults.Dispose();
            fVariables.Dispose();
            fErrors.Dispose();
            fBuffer.Dispose();
            fInverseDiagonalCoefficients.Dispose();
        }

        [Test]
        public void TestSolveJacobi2()
		{
            // Example : speed reduction impulses
            //                          G
            // Impulse1 -> |____________x_______| <- Impulse2
            //                  l1          l2

            float fMass = 2.0f;
            float fInertiaMoment = 0.5f;

            // Valid solving 1
            float fDeltaSpeed1 = 10.0f;
            float fDeltaSpeed2 = 10.0f;
            float fLength1 = 5.0f;
            float fLength2 = -5.0f;
            float fUnitImpulseAngularSpeed1 = 1.0f * fLength1 / fInertiaMoment;
            float fUnitImpulseAngularSpeed2 = 1.0f * fLength2 / fInertiaMoment;

            NativeArray<float> fCoefficients = new NativeArray<float>(4, Allocator.Persistent);
            fCoefficients[0] = (1.0f / fMass) + fLength1 * fUnitImpulseAngularSpeed1;
            fCoefficients[1] = (1.0f / fMass) + fLength1 * fUnitImpulseAngularSpeed2;
            fCoefficients[2] = (1.0f / fMass) + fLength2 * fUnitImpulseAngularSpeed1;
            fCoefficients[3] = (1.0f / fMass) + fLength2 * fUnitImpulseAngularSpeed2;

            NativeArray<float> fResults = new NativeArray<float>(2, Allocator.Persistent);
            fResults[0] = fDeltaSpeed1;
            fResults[1] = fDeltaSpeed2;

            NativeArray<float> fVariables = new NativeArray<float>(2, Allocator.Persistent);
            fVariables[0] = 0.0f;
            fVariables[1] = 0.0f;

            NativeArray<float> fResiduals = new NativeArray<float>(2, Allocator.Persistent);
            fResiduals[0] = float.NaN;
            fResiduals[1] = float.NaN;

            NativeArray<float> fBuffer = new NativeArray<float>(2, Allocator.Persistent);
            fBuffer[0] = float.NaN;
            fBuffer[1] = float.NaN;

            NativeArray<float> fInverseDiagonalCoefficients = new NativeArray<float>(2, Allocator.Persistent);
            fBuffer[0] = float.NaN;
            fBuffer[1] = float.NaN;

            ConvergenceCondition convergenceCondition = new ConvergenceCondition()
            {
                MaxIterationNb = 1000,
                MaxResidual = 0.0f
            };

            SolvingStatus status = Mathematics.LinearSystem.IterativeSolver.SolveWithJacobi(2, in fCoefficients, in fResults,
               ref fVariables, ref fResiduals, ref fBuffer, ref fInverseDiagonalCoefficients, convergenceCondition);
            Assert.AreEqual(SolvingStatus.VALID, status);
            Assert.AreEqual(-4.19616699E-05f, fResiduals[0]);
            Assert.AreEqual(9.99995708f, fVariables[0]);
            Assert.AreEqual(-3.05175781E-05f, fResiduals[1]);
            Assert.AreEqual(9.99995708f, fVariables[1]);

            // Valid solving 2
            fCoefficients[0] = 2.0f;
			fCoefficients[1] = 1.0f;
			fCoefficients[2] = 5.0f;
			fCoefficients[3] = 7.0f;

			fResults[0] = 11.0f;
			fResults[1] = 13.0f;

			fVariables[0] = 1.0f;
			fVariables[1] = 1.0f;

            fResiduals[0] = float.NaN;
            fResiduals[1] = float.NaN;

			fBuffer[0] = float.NaN;
			fBuffer[1] = float.NaN;

			fInverseDiagonalCoefficients[0] = float.NaN;
			fInverseDiagonalCoefficients[1] = float.NaN;

			convergenceCondition = new ConvergenceCondition()
			{
				MaxIterationNb = 25,
                MaxResidual = 0.0f
            };

			status = Mathematics.LinearSystem.IterativeSolver.SolveWithJacobi(2, in fCoefficients, in fResults,
				ref fVariables, ref fResiduals, ref fBuffer, ref fInverseDiagonalCoefficients, convergenceCondition);
            Assert.AreEqual(SolvingStatus.VALID, status);
            Assert.AreEqual(9.53674316E-07f, fResiduals[0]);
            Assert.AreEqual(7.1111021f, fVariables[0]);
            Assert.AreEqual(8.67843628E-05f, fResiduals[1]);
            Assert.AreEqual(-3.22220349f, fVariables[1]);

            // Invalid solving
            fDeltaSpeed1 = 10.0f;
            fDeltaSpeed2 = 20.0f;
            fLength1 = 7.0f;
            fLength2 = -14.0f;
            fUnitImpulseAngularSpeed1 = 1.0f * fLength1 / fInertiaMoment;
            fUnitImpulseAngularSpeed2 = 1.0f * fLength2 / fInertiaMoment;

            fCoefficients[0] = (1.0f / fMass) + fLength1 * fUnitImpulseAngularSpeed1;
            fCoefficients[1] = (1.0f / fMass) + fLength1 * fUnitImpulseAngularSpeed2;
            fCoefficients[2] = (1.0f / fMass) + fLength2 * fUnitImpulseAngularSpeed1;
            fCoefficients[3] = (1.0f / fMass) + fLength2 * fUnitImpulseAngularSpeed2;

            fResults[0] = fDeltaSpeed1;
            fResults[1] = fDeltaSpeed2;

            fVariables[0] = 0.0f;
            fVariables[1] = 0.0f;

            fResiduals[0] = float.NaN;
            fResiduals[1] = float.NaN;

            fBuffer[0] = float.NaN;
            fBuffer[1] = float.NaN;

            fInverseDiagonalCoefficients[0] = float.NaN;
            fInverseDiagonalCoefficients[1] = float.NaN;

            convergenceCondition = new ConvergenceCondition()
            {
                MaxIterationNb = 25,
                MaxResidual = 0.0f
            };

            status = Mathematics.LinearSystem.IterativeSolver.SolveWithJacobi(2, in fCoefficients, in fResults,
              ref fVariables, ref fResiduals, ref fBuffer, ref fInverseDiagonalCoefficients, convergenceCondition);
            Assert.AreEqual(SolvingStatus.INCOMPATIBLE, status);

            fCoefficients.Dispose();
            fResults.Dispose();
            fVariables.Dispose();
            fResiduals.Dispose();
            fBuffer.Dispose();
            fInverseDiagonalCoefficients.Dispose();
        }
    }
}
