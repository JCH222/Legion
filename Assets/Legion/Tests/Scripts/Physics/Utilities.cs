namespace Legion.Test
{
    using NUnit.Framework;
    using Unity.Mathematics;
    public partial class Utilities
    {
        [Test]
        public void TestComputeVelocityAtPoint()
        {
            float invMass = 1.0f;
            float invInertiaTensor = 1.0f;

            Physics.Utilities.ComputeVelocityAtPosition(invMass, invInertiaTensor, float3.zero, 
                float3.zero, math.up(), out float3 linearVelocity, out float3 tangentialVelocity);
            Assert.AreEqual(math.up(), linearVelocity);
            Assert.AreEqual(float3.zero, tangentialVelocity);

            Physics.Utilities.ComputeVelocityAtPosition(invMass, invInertiaTensor, math.forward(),
                math.forward(), math.up(), out linearVelocity, out tangentialVelocity);
            Assert.AreEqual(math.up(), linearVelocity);
            Assert.AreEqual(math.up(), tangentialVelocity);

            Physics.Utilities.ComputeVelocityAtPosition(invMass, invInertiaTensor, math.forward(),
                math.back(), math.up(), out linearVelocity, out tangentialVelocity);
            Assert.AreEqual(math.up(), linearVelocity);
            Assert.AreEqual(-math.up(), tangentialVelocity);

            Physics.Utilities.ComputeVelocityAtPosition(invMass, invInertiaTensor, math.forward(),
                math.back() * 2.0f, math.up(), out linearVelocity, out tangentialVelocity);
            Assert.AreEqual(math.up(), linearVelocity);
            Assert.AreEqual(-math.up() * 2.0f, tangentialVelocity);

            Physics.Utilities.ComputeVelocityAtPosition(invMass, invInertiaTensor, math.forward(),
                math.left(), math.up(), out linearVelocity, out tangentialVelocity);
            Assert.AreEqual(math.up(), linearVelocity);
            Assert.AreEqual(float3.zero, tangentialVelocity);
        }
    }
}
