using System;
using System.Collections.Generic;

namespace VizrtProblemB
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            // Read N (Number of Stages)
            var line = Console.ReadLine();
            int stages = int.Parse(line); // Parse converting to int

            if (stages > 1000) throw new ArgumentOutOfRangeException();

            var stagesData = new Stack<(int S, int L, int T, int C)>();

            int totalMass = 0;
            for (int i = 0; i < stages; i++)
            {
                var valueLine = Console.ReadLine();
                var stageValues = ParseStageValues(valueLine);
                stagesData.Push(stageValues);
                totalMass += stageValues.S + stageValues.L;
            }

            double totalVelocity = 0;
            while (stagesData.Count != 0)
            {
                var stageValues = stagesData.Pop();
                var velocity = CalculateVelocity(stageValues, totalMass);
                totalMass -= stageValues.S + stageValues.L;
                totalVelocity += velocity;

            }

            Console.WriteLine(Math.Round(totalVelocity));
            return 0;
        }

        private static double CalculateVelocity((int S, int L, int T, int C) stageValues, int totalMass)
        {
            double velocity = ((double)stageValues.L / stageValues.C) * (((double)stageValues.T / totalMass) - 9.8);
            return velocity;
        }

        public static (int S, int L, int T, int C) ParseStageValues(string values)
        {
            string[] splittedValues = values.Split(' ');
            int S = int.Parse(splittedValues[0]);
            int L = int.Parse(splittedValues[1]);
            int T = int.Parse(splittedValues[2]);
            int C = int.Parse(splittedValues[3]);

            return (S, L, T, C);
        }
    }
}