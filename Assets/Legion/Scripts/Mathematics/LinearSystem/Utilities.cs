namespace Legion.Mathematics.LinearSystem
{
	using System.Runtime.CompilerServices;
	using Unity.Collections;
	using Unity.Mathematics;

	public struct Utilities
	{
		#region Static Methods
		/// <summary>
		/// Check if a linear system 1 is solvable :
		/// | a00 * VariableA = result0
		/// </summary>
		/// <param name="a00">Coefficients matrix value (row 0 / column 0)</param>
		/// <param name="result0">First equation value</param>>
		/// <param name="denominator">Denominator determinant</param>
		/// <param name="numeratorA">Variable A numerator determinant</param>
		/// <param name="epsilon">Null value range (>= 0)</param>
		/// <returns>Solving status</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SolvingStatus CheckIsSolvable(
			float a00, float result0, out float denominator, 
			out float numeratorA, float epsilon = 0.0f)
		{
			denominator = Determinant.Compute(a00);
			numeratorA = Determinant.Compute(result0);

			if (math.abs(denominator) > epsilon)
			{
				return SolvingStatus.VALID;
			}
			else if (math.abs(numeratorA) > epsilon)
			{
				return SolvingStatus.INCOMPATIBLE;
			}
			else
			{
				return SolvingStatus.INDETERMINATE;
			}
		}

		/// <summary>
		/// Check if a linear system 1 is solvable :
		/// | a00 * VariableA = result0
		/// </summary>
		/// <param name="a00">Coefficients matrix value (row 0 / column 0)</param>
		/// <param name="result0">First equation value</param>>
		/// <param name="denominator">Denominator determinant</param>
		/// <param name="numeratorA">Variable A numerator determinant</param>
		/// <param name="epsilon">Null value range (>= 0)</param>
		/// <returns>Solving status</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SolvingStatus CheckIsSolvable(
			double a00, double result0, out double denominator,
			out double numeratorA, double epsilon = 0.0d)
		{
			denominator = Determinant.Compute(a00);
			numeratorA = Determinant.Compute(result0);

			if (math.abs(denominator) > epsilon)
			{
				return SolvingStatus.VALID;
			}
			else if (math.abs(numeratorA) > epsilon)
			{
				return SolvingStatus.INCOMPATIBLE;
			}
			else
			{
				return SolvingStatus.INDETERMINATE;
			}
		}

		/// <summary>
		/// Check if a linear system 2 is solvable :
		/// | a00 * VariableA + a01 * VariableB = result0
		/// | a10 * VariableA + a11 * VariableB = result1
		/// </summary>
		/// <param name="a00">Coefficients matrix value (row 0 / column 0)</param>
		/// <param name="a01">Coefficients matrix value (row 0 / column 1)</param>
		/// <param name="result0">First equation value</param>
		/// <param name="a10">Coefficients matrix value (row 1 / column 0)</param>
		/// <param name="a11">Coefficients matrix value (row 1 / column 1)</param>
		/// <param name="result1">Second equation value</param>
		/// <param name="denominator">Denominator determinant</param>
		/// <param name="numeratorA">Variable A numerator determinant</param>
		/// <param name="numeratorB">Variable B numerator determinant</param>
		/// <param name="epsilon">Null value range (>= 0)</param>
		/// <returns>Solving status</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SolvingStatus CheckIsSolvable(
			float a00, float a01, float result0,
			float a10, float a11, float result1,
			out float denominator, out float numeratorA, 
			out float numeratorB, float epsilon = 0.0f)
		{
			denominator = Determinant.Compute(a00, a01, a10, a11);
			numeratorA = Determinant.Compute(result0, a01, result1, a11);
			numeratorB = Determinant.Compute(a00, result0, a10, result1);

			if (math.abs(denominator) > epsilon)
			{
				return SolvingStatus.VALID;
			}
			else if (math.abs(numeratorA) > epsilon || math.abs(numeratorB) > epsilon)
			{
				return SolvingStatus.INCOMPATIBLE;
			}
			else
			{
				return SolvingStatus.INDETERMINATE;
			}
		}

		/// <summary>
		/// Check if a linear system 2 is solvable :
		/// | a00 * VariableA + a01 * VariableB = result0
		/// | a10 * VariableA + a11 * VariableB = result1
		/// </summary>
		/// <param name="a00">Coefficients matrix value (row 0 / column 0)</param>
		/// <param name="a01">Coefficients matrix value (row 0 / column 1)</param>
		/// <param name="result0">First equation value</param>
		/// <param name="a10">Coefficients matrix value (row 1 / column 0)</param>
		/// <param name="a11">Coefficients matrix value (row 1 / column 1)</param>
		/// <param name="result1">Second equation value</param>
		/// <param name="denominator">Denominator determinant</param>
		/// <param name="numeratorA">Variable A numerator determinant</param>
		/// <param name="numeratorB">Variable B numerator determinant</param>
		/// <param name="epsilon">Null value range (>= 0)</param>
		/// <returns>Solving status</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SolvingStatus CheckIsSolvable(
			double a00, double a01, double result0,
			double a10, double a11, double result1,
			out double denominator, out double numeratorA,
			out double numeratorB, double epsilon = 0.0d)
		{
			denominator = Determinant.Compute(a00, a01, a10, a11);
			numeratorA = Determinant.Compute(result0, a01, result1, a11);
			numeratorB = Determinant.Compute(a00, result0, a10, result1);

			if (math.abs(denominator) > epsilon)
			{
				return SolvingStatus.VALID;
			}
			else if (math.abs(numeratorA) > epsilon || math.abs(numeratorB) > epsilon)
			{
				return SolvingStatus.INCOMPATIBLE;
			}
			else
			{
				return SolvingStatus.INDETERMINATE;
			}
		}

		/// <summary>
		/// Check if a linear system 3 is solvable :
		/// | a00 * VariableA + a01 * VariableB + a02 * VariableC = result0
		/// | a10 * VariableA + a11 * VariableB + a12 * VariableC = result1
		/// | a20 * VariableA + a21 * VariableB + a22 * VariableC = result2
		/// </summary>
		/// <param name="a00">Coefficients matrix value (row 0 / column 0)</param>
		/// <param name="a01">Coefficients matrix value (row 0 / column 1)</param>
		/// <param name="a02">Coefficients matrix value (row 0 / column 2)</param>
		/// <param name="result0">First equation value</param>
		/// <param name="a10">Coefficients matrix value (row 1 / column 0)</param>
		/// <param name="a11">Coefficients matrix value (row 1 / column 1)</param>
		/// <param name="a12">Coefficients matrix value (row 1 / column 2)</param>
		/// <param name="result1">Second equation value</param>
		/// <param name="a20">Coefficients matrix value (row 2 / column 0)</param>
		/// <param name="a21">Coefficients matrix value (row 2 / column 1)</param>
		/// <param name="a22">Coefficients matrix value (row 2 / column 2)</param>
		/// <param name="result2">Third equation value</param>
		/// <param name="denominator">Denominator determinant</param>
		/// <param name="numeratorA">Variable A numerator determinant</param>
		/// <param name="numeratorB">Variable B numerator determinant</param>
		/// <param name="numeratorC">Variable C numerator determinant</param>
		/// <param name="epsilon">Null value range (>= 0)</param>
		/// <returns>Solving status</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SolvingStatus CheckIsSolvable(
			float a00, float a01, float a02, float result0,
			float a10, float a11, float a12, float result1,
			float a20, float a21, float a22, float result2,
			out float denominator, out float numeratorA,
			out float numeratorB, out float numeratorC,
			float epsilon = 0.0f)
		{
			denominator = Determinant.Compute(a00, a01, a02, a10, a11, a12, a20, a21, a22);
			numeratorA = Determinant.Compute(result0, a01, a02, result1, a11, a12, result2, a21, a22);
			numeratorB = Determinant.Compute(a00, result0, a02, a10, result1, a12, a20, result2, a22);
			numeratorC = Determinant.Compute(a00, a01, result0, a10, a11, result1, a20, a21, result2);

			if (math.abs(denominator) > epsilon)
			{
				return SolvingStatus.VALID;
			}
			else if (math.abs(numeratorA) > epsilon || math.abs(numeratorB) > epsilon
				|| math.abs(numeratorC) > epsilon)
			{
				return SolvingStatus.INCOMPATIBLE;
			}
			else
			{
				return SolvingStatus.UNKNOWN;
			}
		}

		/// <summary>
		/// Check if a linear system 3 is solvable :
		/// | a00 * VariableA + a01 * VariableB + a02 * VariableC = result0
		/// | a10 * VariableA + a11 * VariableB + a12 * VariableC = result1
		/// | a20 * VariableA + a21 * VariableB + a22 * VariableC = result2
		/// </summary>
		/// <param name="a00">Coefficients matrix value (row 0 / column 0)</param>
		/// <param name="a01">Coefficients matrix value (row 0 / column 1)</param>
		/// <param name="a02">Coefficients matrix value (row 0 / column 2)</param>
		/// <param name="result0">First equation value</param>
		/// <param name="a10">Coefficients matrix value (row 1 / column 0)</param>
		/// <param name="a11">Coefficients matrix value (row 1 / column 1)</param>
		/// <param name="a12">Coefficients matrix value (row 1 / column 2)</param>
		/// <param name="result1">Second equation value</param>
		/// <param name="a20">Coefficients matrix value (row 2 / column 0)</param>
		/// <param name="a21">Coefficients matrix value (row 2 / column 1)</param>
		/// <param name="a22">Coefficients matrix value (row 2 / column 2)</param>
		/// <param name="result2">Third equation value</param>
		/// <param name="denominator">Denominator determinant</param>
		/// <param name="numeratorA">Variable A numerator determinant</param>
		/// <param name="numeratorB">Variable B numerator determinant</param>
		/// <param name="numeratorC">Variable C numerator determinant</param>
		/// <param name="epsilon">Null value range (>= 0)</param>
		/// <returns>Solving status</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SolvingStatus CheckIsSolvable(
			double a00, double a01, double a02, double result0,
			double a10, double a11, double a12, double result1,
			double a20, double a21, double a22, double result2,
			out double denominator, out double numeratorA,
			out double numeratorB, out double numeratorC,
			double epsilon = 0.0d)
		{
			denominator = Determinant.Compute(a00, a01, a02, a10, a11, a12, a20, a21, a22);
			numeratorA = Determinant.Compute(result0, a01, a02, result1, a11, a12, result2, a21, a22);
			numeratorB = Determinant.Compute(a00, result0, a02, a10, result1, a12, a20, result2, a22);
			numeratorC = Determinant.Compute(a00, a01, result0, a10, a11, result1, a20, a21, result2);

			if (math.abs(denominator) > epsilon)
			{
				return SolvingStatus.VALID;
			}
			else if (math.abs(numeratorA) > epsilon || math.abs(numeratorB) > epsilon 
				|| math.abs(numeratorC) > epsilon)
			{
				return SolvingStatus.INCOMPATIBLE;
			}
			else
			{
				return SolvingStatus.UNKNOWN;
			}
		}

		/// <summary>
		/// Check if a linear system 4 is solvable :
		/// | a00 * VariableA + a01 * VariableB + a02 * VariableC + a03 * VariableD = result0
		/// | a10 * VariableA + a11 * VariableB + a12 * VariableC + a13 * VariableD = result1
		/// | a20 * VariableA + a21 * VariableB + a22 * VariableC + a23 * VariableD = result2
		/// | a30 * VariableA + a31 * VariableB + a32 * VariableC + a33 * VariableD = result3
		/// </summary>
		/// <param name="a00">Coefficients matrix value (row 0 / column 0)</param>
		/// <param name="a01">Coefficients matrix value (row 0 / column 1)</param>
		/// <param name="a02">Coefficients matrix value (row 0 / column 2)</param>
		/// <param name="a03">Coefficients matrix value (row 0 / column 3)</param>
		/// <param name="result0">First equation value</param>
		/// <param name="a10">Coefficients matrix value (row 1 / column 0)</param>
		/// <param name="a11">Coefficients matrix value (row 1 / column 1)</param>
		/// <param name="a12">Coefficients matrix value (row 1 / column 2)</param>
		/// <param name="a13">Coefficients matrix value (row 1 / column 3)</param>
		/// <param name="result1">Second equation value</param>
		/// <param name="a20">Coefficients matrix value (row 2 / column 0)</param>
		/// <param name="a21">Coefficients matrix value (row 2 / column 1)</param>
		/// <param name="a22">Coefficients matrix value (row 2 / column 2)</param>
		/// <param name="a23">Coefficients matrix value (row 2 / column 3)</param>
		/// <param name="result2">Third equation value</param>
		/// <param name="a30">Coefficients matrix value (row 3 / column 0)</param>
		/// <param name="a31">Coefficients matrix value (row 3 / column 1)</param>
		/// <param name="a32">Coefficients matrix value (row 3 / column 2)</param>
		/// <param name="a33">Coefficients matrix value (row 3 / column 3)</param>
		/// <param name="result3">Fourth equation value</param>
		/// <param name="denominator">Denominator determinant</param>
		/// <param name="numeratorA">Variable A numerator determinant</param>
		/// <param name="numeratorB">Variable B numerator determinant</param>
		/// <param name="numeratorC">Variable C numerator determinant</param>
		/// <param name="numeratorD">Variable D numerator determinant</param>
		/// <param name="epsilon">Null value range (>= 0)</param>
		/// <returns>Solving status</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SolvingStatus CheckIsSolvable(
			float a00, float a01, float a02, float a03, float result0,
			float a10, float a11, float a12, float a13, float result1,
			float a20, float a21, float a22, float a23, float result2,
			float a30, float a31, float a32, float a33, float result3,
			out float denominator, out float numeratorA,
			out float numeratorB, out float numeratorC,
			out float numeratorD, float epsilon = 0.0f)
		{
			denominator = Determinant.Compute(a00, a01, a02, a03, a10, a11, a12, a13, a20, a21, a22, a23, a30, a31, a32, a33);
			numeratorA = Determinant.Compute(result0, a01, a02, a03, result1, a11, a12, a13, result2, a21, a22, a23, result3, a31, a32, a33);
			numeratorB = Determinant.Compute(a00, result0, a02, a03, a10, result1, a12, a13, a20, result2, a22, a23, a30, result3, a32, a33);
			numeratorC = Determinant.Compute(a00, a01, result0, a03, a10, a11, result1, a13, a20, a21, result2, a23, a30, a31, result3, a33);
			numeratorD = Determinant.Compute(a00, a01, a02, result0, a10, a11, a12, result1, a20, a21, a22, result2, a30, a31, a32, result3);

			if (math.abs(denominator) > epsilon)
			{
				return SolvingStatus.VALID;
			}
			else if (math.abs(numeratorA) > epsilon || math.abs(numeratorB) > epsilon
				|| math.abs(numeratorC) > epsilon || math.abs(numeratorD) > epsilon)
			{
				return SolvingStatus.INCOMPATIBLE;
			}
			else
			{
				return SolvingStatus.UNKNOWN;
			}
		}

		/// <summary>
		/// Check if a linear system 4 is solvable :
		/// | a00 * VariableA + a01 * VariableB + a02 * VariableC + a03 * VariableD = result0
		/// | a10 * VariableA + a11 * VariableB + a12 * VariableC + a13 * VariableD = result1
		/// | a20 * VariableA + a21 * VariableB + a22 * VariableC + a23 * VariableD = result2
		/// | a30 * VariableA + a31 * VariableB + a32 * VariableC + a33 * VariableD = result3
		/// </summary>
		/// <param name="a00">Coefficients matrix value (row 0 / column 0)</param>
		/// <param name="a01">Coefficients matrix value (row 0 / column 1)</param>
		/// <param name="a02">Coefficients matrix value (row 0 / column 2)</param>
		/// <param name="a03">Coefficients matrix value (row 0 / column 3)</param>
		/// <param name="result0">First equation value</param>
		/// <param name="a10">Coefficients matrix value (row 1 / column 0)</param>
		/// <param name="a11">Coefficients matrix value (row 1 / column 1)</param>
		/// <param name="a12">Coefficients matrix value (row 1 / column 2)</param>
		/// <param name="a13">Coefficients matrix value (row 1 / column 3)</param>
		/// <param name="result1">Second equation value</param>
		/// <param name="a20">Coefficients matrix value (row 2 / column 0)</param>
		/// <param name="a21">Coefficients matrix value (row 2 / column 1)</param>
		/// <param name="a22">Coefficients matrix value (row 2 / column 2)</param>
		/// <param name="a23">Coefficients matrix value (row 2 / column 3)</param>
		/// <param name="result2">Third equation value</param>
		/// <param name="a30">Coefficients matrix value (row 3 / column 0)</param>
		/// <param name="a31">Coefficients matrix value (row 3 / column 1)</param>
		/// <param name="a32">Coefficients matrix value (row 3 / column 2)</param>
		/// <param name="a33">Coefficients matrix value (row 3 / column 3)</param>
		/// <param name="result3">Fourth equation value</param>
		/// <param name="denominator">Denominator determinant</param>
		/// <param name="numeratorA">Variable A numerator determinant</param>
		/// <param name="numeratorB">Variable B numerator determinant</param>
		/// <param name="numeratorC">Variable C numerator determinant</param>
		/// <param name="numeratorD">Variable D numerator determinant</param>
		/// <param name="epsilon">Null value range (>= 0)</param>
		/// <returns>Solving status</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SolvingStatus CheckIsSolvable(
			double a00, double a01, double a02, double a03, double result0,
			double a10, double a11, double a12, double a13, double result1,
			double a20, double a21, double a22, double a23, double result2,
			double a30, double a31, double a32, double a33, double result3,
			out double denominator, out double numeratorA,
			out double numeratorB, out double numeratorC,
			out double numeratorD, double epsilon = 0.0d)
		{
			denominator = Determinant.Compute(a00, a01, a02, a03, a10, a11, a12, a13, a20, a21, a22, a23, a30, a31, a32, a33);
			numeratorA = Determinant.Compute(result0, a01, a02, a03, result1, a11, a12, a13, result2, a21, a22, a23, result3, a31, a32, a33);
			numeratorB = Determinant.Compute(a00, result0, a02, a03, a10, result1, a12, a13, a20, result2, a22, a23, a30, result3, a32, a33);
			numeratorC = Determinant.Compute(a00, a01, result0, a03, a10, a11, result1, a13, a20, a21, result2, a23, a30, a31, result3, a33);
			numeratorD = Determinant.Compute(a00, a01, a02, result0, a10, a11, a12, result1, a20, a21, a22, result2, a30, a31, a32, result3);

			if (math.abs(denominator) > epsilon)
			{
				return SolvingStatus.VALID;
			}
			else if (math.abs(numeratorA) > epsilon || math.abs(numeratorB) > epsilon
				|| math.abs(numeratorC) > epsilon || math.abs(numeratorD) > epsilon)
			{
				return SolvingStatus.INCOMPATIBLE;
			}
			else
			{
				return SolvingStatus.UNKNOWN;
			}
		}

		/// <summary>
		/// Check if the square matrix is diagonally dominant.
		/// </summary>
		/// <param name="dimension">Sqare matrix dimension</param>
		/// <param name="coefficients">Coefficients of the sqare matrix (row by row)</param>
		/// <returns>Is the matrix diagonally dominant</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool CheckIsDiagonallyDominant(int dimension, in NativeArray<float> coefficients)
		{
			for (int i = 0; i < dimension; i++)
			{
				float coefficient = float.NaN;
				float sum = 0.0f;

				for (int j = 0; j < dimension; j++)
				{
					if (i != j)
					{
						sum += math.abs(coefficients[i * dimension + j]);
					}
					else
					{
						coefficient = math.abs(coefficients[i * dimension + j]);
					}
				}

				if (coefficient < sum)
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Check if the square matrix is diagonally dominant.
		/// </summary>
		/// <param name="dimension">Sqare matrix dimension</param>
		/// <param name="coefficients">Coefficients of the sqare matrix (row by row)</param>
		/// <returns>Is the matrix diagonally dominant</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool CheckIsDiagonallyDominant(int dimension, in NativeArray<double> coefficients)
		{
			for (int i = 0; i < dimension; i++)
			{
				double coefficient = double.NaN;
				double sum = 0.0f;

				for (int j = 0; j < dimension; j++)
				{
					if (i != j)
					{
						sum += math.abs(coefficients[i * dimension + j]);
					}
					else
					{
						coefficient = math.abs(coefficients[i * dimension + j]);
					}
				}

				if (coefficient < sum)
				{
					return false;
				}
			}

			return true;
		}
		#endregion Static Methods
	}
}
