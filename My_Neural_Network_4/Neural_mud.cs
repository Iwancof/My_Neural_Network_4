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

            Output_of_in = new double[Number_of_inUnit];
            Output_of_hi = new double[Number_of_hiUnit];
            Output_of_ou = new double[Number_of_ouUnit];

            //Math.Sign(Rnd.NextDouble() - 0.5) * Rnd.NextDouble()

            Weigth_to_hi = new double[Number_of_hiUnit, Number_of_inUnit];
            Weigth_to_hi_mod = new double[Number_of_hiUnit, Number_of_inUnit];
            Bias_to_hi = new double[Number_of_hiUnit];
            Bias_to_hi_mod = new double[Number_of_hiUnit];
            for (int i = 0; i < Number_of_hiUnit; i++) {
                for (int j = 0; j < Number_of_inUnit; j++) {
                    //Weigth_to_hi[i, j] = random.Next(0, 1000) / 1000d;
                    Weigth_to_hi[i, j] = Math.Sign(random.NextDouble() - 0.5) * random.NextDouble();
                    Weigth_to_hi_mod[i, j] = 0;
                }
                Bias_to_hi[i] = Math.Sign(random.NextDouble() - 0.5) * random.NextDouble();
                Bias_to_hi_mod[i] = 0;
            }

            Weigth_to_ou = new double[Number_of_ouUnit, Number_of_hiUnit];
            Weigth_to_ou_mod = new double[Number_of_ouUnit, Number_of_hiUnit];
            Bias_to_ou = new double[Number_of_inUnit];
            Bias_to_ou_mod = new double[Number_of_inUnit];
            for (int i = 0; i < Number_of_ouUnit; i++) {
                for (int j = 0; j < Number_of_hiUnit; j++) {
                    Weigth_to_ou[i, j] = Math.Sign(random.NextDouble() - 0.5) * random.NextDouble();
                    Weigth_to_ou_mod[i, j] = 0;
                }
                Bias_to_ou[i] = Math.Sign(random.NextDouble() - 0.5) * random.NextDouble();
                Bias_to_ou_mod[i] = 0;
            }
        }

        public double Sigmoid(double x) {
            return 1.0 / (1.0 + Math.Exp(-x));
        }
    }
}