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
            Neural n = new Neural(4, 20, 3);

            double[][] InputData = new double[][] {
                new double[] { 0.0, 0.0, 0.0, 0.0},
                new double[] { 0.0, 0.0, 0.0, 1.0},
                new double[] { 0.0, 0.0, 1.0, 0.0},
                new double[] { 0.0, 0.0, 1.0, 1.0},
                new double[] { 0.0, 1.0, 0.0, 0.0},
                new double[] { 0.0, 1.0, 0.0, 1.0},
                new double[] { 0.0, 1.0, 1.0, 0.0},
                new double[] { 0.0 ,1.0, 1.0, 1.0},
                new double[] { 1.0, 0.0, 0.0, 0.0},
                new double[] { 1.0, 0.0, 0.0, 1.0},
                new double[] { 1.0, 0.0, 1.0, 0.0},
                new double[] { 1.0, 0.0, 1.0, 1.0},
                new double[] { 1.0, 1.0, 0.0, 0.0},
                new double[] { 1.0, 1.0, 0.0, 1.0},
                new double[] { 1.0, 1.0, 1.0, 0.0},
                //new double[] { 1.0, 1.0, 1.0, 1.0},
            };
            /*
            double[][] InputData = new double[][] {
                new double[] { 0.0, 0.0},
                new double[] { 1.0, 0.0},
                new double[] { 0.0, 1.0},
                new double[] { 1.0, 1.0},
            };
            double[][] Answer = new double[][] {
                new double[] { 0.0},
                new double[] { 1.0},
                new double[] { 1.0},
                new double[] { 0.0},
            };
            */


            double[][] Answer = new double[][] {
                new double[] { 0.0, 0.0, 0.0 },
                new double[] { 0.0, 0.0, 1.0 },
                new double[] { 0.0, 0.0, 1.0 },
                new double[] { 0.0, 1.0, 0.0 },
                new double[] { 0.0, 0.0, 1.0 },
                new double[] { 0.0, 1.0, 0.0 },
                new double[] { 0.0, 1.0, 0.0 },
                new double[] { 0.0, 1.0, 1.0 },

                new double[] { 0.0, 0.0, 1.0 },
                new double[] { 0.0, 1.0, 0.0 },
                new double[] { 0.0, 1.0, 0.0 },
                new double[] { 0.0, 1.0, 1.0 },
                new double[] { 0.0, 1.0, 0.0 },
                new double[] { 0.0, 1.0, 1.0 },
                new double[] { 0.0, 1.0, 1.0 },
                //new double[] { 1.0, 0.0, 0.0 },

                /*
                new double[] { 1.0, 0.0, 0.0, 0.0},
                new double[] { 1.0, 0.0, 0.0, 1.0},
                new double[] { 1.0, 0.0, 1.0, 0.0},
                new double[] { 1.0, 0.0, 1.0, 1.0},
                new double[] { 1.0, 1.0, 0.0, 0.0},
                new double[] { 1.0, 1.0, 0.0, 1.0},
                new double[] { 1.0, 1.0, 1.0, 0.0},
                new double[] { 1.0, 1.0, 1.0, 1.0},
                */
            };



            //double[][] InputData = new double[32][];
            /*
            double[][] Answer = new double[][] {
                new double[]{ 0.0 },
                new double[]{ 1.0 },
                new double[]{ 1.0 },
                new double[]{ 0.0 },
            };
            */

            int DataNumber = 15;
            int UnitNumber = 3;

            for (int i = 0; i < 10000; i++) {
                for (int j = 0; j < DataNumber; j++) {
                    n.ForwardPropagation(InputData[j], Answer[j]);
                    n.BackPropagation(InputData[j], Answer[j]);
                }
                //Console.WriteLine(n.GetError());
            }

            Console.WriteLine("Train Finished");

            double[,] Output = new double[DataNumber,UnitNumber];
            double[] Average = new double[UnitNumber];

            for (int i = 0; i < DataNumber; i++) {
                double[] Tmp = n.ForwardPropagation(InputData[i], Answer[i]);
                for (int j = 0; j < UnitNumber; j++) {
                    Output[i, j] = Tmp[j];
                    Average[j] += Tmp[j];
                }               
            }

            //Average[0] /= DataNumber;
            //Average[1] /= DataNumber;



            for (int i = 0;i < DataNumber; i++) {
                for(int count = 0;count < UnitNumber; count++) {
                    Console.Write(Math.Abs(Answer[i][count] - Output[i, count]) + ":");
                }
                Console.WriteLine();
                /*
                foreach(double x in InputData[i]) {
                    Console.Write(x + ":");
                }
                Console.WriteLine();

                foreach (double x in Answer[i]) {
                    Console.Write(x + ":");
                }
                Console.WriteLine();

                for (int j = 0; j < 2; j++)
                    Console.Write(Output[i, j] + ":");
                Console.WriteLine();

                Console.WriteLine("\n");
                */
                /*
                for (int j = 0; j < 2; j++)
                    Console.Write((Output[i, j] > Average[j] ? 1 : 0) + ":"); 
                Console.WriteLine("\n");
                */

                /*
                for(int j = 0;j < 2; j++) {
                    Console.Write(Math.Abs(Answer[i][j] - Output[i, j]) + ":");
                }
                Console.WriteLine();
                */
            }

            Console.WriteLine("test");

            foreach (double x in n.ForwardPropagation(new double[] { 1.0, 1.0, 1.0, 1.0 }, new double[] { 0.0, 0.0, 0.0, 0.0 }))
                Console.Write(x + ":");
            Console.WriteLine();


            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}
