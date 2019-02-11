using System;
using System.Collections.Generic;
using System.Text;

namespace My_Neural_Network_4
{
    public partial class Neural
    {
        public Neural(int[] UnitNumbers) {
            this.Number_of_Unit = UnitNumbers;
            this.Number_of_hiLayer = UnitNumbers.Length - 2;
            this.Number_of_inUnit = UnitNumbers[0];
            this.Number_of_hiUnit = new int[Number_of_hiLayer];
            this.Number_of_ouUnit = UnitNumbers[UnitNumbers.Length - 1];

            Random random = new Random(100);

            Output_of_in = new double[Number_of_inUnit];
            Output_of_hi = new double[Number_of_hiLayer][]; //[深さ][各ユニット]
            Output_of_ou = new double[Number_of_ouUnit];
            for(int i = 0;i < Number_of_hiLayer; i++)
                Output_of_hi[i] = new double[UnitNumbers[i + 1]]; //各レイヤーのユニット数を初期化

            //Math.Sign(Rnd.NextDouble() - 0.5) * Rnd.NextDouble()

            Weigth_to_hi = new double[Number_of_hiLayer][,];
            Weigth_to_hi_mod = new double[Number_of_hiLayer][,];
            Bias_to_hi = new double[Number_of_hiLayer][];
            Bias_to_hi_mod = new double[Number_of_hiLayer][];
            for (int LayerCount = 0; LayerCount < Number_of_hiLayer; LayerCount++) {
                Weigth_to_hi[LayerCount] = new double[UnitNumbers[LayerCount], UnitNumbers[LayerCount + 1]];
                Weigth_to_hi_mod[LayerCount] = new double[UnitNumbers[LayerCount], UnitNumbers[LayerCount + 1]];
                Bias_to_hi[LayerCount] = new double[UnitNumbers[LayerCount + 1]];
                Bias_to_hi_mod[LayerCount] = new double[UnitNumbers[LayerCount + 1]];
                for (int i = 0; i < UnitNumbers[LayerCount]; i++) {
                    for (int j = 0; j < UnitNumbers[LayerCount+1]; j++) {
                        //Weigth_to_hi[i, j] = random.Next(0, 1000) / 1000d;
                        Weigth_to_hi[LayerCount][i, j] = Math.Sign(random.NextDouble() - 0.5) * random.NextDouble();
                        Weigth_to_hi_mod[LayerCount][i, j] = 0;
                    }
                    Bias_to_hi[LayerCount][i] = Math.Sign(random.NextDouble() - 0.5) * random.NextDouble();
                    Bias_to_hi_mod[LayerCount][i] = 0;
                }
            }

            Weigth_to_ou = new double[Number_of_ouUnit, Number_of_hiUnit[Number_of_hiUnit.Length - 1]];
            Weigth_to_ou_mod = new double[Number_of_ouUnit, Number_of_hiUnit[Number_of_hiUnit.Length - 1]];
            Bias_to_ou = new double[Number_of_ouUnit];
            Bias_to_ou_mod = new double[Number_of_ouUnit];
            for (int i = 0; i < Number_of_ouUnit; i++) {
                for (int j = 0; j < Number_of_hiUnit[Number_of_hiUnit.Length - 1]; j++) {
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