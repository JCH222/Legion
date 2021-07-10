namespace Legion.Mathematics
{
	public enum SolvingStatus
	{
		// Unique solution
		VALID = 0,

		// No solutions
		INCOMPATIBLE = -1,

		// More than one solution
		INDETERMINATE = -2,

		// No solutions or more than one solution
		UNKNOWN = -3
	}
}
