namespace Legion.Mathematics.LinearSystem
{
	using System.Runtime.CompilerServices;

	public enum GlobalSolvingType
	{
		CRAMER = 0
	}

	public struct GlobalSolver
	{
		#region Static Methods
		/// <summary>
		/// Solve a dimension 1 linear system :
		/// | a00 * variableA = result0
		/// </summary>
		/// <param name="a00">Coefficient matrix value (row 0 / column 0)</param>
		/// <param name="result0">First equation value</param>
		/// <param name="variableA">Variable matrix value (row 0)</param>
		/// <param name="residual1">Abosulte error of the first equation</param>
		/// <param name="solvingType">Solving method</param>
		/// <param name="epsilon">Null value range (>= 0)/param>
		/// <returns>Solving status</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SolvingStatus Solve(
			float a00, float result0, out float variableA, out float residual1, 
			GlobalSolvingType solvingType = GlobalSolvingType.CRAMER, float epsilon = 0.0f)
		{
			if (solvingType == GlobalSolvingType.CRAMER)
			{
				SolvingStatus status = Utilities.CheckIsSolvable(
					a00, result0, out float denominator, 
					out float numeratorA, epsilon);

				if (status == SolvingStatus.VALID)
				{
					variableA = numeratorA / denominator;
					residual1 = 0.0f;
				}
				else
				{
					variableA = float.NaN;
					residual1 = float.NaN;
				}

				return status;
			}
			else
			{
				variableA = float.NaN;
				residual1 = float.NaN;

				return SolvingStatus.UNKNOWN;
			}
		}

		/// <summary>
		/// Solve a dimension 1 linear system :
		/// | a00 * variableA = result0
		/// </summary>
		/// <param name="a00">Coefficient matrix value (row 0 / column 0)</param>
		/// <param name="result0">First equation value</param>
		/// <param name="variableA">Variable matrix value (row 0)</param>
		/// <param name="residual1">Abosulte error of the first equation</param>
		/// <param name="solvingType">Solving method</param>
		/// <param name="epsilon">Null value range (>= 0)/param>
		/// <returns>Solving status</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SolvingStatus Solve(
			double a00, double result0, out double variableA, out double residual1,
			GlobalSolvingType solvingType = GlobalSolvingType.CRAMER, double epsilon = 0.0d)
		{
			if (solvingType == GlobalSolvingType.CRAMER)
			{
				SolvingStatus status = Utilities.CheckIsSolvable(
					a00, result0, out double denominator,
					out double numeratorA, epsilon);

				if (status == SolvingStatus.VALID)
				{
					variableA = numeratorA / denominator;
					residual1 = 0.0f;
				}
				else
				{
					variableA = double.NaN;
					residual1 = double.NaN;
				}

				return status;
			}
			else
			{
				variableA = double.NaN;
				residual1 = double.NaN;

				return SolvingStatus.UNKNOWN;
			}
		}

		/// <summary>
		/// Solve a dimension 2 linear system :
		/// | a00 * variableA + a01 * variableB = result0
		/// | a10 * variableA + a11 * variableB = result1
		/// </summary>
		/// <param name="a00">Coefficient matrix value (row 0 / column 0)</param>
		/// <param name="a01">Coefficient matrix value (row 0 / column 1)</param>
		/// <param name="result0">First equation value</param>
		/// <param name="a10">Coefficient matrix value (row 1 / column 0)</param>
		/// <param name="a11">Coefficient matrix value (row 1 / column 1)</param>
		/// <param name="result1">Second equation value</param>
		/// <param name="variableA">Variable matrix value (column 0)</param>
		/// <param name="residual1">Abosulte error of the first equation</param>
		/// <param name="variableB">Variable matrix value (column 1)</param>
		/// <param name="residual2">Abosulte error of the second equation</param>
		/// <param name="solvingType">Solving method</param>
		/// <param name="epsilon">Null value range (>= 0)/param>
		/// <returns>Solving status</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SolvingStatus Solve(
			float a00, float a01, float result0,
			float a10, float a11, float result1,
			out float variableA, out float residual1,
			out float variableB, out float residual2,
			GlobalSolvingType solvingType = GlobalSolvingType.CRAMER, 
			float epsilon = 0.0f)
		{
			if (solvingType == GlobalSolvingType.CRAMER)
			{
				SolvingStatus status = Utilities.CheckIsSolvable(
					a00, a01, result0, a10, a11, result1,
					out float denominator, out float numeratorA, 
					out float numeratorB, epsilon);

				if (status == SolvingStatus.VALID)
				{
					variableA = numeratorA / denominator;
					residual1 = 0.0f;
					variableB = numeratorB / denominator;
					residual2 = 0.0f;
				}
				else
				{
					variableA = float.NaN;
					residual1 = float.NaN;
					variableB = float.NaN;
					residual2 = float.NaN;
				}

				return status;
			}
			else
			{
				variableA = float.NaN;
				residual1 = float.NaN;
				variableB = float.NaN;
				residual2 = float.NaN;

				return SolvingStatus.UNKNOWN;
			}
		}

		/// <summary>
		/// Solve a dimension 2 linear system :
		/// | a00 * variableA + a01 * variableB = result0
		/// | a10 * variableA + a11 * variableB = result1
		/// </summary>
		/// <param name="a00">Coefficient matrix value (row 0 / column 0)</param>
		/// <param name="a01">Coefficient matrix value (row 0 / column 1)</param>
		/// <param name="result0">First equation value</param>
		/// <param name="a10">Coefficient matrix value (row 1 / column 0)</param>
		/// <param name="a11">Coefficient matrix value (row 1 / column 1)</param>
		/// <param name="result1">Second equation value</param>
		/// <param name="variableA">Variable matrix value (column 0)</param>
		/// <param name="residual1">Abosulte error of the first equation</param>
		/// <param name="variableB">Variable matrix value (column 1)</param>
		/// <param name="residual2">Abosulte error of the second equation</param>
		/// <param name="solvingType">Solving method</param>
		/// <param name="epsilon">Null value range (>= 0)/param>
		/// <returns>Solving status</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SolvingStatus Solve(
			double a00, double a01, double result0,
			double a10, double a11, double result1,
			out double variableA, out double residual1,
			out double variableB, out double residual2,
			GlobalSolvingType solvingType = GlobalSolvingType.CRAMER,
			double epsilon = 0.0d)
		{
			if (solvingType == GlobalSolvingType.CRAMER)
			{
				SolvingStatus status = Utilities.CheckIsSolvable(
					a00, a01, result0, a10, a11, result1,
					out double denominator, out double numeratorA,
					out double numeratorB, epsilon);

				if (status == SolvingStatus.VALID)
				{
					variableA = numeratorA / denominator;
					residual1 = 0.0d;
					variableB = numeratorB / denominator;
					residual2 = 0.0d;
				}
				else
				{
					variableA = float.NaN;
					residual1 = float.NaN;
					variableB = float.NaN;
					residual2 = float.NaN;
				}

				return status;
			}
			else
			{
				variableA = float.NaN;
				residual1 = float.NaN;
				variableB = float.NaN;
				residual2 = float.NaN;

				return SolvingStatus.UNKNOWN;
			}
		}
		#endregion Static Methods
	}
}
