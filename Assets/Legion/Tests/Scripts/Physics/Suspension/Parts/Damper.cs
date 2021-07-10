namespace Legion.Test
{
    using NUnit.Framework;

    public partial class Damper
    {
        [Test]
        public void TestComputeImpulse()
        {
            Physics.Suspension.Parts.Damper damper = new Physics.Suspension.Parts.Damper()
            {
                DampingCoefficient = 10.0f,
            };

            float impulse = damper.ComputeImpulse(10.0f, UnityEngine.Time.fixedDeltaTime);
            Assert.AreEqual(-2.0f, impulse);

            impulse = damper.ComputeImpulse(-10.0f, UnityEngine.Time.fixedDeltaTime);
            Assert.AreEqual(2.0f, impulse);

            impulse = damper.ComputeImpulse(0.0f, UnityEngine.Time.fixedDeltaTime);
            Assert.AreEqual(0.0f, impulse);
        }
    }
}
