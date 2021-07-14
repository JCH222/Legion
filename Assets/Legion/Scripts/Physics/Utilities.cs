namespace Legion.Physics
{
	using System.Runtime.CompilerServices;
	using Unity.Collections;
	using Unity.Mathematics;

	public struct Utilities
	{
		#region Static Methods
		/// <summary>
		/// Compute linear and tangential velocities of impulse from input position to ouput position 
		/// </summary>
		/// <param name="invMass">Inverse of mass [kg^-1]</param>
		/// <param name="invInertiaTensor">Inverse of inertia tensor [kg^-1.m^-2]</param>
		/// <param name="distanceIn">Distance from the center of mass to the impulse application [m]</param>
		/// <param name="distanceOut">Distance from the center of mass to the velocites computation position [m]</param>
		/// <param name="impulse">Impulse [kg.m.s^-1]</param>
		/// <param name="linearVelocity">Linear velocity [m.s^-1]</param>
		/// <param name="tangentialVelocity">Tangential velocity [m.s^-1]</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ComputeVelocityAtPosition(float invMass,
			float3 invInertiaTensor, float3 distanceIn, 
			float3 distanceOut, float3 impulse,
			out float3 linearVelocity,
			out float3 tangentialVelocity)
		{
			float3 angularImpulse = math.cross(distanceIn, impulse);
			float3 angularVelocity = angularImpulse * invInertiaTensor;
			tangentialVelocity = math.cross(angularVelocity, distanceOut);
			linearVelocity = impulse * invMass;
		}

		/// <summary>
		/// Compute global linear and angular impulses from several impulses.
		/// </summary>
		/// <param name="impulses">Applied impulses [kg.m.s^-1]</param>
		/// <param name="distances">Distances from the center of mass to the impulses application [m]</param>
		/// <param name="linearImpulse">Global linear impulse [kg.m.s^-1]</param>
		/// <param name="angularImpulse">Global angular impulse [kg.m^2.s^-1]</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MergeImpulses(in NativeArray<float3> impulses, 
			in NativeArray<float3> distances, out float3 linearImpulse, 
			out float3 angularImpulse)
		{
			linearImpulse = 0.0f;
			angularImpulse = 0.0f;

			for (int i = 0, length = impulses.Length; i < length; i++)
			{
				float3 impulse = impulses[i];
				linearImpulse += impulse;
				angularImpulse += math.cross(distances[i], impulse);
			}
		}
		#endregion Static Methods
	}
}
