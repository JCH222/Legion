namespace Legion.Test
{
    using NUnit.Framework;
	using Unity.Collections;
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

		[Test]
		public void TestMergeImpulses()
		{
			int anchorNb = 4;
			NativeArray<float3> impulses = new NativeArray<float3>(anchorNb, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			NativeArray<float3> distances = new NativeArray<float3>(anchorNb, Allocator.Persistent, NativeArrayOptions.ClearMemory);

			impulses[0] = math.up();
			impulses[1] = math.up();
			impulses[2] = math.up();
			impulses[3] = math.up();
			distances[0] = math.right();
			distances[1] = math.left();
			distances[2] = math.forward();
			distances[3] = math.back();
			Physics.Utilities.MergeImpulses(in impulses, in distances, out float3 linearImpulse, out float3 angularImpulse);
			Assert.AreEqual(new float3(0.0f, 4.0f, 0.0f), linearImpulse);
			Assert.AreEqual(float3.zero, angularImpulse);

			impulses[0] = math.up();
			impulses[1] = math.down();
			impulses[2] = math.up();
			impulses[3] = math.down();
			distances[0] = math.right();
			distances[1] = math.left();
			distances[2] = math.forward();
			distances[3] = math.back();
			Physics.Utilities.MergeImpulses(in impulses, in distances, out linearImpulse, out angularImpulse);
			Assert.AreEqual(float3.zero, linearImpulse);
			Assert.AreEqual(new float3(-2f, 0f, 2f), angularImpulse);

			impulses[0] = math.forward();
			impulses[1] = math.back();
			impulses[2] = math.up();
			impulses[3] = math.down();
			distances[0] = math.forward();
			distances[1] = math.back();
			distances[2] = math.up();
			distances[3] = math.down();
			Physics.Utilities.MergeImpulses(in impulses, in distances, out linearImpulse, out angularImpulse);
			Assert.AreEqual(float3.zero, linearImpulse);
			Assert.AreEqual(float3.zero, angularImpulse);

			impulses.Dispose();
			distances.Dispose();
		}
    }
}
