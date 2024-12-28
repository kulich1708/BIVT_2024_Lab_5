using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using static Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }

    public void Print(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
    public void Print(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
    public void Print(int[] array)
    {
        foreach (int item in array)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
    public void GetMatrixSize(int[,] matrix, out int n, out int m)
    {
        n = matrix.GetLength(0);
        m = matrix.GetLength(1);
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here

        // create and use Combinations(n, k);
        // create and use Factorial(n);

        answer = Combinations(n, k);
        // end

        return answer;
    }
    public long Combinations(int n, int k)
    {
        long answer = 0;

        if (k == 0 || k > 0 && n == k) answer = 1;
        else if (k > 0 && k < n)
            answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
        else answer = 0;

        return answer;
    }
    public long Factorial(int n)
    {
        long answer = 1;
        for (int i = 2; i <= n; i++) answer *= i;
        return answer;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        // create and use GeronArea(a, b, c);

        // end
        //if (first == null || second == null || first.Length != 3 || second.Length != 3) return -1;

        //double a1 = first[0], a2 = second[0], b1 = first[1], b2 = second[1], c1 = first[2], c2 = second[2];

        //double minSide1 = Math.Min(a1, Math.Min(b1, c1));
        //double maxSide1 = Math.Max(a1, Math.Max(b1, c1));
        //double minSide2 = Math.Min(a2, Math.Min(b2, c2));
        //double maxSide2 = Math.Max(a2, Math.Max(b2, c2));
        //double sumSide1 = a1 + b1 + c1;
        //double sumSide2 = a2 + b2 + c2;

        //if (minSide1 <= 0 || minSide2 <= 0 || maxSide1 >= sumSide1 - maxSide1 || maxSide2 >= sumSide2 - maxSide2) return -1;

        //double firstSquare = GeronArea(a1, b1, c1);
        //double secondSquare = GeronArea(a2, b2, c2);

        double firstSquare = GetSquare(first);
        double secondSquare = GetSquare(second);
        if (firstSquare == -1 || secondSquare == -1) answer = -1;
        else if (firstSquare > secondSquare) answer = 1;
        else if (firstSquare < secondSquare) answer = 2;
        else answer = 0;
        
        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    public double GetSquare(double[] array)
    {
        if (array == null || array.Length != 3) return -1;

        double a = array[0], b = array[1], c = array[2];

        double minSide = Math.Min(a, Math.Min(b, c));
        double maxSide = Math.Max(a, Math.Max(b, c));
        double sumSides = a + b + c;

        if (minSide <= 0 || maxSide >= sumSides - maxSide) return -1;

        double square = GeronArea(a, b, c);

        return square;

    }
    public double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        double answer = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return answer;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours

        if (time < 0) return -1;

        double distance1 = GetDistance(v1, a1, time);
        double distance2 = GetDistance(v2, a2, time);

        if (distance1 == distance2) answer = 0;
        else if (distance1 > distance2) answer = 1;
        else answer = 2;
        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public double GetDistance(double v, double a, int t)
    {
        return Math.Abs(v * t + a * t * t / 2);
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here

        // use GetDistance(v, a, t); t - hours
        for (int t = 1; ;t++) if (GetDistance(v2, a2, t) >= GetDistance(v1, a1, t)) { answer = t; break; }
        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxIndex(matrix, out row, out column);
        if (A != null && B != null && A.GetLength(0) == 5 || A.GetLength(1) == 6 && B.GetLength(0) == 3 && B.GetLength(1) == 5)
        {
            FindMaxIndex(A, out int row1, out int column1);
            FindMaxIndex(B, out int row2, out int column2);
            int p = A[row1, column1];
            A[row1, column1] = B[row2, column2];
            B[row2, column2] = p;
        }
        // end
    }
    public void FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        int max = matrix[0, 0];
        row = 0;
        column = 0;
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
    }
    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);
        B = RemovingRowFromMatrix(B, FindDiagonalMaxIndex(B));
        C = RemovingRowFromMatrix(C, FindDiagonalMaxIndex(C));
        // end
    }
    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int answer = 0;
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            if (matrix[i, i] > matrix[answer, answer]) answer = i;
        }
        return answer;
    }
    public int[,] RemovingRowFromMatrix(int[,] matrix, int rowIndex)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int[,] newMatrix = new int[n - 1, m];
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (i < rowIndex) newMatrix[i, j] = matrix[i, j];
                else newMatrix[i, j] = matrix[i + 1, j];
            }
        }
        return newMatrix;
    }
    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);
        FindMaxInColumn(A, 0, out int rowIndex1);
        FindMaxInColumn(B, 0, out int rowIndex2);

        int n = A.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            int tmp = A[rowIndex1, i];
            A[rowIndex1, i] = B[rowIndex2, i];
            B[rowIndex2, i] = tmp;
        }
        // end
    }

    public void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
    {
        int n = matrix.GetLength(0);
        rowIndex = 0;
        for (int i = 1; i < n; i++)
        {
            if (matrix[i, columnIndex] > matrix[rowIndex, columnIndex]) rowIndex = i;
        }
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);
        GetMatrixSize(B, out int n1, out int m1);
        GetMatrixSize(C, out int n2, out int m2);

        int maxPositiveInRow = 0;
        int maxPositiveInRowIndex = 0;
        for (int i = 0; i < n1; i++)
        {
            int currentCountRowPositive = CountRowPositive(B, i);
            if (currentCountRowPositive > maxPositiveInRow)
            {
                maxPositiveInRow = currentCountRowPositive;
                maxPositiveInRowIndex = i;
            }
        }

        int maxPositiveInColumn = 0;
        int maxPositiveInColumnIndex = 0;
        for (int i = 0; i < m2; i++)
        {
            int currentCountColumnPositive = CountColumnPositive(C, i);
            if (currentCountColumnPositive > maxPositiveInColumn)
            {
                maxPositiveInColumn = currentCountColumnPositive;
                maxPositiveInColumnIndex = i;
            }
        }

        int[,] newB = new int[n1 + 1, m1];
        for (int i = 0; i < n1; i++)
        {
            for (int j = 0; j < m1; j++)
            {
                if (i <= maxPositiveInRowIndex)
                {
                    if (i == maxPositiveInRowIndex) newB[i+1, j] = C[j, maxPositiveInColumnIndex];
                    newB[i, j] = B[i, j]; 
                }
                else
                {
                    newB[i + 1, j] = B[i, j];
                }
            }
        }
        B = newB;
        // end
    }

    public int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int m = matrix.GetLength(1);
        int answer = 0;

        for (int i = 0; i < m; i++)
        {
            if (matrix[rowIndex, i] > 0) answer++;
        }
        return answer;
    }
    public int CountColumnPositive(int[,] matrix, int colIndex)
    {
        int n = matrix.GetLength(0);
        int answer = 0;

        for (int i = 0; i < n; i++)
        {
            if (matrix[i, colIndex] > 0) answer++;
        }
        return answer;
    }
    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {

        // code here
        int m1 = A.GetLength(1);
        int m2 = C.GetLength(1);
        int[] answer = new int[m1 + m2];

        // create and use SumPositiveElementsInColumns(matrix);

        int[] array1 = SumPositiveElementsInColumns(A);
        int[] array2 = SumPositiveElementsInColumns(C);

        int answerIndex = 0;
        for (int i = 0; i < m1; i++)
        {
            answer[answerIndex] = array1[i];
            answerIndex++;
        }
        for (int i = 0; i < m2; i++)
        {
            answer[answerIndex] = array2[i];
            answerIndex++;
        }
        // end

        return answer;
    }
    public int[] SumPositiveElementsInColumns(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int[] answer = new int[m];

        for (int i = 0; i < m; i++)
        {
            int summa = 0;
            for (int j = 0; j < n; j++)
            {
                if (matrix[j, i] > 0) summa += matrix[j, i];
            }
            answer[i] = summa;
        }
        return answer;
    }
    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1
        FindMaxIndex(A, out int row1, out int column1);
        FindMaxIndex(B, out int row2, out int column2);

        int tmp = A[row1, column1];
        A[row1, column1] = B[row2, column2];
        B[row2, column2] = tmp;
        // end
    }

    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);
        FindMaxIndex(matrix, out int row1, out int column1);
        FindMinIndex(matrix, out int row2, out int column2);

        matrix = RemoveRow(matrix, row1);
        if (row1 < row2) matrix = RemoveRow(matrix, row2 - 1);
        else if (row1 > row2) matrix = RemoveRow(matrix, row2);
        // end
    }
    public void FindMinIndex(int[,] matrix, out int row, out int column)
    {
        int min = matrix[0, 0];
        row = 0;
        column = 0;
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
    }
    public int[,] RemoveRow(int[,] matrix, int rowIndex)
    {
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        int[,] newMatrix = new int[n - 1, m];
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (i < rowIndex) newMatrix[i, j] = matrix[i, j];
                else newMatrix[i, j] = matrix[i + 1, j];
            }
        }
        return newMatrix;
    }
    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here

        // create and use GetAverageWithoutMinMax(matrix);
        double[] array = new double[3];
        array[0] = GetAverageWithoutMinMax(A);
        array[1] = GetAverageWithoutMinMax(B);
        array[2] = GetAverageWithoutMinMax(C);

        if (array[0] >= array[1] && array[1] >= array[2]) answer = -1;
        else if (array[0] <= array[1] && array[1] <= array[2]) answer = 1;
        else answer = 0;
        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }
    public double GetAverageWithoutMinMax(int[,] matrix)
    {
        int max = matrix[0, 0], min = matrix[0, 0], avg = 0;

        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                avg += matrix[i, j];
                if (matrix[i, j] < min) min = matrix[i, j];
                if (matrix[i, j] > max) max = matrix[i, j];
            }
        }
        avg = (avg - min - max) / (n * m - 2);
        return avg;
    }
    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);
        SortRowsByMaxElement(A);
        SortRowsByMaxElement(B);
        //Print(A);

        // end
    }

    public void SortRowsByMaxElement(int[,] matrix)
    {
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        int[] array = new int[n];
        int[] indexes = new int[n];
        for (int i = 0; i < n; i++)
        {
            int currentMax = matrix[i, 0];
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] > currentMax) currentMax = matrix[i, j];
            }
            array[i] = currentMax;
            indexes[i] = i;
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] < array[j + 1])
                {
                    int tmp1 = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = tmp1;

                    int tmp2 = indexes[j];
                    indexes[j] = indexes[j + 1];
                    indexes[j + 1] = tmp2;
                }
            }
        }
        int[,] newMatrix = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                newMatrix[i, j] = matrix[indexes[i], j];
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = newMatrix[i, j];
            }
        }
    }
    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        int countRemoveRow = 0;
        for (int i = 0; i < n - countRemoveRow; i++)
        {
            bool flag = false;
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] == 0)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                matrix = RemoveRow(matrix, i);
                i--;
                countRemoveRow++;
            }
        }
        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);
        answerA = CreateArrayFromMins(A);
        answerB = CreateArrayFromMins(B);
        // end
    }
    public int[] CreateArrayFromMins(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int[] answer = new int[n];
        for (int i = 0; i < n; i++)
        {
            int currentMin = matrix[i, i];
            for (int j = i; j < n; j++)
            {
                if (matrix[i, j] < currentMin) currentMin = matrix[i, j];
            }
            answer[i] = currentMin;
        }
        return answer;
    }
    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);
        MatrixValuesChange(A);
        MatrixValuesChange(B);
        // end
    }
    public void MatrixValuesChange(double[,] matrix)
    {
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        double[,] data = new double[5, 3];
        for (int i = 0; i < 5; i++)
        {
            data[i, 0] = double.MinValue;
            data[i, 1] = -1;
            data[i, 2] = -1;
        }
        double min = double.MinValue;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] > min)
                {
                    int k = 3;
                    while (k >= 0 && data[k, 0] < matrix[i, j])
                    {
                        data[k + 1, 0] = data[k, 0];
                        data[k + 1, 1] = data[k, 1];
                        data[k + 1, 2] = data[k, 2];
                        k--;
                    }
                    data[k + 1, 0] = matrix[i, j];
                    data[k + 1, 1] = i;
                    data[k + 1, 2] = j;
                    min = data[4, 0];
                }
            }
        }
        for (int i = 0; i < 5; i++)
        {
            if (data[i, 1] != -1) matrix[(int)data[i, 1], (int)data[i, 2]] *= matrix[(int)data[i, 1], (int)data[i, 2]] > 0 ? 4 : (0.25);
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] *= matrix[i, j] > 0 ? 0.5 : 2;
            }
        }
    }
    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here

        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);
        // end
    }
    public int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int answer = 0;
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        for (int i = 0; i < m; i++)
        {
            if (matrix[rowIndex, i] < 0) answer++;
        }
        return answer;
    }
    public int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int answer = 0;
        int max = 0;
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            int currentCount = CountNegativeInRow(matrix, i);
            if (currentCount > max)
            {
                answer = i;
                max = currentCount;
            }
        }
        return answer;
    }
    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);
        UpdateMatrix(A);
        UpdateMatrix(B);
        // end
    }

    public void FindRowMaxIndex(int[,] matrix, int rowIndex, out int columnIndex)
    {
        int max = matrix[rowIndex, 0];
        columnIndex = 0;
        int m = matrix.GetLength(1);
        for (int i = 0; i < m; i++)
        {
            if (matrix[rowIndex, i] > max)
            {
                max = matrix[rowIndex, i];
                columnIndex = i;
            }
        }
    }
    public void ReplaceMaxElementOdd(int[,] matrix, int row, int column)
    {
        matrix[row, column] *= (column + 1);
    }
    public void ReplaceMaxElementEven(int[,] matrix, int row, int column)
    {
        matrix[row, column] = 0;
    }
    public void UpdateMatrix(int[,] matrix)
    {
        GetMatrixSize(matrix, out int n, out int m);
        for (int i = 0; i < n; i++)
        {
            FindRowMaxIndex(matrix, i, out int columnIndex);
            if (i % 2 == 1) ReplaceMaxElementEven(matrix, i, columnIndex);
            else ReplaceMaxElementOdd(matrix, i, columnIndex);
             
        }
        
    }
    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        // end
    }
    #endregion

    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x
        firstSumAndY = GetSumAndY(Sum1, y1, 0.1, 1, 0.1);
        secondSumAndY = GetSumAndY(Sum2, y2, Math.PI / 5, Math.PI, Math.PI / 25);
        // end
    }
    public delegate double SumFunction(double x);
    public double Sum1(double x)
    {
        double sum = 1;
        double chisl = Math.Cos(x);
        double factorial = 1;
        double currentElement = chisl / factorial;
        for (int i = 2; Math.Abs(currentElement) > 0.0001; i++)
        {
            sum += currentElement;
            chisl = Math.Cos(i*x);
            factorial *= i;
            currentElement = chisl / factorial;
        }
        return sum;
    }
    public double Sum2(double x)
    {
        double sum = 0;
        double pow = -1;
        double chisl = Math.Cos(x);
        double currentElement = pow * chisl;

        for (int i = 2; Math.Abs(currentElement) > 0.0001; i++)
        {
            sum += currentElement;
            pow *= -1;
            chisl = Math.Cos(i * x);
            currentElement = pow * chisl / (i * i);
        }
        return sum;
    }
    public delegate double YFunction(double x);
    public double y1(double x)
    {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }
    public double y2(double x)
    {
        return (x * x - Math.PI * Math.PI / 3) / 4;
    }
    public double[,] GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h)
    {
        double[,] answer = new double[(int)((b - a) / h) + 1, 2];
        int i = 0;
        for (double x = a; Math.Round(x, 5) <= b; x += h)
        {
            answer[i, 0] = sFunction(x);
            answer[i, 1] = yFunction(x);
            i++;
        }
        return answer;
    }
    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
    }

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        SwapDirection swapper = default(SwapDirection);

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)
        double avg = GetSum(array) / array.Length;
        if (array[0] > avg) swapper = SwapLeft;
        else swapper = SwapRight;
        swapper(array);
        answer = GetSumOddIndexes(array);
        // end

        return answer;
    }

    public delegate void SwapDirection(double[] array);
    public void SwapRight(double[] array)
    {
        for (int i = array.Length - 2; i >= 0; i-=2)
        {
            double p = array[i];
            array[i] = array[i + 1];
            array[i + 1] = p;
        }
    }
    public void SwapLeft(double[] array)
    {
        for (int i = 0; i < array.Length - 1; i+=2)
        {
            double p = array[i];
            array[i] = array[i + 1];
            array[i + 1] = p;
        }
    }

    public double GetSumOddIndexes(double[] array)
    {
        double sum = 0;
        for (int i = 1; i < array.Length; i += 2) sum += array[i];
        return sum;
    }
    public double GetSum(double[] array)
    {
        double sum = 0;
        for (int i = 0; i < array.Length; i++) sum += array[i];
        return sum;
    }
    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

        // end

        return answer;
    }

    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions
        func1 = CountSignFlips(y3, 0, 2, 0.1);
        func2 = CountSignFlips(y4, -1, 1, 0.2);
        // end
    }
    public double y3(double x)
    {
        return x * x - Math.Sin(x);
    }
    public double y4(double x)
    {
        return Math.Exp(x) - 1;
    }
    public int CountSignFlips(YFunction yFunction, double a, double b, double h)
    {
        int answer = 0;
        double prevY = yFunction(a);
        int prevZnak = prevY > 0 ? 1 : -1;
        for (double x = a + h; x <= b; x += h)
        {
            double currentY = yFunction(x);
            int currentZnak = currentY > 0 ? 1 : -1;
            if (currentZnak != prevZnak) answer++;
            prevZnak = currentZnak;
        }
        return answer;
    }
    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);
        B = InsertColumn(B, CountRowPositive, C, CountColumnPositive);
        // end
    }
    public int[,] InsertColumn(int[,] matrixB, CountPositive CountRow, int[,] matrixC, CountPositive CountColumn)
    {
        GetMatrixSize(matrixB, out int n1, out int m1);
        GetMatrixSize(matrixC, out int n2, out int m2);

        int maxPositiveInRow = 0;
        int maxPositiveInRowIndex = 0;
        for (int i = 0; i < n1; i++)
        {
            int currentCountRowPositive = CountRow(matrixB, i);
            if (currentCountRowPositive > maxPositiveInRow)
            {
                maxPositiveInRow = currentCountRowPositive;
                maxPositiveInRowIndex = i;
            }
        }

        int maxPositiveInColumn = 0;
        int maxPositiveInColumnIndex = 0;
        for (int i = 0; i < m2; i++)
        {
            int currentCountColumnPositive = CountColumn(matrixC, i);
            if (currentCountColumnPositive > maxPositiveInColumn)
            {
                maxPositiveInColumn = currentCountColumnPositive;
                maxPositiveInColumnIndex = i;
            }
        }

        int[,] newB = new int[n1 + 1, m1];
        for (int i = 0; i < n1; i++)
        {
            for (int j = 0; j < m1; j++)
            {
                if (i <= maxPositiveInRowIndex)
                {
                    if (i == maxPositiveInRowIndex) newB[i + 1, j] = matrixC[j, maxPositiveInColumnIndex];
                    newB[i, j] = matrixB[i, j];
                }
                else
                {
                    newB[i + 1, j] = matrixB[i, j];
                }
            }
        }
        return newB;

    }
    public delegate int CountPositive(int[,] matrix, int index);
    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me

        // code here

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        // end
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)
        matrix = RemoveRows(matrix, FindRowIndexWithMaxElement, FindRowIndexWithMinElement);
        // end
    }

    public delegate int FindElementDelegate(int[,] matrix);
    public int[,] RemoveRows(int[,] matrix, FindElementDelegate findMax, FindElementDelegate findMin)
    {
        int rowMax = findMax(matrix);
        int rowMin = findMin(matrix);
        matrix = RemoveRow(matrix, rowMax);
        if (rowMax < rowMin) matrix = RemoveRow(matrix, rowMin - 1);
        else if (rowMax > rowMin) matrix = RemoveRow(matrix, rowMin);
        return matrix;
    }
    public int FindRowIndexWithMinElement(int[,] matrix)
    {
        int rowIndex = 0;
        int minElement = matrix[0, 0];
        GetMatrixSize(matrix, out int n, out int m);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] < minElement)
                {
                    minElement = matrix[i, j];
                    rowIndex = i;
                }
            }
        }
        return rowIndex;
    }
    public int FindRowIndexWithMaxElement(int[,] matrix)
    {
        int rowIndex = 0;
        int maxElement = matrix[0, 0];
        GetMatrixSize(matrix, out int n, out int m);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] > maxElement)
                {
                    maxElement = matrix[i, j];
                    rowIndex = i;
                }
            }
        }
        return rowIndex;
    }
    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);
        EvenOddRowsTransform(A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(B, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        // end
    }
    public delegate void ReplaceMaxElement(int[,] matrix, int rowIndex, int max);
    public void EvenOddRowsTransform(int[,] matrix, ReplaceMaxElement replaceMaxElementOdd, ReplaceMaxElement replaceMaxElementEven)
    {
        GetMatrixSize(matrix, out int n, out int m);
        for (int i = 0; i < n; i++)
        {
            FindRowMaxIndex(matrix, i, out int columnIndex);
            if (i % 2 == 1) replaceMaxElementEven(matrix, i, columnIndex);
            else replaceMaxElementOdd(matrix, i, columnIndex);

        }

    }
    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        // end
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        MatrixConverter[] mc = new MatrixConverter[4];

        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle
        // end
        mc[0] = ToUpperTriangular;
        mc[1] = ToLowerTriangular;
        mc[2] = ToLeftDiagonal;
        mc[3] = ToRightDiagonal;

        mc[index](matrix);
        return matrix;
    }
    public delegate void MatrixConverter(double[,] matrix);
    public void ToUpperTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                double ratio = matrix[j, i] / matrix[i, i];
                for (int k = i; k < n; k++)
                {
                    matrix[j, k] -= matrix[i, k] * ratio;
                }
            }
        }
    }
    public void ToLowerTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (int i = n-1; i >= 0; i--)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                double ratio = matrix[j, i] / matrix[i, i];
                for (int k = i; k >= 0; k--)
                {
                    matrix[j, k] -= matrix[i, k] * ratio;
                }
            }
        }
    }
    public void ToLeftDiagonal(double[,] matrix)
    {
        ToUpperTriangular(matrix);
        ToLowerTriangular(matrix);
    }
    public void ToRightDiagonal(double[,] matrix)
    {
        ToLowerTriangular(matrix);
        ToUpperTriangular(matrix);
    }
    #endregion
}
