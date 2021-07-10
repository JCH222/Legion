namespace Legion.Test
{
    using NUnit.Framework;
	using System.IO;
	using Unity.Mathematics;
	using UnityEngine;

	public class Solver
    {
        private static readonly float duration = 60.0f;
        private static readonly float timeStep = Time.fixedDeltaTime;
        private static readonly float dragCoefficient = 100.0f;
        private static readonly float mass = 500.0f;
        private static readonly float gravity = 9.81f;
        private static readonly float length = 9.81f;
        private static readonly string dataExportFolderPath = Application.persistentDataPath + "/Test/DifferentialEquation/Solver/";
        private static readonly string dataExportHeaderLine1 = "Time (s);Speed (m/s)";
        private static readonly string dataExportHeaderLine2 = "Time (s);Position (rad)";

        private float FreeFallAcceleration(float currentSpeed)
		{
            return -(dragCoefficient / mass) * currentSpeed + gravity;
        }

        private float PendulumMovementAcceleration(float currentAngularPosition)
		{
            return -math.sqrt(gravity / length) * math.sin(currentAngularPosition);
		}

        [Test]
        public void TestSolveWithExplicitEuler()
        {
            // Dimension 1
            string filePath = dataExportFolderPath + "Dimension1/ExplicitEuler.csv";
            StreamWriter writer = new StreamWriter(filePath, false);
            writer.WriteLine(dataExportHeaderLine1);
            float currentTime = 0.0f;
            float currentSpeed = 0.0f;
            while (currentTime <= duration)
			{
                writer.WriteLine(string.Format("{0};{1}", currentTime, currentSpeed));

                float currentAcceleration = FreeFallAcceleration(currentSpeed);
                currentSpeed = Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(currentSpeed, currentAcceleration, timeStep);
                currentTime += timeStep;
			}
            writer.Close();
            Debug.Log(string.Format("Result exported : {0}", filePath));

            float finalSpeed = mass * gravity / dragCoefficient;
            Assert.AreEqual(finalSpeed, currentSpeed, 1.0E-3f);

            // Dimension 2
            filePath = dataExportFolderPath + "Dimension2/ExplicitEuler.csv";
            writer = new StreamWriter(filePath, false);
            writer.WriteLine(dataExportHeaderLine2);
            currentTime = 0.0f;
            int iterationNb = 0;
            float currentAngularPosition = 0.5f * math.PI;
            float currentAngularVelocity = 0.0f;
            while (currentTime <= duration)
            {
                writer.WriteLine(string.Format("{0};{1}", currentTime, currentAngularPosition));

                float currentAngularAcceleration = PendulumMovementAcceleration(currentAngularPosition);
                float2 result = Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(
                    new float2(currentAngularPosition, currentAngularVelocity), 
                    new float2(currentAngularVelocity, currentAngularAcceleration), timeStep);
                currentAngularPosition = result.x;
                currentAngularVelocity = result.y;
                currentTime += timeStep;
                iterationNb++;
            }
            writer.Close();
            Debug.Log(string.Format("Result exported : {0}", filePath));
            Debug.LogWarning(string.Format("Assert method is missing, check result file : {0}", filePath));
        }

        [Test]
        public void TestSolveWithExplicitRungeKutta2()
        {
            // Dimension 1
            string filePath = dataExportFolderPath + "Dimension1/RungeKutta2.csv";
            StreamWriter writer = new StreamWriter(filePath, false);
            writer.WriteLine(dataExportHeaderLine1);
            float currentTime = 0.0f;
            float currentSpeed = 0.0f;
            while (currentTime <= duration)
            {
                writer.WriteLine(string.Format("{0};{1}", currentTime, currentSpeed));

                float k1 = FreeFallAcceleration(currentSpeed);
                float k2 = FreeFallAcceleration(Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(currentSpeed, k1, timeStep));
                currentSpeed = Mathematics.DifferentialEquation.Solver.SolveWithExplicitRungeKutta2(currentSpeed, k1, k2, timeStep);
                currentTime += timeStep;
            }
            writer.Close();
            Debug.Log(string.Format("Result exported : {0}", filePath));

            float finalSpeed = mass * gravity / dragCoefficient;
            Assert.AreEqual(finalSpeed, currentSpeed, 1.0E-3f);

            // Dimension 2
            filePath = dataExportFolderPath + "Dimension2/RungeKutta2.csv";
            writer = new StreamWriter(filePath, false);
            writer.WriteLine(dataExportHeaderLine2);
            currentTime = 0.0f;
            int iterationNb = 0;
            float currentAngularPosition = 0.5f * math.PI;
            float currentAngularVelocity = 0.0f;
            while (currentTime <= duration)
            {
                writer.WriteLine(string.Format("{0};{1}", currentTime, currentAngularPosition));

                float2 variable = new float2(currentAngularPosition, currentAngularVelocity);
                float2 k1 = new float2(currentAngularVelocity, PendulumMovementAcceleration(currentAngularPosition));
                float2 tempResult = Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(variable, k1, timeStep);
                float2 k2 = new float2(tempResult.y, PendulumMovementAcceleration(tempResult.x));

                float2 result = Mathematics.DifferentialEquation.Solver.SolveWithExplicitRungeKutta2(variable, k1, k2, timeStep);
                currentAngularPosition = result.x;
                currentAngularVelocity = result.y;
                currentTime += timeStep;
                iterationNb++;
            }
            writer.Close();
            Debug.Log(string.Format("Result exported : {0}", filePath));
            Debug.LogWarning(string.Format("Assert method is missing, check result file : {0}", filePath));
        }

        [Test]
        public void TestSolveWithExplicitRungeKutta4()
		{
            // Dimension 1
            string filePath = dataExportFolderPath + "Dimension1/RungeKutta4.csv";
            StreamWriter writer = new StreamWriter(filePath, false);
            writer.WriteLine(dataExportHeaderLine1);
            float halfTimeStep = 0.5f * timeStep;
            float currentTime = 0.0f;
            float currentSpeed = 0.0f;
            while (currentTime <= duration)
            {
                writer.WriteLine(string.Format("{0};{1}", currentTime, currentSpeed));

                float k1 = FreeFallAcceleration(currentSpeed);
                float k2 = FreeFallAcceleration(Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(currentSpeed, k1, halfTimeStep));
                float k3 = FreeFallAcceleration(Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(currentSpeed, k2, halfTimeStep));
                float k4 = FreeFallAcceleration(Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(currentSpeed, k3, timeStep));
                currentSpeed = Mathematics.DifferentialEquation.Solver.SolveWithExplicitRungeKutta4(currentSpeed, k1, k2, k3, k4, timeStep);
                currentTime += timeStep;
            }
            writer.Close();
            Debug.Log(string.Format("Result exported : {0}", filePath));

            float finalSpeed = mass * gravity / dragCoefficient;
            Assert.AreEqual(finalSpeed, currentSpeed, 1.0E-3f);

            // Dimension 2
            filePath = dataExportFolderPath + "Dimension2/RungeKutta4.csv";
            writer = new StreamWriter(filePath, false);
            writer.WriteLine(dataExportHeaderLine2);
            currentTime = 0.0f;
            int iterationNb = 0;
            float currentAngularPosition = 0.5f * math.PI;
            float currentAngularVelocity = 0.0f;
            while (currentTime <= duration)
            {
                writer.WriteLine(string.Format("{0};{1}", currentTime, currentAngularPosition));

                float2 variable = new float2(currentAngularPosition, currentAngularVelocity);
                float2 k1 = new float2(currentAngularVelocity, PendulumMovementAcceleration(currentAngularPosition));
                float2 tempResultA = Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(variable, k1, halfTimeStep);
                float2 k2 = new float2(tempResultA.y, PendulumMovementAcceleration(tempResultA.x));
                float2 tempResultB = Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(variable, k2, halfTimeStep);
                float2 k3 = new float2(tempResultB.y, PendulumMovementAcceleration(tempResultB.x));
                float2 tempResultC = Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(variable, k3, timeStep);
                float2 k4 = new float2(tempResultC.y, PendulumMovementAcceleration(tempResultC.x));

                float2 result = Mathematics.DifferentialEquation.Solver.SolveWithExplicitRungeKutta4(variable, k1, k2, k3, k4, timeStep);
                currentAngularPosition = result.x;
                currentAngularVelocity = result.y;
                currentTime += timeStep;
                iterationNb++;
            }
            writer.Close();
            Debug.Log(string.Format("Result exported : {0}", filePath));
            Debug.LogWarning(string.Format("Assert method is missing, check result file : {0}", filePath));
        }

        [Test]
        public void TestSolveWithVerlet1()
		{
            string filePath = dataExportFolderPath + "Dimension2/Verlet1.csv";
            StreamWriter writer = new StreamWriter(filePath, false);
            writer.WriteLine(dataExportHeaderLine2);
            float currentTime = 0.0f;
            int iterationNb = 0;
            float currentAngularPosition = 0.5f * math.PI;
            float currentAngularVelocity = 0.0f;
            while (currentTime <= duration)
            {
                writer.WriteLine(string.Format("{0};{1}", currentTime, currentAngularPosition));

                float currentAngularAcceleration = PendulumMovementAcceleration(currentAngularPosition);
                currentAngularPosition = Mathematics.DifferentialEquation.Solver.StartSolvingWithVerlet1(currentAngularPosition, currentAngularVelocity, currentAngularAcceleration, timeStep);
                float nextAngularAcceleration = PendulumMovementAcceleration(currentAngularPosition);
                currentAngularVelocity = Mathematics.DifferentialEquation.Solver.EndSolvingWithVerlet1(currentAngularVelocity, currentAngularAcceleration, nextAngularAcceleration, timeStep);
                currentTime += timeStep;
                iterationNb++;
            }
            writer.Close();
            Debug.Log(string.Format("Result exported : {0}", filePath));
            Debug.LogWarning(string.Format("Assert method is missing, check result file : {0}", filePath));
        }

        [Test]
        public void TestAccuracyDimension1()
        {
            int iterationNb = 0;
            float halfTimeStep = 0.5f * timeStep;
            float currentTime = 0.0f;
			float currentExplicitEulerSpeed = 0.0f;
            float currentRungeKutta2Speed = 0.0f;
            float currentRungeKutta4Speed = 0.0f;
            float ratio = -mass * gravity / dragCoefficient;

            float meanExplicitEulerRelativeError = 0.0f;
            float meanRungeKutta2RelativeError = 0.0f;
            float meanRungeKutta4RelativeError = 0.0f;

            while (currentTime <= duration)
            {
				float currentRealSpeed = ratio * math.exp(-dragCoefficient * (currentTime + timeStep) / mass) - ratio;

				float currentAcceleration = FreeFallAcceleration(currentExplicitEulerSpeed);
                currentExplicitEulerSpeed = Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(currentExplicitEulerSpeed, currentAcceleration, timeStep);

                float k1 = FreeFallAcceleration(currentRungeKutta2Speed);
                float k2 = FreeFallAcceleration(Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(currentRungeKutta2Speed, k1, timeStep));
                currentRungeKutta2Speed = Mathematics.DifferentialEquation.Solver.SolveWithExplicitRungeKutta2(currentRungeKutta2Speed, k1, k2, timeStep);

                k1 = FreeFallAcceleration(currentRungeKutta4Speed);
                k2 = FreeFallAcceleration(Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(currentRungeKutta4Speed, k1, halfTimeStep));
                float k3 = FreeFallAcceleration(Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(currentRungeKutta4Speed, k2, halfTimeStep));
                float k4 = FreeFallAcceleration(Mathematics.DifferentialEquation.Solver.SolveWithExplicitEuler(currentRungeKutta4Speed, k3, timeStep));
                currentRungeKutta4Speed = Mathematics.DifferentialEquation.Solver.SolveWithExplicitRungeKutta4(currentRungeKutta4Speed, k1, k2, k3, k4, timeStep);

                meanExplicitEulerRelativeError += math.abs((currentRealSpeed - currentExplicitEulerSpeed) / currentRealSpeed);
                meanRungeKutta2RelativeError += math.abs((currentRealSpeed - currentRungeKutta2Speed) / currentRealSpeed);
                meanRungeKutta4RelativeError += math.abs((currentRealSpeed - currentRungeKutta4Speed) / currentRealSpeed);

                currentTime += timeStep;
                iterationNb++;
            }

            meanExplicitEulerRelativeError /= (float)iterationNb;
            meanRungeKutta2RelativeError /= (float)iterationNb;
            meanRungeKutta4RelativeError /= (float)iterationNb;

            Assert.Greater(meanExplicitEulerRelativeError, meanRungeKutta2RelativeError);
            Assert.Greater(meanRungeKutta2RelativeError, meanRungeKutta4RelativeError);
        }

        [Test]
        public void TestAccuracyDimension2()
		{
            // TODO
            Debug.LogWarning("Dimension 2 accuracy test not implemented");
        }
    }
}
