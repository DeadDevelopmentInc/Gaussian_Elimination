using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SltnsLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        double[] X;
        string source;
        const int from = 1;
        Gauss_Elimination decomposition = new Gauss_Elimination();

        [TestMethod]
        public void TestReadFile()
        {
            source = "Matrix3.txt";

            double[] XX = new double[] { 0.73421, 0.27065, -1.05448, -0.50694 };

            decomposition.ClcltLU_Dcmp(source, from, out X);

            foreach (double x in X)
            {
                X[0] = Math.Round(X[0], 5);
            }
            int i = 0;
            bool fl = false;
            while (!fl && i < X.Length)
            {
                if (X[i] == XX[0])
                    fl = true;
                i++;
            }
            Assert.AreEqual(true, fl);

        }
    }
}
