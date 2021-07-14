namespace Legion.Physics.Suspension
{
	using Legion.Physics.Suspension.Parts;
	using System.Runtime.CompilerServices;
	using Unity.Collections;
	using Unity.Mathematics;

	/// <summary>
	/// Differential equation solving type.
	/// </summary>
	public enum SolvingType
	{
		EXPLICIT_EULER = 0,
		EXPLICIT_RUNGE_KUTTA_2 = 1,
		EXPLICIT_RUNGE_KUTTA_4 = 2,
		VERLET_1 = 3
	}

	public struct Utilities
	{
		/// <summary>
		/// Simulate the impulse response of the suspension system at rest.
		/// </summary>
		/// <param name="spring">Spring of the suspension</param>
		/// <param name="damper">Damper of the suspension</param>
		/// <param name="inverseMass">Inverse of the mass [kg^-1]</param>
		/// <param name="timeStep">Time step of the simulation [s]</param>
		/// <param name="initialImpulse">Initial impulse [kg.m.s^-1]</param>
		/// <param name="behaviour">Suspension behaviour (Elapsed Time [s] | Length [m] | Speed [m.s^-1])</param>
		/// <returns>Is succeed</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool SimulateImpulseResponse(in Spring spring, in Damper damper, float inverseMass, 
			float timeStep, float initialImpulse, SolvingType solvingType, ref NativeArray<float3> behaviour)
		{
			float currentTime = 0.0f;
			float currentLength = spring.NeutralLength;
			float currentSpeed = initialImpulse * inverseMass;

			behaviour[0] = new float3(currentTime, currentLength, currentSpeed);
			for (int i = 1, size = behaviour.Length; i < size; i++)
			{
				float2 nextVariable;
				if (solvingType == SolvingType.EXPLICIT_EULER)
				{
					nextVariable = Solver.SimulateWithExplicitEuler(in spring, in damper, 
						inverseMass, timeStep, currentLength, currentSpeed, out float _);
				}
				else if (solvingType == SolvingType.EXPLICIT_RUNGE_KUTTA_2)
				{
					nextVariable = Solver.SimulateWithExplicitRungeKutta2(in spring, in damper, 
						inverseMass, timeStep, currentLength, currentSpeed, out float _);
				}
				else
				{
					return false;
				}

				currentLength = nextVariable.x;
				currentSpeed = nextVariable.y;
				currentTime += timeStep;
				behaviour[i] = new float3(currentTime, currentLength, currentSpeed);
			}

			return true;
		}

		/// <summary>
		/// Simulate the impulse response of the suspension system at rest.
		/// </summary>
		/// <param name="spring">Spring of the suspension</param>
		/// <param name="inverseMass">Inverse of the mass [kg^-1]</param>
		/// <param name="timeStep">Time step of the simulation [s]</param>
		/// <param name="initialImpulse">Initial impulse [kg.m.s^-1]</param>
		/// <param name="lengthBehaviour">Suspension behaviour [m | m.s^-1 |-> s]</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SimulateImpulseResponse(in Spring spring, 
			float inverseMass, float timeStep, float initialImpulse,
			SolvingType solvingType, ref NativeArray<float3> behaviour)
		{
			Damper damper = new Damper()
			{
				DampingCoefficient = 0.0f
			};

			SimulateImpulseResponse(in spring, in damper, inverseMass,
				timeStep, initialImpulse, solvingType, ref behaviour);
		}

		/// <summary>
		/// Simulate the impulse response of the suspension system at rest.
		/// </summary>
		/// <param name="damper">Damper of the suspension</param>
		/// <param name="initialLength">Initial length of the suspension [m]</param>
		/// <param name="inverseMass">Inverse of the mass [kg^-1]</param>
		/// <param name="timeStep">Time step of the simulation [s]</param>
		/// <param name="initialImpulse">Initial impulse [kg.m.s^-1]</param>
		/// <param name="lengthBehaviour">Suspension behaviour [m | m.s^-1 |-> s]</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SimulateImpulseResponse(in Damper damper, float initialLength, float inverseMass, 
			float timeStep, float initialImpulse, SolvingType solvingType, ref NativeArray<float3> behaviour)
		{
			Spring spring = new Spring()
			{
				NeutralLength = initialLength,
				Stiffness = 0.0f
			};

			SimulateImpulseResponse(in spring, in damper, inverseMass,
				timeStep, initialImpulse, solvingType, ref behaviour);
		}
	}
}
