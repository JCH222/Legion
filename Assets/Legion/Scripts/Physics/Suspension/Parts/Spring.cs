namespace Legion.Physics.Suspension.Parts
{
	/// <summary>
	/// Energy-restituting suspension part.
	/// </summary>
	[System.Serializable]
	public struct Spring
	{
		#region Fields
		public float Stiffness;
		public float NeutralLength;
		#endregion Fields

		#region Methods
		/// <summary>
		/// Compute the impulse.
		/// </summary>
		/// <param name="currentLength">Length of the suspension [m]</param>
		/// <param name="timeStep">Time step of the simulation [s]</param>
		/// <returns>The impulse [kg.m.s^-1]</returns>
		public float ComputeImpulse(float currentLength, float timeStep)
		{
			return Stiffness * (NeutralLength - currentLength) * timeStep;
		}
		#endregion Methods
	}
}
