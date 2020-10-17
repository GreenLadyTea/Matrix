using System;

namespace MATRIX
{
    class Program
    {
        private static void GetValues(ref int rows, ref int cols)
        {
            Console.WriteLine("Введите размерность матрицы:");

            Console.Write("Количество строк: ");
            rows = Convert.ToInt32(Console.ReadLine());

            Console.Write("Количество столбцов: ");
            cols = Convert.ToInt32(Console.ReadLine());
        }

        static void Main()
        {
            int rows = 0;
            int cols = 0;
            int x = 0;

            Console.WriteLine("Первая матрица: ");
            GetValues(ref rows, ref cols);
            Matrix A = new Matrix(rows, cols);
            A.Fill();
            //x = A[0, 0];
            //Console.WriteLine($"{x}");
            Console.WriteLine("\nПервая матрица:\n" + A.ToString());
            
            Console.WriteLine("Вторая матрица: ");
            GetValues(ref rows, ref cols);
            Matrix B = new Matrix(rows, cols);
            B.Fill();
            Console.WriteLine("\nВторая матрица:\n" + B.ToString());

            Console.WriteLine("Сумма матриц:");
            Console.WriteLine((A + B).ToString());
            Console.WriteLine("Разность матриц:");
            Console.WriteLine((A - B).ToString());
            Console.WriteLine("Произведение матриц:");
            Console.WriteLine((A * B).ToString());
        }
    }
}
