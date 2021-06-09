namespace Legion.Test
{
	using NUnit.Framework;
	using Unity.Mathematics;

	public class VelocityConstraint
	{
		[Test]
		public void TestGenerateLinearSystem1()
		{
			Physics.VelocityConstraint constraint = new Physics.VelocityConstraint()
			{
				LocalDirection = math.forward(),
				LocalDistance = float3.zero,
				Bias = 0.0f
			};
			float invMass = 0.5f;
			float3 invInertiaTensor = 1.0f;

			Physics.VelocityConstraint.GenerateLinearSystem(
				invMass, invInertiaTensor, in constraint, out float a00);
			Assert.AreEqual(0.5f, a00);
		}

		[Test]
		public void TestGenerateLinearSystem2()
		{
			Physics.VelocityConstraint constraintA = new Physics.VelocityConstraint()
			{
				LocalDirection = math.right(),
				LocalDistance = math.forward(),
				Bias = 0.0f
			};
			Physics.VelocityConstraint constraintB = new Physics.VelocityConstraint()
			{
				LocalDirection = math.right(),
				LocalDistance = 2.0f * math.back(),
				Bias = 0.0f
			};
			float invMass = 0.5f;
			float3 invInertiaTensor = 1.0f;

			Physics.VelocityConstraint.GenerateLinearSystem(
				invMass, invInertiaTensor, in constraintA, in constraintB, 
				out float a00, out float a01, out float a10, out float a11);
			Assert.AreEqual(1.5f, a00);
			Assert.AreEqual(-1.5f, a01);
			Assert.AreEqual(-1.5f, a10);
			Assert.AreEqual(4.5f, a11);
		}
	}
}
