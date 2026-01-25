using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndIndexers
{
    /// <summary>
    /// A list of doubles with custom written methods.
    /// </summary>
    internal class CustomList<T>
    {
        // --------------------------------------------------------------------
        // Fields of the class
        // --------------------------------------------------------------------

        private T[] data;      // Underlying array that holds all list data
        private int count;          // Size of the list

        // **************************************************
        // * Answer the following question:                 *
        // * - Why DON'T we need an extra field to hold     *
        // *   the list's capacity?                         *
        // **************************************************
        // ANSWER(s): 
        //
        // Lists can grow in size, and are not limited by a capacity.


        // --------------------------------------------------------------------
        // Properties of the class
        // --------------------------------------------------------------------

        /// <summary>
        /// Returns the current amount of data in the list.
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        // **************************************************
        // * Answer the following questions:                *
        // * - Why is the Count property get-only?          *
        // * - Why not include a set?                       *
        // **************************************************
        // ANSWER(s): 
        //
        // We don't want to set the count, but we want the knowledge of the actual count integer.
        // Setting the count is something the list code already does


        /// <summary>
        /// Returns the overall number of elements the internal data structure
        /// can hold before a resize operation.
        /// </summary>
        public int Capacity
        {
            get { return data.Length; }
        }


        /*
        // NOOOOO! Don't do this! This is included to show what NOT to do.
        public double[] Data
        {
            get { return data; }
            set { data = value; }
        }
        */
        // **************************************************
        // * Answer the following question:                 *
        // * - Why DON'T we want a property that gets or    *
        // *   sets the data array?                         *
        // **************************************************
        // ANSWER(s): 
        //
        // It messes with the Array itself, being able to set changes from outside of anything, and it should not be able
        // to have acces to make those changes, and getting the array could also harm the integrity of the array


        // --------------------------------------------------------------------
        // Indexer Property
        // --------------------------------------------------------------------

        // TODO: Write an indexer property with get and set
        //Added Indexer

        public T this[int index]
        {
            //Added the get method for the indexer
            get
            {
                if (index >= 0 && index < count)
                {
                    //returns the data at the index position if it's in a valid range
                    return data[index];
                }
                //makes a string for the exception message
                string exceptionMessage;

                //checks if the data's count is 0
                if (count == 0)
                {
                    //If count is zero, then there is no data in the list
                    exceptionMessage = "No data to retrieve, list is empty.";
                }

                //otherwise, checks if the count is out of range
                else
                {
                    //Builds an exception string that returns the position number requested by the user and the count number that
                    //it should be
                    exceptionMessage = String.Format(
                        "Index {0} is out of range. Index must be between 0 and {1}",
                        index,
                        count - 1);
                }
                //Catches anything that tries to put something in a negative position or larger than the size of the array
                throw new IndexOutOfRangeException(exceptionMessage);
            
            }
        

            //Set data for the intdex
            set
            {
                if (index >= 0 && index < count)
                {
                    data[index] = value;
                }
                else
                {
                    string exceptionMessage;

                    //checks if the data's count is 0
                    if (count == 0)
                    {
                        //If count is zero, then there is no data in the list
                        exceptionMessage = "No data to set, list is empty.";
                    }

                    //otherwise, checks if the count is out of range
                    else
                    {
                        //Builds an exception string that returns the position number requested by the user and the count number that
                        //it should be
                        exceptionMessage = String.Format(
                            "Index {0} is out of range. Index must be between 0 and {1}",
                            index,
                            count - 1);
                    }
                    //Catches anything that tries to put something in a negative position or larger than the size of the array
                    throw new IndexOutOfRangeException(exceptionMessage);
                }

            }

        }






        // --------------------------------------------------------------------
        // Class Constructors
        // --------------------------------------------------------------------

        /// <summary>
        /// Instantiates a new list of doubles with a starting size of 4.
        /// </summary>
        public CustomList()
        {
            data = new T[4];
        }


        /// <summary>
        /// Instantiates a new list of doubles with a specified starting size.
        /// </summary>
        /// <param name="listSize">Initial size of the list.</param>
        public CustomList(int listSize)
        {
            data = new T[listSize];
        }


        // --------------------------------------------------------------------
        // Methods
        // --------------------------------------------------------------------

        /// <summary>
        /// Add new data to the list.
        /// </summary>
        /// <param name="item">Item to add to the next available spot.</param>
        public void Add(T item)
        {
            // **************************************************
            // * Comment this conditional.                      *
            // * WHAT does it do and, more importantly,         *
            // * WHY is it happening?                           *
            // **************************************************

            //Checks if the add method is using up the last position in the array
            if (count == data.Length - 1)
            {
                // increases the size of the array by creating a new array that's two times larger.
                // This is required to make sure that the count position exists in the array
                IncreaseSizeAndCopyData();
            }

            // **************************************************
            // * Comment this code.                             *
            // * WHAT does it do and, more importantly,         *
            // * WHY is it happening?                           *
            // **************************************************

            //Changing what's at position count in the data array with what's in the variable called 'item'
            data[count] = item;

            //adds one to the count size
            //the next time someone wants to add something to the array, it knows what position to go to
            count++;
        }


        // **************************************************
        // * Answer the following questions:                *
        // * - What is the purpose of a private method?     *
        // * - Why is the IncreaseSizeAndCopyData method    *
        // *   private?                                     *
        // **************************************************
        // ANSWER(s): 
        //
        //The purpose of a private method is to make sure that it exists but can't be accessed by anything outside it's original
        //class.
        //It's private so that nothing else can access it.

        /// <summary>
        /// Doubles the size of the data array.
        /// </summary>
        private void IncreaseSizeAndCopyData()
        {
            // **************************************************
            // * Comment this conditional.                      *
            // * WHAT does it do and, more importantly,         *
            // * WHY is it happening?                           *
            // **************************************************

            // Checks if the count position is in the range
            if (count != data.Length - 1)
            {

                // returns if the count position is in range and not at the last position
                // This is to check if we don't need to increase the size
                return;
            }

            // **************************************************
            // * Comment every line of this code.               *
            // * WHAT does it do and, more importantly,         *
            // * WHY is it happening?                           *
            // **************************************************

            //Creates a second array called larger copy that is double the size of the original
            T[] largerCopy = new T[data.Length * 2];

            //For loop that runs for the length of the original array
            for (int i = 0; i < data.Length; i++)
            {
                //Takes the same position data in the original array and puts it in the same positions in the larger array
                largerCopy[i] = data[i];
            }

            //Replaces the original array and rewrites it with the larger array
            data = largerCopy;
        }


        // **************************************************
        // * Answer the following questions:                *
        // * - Where is GetData's thrown exception being    *
        // *   caught?                                      *
        // * - Why is the thrown exception NOT caught       *
        // *   directly in the GetData method?              *
        // **************************************************
        // ANSWER(s): 
        //
        //It is being caught at the very end of the GetData Method
        //The thrown exception is not directly in the GetData Method because the throw exception needs to know
        //what exception is being found

        /// <summary>
        /// Retrieve data at an index.
        /// </summary>
        /// <param name="index">Integer index between 0 and the list's count.</param>
        /// <returns>Data at a specified index.</returns>
        /// <exception cref="Exception">Thrown exception when the index is out of range.</excepti
        /*public T GetData(int index)
        {
            // **************************************************
            // * Comment this conditional.                      *
            // * WHAT does it do and, more importantly,         *
            // * WHY is it happening?                           *
            // **************************************************

            //checks if the index is in a valid range of the data array
            if (index >= 0 && index < count)
            {
                //returns the data at the index position if it's in a valid range
                return data[index];
            }

            // **************************************************
            // * Comment every statement in this code.          *
            // * WHAT does it do and, more importantly,         *
            // * WHY is it happening?                           *
            // **************************************************

            //makes a string for the exception message
            string exceptionMessage;

            //checks if the data's count is 0
            if (count == 0)
            {
                //If count is zero, then there is no data in the list
                exceptionMessage = "No data to retrieve, list is empty.";
            }

            //otherwise, checks if the count is out of range
            else
            {
                //Builds an exception string that returns the position number requested by the user and the count number that
                //it should be
                exceptionMessage = String.Format(
                    "Index {0} is out of range. Index must be between 0 and {1}",
                    index,
                    count - 1);
            }
            //Catches anything that tries to put something in a negative position or larger than the size of the array
            throw new IndexOutOfRangeException(exceptionMessage);
        }
        */


        // TODO:  Add XML comment for this method
        /// <summary>
        /// Set Data at an index
        /// </summary>
        /// <param name="index">Integer index at a list's count.</param>
        /// <param name="newValue">The New Value set to the data at the specified insex</param>
        /* public void SetData(int index, T newValue)
    {
        // TODO:  Write the body of this method
        //Added the set for the newValue by checking if the index is in a valid position
        if (index >= 0 && index < count)
        {
            data[index] = newValue;
        }

        //Copied from code above in the GetData Method
        string exceptionMessage;

        //checks if the data's count is 0
        if (count == 0)
        {
            //If count is zero, then there is no data in the list
            exceptionMessage = "No data to retrieve, list is empty.";
        }

        //otherwise, checks if the count is out of range
        else
        {
            //Builds an exception string that returns the position number requested by the user and the count number that
            //it should be
            exceptionMessage = String.Format(
                "Index {0} is out of range. Index must be between 0 and {1}",
                index,
                count - 1);
        }
        //Catches anything that tries to put something in a negative position or larger than the size of the array
        throw new IndexOutOfRangeException(exceptionMessage);

        }*/

        
    }
    }

