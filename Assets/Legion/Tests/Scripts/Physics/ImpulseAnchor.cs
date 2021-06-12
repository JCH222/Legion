namespace Legion.Test
{
	using NUnit.Framework;
	using Unity.Collections;
	using Unity.Mathematics;

	public class ImpulseAnchor
	{
		[Test]
		public void TestApplyAnchors()
		{
			float invMass = 0.5f;
			float3 invInertiaTensor = 1.0f;

			NativeArray<Physics.ImpulseAnchor> anchors = 
				new NativeArray<Physics.ImpulseAnchor>(1, Allocator.Persistent);
			anchors[0] = new Physics.ImpulseAnchor(math.up(), math.back(), 1.0f);
			Physics.ImpulseAnchor.ApplyAnchors(invMass, invInertiaTensor, in anchors, 
				out float3 deltaLinearVelocity, out float3 deltaAngularVelocity);
			Assert.AreEqual(new float3(0.0f, 0.5f, 0.0f), deltaLinearVelocity);
			Assert.AreEqual(math.right(), deltaAngularVelocity);
			anchors.Dispose();

			anchors = new NativeArray<Physics.ImpulseAnchor>(3, Allocator.Persistent);
			anchors[0] = new Physics.ImpulseAnchor(math.normalize(new float3(0.0f, 1.0f, 1.0f)), 
				math.forward(), 10.0f);
			anchors[1] = new Physics.ImpulseAnchor(math.normalize(new float3(1.0f, 1.0f, -1.0f)), 
				math.normalize(new float3(1.0f, 0.0f, -1.0f)), 5.0f);
			anchors[2] = new Physics.ImpulseAnchor(math.normalize(new float3(-1.0f, 1.0f, -1.0f)), 
				math.normalize(new float3(-1.0f, 0.0f, -1.0f)), 5.0f);
			Physics.ImpulseAnchor.ApplyAnchors(invMass, invInertiaTensor, in anchors, 
				out deltaLinearVelocity, out deltaAngularVelocity);
			Assert.AreEqual(new float3(0.0f, 6.422285f, 0.64878273f), deltaLinearVelocity);
			Assert.AreEqual(new float3(-2.98858476f, 0.0f, 0.0f), deltaAngularVelocity);
			anchors.Dispose();
		}
	}
}
