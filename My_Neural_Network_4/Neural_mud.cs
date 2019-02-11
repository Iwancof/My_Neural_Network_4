using System;
using System.Collections.Generic;
using System.Text;

namespace My_Neural_Network_4
{
    public partial class Neural
    {
        public Neural(int uniIn, int uniHi, int uniOu) {
            this.Number_of_inUnit = uniIn;
            this.Number_of_hiUnit = uniHi;
            this.Number_of_ouUnit = uniOu;

            Random random = new Random(100);

            Weigth_to_hi = new double[Number_of_hiUnit, Number_of_inUnit];
            for (int i = 0; i < Number_of_hiUnit; i++) {
                for (int j = 0; j < Number_of_inUnit; j++) {
                    Weigth_to_hi[i, j] = random.Next(0, 1000) / 1000d;
                    Weigth_to_hi_mod[i, j] = 0;
                }
                Bias_to_hi[i] = random.Next(0, 1000) / 1000d;
                Bias_to_hi_mod[i] = 0;
            }

            Weigth_to_ou = new double[Number_of_ouUnit, Number_of_hiUnit];
            for (int i = 0; i < Number_of_ouUnit; i++) {
                for (int j = 0; j < Number_of_hiUnit; j++) {
                    Weigth_to_ou[i, j] = random.Next(0, 1000) / 1000d;
                    Weigth_to_ou_mod[i, j] = 0;
                }
                Bias_to_ou[i] = random.Next(0, 1000) / 1000d;
                Bias_to_ou_mod[i] = 0;
            }
        }

        public double Sigmoid(double x) {
            return 1d / (1 + Math.Exp(-x));
        }
    }
}