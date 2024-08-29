using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_4
{
    using System;

    class Matrix<T> where T : IComparable<T>
    {
        private T[,] data;

        public Matrix(T[,] data)
        {
            this.data = data;
        }

        public void ShellSort()
        {
            int n = data.Length;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    T temp = data[i / data.GetLength(1), i % data.GetLength(1)];

                    int j = i;
                    while (j >= gap && data[(j - gap) / data.GetLength(1), (j - gap) % data.GetLength(1)].CompareTo(temp) > 0)
                    {
                        data[j / data.GetLength(1), j % data.GetLength(1)] = data[(j - gap) / data.GetLength(1), (j - gap) % data.GetLength(1)];
                        j -= gap;
                    }

                    data[j / data.GetLength(1), j % data.GetLength(1)] = temp;
                }

                gap /= 2;
            }
        }

        public void MergeSort()
        {
            T[,] tempData = new T[data.GetLength(0), data.GetLength(1)];
            Array.Copy(data, tempData, data.Length);

            MergeSortRec(tempData, 0, data.GetLength(0) - 1);
        }

        private void MergeSortRec(T[,] tempData, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSortRec(tempData, left, mid);
                MergeSortRec(tempData, mid + 1, right);

                Merge(tempData, left, mid, right);
            }
        }

        private void Merge(T[,] tempData, int left, int mid, int right)
        {
            int i = left;
            int j = mid + 1;
            int k = left;

            T[,] mergedData = new T[data.GetLength(0), data.GetLength(1)];
            Array.Copy(data, mergedData, data.Length);

            while (i <= mid && j <= right)
            {
                if (tempData[i / data.GetLength(1), i % data.GetLength(1)].CompareTo(tempData[j / data.GetLength(1), j % data.GetLength(1)]) <= 0)
                {
                    mergedData[k / data.GetLength(1), k % data.GetLength(1)] = tempData[i / data.GetLength(1), i % data.GetLength(1)];
                    i++;
                }
                else
                {
                    mergedData[k / data.GetLength(1), k % data.GetLength(1)] = tempData[j / data.GetLength(1), j % data.GetLength(1)];
                    j++;
                }
                k++;
            }

            while (i <= mid)
            {
                mergedData[k / data.GetLength(1), k % data.GetLength(1)] = tempData[i / data.GetLength(1), i % data.GetLength(1)];
                i++;
                k++;
            }

            while (j <= right)
            {
                mergedData[k / data.GetLength(1), k % data.GetLength(1)] = tempData[j / data.GetLength(1), j % data.GetLength(1)];
                j++;
                k++;
            }

            data = mergedData;
        }
    }

}
