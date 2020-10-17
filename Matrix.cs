using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;

namespace MATRIX
{
    public class Matrix
    {
        private int[,] matrix = new int[0, 0];
        private readonly int rows = 0;
        private readonly int cols = 0;

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new int[rows, cols];
        }

        public override string ToString()
        {
            string matrix_to_string = "";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix_to_string += $"{matrix[i, j]}\t";
                }
                matrix_to_string += "\n";
            }

            return matrix_to_string;
        }

        public int this[int rows, int cols]
        {
            get
            {
                return matrix[rows, cols];
            }

            private set
            {
                matrix[rows, cols] = value;
            }
        }

        public static Matrix operator +(Matrix first_matrix, Matrix second_matrix)
        {
            Matrix result_matrix = new Matrix(first_matrix.rows, first_matrix.cols);
            if(first_matrix.rows == second_matrix.rows && first_matrix.cols == second_matrix.cols)
            {
                for(int i = 0; i < result_matrix.rows; i++)
                {
                    for(int j = 0; j < result_matrix.cols; j++)
                    {
                        result_matrix[i, j] = first_matrix[i, j] + second_matrix[i, j];
                    }
                }
                return result_matrix;
            }
            else
            {
                result_matrix = new Matrix(0,0);
                Console.WriteLine("ВНИМАНИЕ: Невозможная операция, не совпадают размерности");
                return result_matrix;
            }
        }

        public static Matrix operator -(Matrix this_matrix)
        {
            for (int i = 0; i < this_matrix.rows; i++)
            {
                for (int j = 0; j < this_matrix.cols; j++)
                {
                    this_matrix[i, j] = 0 - this_matrix[i, j];
                }
            }
            return this_matrix;
        }

        public static Matrix operator -(Matrix first_matrix, Matrix second_matrix)
        {
            Matrix result_matrix = first_matrix + (-second_matrix);
            return result_matrix;   
        }

        public static Matrix operator *(Matrix first_matrix, Matrix second_matrix)
        {
            Matrix result_matrix = new Matrix(0, 0);

            if (first_matrix.cols == second_matrix.rows)
            {
                result_matrix = new Matrix(first_matrix.rows, second_matrix.cols);

                for (int i = 0; i < first_matrix.rows; i++)
                {
                    for (int j = 0; j < second_matrix.cols; j++)
                    {
                        for (int k = 0; k < first_matrix.cols; k++)
                        {
                            result_matrix[i, j] -= first_matrix[i, k] * second_matrix[k, j];
                        }
                    }
                }
                return result_matrix;
            }
            else
            {
                Console.WriteLine("ВНИМАНИЕ! Невозможная операция, не совпадают размерности");
                return result_matrix;
            }
        }

        public Matrix Fill()
        {
            int current_value;
            Console.WriteLine("Заполняем матрицу. Введите значения по порядку с первой строки слева направо:");
            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    current_value = Convert.ToInt32(Console.ReadLine());
                    matrix[i, j] = current_value;
                }
            }
            return this;
        }
    }
}
