namespace Legion.Physics
{
	using System.Runtime.CompilerServices;
	using Unity.Collections;
	using Unity.Mathematics;

	/// <summary>
	/// Impulse application anchor in a rigid body.
	/// </summary>
	public struct ImpulseAnchor
	{
		#region Fields
		public bool IsActive; // Impulse application trigger
		public float3 LocalDirection; // Direction of the impulse application in the local world [m]
		public float3 LocalDistance; // Distance of the impulse application from the center of mass in the local world [m]
		public float Magnitude; // Magnitude of the applied impulse [kg.m.s^-1]
		#endregion Fields

		#region Constructors
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="localDirection">Direction of the impulse application in the local world [m]</param>
		/// <param name="localDistance">Distance of the impulse application from the center of mass in the local world [m]</param>
		/// <param name="magnitude">Magnitude of the applied impulse [kg.m.s^-1]</param>
		/// <param name="isActive">Impulse application trigger</param>
		public ImpulseAnchor(float3 localDirection, float3 localDistance, float magnitude, bool isActive = true)
		{
			IsActive = isActive;
			LocalDistance = localDistance;
			LocalDirection = localDirection;
			Magnitude = magnitude;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="constraint">Velocity constraint</param>
		/// <param name="magnitude">Magnitude of the applied impulse [kg.m.s^-1]</param>
		public ImpulseAnchor(VelocityConstraint constraint, float magnitude)
		{
			IsActive = constraint.IsActive;
			LocalDistance = constraint.LocalDistance;
			LocalDirection = constraint.LocalDirection;
			Magnitude = magnitude;
		}
		#endregion Constructors

		#region Static Methods
		/// <summary>
		/// Apply several impulses to a rigid body.
		/// </summary>
		/// <param name="invMass">Inverse of mass [kg^-1]</param>
		/// <param name="invInertiaTensor">Inverse of inertia tensor [kg^-1.m^-2]</param>
		/// <param name="anchors">Impulse anchors</param>
		/// <param name="deltaLinearVelocity">Generated delta linear velocity in the local world [m.s^-1]</param>
		/// <param name="deltaAngularVelocity">Generated delta angular velocity in the local world [rad.s^-1]</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ApplyAnchors(float invMass, 
			float3 invInertiaTensor, in NativeArray<ImpulseAnchor> anchors, 
			out float3 deltaLinearVelocity, out float3 deltaAngularVelocity)
		{
			deltaLinearVelocity = float3.zero;
			deltaAngularVelocity = float3.zero;

			float3 deltaLinearImpulse = float3.zero;
			float3 deltaAngularImpulse = float3.zero;

			foreach (ImpulseAnchor anchor in anchors)
			{
				if (anchor.IsActive)
				{
					float3 currentDeltaLinearImpulse = anchor.LocalDirection * anchor.Magnitude;
					deltaLinearImpulse += currentDeltaLinearImpulse;
					deltaAngularImpulse += math.cross(anchor.LocalDistance, currentDeltaLinearImpulse);
				}
			}

			deltaLinearVelocity = deltaLinearImpulse * invMass;
			deltaAngularVelocity = deltaAngularImpulse * invInertiaTensor;
		}
		#endregion Static Methods
	}
}
