using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SltnsLibrary;

namespace Gaussian_Elimination
{
    class Program
    {
        static void Main(string[] args)
        {
            LU_Decomposition decomposition = new LU_Decomposition();

            string source = "Matrix.txt";

            int from = 0;

            double[] vector;

            byte key = 99;

            while (key != 0)
            {
                Console.Clear();
                Console.WriteLine("Choose point of menu");
                Console.WriteLine("1. Write data");
                if (from != 0)
                    Console.WriteLine("2. Output determination");
                Console.WriteLine("3. Output README");
                Console.WriteLine("4. Exit");
                Console.Write("Your number: ");
                key = Byte.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        {
                            Console.WriteLine("What kind of source(file or hand-create values)\n" +
                                "Your number: ");
                            int fl = Convert.ToInt32(Console.ReadLine());
                            switch (fl)
                            {
                                case 1:
                                    {
                                        from = 1;
                                    }
                                    break;
                                case 2:
                                    {
                                        from = 2;
                                    }
                                    break;
                            }
                        }
                        break;
                    case 2:
                        {
                            if (from != 0)
                            {
                                Console.WriteLine("Your output is");
                                decomposition.ClcltLU_Dcmp(source, from, out vector);
                                foreach (double x in vector)
                                {
                                    Console.Write(Math.Round(x, 5) + " ");
                                }
                                Console.ReadKey();
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.Write("I");
                        }
                        break;
                    case 4:
                        {
                            key = 0;
                        }
                        break;
                }
            }
        }
    }
}
