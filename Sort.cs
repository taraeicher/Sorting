using System;
using System.Collections.Generic;
using System.Linq;

/*Project Number:Team Project - Sorting
 *Date: 16 December 2011
 *Programmer Names: Heather Ranney, Stephanie Goedde, Tara Eicher
 *Program Description: This class contains sorting algorithms in the form of methods to sort arrays of
 *      comparable objects. The radix sort handles only integers, and the bucket sort handles only 
 *      integers and strings. Properties within the class return the number of swaps made, the number 
 *      of comparisons made, the number of elements sorted, the array passed in through the methods,
 *      and the time elapsed.
 */

namespace SortingAlgorithms
{
    public class Sort<T> where T:IComparable
    {
        
        int numSorted=0, numComparisons=0, numSwaps=0;
        double time;

        //container for radix sort
        public struct KVEntry
        {
            int key, value;

            public int Key
            {
                get { return key; }
                set { key = value; }
            }

            public int Value
            {
                get { return value; }
                set { this.value = value; }
            }
        }
        
        //Property for StopWatch
        public double Time
        {
            get { return time; }
            set { time = value; }
        }

        //Property holds the number of elements sorted by the chosen sort method.
        public int NumberOfElementsSorted
        {
            get { return numSorted; }
            set { numSorted = value; }
        }

        //Property holds the number of comparisons performed by the chosen sort method.
        public int NumberOfComparisonsPerformed
        {
            get { return numComparisons; }
            set { numComparisons = value; }
        }

        //Property holds the number of swaps performed by the chosen sort method.
        public int NumberofSwapsMade
        {
            get { return numSwaps; }
            set { numSwaps = value; }
        }
        //SelectionSort
        public T[] Selection(T[] sortArray)
        {
            int smallest; //index of smallest element

            //start timer
            StopWatch a = new StopWatch();
            a.Start();

            //loop through array
            for (int i = 0; i < sortArray.Length - 1; i++)
            {
                smallest = i;//first index of remaining array

                //loop to find index of smallest element
                for (int index = i + 1; index < sortArray.Length; index++)
                {
                    numComparisons++;

                    if (sortArray[index].CompareTo(sortArray[smallest]) < 0)
                    {
                        smallest = index;
                        numComparisons++;
                    }
                }

                //calls method to swap elements
                SwapSelect(i, smallest, sortArray);
            }
            numSwaps++;

            //stops timer and calculates difference
            a.Stop();
            time = a.GetElapsedTime();
            numSorted = sortArray.Length;

            return sortArray;//returns array to gui

        }

        //helper method-swaps for selection sort
        private void SwapSelect(int first, int second, T[] sortArray)
        {
            T temporary = sortArray[first];
            sortArray[first] = sortArray[second];
            sortArray[second] = temporary;
            numSwaps++;
        }

        public T[] MergeSort(T[] sortArray)
        {
            //starts timer
            StopWatch a = new StopWatch();
            a.Start();

            //calls method to sort
            SortArrayMerge(0, sortArray.Length - 1, sortArray);

            //stops timer and calculates difference
            a.Stop();
            time = a.GetElapsedTime();
            numSorted = sortArray.Length;

            return sortArray;//returns array to gui
        }

        //recursive method to split array, sort subarrays and merge back into one array
        private void SortArrayMerge(int intLow, int intHigh, T[] sortArray)
        {
            //tests # of elements in array
            if ((intHigh - intLow) >= 1)
            {
                numComparisons++;
                int intMid1 = (intLow + intHigh) / 2;//find middle of array
                int intMid2 = intMid1 + 1;//find next element after middle

                SortArrayMerge(intLow, intMid1, sortArray);//first half of array-recursive calls
                SortArrayMerge(intMid2, intHigh, sortArray);//second half or array-recursive calls

                //merge two sorted subarrays into one
                Merge(intLow, intMid1, intMid2, intHigh, sortArray);
            }
        }

        //helper method for MergeSort-merges subarrays into one
        private void Merge(int intLeft, int intMid1, int intMid2, int intRight, T[] sortArray)
        {
            int intLeftIndex = intLeft;
            int intRightIndex = intMid2;
            int intComboIndex = intLeft;
            T[] combined = new T[sortArray.Length];

            //merge arrays until reaching end of either
            while (intLeftIndex <= intMid1 && intRightIndex <= intRight)
            {
                //places smaller of two current elements into result and move
                //to next space in arrays
                if (sortArray[intLeftIndex].CompareTo(sortArray[intRightIndex]) < 0)
                {
                    numComparisons++;
                    combined[intComboIndex++] = sortArray[intLeftIndex++];
                    numSwaps++;
                }
                else
                {
                    numComparisons++;
                    combined[intComboIndex++] = sortArray[intRightIndex++];
                    numSwaps++;
                }
            }

            //if left array is empty
            if (intLeftIndex == intMid2)
            {
                //copy in rest of right array
                while (intRightIndex <= intRight)
                {
                    combined[intComboIndex++] = sortArray[intRightIndex++];
                }
            }
            else//right array is empty
            {
                //copy in rest of left array
                while (intLeftIndex <= intMid1)
                {
                    combined[intComboIndex++] = sortArray[intLeftIndex++];
                }
            }

            //copy values back into original array
            for (int i = intLeft; i <= intRight; i++)
            {
                sortArray[i] = combined[i];
            }
        }

        public T[] RadixSort(T[] sortArray)
        {
            //start timer
            StopWatch a = new StopWatch();
            a.Start();

            //create new array type int of length sortArray
            int[] intSortArray = new int[sortArray.Length];
            //convert from type T to type int and put into new array
            for (int k = 0; k < sortArray.Length; k++)
            {
                intSortArray[k] = Convert.ToInt32(sortArray[k]);
            }

            //call recursive method for sort and set result = to intSortArray
            intSortArray = RadixSortAux(intSortArray, 1);

            //convert back to type T and put back into sortArray
            for (int k = 0; k < intSortArray.Length; k++)
            {
                sortArray[k] = (T)Convert.ChangeType(intSortArray[k], typeof(T));
            }

            //stop timer and calculate difference
            a.Stop();
            time = a.GetElapsedTime();
            numSorted = sortArray.Length;

            //return to gui
            return sortArray;
        }

        //recursive method for radix sort
        private int[] RadixSortAux(int[] intSortArray, int digit)
        {
            bool Empty = true;//set depending on if array is empty
            //array will hold key and value for type struct KVEntry
            KVEntry[] digits = new KVEntry[intSortArray.Length];
            //array to hold sorted values
            int[] SortedArray = new int[intSortArray.Length];

            //checks each element in array and sets key and value
            //also checks if there is a current digit placeholder
            for (int i = 0; i < intSortArray.Length; i++)
            {
                digits[i] = new KVEntry();//initialized array
                digits[i].Key = i;//sets key to i
                //sets value to current digit placeholder(i.e. 1, 10, 100)
                digits[i].Value = (intSortArray[i] / digit) % 10;
                numComparisons++;
                //checks if value exists for current digit placeholder
                if (intSortArray[i] / digit != 0)
                    Empty = false;
            }

            //if no current digit placeholder
            if (Empty)
            {
                //initializes array to hold final sorted values
                int[] finalIntSort = new int[intSortArray.Length];
                //places sorted values into final sorted array
                for (int j = 0; j < intSortArray.Length; j++)
                {
                    finalIntSort[j] = intSortArray[j];
                }

                return finalIntSort;//returns to method RadixSort               
            }
            else
            {
                //sets array = to method CountingSort using digits array
                KVEntry[] SortedDigits = CountingSort(digits);
                //puts newly sorted values into SortedArray
                for (int i = 0; i < SortedArray.Length; i++)
                    SortedArray[i] = intSortArray[SortedDigits[i].Key];
                //returns current sort and recalls method with current values and current digit*10
                return RadixSortAux(SortedArray, digit * 10);
            }
        }

        //method that swaps elements for radix sort
        private KVEntry[] CountingSort(KVEntry[] ArrayA)
        {
            //new array of length MaxValue + 1
            int[] ArrayB = new int[MaxValue(ArrayA) + 1];
            //new array of length arrayA/SortedArray
            KVEntry[] ArrayC = new KVEntry[ArrayA.Length];

            //sets arrayB values to 0
            for (int i = 0; i < ArrayB.Length; i++)
            {
                ArrayB[i] = 0;
            }

            //value of arrayA index i becomes index of arrayB
            //value for arrayB becomes # of elements with same value in arrayA
            //values added separately in loop
            for (int i = 0; i < ArrayA.Length; i++)
            {
                ArrayB[ArrayA[i].Value]++;
                numSwaps++;
            }

            //adds values from index i and (i-1) and places at i
            for (int i = 1; i < ArrayB.Length; i++)
            {
                ArrayB[i] += ArrayB[i - 1];
                numSwaps++;
            }

            for (int i = ArrayA.Length - 1; i >= 0; i--)
            {
                //gets value for arrayA at index i
                int value = ArrayA[i].Value;
                //gets value for arrayB and index value
                int index = ArrayB[value];
                //subtracts 1 from value
                ArrayB[value]--;
                //next 3 steps put values in arrayC-values for current placeholder are now sorted
                ArrayC[index - 1] = new KVEntry();
                ArrayC[index - 1].Key = i;
                ArrayC[index - 1].Value = value;
                numSwaps++;
            }
            return ArrayC;//returns to method RadixSortAux
        }

        //method for radix-determines largest # of current placeholder
        private int MaxValue(KVEntry[] arr)
        {
            int Max = arr[0].Value;//value of first element
            //compares with rest of elements in array and sets max to largest
            for (int i = 1; i < arr.Length; i++)
                if (arr[i].Value > Max)
                {
                    Max = arr[i].Value;
                    numComparisons++;
                }
            return Max;//returns value to CountingSort method
        }

        public T[] HeapSort(T[] sortArray)
        {
            int n = sortArray.Length;

            //start timer
            StopWatch a = new StopWatch();
            a.Start();

            for (int i = (n / 2); i > 0; i--)
            {
                shiftDown(sortArray, i, n);
                numComparisons++;
            }

            do
            {
                SwapHeap(sortArray, 0, n - 1);
                n = n - 1;
                shiftDown(sortArray, 1, n);
                numComparisons++;
            }
            while (n > 1);

            //stop timer and calculate difference
            a.Stop();
            time = a.GetElapsedTime();
            numSorted = sortArray.Length;

            //return array to gui
            return sortArray;
        }

        //method for heap sort-finds largest and rebuilds heap without
        private void shiftDown(T[] sortArray, int k, int n)
        {
            bool loop = true;
            int j;

            while ((k <= n / 2) && (loop))
            {

                j = k + k;
                if (j < n)
                {
                    numComparisons++;
                    if (sortArray[j - 1].CompareTo(sortArray[j]) < 0)
                    {
                        j++;
                        numComparisons++;
                    }
                }
                if (sortArray[k - 1].CompareTo(sortArray[j - 1]) >= 0)
                {
                    loop = false;
                    numComparisons++;
                }
                else
                {
                    SwapHeap(sortArray, k - 1, j - 1);
                    k = j;
                }
            }
        }

        //helper method for heap sort-performs swap
        private void SwapHeap(T[] sortArray, int left, int right)
        {
            object swap = sortArray[left];
            sortArray[left] = sortArray[right];
            sortArray[right] = (T)swap;
            numSwaps++;
        }

        //BubbleSort
        public T[] BubbleSort(T[] arrSort)
        {
            StopWatch a = new StopWatch();
            a.Start();

            T temp;
            int n = arrSort.Count();
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 1; j < n; j++)
                {
                    numComparisons++;
                    if (arrSort[j].CompareTo(arrSort[j - 1]) < 0)
                    {
                        temp = arrSort[j - 1];
                        arrSort[j - 1] = arrSort[j];
                        arrSort[j] = temp;
                        numSwaps++;
                    }
                }
            }

            a.Stop();
            time = a.GetElapsedTime();
            numSorted = arrSort.Length;

            return arrSort;
        }

        //InsertionSort
        public T[] InsertionSort(T[] arrSort)
        {
            StopWatch a = new StopWatch();
            a.Start();

            int intNumElements = arrSort.Length;
            int j;

            for (int i = 1; i < intNumElements; i++)
            {

                j = i;
                numComparisons++;
                while ((j > 0) && (arrSort[j - 1].CompareTo(arrSort[j])) > 0)
                {
                    T temp = arrSort[j - 1];
                    arrSort[j - 1] = arrSort[j];
                    arrSort[j] = temp;
                    j--;
                    numSwaps++;
                    numComparisons++;
                }
            }

            a.Stop();
            time = a.GetElapsedTime();
            numSorted = arrSort.Length;

            return arrSort;
        }

        //BucketSort Int
        public int[] BucketSort(int[] arrSort)
        {
            StopWatch a = new StopWatch();
            a.Start();

            if (arrSort.Count() == 0)
                throw new ArgumentNullException();

            else
            {
                int maxValue = arrSort[0];
                int minValue = arrSort[0];
                for (int i = 1; i < arrSort.Length; i++)
                {

                    if (arrSort[i].CompareTo(maxValue) > 0)
                    {
                        maxValue = arrSort[i];
                    }

                    if (arrSort[i].CompareTo(minValue) < 0)
                    {
                        minValue = arrSort[i];
                    }

                }

                List<int>[] bucket = new List<int>[maxValue - minValue + 1];

                for (int i = 0; i < bucket.Length; i++)
                {
                    bucket[i] = new List<int>();
                }

                for (int i = 0; i < arrSort.Length; i++)
                {
                    bucket[arrSort[i] - minValue].Add(arrSort[i]);
                    numSwaps++;
                    numComparisons++;
                }

                int k = 0;
                for (int i = 0; i < bucket.Length; i++)
                {
                    if (bucket[i].Count > 0)
                        for (int j = 0; j < bucket[i].Count; j++)
                        {
                            arrSort[k] = bucket[i][j];
                            k++;
                        }
                }
                a.Stop();
                time = a.GetElapsedTime();
                numSorted = arrSort.Length;

                return arrSort;
                
            }
        }

        //BucketSort String
        public string[] BucketSort(string[] arrSort)
        {
            StopWatch a = new StopWatch();

            a.Start();

            string[,] Bucket = new string[27, arrSort.Length];
            int o = 0;
            while (o < 12)
            {
                for (int r = 0; r < 27; r++)
                {
                    for (int c = 0; c < arrSort.Length; c++)
                    {
                        Bucket[r, c] = "";
                    }
                }
                int j = 0;
                for (int b = 0; b < arrSort.Length; b++ )
                    {
                        arrSort[b] = arrSort[b].ToUpper();   
                    }
                foreach (string element in arrSort)
                {
                    char[] arrChar = element.ToCharArray();
                    
                    if (arrChar.Length - (o + 1) < 0)
                    {
                        int placement = (int)arrChar[0] - 64;
                        Bucket[placement, j] = element;
                        j++;
                        
                    }
                    else
                    {
                        int index = arrChar.Length - (o + 1);
                        int placement = (int)arrChar[index] - 64;
                        Bucket[placement, j] = element;
                        j++;
                        numSwaps++;
                        numComparisons++;
                    }
                }
                int m = 0;
                for (int r = 0; r < 27; r++)
                {
                    for (int c = 0; c < arrSort.Length; c++)
                    {
                        if (Bucket[r, c] != "")
                        {
                            arrSort[m] = Bucket[r, c];
                            m++;
                        }
                    }
                }
                o++;
            }
            a.Stop();

            time = a.GetElapsedTime();

            numSorted = arrSort.Length;

            return arrSort;
        }
        //QuickSort
        public T[] QuickSort(T[] arrSort)
        {
            StopWatch a = new StopWatch();

            a.Start();

            QSort(0, arrSort.Length - 1,arrSort);
            a.Stop();

            time = a.GetElapsedTime();
            numSorted = arrSort.Length;
            return arrSort;
        }
        private void QSort(int leftIndex, int rightIndex,T[]arrSort)
        {
            int holdLeft, holdRight;
            int pivot;
            T pivotValue;

            holdLeft = leftIndex;
            holdRight = rightIndex;
            pivot = leftIndex;
            pivotValue = arrSort[leftIndex];

            while (leftIndex < rightIndex)
            {
                numComparisons++;
                while (arrSort[rightIndex].CompareTo(pivotValue) >= 0 && leftIndex < rightIndex)
                {
                    rightIndex--;
                    numComparisons++;
                }

                if (leftIndex != rightIndex)
                {
                    arrSort[leftIndex] = arrSort[rightIndex];
                    numSwaps++;
                    leftIndex++;
                }
                numComparisons++;
                while (arrSort[leftIndex].CompareTo(pivotValue) <= 0 && (leftIndex < rightIndex))
                {
                    leftIndex++;
                    numComparisons++;
                }

                if (leftIndex != rightIndex)
                {
                    arrSort[rightIndex] = arrSort[leftIndex];
                    numSwaps++;
                    rightIndex--;
                }

            }
            arrSort[leftIndex] = pivotValue;
            numSwaps++;
            pivot = leftIndex;
            leftIndex = holdLeft;
            rightIndex = holdRight;

            if (leftIndex < pivot)
            {
                QSort(leftIndex, pivot - 1,arrSort);
            }
            if (rightIndex > pivot)
            {
                QSort(pivot + 1, rightIndex,arrSort);
            }
        }

        }
    }

