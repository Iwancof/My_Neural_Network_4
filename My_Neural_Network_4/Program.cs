using System;

namespace My_Neural_Network_4
{
    class Program
    {
        static void Main(string[] args) {
            Neural n = new Neural(2,3,2);

            double[][] InputData = new double[][] {
                new double[] { 0.0, 0.0},
                new double[] { 0.0, 1.0},
                new double[] { 1.0, 0.0},
                new double[] { 1.0, 1.0},
            };
            double[][] Answer = new double[][] {
                new double[] { 0.0, 0.0},
                new double[] { 0.0, 1.0},
                new double[] { 0.0, 1.0},
                new double[] { 1.0, 0.0},
            };

            for(int i = 0;i < 10000; i++) {
                for(int j = 0;j < 4; j++) {
                    n.ForwardPropagation(InputData[j]);
                    n.BackPropagation(InputData[j], Answer[j]);
                }
            }

            for(int i = 0;i < 4; i++) {
                foreach(double x in InputData[i]) {
                    Console.Write(x + ":");
                }
                Console.WriteLine();
                foreach (double x in Answer[i]) {
                    Console.Write(x + ":");
                }
                Console.WriteLine();
                foreach (double x in n.ForwardPropagation(InputData[i])) {
                    Console.Write(x + ":");                    
                }
                Console.WriteLine("\n\n\n");

            }


            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}
