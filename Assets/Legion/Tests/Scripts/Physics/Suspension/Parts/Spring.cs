namespace Legion.Test
{
    using NUnit.Framework;

	public partial class Spring
    {
        [Test]
        public void TestComputeImpulse()
        {
            Physics.Suspension.Parts.Spring spring = new Physics.Suspension.Parts.Spring()
            {
                NeutralLength = 0.5f,
                Stiffness = 100.0f
			};

            float impulse = spring.ComputeImpulse(1.0f, UnityEngine.Time.fixedDeltaTime);
            Assert.AreEqual(-1.0f, impulse);

            impulse = spring.ComputeImpulse(0.25f, UnityEngine.Time.fixedDeltaTime);
            Assert.AreEqual(0.5f, impulse);

            impulse = spring.ComputeImpulse(0.5f, UnityEngine.Time.fixedDeltaTime);
            Assert.AreEqual(0.0f, impulse);
        }
    }
}
