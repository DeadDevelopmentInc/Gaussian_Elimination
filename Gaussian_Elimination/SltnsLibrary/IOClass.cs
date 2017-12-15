using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SltnsLibrary
{
    class IOClass
    {
        public static void ReadFile(string source, out IMatrix matrix,
            out double[] vectorB)
        {
            int count = 0;


            List<string> allElement = new List<string>();
            //Считвание значений в переменнуй строками
            using (StreamReader fs = new StreamReader(source))
            {
                string line;
                while ((line = fs.ReadLine()) != null)
                {
                    allElement.Add(line);
                    count++;
                }
            }
            //создание начальной матрицы
            matrix = new HashMatrix(count);
            vectorB = new double[count];
            //Ввод элементов из файла
            for (int i = 0; i < allElement.Count; i++)
            {
                string[] part = allElement[i].Split(' ');
                for (int j = 0; j < part.Length - 1; j++)
                {
                    matrix[i, j] =  Double.Parse(part[j]);
                }
                vectorB[i] = Convert.ToDouble(part[part.Length - 1]);
            }
        }

        public static void ReadConsole(out IMatrix matrix, out double[] vectorB)
        {
            Console.WriteLine("Input rows and colns of matrix");
            int count = int.Parse(Console.ReadLine());
            matrix = new HashMatrix(count);
            vectorB = new double[count];
            for(int i = 0; i < count; i++)
            {
                try
                {
                    Console.WriteLine("Input " + i.ToString() + " rows");
                    string byfer = Console.ReadLine();
                    string[] parts = byfer.Split(' ');
                    for (int j = 0; j < parts.Length; j++)
                    {
                        matrix[i, j] = Double.Parse(parts[j]);
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Not correct data. Please retry");
                    i--;
                }
            }
            Console.WriteLine("Input vector B");
            string byfers = Console.ReadLine();
            string[] part = byfers.Split(' ');
            for (int j = 0; j < part.Length; j++)
            {
                vectorB[j] = Convert.ToDouble(part[j]);
            }
        }
    }
}