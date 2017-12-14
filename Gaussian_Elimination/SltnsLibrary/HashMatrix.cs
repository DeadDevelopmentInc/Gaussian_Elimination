using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SltnsLibrary
{
    public class HashMatrix : Matrix
    {
        // jp - строки верхней полуматрицы
        // jm - столбцы нижней полуматрицы
        // dd - главная диагональ
        private IRow[] jp, jm;
        private double[] dd;

        public override double this[int row, int col]
        {
            get
            {
                if (row == col) return dd[row];
                int d = getD(row, col);
                int j = getJ(row, col);
                return (j > 0) ? jp[d].getValue(j) : jm[d].getValue(-j);
            }
            set
            {
                if (row == col)
                {
                    dd[row] = value;
                    return;
                }
                int d = getD(row, col);
                int j = getJ(row, col);
                if (j > 0) jp[d].setValue(j, value);
                else jm[d].setValue(-j, value);
            }
        }

        // конструктор матрицы
        // type - тип хранения данных ARRAY_TYPE/HASH_TYPE
        // N - порядок матрицы
        public HashMatrix(int N) : base(N)
        {
            dd = new double[N];
            jp = new Hash[N];
            jm = new Hash[N];
            for (int i = 0; i < N; i++)
            {
                jp[i] = new Hash();
                jm[i] = new Hash();
            }
        }

        public override void setValue(int row, int col, double value)
        {
            if (row == col)
            {
                dd[row] = value;
                return;
            }
            int d = getD(row, col);
            int j = getJ(row, col);
            if (j > 0) jp[d].setValue(j, value);
            else jm[d].setValue(-j, value);
        }

        public override double getValue(int row, int col)
        {
            if (row == col) return dd[row];
            int d = getD(row, col);
            int j = getJ(row, col);
            return (j > 0) ? jp[d].getValue(j) : jm[d].getValue(-j);
        }

        public override void addValue(int row, int col, double value)
        {
            if (value == 0) return;
            if (row == col)
            {
                dd[row] += value;
                return;
            }
            int d = getD(row, col);
            int j = getJ(row, col);
            if (j > 0) jp[d].addValue(j, value);
            else jm[d].addValue(-j, value);
        }

        public override void getJRow(int d, ref int[] indexes, ref double[] values)
        {
            jp[d].getValues(ref indexes, ref values);
            for (int i = 0; i < indexes.Length; i++) indexes[i] = getCol(d, indexes[i]);
        }
        public override void getJCol(int d, ref int[] indexes, ref double[] values)
        {
            jm[d].getValues(ref indexes, ref values);
            for (int i = 0; i < indexes.Length; i++) indexes[i] = getRow(d, -indexes[i]);
        }
    }
}
