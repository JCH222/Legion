namespace Legion.Test
{
	using Legion.Mathematics.LinearSystem;
	using NUnit.Framework;

    public class GlobalSolver
    {
        [Test]
        public void TestSolve1()
        {
            // Example : speed reduction impulse

            float fMass = 2.0f;
            float fDeltaSpeed = -10.0f;
            SolvingStatus status = Mathematics.LinearSystem.GlobalSolver.Solve(
                1.0f / fMass, fDeltaSpeed, out float fImpulse, out float fError);
            Assert.AreEqual(SolvingStatus.VALID, status);
            Assert.AreEqual(0.0f, fError);
            Assert.AreEqual(-20.0f, fImpulse);

            double dMass = 2.0d;
            double dDeltaSpeed = -10.0d;
            status = Mathematics.LinearSystem.GlobalSolver.Solve(
                1.0d / dMass, dDeltaSpeed, out double dImpulse, out double dError);
            Assert.AreEqual(SolvingStatus.VALID, status);
            Assert.AreEqual(0.0f, dError);
            Assert.AreEqual(-20.0f, dImpulse);
        }

        [Test]
        public void TestSolve2()
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
            SolvingStatus status = Mathematics.LinearSystem.GlobalSolver.Solve(
                (1.0f / fMass) + fLength1 * fUnitImpulseAngularSpeed1, (1.0f / fMass) + fLength1 * fUnitImpulseAngularSpeed2, fDeltaSpeed1,
                (1.0f / fMass) + fLength2 * fUnitImpulseAngularSpeed1, (1.0f / fMass) + fLength2 * fUnitImpulseAngularSpeed2, fDeltaSpeed2,
                out float fImpulseA, out float fErrorA, out float fImpulseB, out float fErrorB);
            Assert.AreEqual(SolvingStatus.VALID, status);
            Assert.AreEqual(0.0f, fErrorA);
            Assert.AreEqual(10.0f, fImpulseA);
            Assert.AreEqual(0.0f, fErrorB);
            Assert.AreEqual(10.0f, fImpulseB);

            // Valid solving 2
            fDeltaSpeed1 = 10.0f;
            fDeltaSpeed2 = 20.0f;
            fLength1 = 7.0f;
            fLength2 = -14.0f;
            fUnitImpulseAngularSpeed1 = 1.0f * fLength1 / fInertiaMoment;
            fUnitImpulseAngularSpeed2 = 1.0f * fLength2 / fInertiaMoment;
            status = Mathematics.LinearSystem.GlobalSolver.Solve(
                (1.0f / fMass) + fLength1 * fUnitImpulseAngularSpeed1, (1.0f / fMass) + fLength1 * fUnitImpulseAngularSpeed2, fDeltaSpeed1,
                (1.0f / fMass) + fLength2 * fUnitImpulseAngularSpeed1, (1.0f / fMass) + fLength2 * fUnitImpulseAngularSpeed2, fDeltaSpeed2,
                out fImpulseA, out fErrorA, out fImpulseB, out fErrorB);
            Assert.AreEqual(SolvingStatus.VALID, status);
            Assert.AreEqual(0.0f, fErrorA);
            Assert.AreEqual(17.76644f, fImpulseA);
            Assert.AreEqual(0.0f, fErrorB);
            Assert.AreEqual(8.900227f, fImpulseB);

            double dMass = 2.0f;
            double dInertiaMoment = 0.5f;

            // Valid solving 1
            double dDeltaSpeed1 = 10.0d;
            double dDeltaSpeed2 = 10.0d;
            double dLength1 = 5.0d;
            double dLength2 = -5.0d;
            double dUnitImpulseAngularSpeed1 = 1.0d * dLength1 / dInertiaMoment;
            double dUnitImpulseAngularSpeed2 = 1.0d * dLength2 / dInertiaMoment;
            status = Mathematics.LinearSystem.GlobalSolver.Solve(
                (1.0d / dMass) + dLength1 * dUnitImpulseAngularSpeed1, (1.0d / dMass) + dLength1 * dUnitImpulseAngularSpeed2, dDeltaSpeed1,
                (1.0d / dMass) + dLength2 * dUnitImpulseAngularSpeed1, (1.0d / dMass) + dLength2 * dUnitImpulseAngularSpeed2, dDeltaSpeed2,
                out double dImpulseA, out double dErrorA, out double dImpulseB, out double dErrorB);
            Assert.AreEqual(SolvingStatus.VALID, status);
            Assert.AreEqual(0.0d, dErrorA);
            Assert.AreEqual(10.0d, dImpulseA);
            Assert.AreEqual(0.0d, dErrorB);
            Assert.AreEqual(10.0d, dImpulseB);

            // Valid solving 2
            dDeltaSpeed1 = 10.0d;
            dDeltaSpeed2 = 20.0d;
            dLength1 = 7.0d;
            dLength2 = -14.0d;
            dUnitImpulseAngularSpeed1 = 1.0d * dLength1 / dInertiaMoment;
            dUnitImpulseAngularSpeed2 = 1.0d * dLength2 / dInertiaMoment;
            status = Mathematics.LinearSystem.GlobalSolver.Solve(
                (1.0d / dMass) + dLength1 * dUnitImpulseAngularSpeed1, (1.0d / dMass) + dLength1 * dUnitImpulseAngularSpeed2, dDeltaSpeed1,
                (1.0d / dMass) + dLength2 * dUnitImpulseAngularSpeed1, (1.0d / dMass) + dLength2 * dUnitImpulseAngularSpeed2, dDeltaSpeed2,
                out dImpulseA, out dErrorA, out dImpulseB, out dErrorB);
            Assert.AreEqual(SolvingStatus.VALID, status);
            Assert.AreEqual(0.0f, dErrorA);
            Assert.AreEqual(17.766439909297052d, dImpulseA);
            Assert.AreEqual(0.0f, dErrorB);
            Assert.AreEqual(8.9002267573696141d, dImpulseB);
        }
    }
}
