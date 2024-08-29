using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_4
{
    using System;

    public class ArrayManager<T> where T : IComparable
    {
        private T[] array;
        private int size;

        public ArrayManager(int size)
        {
            this.size = size;
            array = new T[size];
        }

        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        public void FillWithDefaultValues(T defaultValue)
        {
            for (int i = 0; i < size; i++)
            {
                array[i] = defaultValue;
            }
        }

        public void MergeSort()
        {
            MergeSort(array, 0, array.Length - 1);
        }

        private void MergeSort(T[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        private void Merge(T[] array, int left, int mid, int right)
        {
            int leftSize = mid - left + 1;
            int rightSize = right - mid;

            T[] leftArray = new T[leftSize];
            T[] rightArray = new T[rightSize];

            Array.Copy(array, left, leftArray, 0, leftSize);
            Array.Copy(array, mid + 1, rightArray, 0, rightSize);

            int i = 0, j = 0, k = left;

            while (i < leftSize && j < rightSize)
            {
                if (leftArray[i].CompareTo(rightArray[j]) <= 0)
                {
                    array[k++] = leftArray[i++];
                }
                else
                {
                    array[k++] = rightArray[j++];
                }
            }

            while (i < leftSize)
            {
                array[k++] = leftArray[i++];
            }

            while (j < rightSize)
            {
                array[k++] = rightArray[j++];
            }
        }

        public void ShellSort()
        {
            int n = array.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    T temp = array[i];
                    int j;

                    for (j = i; j >= gap && array[j - gap].CompareTo(temp) > 0; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
            }
        }

        public T[] ToArray()
        {
            return array;
        }
    }
}
