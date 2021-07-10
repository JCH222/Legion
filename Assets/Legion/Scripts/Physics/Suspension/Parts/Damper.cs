namespace Legion.Physics.Suspension.Parts
{
	/// <summary>
	/// Energy-dissipating suspension part.
	/// </summary>
	public struct Damper
	{
		#region Fields
		public float DampingCoefficient;
		#endregion Fields

		#region Methods
		/// <summary>
		/// Compute the impulse.
		/// </summary>
		/// <param name="currentSpeed">Current speed of the suspension [m.s^-1]</param>
		/// <param name="timeStep">Time step of the simulation [s]</param>
		/// <returns>The impulse [kg.m.s^-1]</returns>
		public float ComputeImpulse(float currentSpeed, float timeStep)
		{
			return -DampingCoefficient * currentSpeed * timeStep;
		}
		#endregion Methods
	}
}
