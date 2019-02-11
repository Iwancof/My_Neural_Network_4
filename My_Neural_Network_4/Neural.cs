using System;
using System.Collections.Generic;
using System.Text;

namespace My_Neural_Network_4
{
    public partial class Neural
    {
        public int Number_of_inUnit;
        public int Number_of_hiUnit;
        public int Number_of_ouUnit;

        public double[] Output_of_in;
        public double[] Output_of_hi;
        public double[] Output_of_ou;

        public double[,] Weigth_to_hi;
        public double[,] Weigth_to_hi_mod;
        public double[,] Weigth_to_ou;
        public double[,] Weigth_to_ou_mod;

        public double[] Bias_to_hi;
        public double[] Bias_to_hi_mod;
        public double[] Bias_to_ou;
        public double[] Bias_to_ou_mod;

        public double[] ForwardPropagation(double[] Input) {
            Output_of_in = (double[])Input.Clone();

            //Input -> Hidden
            for(int Hidden_Count = 0;Hidden_Count < Number_of_hiUnit; Hidden_Count++) {
                double sum = 0;
                for(int Input_Count = 0;Input_Count< Number_of_inUnit; Input_Count++) 
                    sum += Weigth_to_hi[Hidden_Count, Input_Count] * Output_of_in[Input_Count];
                Output_of_hi[Hidden_Count] = Sigmoid(sum + Bias_to_hi[Hidden_Count]);
            }

            //forprint(Output_of_hi);

            for (int Output_Count = 0; Output_Count < Number_of_ouUnit; Output_Count++) {
                double sum = 0;
                for (int Hidden_Count = 0; Hidden_Count < Number_of_hiUnit; Hidden_Count++)
                    sum += Weigth_to_ou[Output_Count, Hidden_Count] * Output_of_hi[Hidden_Count];
                Output_of_ou[Output_Count] = Sigmoid(sum + Bias_to_hi[Output_Count]);
            }

            return Output_of_ou;
        }

        public void BackPropagation(double[] Input, double[] Answer) {
            double[] Delta_ou = new double[Number_of_ouUnit];
            double[] Delta_hi = new double[Number_of_hiUnit];
            double Eps = 0.8;
            double Mu = 0.75;

            for (int i = 0; i < Number_of_ouUnit; i++) {
                Delta_ou[i] = (Answer[i] - Output_of_ou[i]) * Output_of_ou[i] + (1.0 - Output_of_ou[i]);
            }

            for (int i = 0; i < Number_of_hiUnit; i++) {
                double sum = 0.0;
                for (int j = 0; j < Number_of_ouUnit; j++) {
                    Weigth_to_ou_mod[j, i] = Eps * Delta_ou[j] * Output_of_hi[i] + Mu * Weigth_to_ou_mod[j, i];
                    Weigth_to_ou[j, i] += Weigth_to_ou_mod[j, i];
                    sum += Delta_ou[j] * Weigth_to_ou[j, i];
                }
                // シグモイド関数の１次微分と掛け合わせる
                Delta_hi[i] = Output_of_hi[i] * (1 - Output_of_hi[i]) * sum;
            }

            for (int i = 0; i < Number_of_ouUnit; i++) {
                Bias_to_ou_mod[i] = Eps * Delta_ou[i] + Mu * Bias_to_ou_mod[i];
                Bias_to_ou[i] += Bias_to_ou_mod[i];
            }

            for(int i = 0;i < Number_of_inUnit; i++) {
                for(int j = 0;j < Number_of_hiUnit; j++) {
                    Weigth_to_hi_mod[j, i] = Eps * Delta_hi[j] * Input[i] + Mu * Weigth_to_hi_mod[j,i];
                    Weigth_to_hi[j, i] += Weigth_to_hi_mod[j, i];
                }
            }

            for(int i = 0;i < Number_of_hiUnit; i++) {
                Bias_to_hi_mod[i] = Eps * Delta_hi[i] + Mu * Bias_to_hi_mod[i];
                Bias_to_hi[i] += Bias_to_hi_mod[i];
            }

        }
        void forprint(double[] x) {
            foreach (double e in x)
                Console.Write(e);
            Console.WriteLine();
        }
    }
}
