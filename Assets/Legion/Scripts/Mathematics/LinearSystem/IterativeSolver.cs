namespace Legion.Mathematics.LinearSystem
{
	using System.Runtime.CompilerServices;
	using Unity.Collections;
	using Unity.Mathematics;

	/// <summary>
	/// Parameters used to check if the convergence during iterative solving is reached.
	/// </summary>
	public struct ConvergenceCondition
	{
		#region Fields
		public int MaxIterationNb;
		public double MaxResidual;
		#endregion Fields

		#region Methods
		/// <summary>
		/// Check if the convergence during iterative solving is reached.
		/// </summary>
		/// <param name="iterationNb">Current iterative number</param>
		/// <param name="residuals">Current absolute errors</param>
		/// <returns>Is convergence reached/returns>
		public bool IsConvergenceReached(int iterationNb, in NativeArray<float> residuals)
		{
			if (iterationNb >= MaxIterationNb)
			{
				return true;
			}

			foreach (float residual in residuals)
			{
				if (math.abs(residual) > MaxResidual)
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Check if the convergence during iterative solving is reached.
		/// </summary>
		/// <param name="iterationNb">Current iterative number</param>
		/// <param name="residuals">Current absolute errors</param>
		/// <returns>Is convergence reached/returns>
		public bool IsConvergenceReached(int iterationNb, in NativeArray<double> residuals)
		{
			if (iterationNb >= MaxIterationNb)
			{
				return true;
			}

			foreach (float residual in residuals)
			{
				if (math.abs(residual) > MaxResidual)
				{
					return false;
				}
			}

			return true;
		}
		#endregion Methods
	}

	public struct IterativeSolver
	{
		#region Static Methods
		/// <summary>
		/// Solve a dimension X linear system with Jacobi method :
		/// | a00 * variableA + a01 * variableB + ... = result1
		/// | ...
		/// | ...
		/// | aX0 * variableXA + aX1 * variableXB + ... = resultX 
		/// </summary>
		/// <param name="dimension">Dimension of the coefficient matrix</param>
		/// <param name="coefficients">Coefficient matrix values (dimension * dimension size)</param>
		/// <param name="results">Equations values  (dimension size)</param>
		/// <param name="variables">Variable matrix values (dimension size)</param>
		/// <param name="residuals">Absolute errors of the equations (dimension size)</param>
		/// <param name="buffer">Temporary values array (dimension size)</param>
		/// <param name="inverseDiagonalCoefficients">Inverse of the diagonal coefficients (dimension size)</param>
		/// <param name="convergenceCondition">Convergence condition</param>
		/// <param name="epsilon">Null value range (>= 0)</param>
		/// <returns>Solving status</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SolvingStatus SolveWithJacobi(int dimension, in NativeArray<float> coefficients,
			in NativeArray<float> results, ref NativeArray<float> variables, ref NativeArray<float> residuals,
			ref NativeArray<float> buffer, ref NativeArray<float> inverseDiagonalCoefficients,
			ConvergenceCondition convergenceCondition, float epsilon = 0.0f)
		{
			if (Utilities.CheckIsDiagonallyDominant(dimension, in coefficients))
			{
				int index = 0;
				for (int i = 0; i < dimension; i++)
				{
					float coefficient = coefficients[index];
					if (math.abs(coefficient) > epsilon)
					{
						inverseDiagonalCoefficients[i] = 1.0f / coefficient;
						index += dimension + 1;
					}
					else
					{
						return SolvingStatus.INCOMPATIBLE;
					}
				}

				int iterationNb = 0;
				bool isConvergenceReached = false;
				while (isConvergenceReached == false)
				{
					for (int i = 0; i < dimension; i++)
					{
						float sigma = 0.0f;
						for (int j = 0; j < dimension; j++)
						{
							if (j != i)
							{
								sigma += coefficients[i * dimension + j] * variables[j];
							}
						}

						buffer[i] = inverseDiagonalCoefficients[i] * (results[i] - sigma);
					}

					for (int i = 0; i < dimension; i++)
					{
						residuals[i] = 0.0f;
						for (int j = 0; j < dimension; j++)
						{
							residuals[i] += coefficients[i * dimension + j] * buffer[j];
						}
						residuals[i] -= results[i];
						variables[i] = buffer[i];
					}

					iterationNb++;
					isConvergenceReached = convergenceCondition.IsConvergenceReached(iterationNb, in residuals);
				}

				return SolvingStatus.VALID;
			}
			else
			{
				return SolvingStatus.INCOMPATIBLE;
			}
		}

		/// <summary>
		/// Solve a dimension X linear system with Gauss-Seidel method :
		/// | a00 * variableA + a01 * variableB + ... = result1
		/// | ...
		/// | ...
		/// | aX0 * variableXA + aX1 * variableXB + ... = resultX 
		/// </summary>
		/// <param name="dimension">Dimension of the coefficient matrix</param>
		/// <param name="coefficients">Coefficient matrix values (dimension * dimension size)</param>
		/// <param name="results">Equations values  (dimension size)</param>
		/// <param name="variables">Variable matrix values (dimension size)</param>
		/// <param name="residuals">Absolute errors of the equations (dimension size)</param>
		/// <param name="inverseDiagonalCoefficients">Inverse of the diagonal coefficients (dimension size)</param>
		/// <param name="convergenceCondition">Convergence condition</param>
		/// <param name="epsilon">Null value range (>= 0)</param>
		/// <returns>Solving status</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SolvingStatus SolveWithGaussSeidel(int dimension, in NativeArray<float> coefficients,
			in NativeArray<float> results, ref NativeArray<float> variables, ref NativeArray<float> residuals,
			ref NativeArray<float> inverseDiagonalCoefficients, ConvergenceCondition convergenceCondition,
			float epsilon = 0.0f)
		{
			if (Utilities.CheckIsDiagonallyDominant(dimension, in coefficients))
			{
				int index = 0;
				for (int i = 0; i < dimension; i++)
				{
					float coefficient = coefficients[index];
					if (math.abs(coefficient) > epsilon)
					{
						inverseDiagonalCoefficients[i] = 1.0f / coefficient;
						index += dimension + 1;
					}
					else
					{
						return SolvingStatus.INCOMPATIBLE;
					}
				}

				int iterationNb = 0;
				bool isConvergenceReached = false;
				while (isConvergenceReached == false)
				{
					for (int i = 0; i < dimension; i++)
					{
						float sigma = 0.0f;
						for (int j = 0; j < dimension; j++)
						{
							if (i != j)
							{
								sigma += coefficients[i * dimension + j] * variables[j];
							}
						}

						variables[i] = (results[i] - sigma) * inverseDiagonalCoefficients[i];
					}

					for (int i = 0; i < dimension; i++)
					{
						residuals[i] = 0.0f;
						for (int j = 0; j < dimension; j++)
						{
							residuals[i] += coefficients[i * dimension + j] * variables[j];
						}
						residuals[i] -= results[i];
					}

					iterationNb++;
					isConvergenceReached = convergenceCondition.IsConvergenceReached(iterationNb, in residuals);
				}

				return SolvingStatus.VALID;
			}
			else
			{
				return SolvingStatus.INCOMPATIBLE;
			}
		}
		#endregion Static Methods
	}
}
