namespace Legion.Physics.Suspension
{
	using Legion.Physics.Suspension.Parts;
	using System.Runtime.CompilerServices;
	using Unity.Mathematics;

	public struct Solver
	{
		#region Static Methods
		/// <summary>
		/// Simulate suspension behaviour with the explicit Euler method for the next time step.
		/// </summary>
		/// <param name="spring">Spring configuration</param>
		/// <param name="damper">Damper configuration</param>
		/// <param name="inverseMass">Inverse of the mass [kg]</param>
		/// <param name="timeStep">Time Step of the simulation [s]</param>
		/// <param name="initialLength">Initial length of the suspension [m]</param>
		/// <param name="initialSpeed">Initial speed of the suspension [m.s^-1]</param>
		/// <param name="impulse">Generated impulse [kg.m.s^-1] for the next time step</param>
		/// <returns>Length [m] and speed [m.s^-1] of the suspension for the next time step</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 SimulateWithExplicitEuler(in Spring spring, in Damper damper, 
			float inverseMass, float timeStep, float initialLength, float initialSpeed, out float impulse)
		{
			float springImpulse = spring.ComputeImpulse(initialLength, timeStep);
			float damperImpulse = damper.ComputeImpulse(initialSpeed, timeStep);
			impulse = springImpulse + damperImpulse;
			float initialAcceleration = impulse * inverseMass / timeStep;

			float2 variable = new float2(initialLength, initialSpeed);
			float2 derivative = new float2(initialSpeed, initialAcceleration);

			return Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(variable, derivative, timeStep);
		}

		/// <summary>
		/// Simulate suspension behaviour with the explicit Second order Runge-Kutta method for the next time step.
		/// </summary>
		/// <param name="spring">Spring configuration</param>
		/// <param name="damper">Damper configuration</param>
		/// <param name="inverseMass">Inverse of the mass [kg]</param>
		/// <param name="timeStep">Time Step of the simulation [s]</param>
		/// <param name="initialLength">Initial length of the suspension [m]</param>
		/// <param name="initialSpeed">Initial speed of the suspension [m.s^-1]</param>
		/// <param name="impulse">Generated impulse [kg.m.s^-1] for the next time step</param>
		/// <returns>Length [m] and speed [m.s^-1] of the suspension for the next time step</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 SimulateWithExplicitRungeKutta2(in Spring spring, in Damper damper,
			float inverseMass, float timeStep, float initialLength, float initialSpeed, out float impulse)
		{
			float springImpulse = spring.ComputeImpulse(initialLength, timeStep);
			float damperImpulse = damper.ComputeImpulse(initialSpeed, timeStep);

			impulse = springImpulse + damperImpulse;
			float initialAcceleration = impulse * inverseMass / timeStep;

			float2 variable = new float2(initialLength, initialSpeed);
			float2 derivative = new float2(initialSpeed, initialAcceleration);
			float2 tempVariable = Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(variable, derivative, timeStep);
			float tempAcceleration = (spring.ComputeImpulse(tempVariable.x, timeStep) +
				damper.ComputeImpulse(tempVariable.y, timeStep)) * inverseMass / timeStep;

			return Mathematics.DifferentialEquation.Solver.SolveWithExplicitRungeKutta2(variable, derivative, 
				new float2(tempVariable.y, tempAcceleration), timeStep);
		}

		// TODO : Add RK4 and Verlet1
		#endregion Static Methods
	}
}
