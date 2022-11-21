namespace Projekt_2_vistula
{
    internal class Program
    {
        static int[] BubbleArray = new int[20];
        static int[] SelectionArray = new int[20];
        static int[] InsertionArray = new int[20];
        static void Main(string[] args)
        {
            RandomizeArrayValues(BubbleArray);
            Console.WriteLine("Initial array");
            DisplayArray(BubbleArray);

            Console.WriteLine();

            Console.WriteLine("It took {0} swaps to sort this array", BubbleSorting(BubbleArray));
            DisplayArray(BubbleArray);

            Console.WriteLine();

            RandomizeArrayValues(InsertionArray);
            Console.WriteLine("Initial array");
            DisplayArray(InsertionArray);

            Console.WriteLine();

            Console.WriteLine("It took {0} swaps to sort this array", InsertSorting(InsertionArray));
            DisplayArray(InsertionArray);

            Console.WriteLine();

            RandomizeArrayValues(SelectionArray);
            Console.WriteLine("Initial array");
            DisplayArray(SelectionArray);

            Console.WriteLine();

            Console.WriteLine("It took {0} swaps to sort this array", SelectionSorting(SelectionArray));
            DisplayArray(SelectionArray);
        }

        /// <summary>
        /// Sorts the the values of 1d array via insert sorting algorithm 
        /// </summary>
        /// <param name="array"></param>
        private static int InsertSorting(int[] array)
        {
            Console.WriteLine("Sorting values via insert sorting algorithm");
            int noSwapCounter = 0;
            for (int i = 1; i <= array.Length - 1; i++)
            {
                int j = i;
                while (j > 0 && array[j - 1] > array[j])
                {
                    (int, int) temp = (array[j], array[j - 1]);
                    array[j] = temp.Item2;
                    array[j - 1] = temp.Item1;
                    noSwapCounter++;
                    j--;
                }
            }
            return noSwapCounter;
        }

        /// <summary>
        /// Sorts the the values of 1d array via selection sorting algorithm 
        /// </summary>
        /// <param name="array"></param>
        private static int SelectionSorting(int[] array)
        {
            Console.WriteLine("Sorting values via selection sorting algorithm");
            int noSwapCounter = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minValueIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minValueIndex])
                    {
                        minValueIndex = j;
                    }
                }

                (int, int) temp = (array[minValueIndex], array[i]);
                array[minValueIndex] = temp.Item2;
                array[i] = temp.Item1;
                noSwapCounter++;
            }
            return noSwapCounter;
        }

        /// <summary>
        /// Sorts the the values of 1d array via bubble sorting algorithm 
        /// </summary>
        /// <param name="array"></param>
        private static int BubbleSorting(int[] array)
        {
            Console.WriteLine("Sorting values via bubble sorting algorithm");
            int swapCounter = 0;      // tracks how many times numbers changed place
            int noSwapCounter = 0;   // track since when the last swap of values were made
                                      // when all values are sorted correctly this value is equal the array lenght
            bool done = true;         // ends the while loop when algorithm finishes sorting
            while (done)
            {

                for(int i = 0; i < array.Length-1; i++)
                {
                    if(array[i] > array[i+1])
                    {
                        noSwapCounter = 0;
                        (int, int) temp = (array[i], array[i + 1]);
                        array[i] = temp.Item2;
                        array[i + 1] = temp.Item1;
                        swapCounter++;
                    }
                    else
                    {
                        noSwapCounter++;
                        if (array.Length < noSwapCounter)
                        {
                            done = false;
                        }
                    }
                }
            }
            return noSwapCounter;
        }

        /// <summary>
        /// Inserts random values to all slots of the array
        /// </summary>
        /// <param name="array"></param>
        private static void RandomizeArrayValues(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 101);
            }
        }

        /// <summary>
        /// Displays all values from 1d array with int values
        /// </summary>
        /// <param name="array"></param>
        private static void DisplayArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                string output = array[i].ToString();
                Console.Write(output.PadRight(4));
            }
            Console.WriteLine();
        }
    }
}