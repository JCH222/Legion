namespace Legion.Mathematics
{
	using System.Runtime.CompilerServices;

	public struct Determinant
	{
		#region Static Methods
		/// <summary>
		/// Compute a 1x1 determinant : | a00 |
		/// </summary>
		/// <param name="a00">>Coefficient (row 0 / column 0)</param>
		/// <returns>Determinant value</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Compute(float a00)
		{
			return a00;
		}

		/// <summary>
		/// Compute a 1x1 determinant : | a00 |
		/// </summary>
		/// <param name="a00">>Coefficient (row 0 / column 0)</param>
		/// <returns>Determinant value</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Compute(double a00)
		{
			return a00;
		}

		/// <summary>
		/// Compute a 2x2 determinant :
		/// | a00 a01 |
		/// | a10 a11 |
		/// </summary>
		/// <param name="a00">Coefficient (row 0 / column 0)</param>
		/// <param name="a01">Coefficient (row 0 / column 1)</param>
		/// <param name="a10">Coefficient (row 1 / column 0)</param>
		/// <param name="a11">Coefficient (row 1 / column 1)</param>
		/// <returns>Determinant value</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Compute(float a00, float a01, float a10, float a11)
		{
			return a00 * a11 - a01 * a10;
		}

		/// <summary>
		/// Compute a 2x2 determinant :
		/// | a00 a01 |
		/// | a10 a11 |
		/// </summary>
		/// <param name="a00">Coefficient (row 0 / column 0)</param>
		/// <param name="a01">Coefficient (row 0 / column 1)</param>
		/// <param name="a10">Coefficient (row 1 / column 0)</param>
		/// <param name="a11">Coefficient (row 1 / column 1)</param>
		/// <returns>Determinant value</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Compute(double a00, double a01, double a10, double a11)
		{
			return a00 * a11 - a01 * a10;
		}

		/// <summary>
		/// Compute a 3x3 determinant :
		/// | a00 a01 a02 |
		/// | a10 a11 a12 |
		/// | a20 a21 a22 |
		/// </summary>
		/// <param name="a00">Coefficient (row 0 / column 0)</param>
		/// <param name="a01">Coefficient (row 0 / column 1)</param>
		/// <param name="a02">Coefficient (row 0 / column 2)</param>
		/// <param name="a10">Coefficient (row 1 / column 0)</param>
		/// <param name="a11">Coefficient (row 1 / column 1)</param>
		/// <param name="a12">Coefficient (row 1 / column 2)</param>
		/// <param name="a20">Coefficient (row 2 / column 0)</param>
		/// <param name="a21">Coefficient (row 2 / column 1)</param>
		/// <param name="a22">Coefficient (row 2 / column 2)</param>
		/// <returns>Determinant value</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Compute(
			float a00, float a01, float a02,
			float a10, float a11, float a12,
			float a20, float a21, float a22)
		{
			return a00 * Compute(a11, a12, a21, a22)
				- a01 * Compute(a10, a12, a20, a22)
				+ a02 * Compute(a10, a11, a20, a21);
		}

		/// <summary>
		/// Compute a 3x3 determinant :
		/// | a00 a01 a02 |
		/// | a10 a11 a12 |
		/// | a20 a21 a22 |
		/// </summary>
		/// <param name="a00">Coefficient (row 0 / column 0)</param>
		/// <param name="a01">Coefficient (row 0 / column 1)</param>
		/// <param name="a02">Coefficient (row 0 / column 2)</param>
		/// <param name="a10">Coefficient (row 1 / column 0)</param>
		/// <param name="a11">Coefficient (row 1 / column 1)</param>
		/// <param name="a12">Coefficient (row 1 / column 2)</param>
		/// <param name="a20">Coefficient (row 2 / column 0)</param>
		/// <param name="a21">Coefficient (row 2 / column 1)</param>
		/// <param name="a22">Coefficient (row 2 / column 2)</param>
		/// <returns>Determinant value</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Compute(
			double a00, double a01, double a02,
			double a10, double a11, double a12,
			double a20, double a21, double a22)
		{
			return a00 * Compute(a11, a12, a21, a22)
				- a01 * Compute(a10, a12, a20, a22)
				+ a02 * Compute(a10, a11, a20, a21);
		}

		/// <summary>
		/// Compute a 4x4 determinant :
		/// | a00 a01 a02 a03 |
		/// | a10 a11 a12 a13 |
		/// | a20 a21 a22 a23 |
		/// | a30 a31 a32 a33 |
		/// </summary>
		/// <param name="a00">Coefficient (row 0 / column 0)</param>
		/// <param name="a01">Coefficient (row 0 / column 1)</param>
		/// <param name="a02">Coefficient (row 0 / column 2)</param>
		/// <param name="a03">Coefficient (row 0 / column 3)</param>
		/// <param name="a10">Coefficient (row 1 / column 0)</param>
		/// <param name="a11">Coefficient (row 1 / column 1)</param>
		/// <param name="a12">Coefficient (row 1 / column 2)</param>
		/// <param name="a13">Coefficient (row 1 / column 3)</param>
		/// <param name="a20">Coefficient (row 2 / column 0)</param>
		/// <param name="a21">Coefficient (row 2 / column 1)</param>
		/// <param name="a22">Coefficient (row 2 / column 2)</param>
		/// <param name="a23">Coefficient (row 2 / column 3)</param>
		/// <param name="a30">Coefficient (row 3 / column 0)</param>
		/// <param name="a31">Coefficient (row 3 / column 1)</param>
		/// <param name="a32">Coefficient (row 3 / column 2)</param>
		/// <param name="a33">Coefficient (row 3 / column 3)</param>
		/// <returns>Determinant value</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Compute(
			float a00, float a01, float a02, float a03,
			float a10, float a11, float a12, float a13,
			float a20, float a21, float a22, float a23,
			float a30, float a31, float a32, float a33)
		{
			return a00 * Compute(a11, a12, a13, a21, a22, a23, a31, a32, a33)
				- a01 * Compute(a10, a12, a13, a20, a22, a23, a30, a32, a33)
				+ a02 * Compute(a10, a11, a13, a20, a21, a23, a30, a31, a33)
				- a03 * Compute(a10, a11, a12, a20, a21, a22, a30, a31, a32);
		}

		/// <summary>
		/// Compute a 4x4 determinant :
		/// | a00 a01 a02 a03 |
		/// | a10 a11 a12 a13 |
		/// | a20 a21 a22 a23 |
		/// | a30 a31 a32 a33 |
		/// </summary>
		/// <param name="a00">Coefficient (row 0 / column 0)</param>
		/// <param name="a01">Coefficient (row 0 / column 1)</param>
		/// <param name="a02">Coefficient (row 0 / column 2)</param>
		/// <param name="a03">Coefficient (row 0 / column 3)</param>
		/// <param name="a10">Coefficient (row 1 / column 0)</param>
		/// <param name="a11">Coefficient (row 1 / column 1)</param>
		/// <param name="a12">Coefficient (row 1 / column 2)</param>
		/// <param name="a13">Coefficient (row 1 / column 3)</param>
		/// <param name="a20">Coefficient (row 2 / column 0)</param>
		/// <param name="a21">Coefficient (row 2 / column 1)</param>
		/// <param name="a22">Coefficient (row 2 / column 2)</param>
		/// <param name="a23">Coefficient (row 2 / column 3)</param>
		/// <param name="a30">Coefficient (row 3 / column 0)</param>
		/// <param name="a31">Coefficient (row 3 / column 1)</param>
		/// <param name="a32">Coefficient (row 3 / column 2)</param>
		/// <param name="a33">Coefficient (row 3 / column 3)</param>
		/// <returns>Determinant value</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Compute(
			double a00, double a01, double a02, double a03,
			double a10, double a11, double a12, double a13,
			double a20, double a21, double a22, double a23,
			double a30, double a31, double a32, double a33)
		{
			return a00 * Compute(a11, a12, a13, a21, a22, a23, a31, a32, a33)
				- a01 * Compute(a10, a12, a13, a20, a22, a23, a30, a32, a33)
				+ a02 * Compute(a10, a11, a13, a20, a21, a23, a30, a31, a33)
				- a03 * Compute(a10, a11, a12, a20, a21, a22, a30, a31, a32);
		}
		#endregion Static Methods
	}
}
