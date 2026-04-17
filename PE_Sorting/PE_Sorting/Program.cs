// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {

        //initializing the Bubble Array
        int[] bubbleArray = new int[10];


        //initializing the Selection Array
        int[] selectionArray = new int[10];


        //initializing the Insertion Array
        int[] insertionArray = new int[10];



        Random rand = new Random();

        
        //initializing the randomizer for the random values in the bubble array
        for(int i = 0; i < bubbleArray.Length; i++)
        {
            bubbleArray[i] = rand.Next(1, 11);
        }


        //initializing the randomizer for the random values in the selection array
        for (int i = 0; i < selectionArray.Length; i++)
        {
            selectionArray[i] = rand.Next(1, 11);
        }


        //initializing the randomizer for the random values in the insertion array
        for (int i = 0; i < insertionArray.Length; i++)
        {
            insertionArray[i] = rand.Next(1, 11);
        }



        //Console write for the Bubble Array
        BubbleSort(bubbleArray);
        foreach(int i in bubbleArray)
        {
            Console.Write(i + " ");
        }


        Console.WriteLine("");

        Console.WriteLine("");

        //Console Write for the Selection Array
        SelectionSort(selectionArray);
        foreach(int i in selectionArray)
        {
            Console.Write(i + " ");
        }


        Console.WriteLine("");

        Console.WriteLine("");

        //Console write for the Insertion Array
        InsertionSort(insertionArray);
        foreach (int i in insertionArray)
        {
            Console.Write(i + " ");
        }



        //initialized the stopwatch for the Array
        Stopwatch watch = new Stopwatch();

        //updated the array to make it bigger
        bubbleArray = new int[1000];

        //updated the array to make it bigger
        selectionArray = new int[1000];

        //updated the array to make it bigger
        insertionArray = new int[1000];

        //initializing the randomizer for the random values in the bubble array
        for (int i = 0; i < bubbleArray.Length; i++)
        {
            bubbleArray[i] = rand.Next(1, 101);
        }


        //initializing the randomizer for the random values in the selection array
        for (int i = 0; i < selectionArray.Length; i++)
        {
            selectionArray[i] = rand.Next(1, 101);
        }


        //initializing the randomizer for the random values in the insertion array
        for (int i = 0; i < insertionArray.Length; i++)
        {
            insertionArray[i] = rand.Next(1, 101);
        }


        //SECOND BUBBLE SORT:

        Console.WriteLine("");

        Console.WriteLine("");

        //starts the watch
        watch.Start();

        //Console write for the Bubble Array
        BubbleSort(bubbleArray);

        //stops the watch, then writes it out
        watch.Stop();

        Console.WriteLine("Total time: " + watch.Elapsed.TotalMilliseconds);


        //SECOND SELECTION SORT:

        Console.WriteLine("");

        Console.WriteLine("");

        //starts the watch
        watch.Start();

        //Console write for the selection Array
        SelectionSort(selectionArray);

        //stops the watch, then writes it out
        watch.Stop();

        Console.WriteLine("Total time: " + watch.Elapsed.TotalMilliseconds);


        //SECOND INSERTION SORT:

        Console.WriteLine("");

        Console.WriteLine("");

        //starts the watch
        watch.Start();

        //Console write for the insertion Array
        InsertionSort(insertionArray);

        //stops the watch, then writes it out
        watch.Stop();

        Console.WriteLine("Total time: " + watch.Elapsed.TotalMilliseconds);

    }



    public static void BubbleSort(int[] bubble)
    {
        for (int i = 0; i < bubble.Length - 1; i++)
        {
            for (int j = 0; j < bubble.Length - 1 - i; j++)
            {
                if (bubble[j] > bubble[j + 1])
                {
                    int bubbleTemp = bubble[j];
                    bubble[j] = bubble[j + 1];
                    bubble[j + 1] = bubbleTemp;
                }

            }

        }
    }

    public static void SelectionSort(int[] selection)
    {
        for (int i = 0; i < selection.Length; i++)
        {
            int selectionTemp = selection[i];
            int selectionSwap = i;

            for (int j = i + 1; j < selection.Length; j++)
            {
                if (selection[j] < selectionTemp)
                {
                    selectionTemp = selection[j];
                    selectionSwap = j;
                }
            }
            selection[selectionSwap] = selection[i];
            selection[i] = selectionTemp;
        }
    }

    public static void InsertionSort(int[] insertion)
    {
        for(int i = 1; i < insertion.Length; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (insertion[j] < insertion[j - 1] )
                {
                    int insertionTemp = insertion[j];
                    insertion[j] = insertion[j - 1];
                    insertion[j - 1] = insertionTemp;
                }
            }
        }


    }

}
