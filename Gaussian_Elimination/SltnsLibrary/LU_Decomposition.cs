using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SltnsLibrary
{
    public class LU_Decomposition
    {

        public void ClcltLU_Dcmp(string source, int inputType, out double[] X)
        {
            IMatrix A;
            double[] vectorB;
            if(inputType == 1)
            {
                IOClass.ReadFile(source, out A, out vectorB);
            }
            else
            {
                IOClass.ReadConsole(out A, out vectorB);
            }

            X = new double[A.getN()];

            ClcltLU(A, A.getN(), vectorB, X);
        }

        private void ClcltLU(IMatrix matrix, int n, double[] vectorB, double[] X)
        {
            // обнуляем нижнюю полуматрицу, перебирая сверху вниз все строки
            // и складывая каждую со всеми нижележащими
            for (int row = 0; row < (matrix.getN() - 1); row++)
            {
                // get all non-zero values of zeroing column
                int[] colIndexes = new int[0];
                double[] colValues = new double[0];
                matrix.getJCol(row, ref colIndexes, ref colValues);

                // получаем все ненулевые значения обнуляемого столбца
                // получаем индексы и значения ячеек строки, правее главной диагонали
                int[] rowIndexes = new int[0];
                double[] rowValues = new double[0];
                matrix.getJRow(row, ref rowIndexes, ref rowValues);

                // получаем элемент главной диагонали, которым будем обнулять столбец
                double dd = matrix.getValue(row, row);
                for (int i = 0; i < matrix.getN(); i++)// высчитываем коэффициент 
                {
                    double k = colValues[i] / dd;

                    // k подобран таким образом чтобы обнулить ячейку столбца,
                    matrix.setValue(colIndexes[i], row, 0);

                    // складываем строки
                    for (int ii = 0; ii < rowIndexes.Length; ii++)
                    {
                        matrix.addValue(colIndexes[i], rowIndexes[ii], -rowValues[ii] * k);
                    }

                    // складываем соответствующие свободные члены
                    vectorB[colIndexes[i]] -= vectorB[row] * k;
                }
                   
            }

            // используя обратный ход находим неизвестные
            for (int row = (matrix.getN() - 1); row >= 0; row--)
            {
                double e = 0;
                int[] indexes = new int[0];
                double[] values = new double[0];
                matrix.getJRow(row, ref indexes, ref values);
                for (int i = 0; i < indexes.Length; i++) e += X[indexes[i]] * values[i];
                X[row] = (vectorB[row] - e) / matrix.getValue(row, row);
            }
        }
    }
}
