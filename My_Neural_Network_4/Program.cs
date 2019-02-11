using System;

namespace My_Neural_Network_4
{
    class Program
    {
        static double[] ReplaceToOneZero(double[] inp,double[] s) {
            double[] Result = new double[inp.Length];
            for(int i = 0;i < Result.Length; i++) {
                Result[i] = ((inp[i] >= s[i]) ? 1 : 0);
            }
            return Result;
        }

        static void Main(string[] args) {
            Neural n = new Neural(3, 5, 2);

            /*
            double[][] InputData = new double[][] {
                new double[] { 0.0, 0.0, 0.0},
                new double[] { 0.0, 0.0, 1.0},
                new double[] { 0.0, 1.0, 0.0},
                new double[] { 0.0, 1.0, 1.0},
                new double[] { 1.0, 0.0, 0.0},
                new double[] { 1.0, 0.0, 1.0},
                new double[] { 1.0, 1.0, 0.0},
                new double[] { 1.0, 1.0, 1.0},
            };
            double[][] Answer = new double[][] {
                new double[] { 0.0, 0.0},
                new double[] { 0.0, 1.0},
                new double[] { 0.0, 1.0},
                new double[] { 1.0, 0.0},
                new double[] { 0.0, 1.0},
                new double[] { 1.0, 0.0},
                new double[] { 1.0, 0.0},
                new double[] { 1.0, 1.0},
            };
            */
            double[][] InputData = new double[32][];
            /*
            double[][] Answer = new double[][] {
                new double[]{ 0.0 },
                new double[]{ 1.0 },
                new double[]{ 1.0 },
                new double[]{ 0.0 },
            };
            */

            for (int i = 0; i < 10000; i++) {
                for (int j = 0; j < 8; j++) {
                    n.ForwardPropagation(InputData[j], Answer[j]);
                    n.BackPropagation(InputData[j], Answer[j]);
                }
                //Console.WriteLine(n.GetError());
            }

            double[,] Output = new double[8,2];
            double[] Average = new double[2];

            for (int i = 0; i < 8; i++) {
                double[] Tmp = n.ForwardPropagation(InputData[i], Answer[i]);
                for (int j = 0; j < 2; j++) {
                    Output[i, j] = Tmp[j];
                    Average[j] += Tmp[j];
                }               
            }

            Average[0] /= 8;
            Average[1] /= 8;



            for (int i = 0;i < 8; i++) {
                /*
                foreach(double x in InputData[i]) {
                    Console.Write(x + ":");
                }
                */
                /*
                Console.WriteLine();
                foreach (double x in Answer[i]) {
                    Console.Write(x + ":");
                }
                Console.WriteLine();
                */
                /*
                for (int j = 0; j < 2; j++)
                    Console.Write(Output[i, j] + ":");
                Console.WriteLine();
                */
                /*
                for (int j = 0; j < 2; j++)
                    Console.Write((Output[i, j] > Average[j] ? 1 : 0) + ":"); 
                Console.WriteLine("\n");
                */
                for(int j = 0;j < 2; j++) {
                    Console.Write(Math.Abs(Answer[i][j] - Output[i, j]) + ":");
                }
                Console.WriteLine();
            }


            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}
