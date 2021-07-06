namespace Legion.Mathematics.DifferentialEquation
{
	using System.Runtime.CompilerServices;
	using Unity.Mathematics;

	public struct Solver
	{
		#region Static Methods
		/// <summary>
		/// Solve first order differential equation for the next step with the explicit Euler method.
		/// </summary>
		/// <param name="currentVariable">Current value of the variable</param>
		/// <param name="currentDerivative">Current value of the derivative</param>
		/// <param name="step">Simulation step</param>
		/// <returns>Next value of the variable</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SolveWithExplicitEuler(float currentVariable, float currentDerivative, float step)
		{
			return currentVariable + step * currentDerivative;
		}

		/// <summary>
		/// Solve second order differential equation for the next step with the explicit Euler method.
		/// </summary>
		/// <param name="currentVariable">Current value of the variable</param>
		/// <param name="currentDerivative">Current value of the derivative</param>
		/// <param name="step">Simulation step</param>
		/// <returns>Next value of the variable and the derivative</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 SolveWithExplicitEuler(float2 currentVariable, float2 currentDerivative, float step)
		{
			return currentVariable + step * currentDerivative;
		}

		/// <summary>
		/// Solve first order differential equation for the next step with the second order Runge-Kutta method.
		/// </summary>
		/// <param name="currentVariable">Current value of the variable</param>
		/// <param name="k1">Current value of the derivative</param>
		/// <param name="k2">Next value of the derivative computed with 
		/// the next value of the variable (k1) from the explicit Euler method</param>
		/// <param name="step">Simulation step</param>
		/// <returns>Next value of the variable</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SolveWithExplicitRungeKutta2(float currentVariable, float k1, float k2, float step)
		{
			return currentVariable + step * (0.5f * k1 + 0.5f * k2);
		}

		/// <summary>
		/// Solve second order differential equation for the next step with the second order Runge-Kutta method.
		/// </summary>
		/// <param name="currentVariable">Current value of the variable</param>
		/// <param name="k1">Current value of the derivative</param>
		/// <param name="k2">Next value of the derivative computed with the next value of 
		/// the variable (k1) from the explicit Euler method</param>
		/// <param name="step">Simulation step</param>
		/// <returns>Next value of the variable and the derivative</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 SolveWithExplicitRungeKutta2(float2 currentVariable, float2 k1, float2 k2, float step)
		{
			return currentVariable + step * (0.5f * k1 + 0.5f * k2);
		}

		/// <summary>
		/// Solve first order differential equation for the next step with the fourth order Runge-Kutta method.
		/// </summary>
		/// <param name="currentVariable">Current value of the variable</param>
		/// <param name="k1">Current value of the derivative</param>
		/// <param name="k2">>Value of the derivative (at time + 0.5 * step) computed with 
		/// the next value of the variable (k1) from the explicit Euler method</param>
		/// <param name="k3">Value of the derivative (at time + 0.5 * step) computed with 
		/// the next value of the variable (k2) from the explicit Euler method</param>
		/// <param name="k4">Next value of the derivative computed with 
		/// the next value of the variable (k3) from the explicit Euler method</param>
		/// <param name="step">Simulation step</param>
		/// <returns>Next value of the variable</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SolveWithExplicitRungeKutta4(float currentVariable, float k1, float k2, float k3, float k4, float step)
		{
			return currentVariable + (1.0f / 6.0f) * step * (k1 + 2.0f * k2 + 2.0f * k3 + k4);
		}

		/// <summary>
		/// Solve second order differential equation for the next step with the fourth order Runge-Kutta method.
		/// </summary>
		/// <param name="currentVariable">Current value of the variable</param>
		/// <param name="k1">Current value of the derivative</param>
		/// <param name="k2">Value of the derivative (at time + 0.5 * step) 
		/// computed with the next value of the variable (k1) from the explicit Euler method</param>
		/// <param name="k3">Value of the derivative (at time + 0.5 * step) 
		/// computed with the next value of the variable (k2) from the explicit Euler method</param>
		/// <param name="k4">Next value of the derivative computed with the next value of 
		/// the variable (k3) from the explicit Euler method</param>
		/// <param name="step">Simulation step</param>
		/// <returns>Next value of the variable and the derivative</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 SolveWithExplicitRungeKutta4(float2 currentVariable, float2 k1, float2 k2, float2 k3, float2 k4, float step)
		{
			return currentVariable + (1.0f / 6.0f) * step * (k1 + 2.0f * k2 + 2.0f * k3 + k4);
		}

		/// <summary>
		/// Solve variable of the differential equation for the next step with the one step Verlet method.
		/// </summary>
		/// <param name="currentVariable">Current value of the variable</param>
		/// <param name="currentDerivative">Current value of the derivative</param>
		/// <param name="currentSecondDerivative">Current value of the second derivative</param>
		/// <param name="step">Simulation step</param>
		/// <returns>Next value of the variable</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float StartSolvingWithVerlet1(float currentVariable, float currentDerivative, float currentSecondDerivative, float step)
		{
			return currentVariable + step * currentDerivative + 0.5f * step * step * currentSecondDerivative;
		}

		/// <summary>
		/// Solve derivative of the differential equation for the next step with the one step Verlet method.
		/// </summary>
		/// <param name="currentDerivative">Current value of the derivative</param>
		/// <param name="currentSecondDerivative">Current value of the second derivative</param>
		/// <param name="nextSecondDerivative">Next value of the second derivative</param>
		/// <param name="step">Simulation step</param>
		/// <returns>Next value of the derivative</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EndSolvingWithVerlet1(float currentDerivative, float currentSecondDerivative, float nextSecondDerivative, float step)
		{
			return currentDerivative + 0.5f * step * (currentSecondDerivative + nextSecondDerivative);
		}
		#endregion Static Methods
	}
}
