namespace Legion.Test
{
	using NUnit.Framework;
	using System.IO;
	using Unity.Collections;
	using Unity.Mathematics;

	public partial class Utilities
	{
		private static readonly float duration = 60.0f;
		private static readonly float timeStep = 0.02f;
		private static readonly float mass = 500.0f;
		private static readonly float neutralLength = 2.0f;
		private static readonly float stiffness = 1000.0f;
		private static readonly float dampingCoefficient = 200.0f;
		private static readonly string dataExportHeaderLine = "Time (s);Length (m);Speed (m/s)";
		private static readonly string dataExportFolderPath = UnityEngine.Application.persistentDataPath + "/Test/Suspension/Utilities/";
		private static readonly string exportFileFormat = ".csv";

		public struct SuspensionTestArgs
		{
			public Physics.Suspension.SolvingType SolvingType;
			public string ExportFileSuffix;
		}

		public static readonly SuspensionTestArgs[] argsArray = new SuspensionTestArgs[]
		{
			new SuspensionTestArgs()
			{
				SolvingType = Physics.Suspension.SolvingType.EXPLICIT_EULER,
				ExportFileSuffix = "ExplicitEuler"
			},
			new SuspensionTestArgs()
			{
				SolvingType = Physics.Suspension.SolvingType.EXPLICIT_RUNGE_KUTTA_2,
				ExportFileSuffix = "ExplicitRungeKutta2"
			}

			// TODO : Add RK4 and Verlet1
		};

		[Test]
		public void TestSimulateImpulseResponse([ValueSource("argsArray")] SuspensionTestArgs args)
		{
			string springExplicitEulerFilePath = dataExportFolderPath + "ImpulseResponse/Spring" + args.ExportFileSuffix + exportFileFormat;
			StreamWriter springFileWriter = new StreamWriter(springExplicitEulerFilePath, false);
			springFileWriter.WriteLine(dataExportHeaderLine);

			string damperExplicitEulerFilePath = dataExportFolderPath + "ImpulseResponse/Damper" + args.ExportFileSuffix + exportFileFormat;
			StreamWriter damperFileWriter = new StreamWriter(damperExplicitEulerFilePath, false);
			damperFileWriter.WriteLine(dataExportHeaderLine);

			string springDamperExplicitEulerFilePath = dataExportFolderPath + "ImpulseResponse/SpringDamper" + args.ExportFileSuffix + exportFileFormat;
			StreamWriter springDamperFileWriter = new StreamWriter(springDamperExplicitEulerFilePath, false);
			springDamperFileWriter.WriteLine(dataExportHeaderLine);

			NativeArray<float3> behaviour = new NativeArray<float3>((int)(duration / timeStep) + 1, Allocator.Persistent);
			// Arbitrary value
			float initialImpulse = mass * (0.03f / timeStep);
			float inverseMass = 1.0f / mass;
			Physics.Suspension.Parts.Spring spring = new Physics.Suspension.Parts.Spring()
			{
				NeutralLength = neutralLength,
				Stiffness = stiffness
			};
			Physics.Suspension.Parts.Damper damper = new Physics.Suspension.Parts.Damper()
			{
				DampingCoefficient = dampingCoefficient
			};

			// Spring with explicit Euler method
			Physics.Suspension.Utilities.SimulateImpulseResponse(in spring, inverseMass, timeStep, initialImpulse, args.SolvingType, ref behaviour);
			foreach (float3 snapshot in behaviour)
			{
				springFileWriter.WriteLine(string.Format("{0};{1};{2}", snapshot.x, snapshot.y, snapshot.z));
			}
			springFileWriter.Close();
			UnityEngine.Debug.Log(string.Format("Result exported : {0}", springExplicitEulerFilePath));
			UnityEngine.Debug.LogWarning(string.Format("Assert method is missing, check result file : {0}", springExplicitEulerFilePath));

			// Damper with explicit Euler method
			Physics.Suspension.Utilities.SimulateImpulseResponse(in damper, neutralLength, inverseMass, timeStep, initialImpulse, args.SolvingType, ref behaviour);
			foreach (float3 snapshot in behaviour)
			{
				damperFileWriter.WriteLine(string.Format("{0};{1};{2}", snapshot.x, snapshot.y, snapshot.z));
			}
			damperFileWriter.Close();
			UnityEngine.Debug.Log(string.Format("Result exported : {0}", damperExplicitEulerFilePath));
			UnityEngine.Debug.LogWarning(string.Format("Assert method is missing, check result file : {0}", damperExplicitEulerFilePath));

			// Spring-Damper with explicit Euler method
			Physics.Suspension.Utilities.SimulateImpulseResponse(in spring, in damper, inverseMass, timeStep, initialImpulse, args.SolvingType, ref behaviour);
			foreach (float3 snapshot in behaviour)
			{
				springDamperFileWriter.WriteLine(string.Format("{0};{1};{2}", snapshot.x, snapshot.y, snapshot.z));
			}
			springDamperFileWriter.Close();
			UnityEngine.Debug.Log(string.Format("Result exported : {0}", springDamperExplicitEulerFilePath));
			UnityEngine.Debug.LogWarning(string.Format("Assert method is missing, check result file : {0}", springDamperExplicitEulerFilePath));

			behaviour.Dispose();
		}
	}
}
