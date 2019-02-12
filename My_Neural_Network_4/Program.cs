using System;

namespace My_Neural_Network_4
{
    class Program
    {
        static double Sum(double[] x) {
            double Result = 0;
            foreach (double y in x)
                Result += y;
            return Result;
        }
        static void Main(string[] args) {
            double[][] Data = new double[][] {
                new double[] { 1, 5 },
                new double[] { 3, 5 },
                new double[] { 2, 4 },
                new double[] { 7, 4 },
                new double[] { 2, 3 },
                new double[] { 5, 5 },
                new double[] { 1, 7 },
                new double[] { 1, 3 }
            };
            /*
            double[][] Answer = new double[][] {
                new double[] { 0,0,0 },
                new double[] { 0,1,0 },
                new double[] { 0,1,0 },
                new double[] { 1,0,0 },
                new double[] { 0,1,0 },
                new double[] { 1,0,0 },
                new double[] { 1,0,0 },
                new double[] { 1,1,0 },
            };
            */
            double[][] Answer = new double[8][];
            for (int i = 0; i < 8; i++)
                Answer[i] = new double[] { Sum(Data[i]) };

            int TrainNumber = 10000; //学習回数
            int DataNumber = 8;

            Neural Tissue = new Neural(2, 2, 1);

            for (int TrainCount = 0; TrainCount < TrainNumber; TrainCount++) {
                for (int DataCount = 0; DataCount < 8; DataCount++) {
                    Tissue.ForwardPropagation(Data[DataCount], Answer[DataCount]);
                    Tissue.BackPropagation(Data[DataCount], Answer[DataCount]);
                }
                    if (TrainCount % 10 == 0)
                        Console.WriteLine("TrainCount : " + TrainCount.ToString().PadLeft(5, ' ') + ", Error : " + Tissue.GetError().ToString().PadLeft(15, ' '));
                    else
                        Tissue.Error = 0;
            }

            Console.WriteLine("Train Finished");

            for(int DataCount = 0;DataCount < DataNumber; DataCount++) {
                Console.Write("\nInput : ");
                foreach (double inp in Data[DataCount])
                    Console.Write(inp + ":");
                Console.Write("\nRight answer    :");
                foreach (double ans in Answer[DataCount])
                    Console.Write(ans.ToString().PadLeft(20,' ') + ":");
                Console.Write("\nPredicted answer:");
                foreach (double pre in Tissue.ForwardPropagation(Data[DataCount], Answer[DataCount]))
                    Console.Write(pre.ToString().PadLeft(20, ' ') + ":");
                Console.WriteLine();
            }

            Console.WriteLine("\nエラー率:" + Tissue.GetError());

            for (int i = 0; i < Tissue.Weigth_to_hi.GetLength(0); i++)
                for (int j = 0; j < Tissue.Weigth_to_hi.GetLength(1); j++)
                    Console.WriteLine(string.Format("Weigth[{0},{1}] = {2}", i, j, Tissue.Weigth_to_hi[i, j]));

            for (int i = 0; i < Tissue.Bias_to_hi.Length; i++)
                Console.WriteLine(string.Format("Bias[{0}] = {1}", i, Tissue.Bias_to_hi[i]));

            Console.WriteLine("------------------");
            for (int i = 0; i < Tissue.Weigth_to_ou.GetLength(0); i++)
                for (int j = 0; j < Tissue.Weigth_to_ou.GetLength(1); j++)
                    Console.WriteLine(string.Format("Weigth[{0},{1}] = {2}", i, j, Tissue.Weigth_to_ou[i, j]));

            for (int i = 0; i < Tissue.Bias_to_ou.Length; i++)
                Console.WriteLine(string.Format("Bias[{0}] = {1}", i, Tissue.Bias_to_ou[i]));

            Console.WriteLine("Finished");
            Console.ReadLine();
        }

        static void Main_(string[] args) {
            Neural n = new Neural(4, 6, 3);

            double[][] InputData = new double[][] {
                new double[] { 0.0, 0.0, 0.0, 0.0},
                new double[] { 0.0, 0.0, 0.0, 1.0},
                new double[] { 0.0, 0.0, 1.0, 0.0},
                new double[] { 0.0, 0.0, 1.0, 1.0},
                new double[] { 0.0, 1.0, 0.0, 0.0},
                new double[] { 0.0, 1.0, 0.0, 1.0},
                new double[] { 0.0, 1.0, 1.0, 0.0},
                new double[] { 0.0 ,1.0, 1.0, 1.0},
                /*
                new double[] { 1.0, 0.0, 0.0, 0.0},
                new double[] { 1.0, 0.0, 0.0, 1.0},
                new double[] { 1.0, 0.0, 1.0, 0.0},
                new double[] { 1.0, 0.0, 1.0, 1.0},
                new double[] { 1.0, 1.0, 0.0, 0.0},
                new double[] { 1.0, 1.0, 0.0, 1.0},
                new double[] { 1.0, 1.0, 1.0, 0.0},
                //new double[] { 1.0, 1.0, 1.0, 1.0},
                */
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
                /*
                new double[] { 0.0, 0.0, 1.0 },
                new double[] { 0.0, 1.0, 0.0 },
                new double[] { 0.0, 1.0, 0.0 },
                new double[] { 0.0, 1.0, 1.0 },
                new double[] { 0.0, 1.0, 0.0 },
                new double[] { 0.0, 1.0, 1.0 },
                new double[] { 0.0, 1.0, 1.0 },
                //new double[] { 1.0, 0.0, 0.0 },
                */
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

            int DataNumber = 8;
            int UnitNumber = 3;

            for (int i = 0; i < 1000; i++) {
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



            for (int i = 0; i < DataNumber; i++) {
                for (int count = 0; count < UnitNumber; count++) {
                    Console.Write(Math.Abs(Answer[i][count] - Output[i, count]).ToString().PadRight(20,' ') + " :");
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

            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}
