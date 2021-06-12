namespace Legion.Physics
{
	using System.Runtime.CompilerServices;
	using Unity.Mathematics;

	/// <summary>
	/// Velocity constraint applied to a rigid body.
	/// </summary>
	public struct VelocityConstraint
	{
		#region Fields
		public bool IsActive; // Constraint activation trigger
		public float3 LocalDirection; // Direction of the contraint in the local world [m]
		public float3 LocalDistance; // Distance of the contraint from the center of mass in the local world [m]
		public float Bias; // Additional speed of the constraint [m.s^-1]
		#endregion Fields

		#region Static Methods
		/// <summary>
		/// Generate the linear system coefficient from one velocity constraint.
		/// </summary>
		/// <param name="invMass">Inverse of mass [kg^-1]</param>
		/// <param name="invInertiaTensor">Inverse of inertia tensor [kg^-1.m^-2]</param>
		/// <param name="constraintA">Velocity constraint</param>
		/// <param name="a00">Coefficients matrix value (row 0 / column 0)</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GenerateLinearSystem(float invMass, float3 invInertiaTensor, 
			in VelocityConstraint constraintA, out float a00)
		{
			Utilities.ComputeVelocityAtPosition(invMass, invInertiaTensor, constraintA.LocalDistance,
				constraintA.LocalDistance, constraintA.LocalDirection, out float3 linearVelocity, out float3 tangentialVelocity);
			a00 = math.dot(constraintA.LocalDirection, linearVelocity + tangentialVelocity);
		}

		/// <summary>
		/// Generate the linear system coefficients from two velocity constraints.
		/// </summary>
		/// <param name="invMass">Inverse of mass [kg^-1]</param>
		/// <param name="invInertiaTensor">Inverse of inertia tensor [kg^-1.m^-2]</param>
		/// <param name="constraintA">First velocity constraint A</param>
		/// <param name="constraintB">Second velocity constraint B</param>
		/// <param name="a00">Coefficients matrix value (row 0 / column 0)</param>
		/// <param name="a01">Coefficients matrix value (row 0 / column 1)</param>
		/// <param name="a10">Coefficients matrix value (row 1 / column 0)</param>
		/// <param name="a11">Coefficients matrix value (row 1 / column 1)</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GenerateLinearSystem(float invMass, float3 invInertiaTensor, 
			in VelocityConstraint constraintA, in VelocityConstraint constraintB,
			out float a00, out float a01, out float a10, out float a11)
		{
			Utilities.ComputeVelocityAtPosition(invMass, invInertiaTensor, constraintA.LocalDistance,
				constraintA.LocalDistance, constraintA.LocalDirection, out float3 linearVelocity00, out float3 tangentialVelocity00);
			a00 = math.dot(constraintA.LocalDirection, linearVelocity00 + tangentialVelocity00);

			Utilities.ComputeVelocityAtPosition(invMass, invInertiaTensor, constraintB.LocalDistance,
				constraintA.LocalDistance, constraintB.LocalDirection, out float3 linearVelocity01, out float3 tangentialVelocity01);
			a01 = math.dot(constraintA.LocalDirection, linearVelocity01 + tangentialVelocity01);

			Utilities.ComputeVelocityAtPosition(invMass, invInertiaTensor, constraintA.LocalDistance,
				constraintB.LocalDistance, constraintA.LocalDirection, out float3 linearVelocity10, out float3 tangentialVelocity10);
			a10 = math.dot(constraintB.LocalDirection, linearVelocity10 + tangentialVelocity10);

			Utilities.ComputeVelocityAtPosition(invMass, invInertiaTensor, constraintB.LocalDistance,
				constraintB.LocalDistance, constraintB.LocalDirection, out float3 linearVelocity11, out float3 tangentialVelocity11);
			a11 = math.dot(constraintB.LocalDirection, linearVelocity11 + tangentialVelocity11);
		}
		#endregion Static Methods
	}
}
