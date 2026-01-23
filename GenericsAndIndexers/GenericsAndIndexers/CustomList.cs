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
        internal class CustomList
        {
            // --------------------------------------------------------------------
            // Fields of the class
            // --------------------------------------------------------------------

            private double[] data;      // Underlying array that holds all list data
            private int count;          // Size of the list

            // **************************************************
            // * Answer the following question:                 *
            // * - Why DON'T we need an extra field to hold     *
            // *   the list's capacity?                         *
            // **************************************************
            // ANSWER(s): 
            //
            // Lists can grow in size exponentially, we can check what's in our lists at any given time, and Lists can be
            // holding any number of objects at a time.


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
            // Setting the count to something else could potentially cause errors.


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
            // It messes with the Array itself, being able to set changes from outside of anything that should be able to
            // have access to make those changes, and getting the array could also harm the integrity of the array


            // --------------------------------------------------------------------
            // Indexer Property
            // --------------------------------------------------------------------

            // TODO: Write an indexer property with get and set




            // --------------------------------------------------------------------
            // Class Constructors
            // --------------------------------------------------------------------

            /// <summary>
            /// Instantiates a new list of doubles with a starting size of 4.
            /// </summary>
            public CustomList()
            {
                data = new double[4];
            }


            /// <summary>
            /// Instantiates a new list of doubles with a specified starting size.
            /// </summary>
            /// <param name="listSize">Initial size of the list.</param>
            public CustomList(int listSize)
            {
                data = new double[listSize];
            }


            // --------------------------------------------------------------------
            // Methods
            // --------------------------------------------------------------------

            /// <summary>
            /// Add new data to the list.
            /// </summary>
            /// <param name="item">Item to add to the next available spot.</param>
            public void Add(double item)
            {
                // **************************************************
                // * Comment this conditional.                      *
                // * WHAT does it do and, more importantly,         *
                // * WHY is it happening?                           *
                // **************************************************
                if (count == data.Length - 1)
                {
                    IncreaseSizeAndCopyData();
                }

                // **************************************************
                // * Comment this code.                             *
                // * WHAT does it do and, more importantly,         *
                // * WHY is it happening?                           *
                // **************************************************
                data[count] = item;
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
            //

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
                if (count != data.Length - 1)
                {
                    return;
                }

                // **************************************************
                // * Comment every line of this code.               *
                // * WHAT does it do and, more importantly,         *
                // * WHY is it happening?                           *
                // **************************************************
                double[] largerCopy = new double[data.Length * 2];

                for (int i = 0; i < data.Length; i++)
                {
                    largerCopy[i] = data[i];
                }

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
            //

            /// <summary>
            /// Retrieve data at an index.
            /// </summary>
            /// <param name="index">Integer index between 0 and the list's count.</param>
            /// <returns>Data at a specified index.</returns>
            /// <exception cref="Exception">Thrown exception when the index is out of range.</excepti
            public double GetData(int index)
            {
                // **************************************************
                // * Comment this conditional.                      *
                // * WHAT does it do and, more importantly,         *
                // * WHY is it happening?                           *
                // **************************************************
                if (index >= 0 && index < count)
                {
                    return data[index];
                }

                // **************************************************
                // * Comment every statement in this code.          *
                // * WHAT does it do and, more importantly,         *
                // * WHY is it happening?                           *
                // **************************************************
                string exceptionMessage;
                if (count == 0)
                {
                    exceptionMessage = "No data to retrieve, list is empty.";
                }
                else
                {
                    exceptionMessage = String.Format(
                        "Index {0} is out of range. Index must be between 0 and {1}",
                        index,
                        count - 1);
                }
                throw new IndexOutOfRangeException(exceptionMessage);
            }


            // TODO:  Add XML comment for this method
            public void SetData(int index, double newValue)
            {
                // TODO:  Write the body of this method
            }
        }
    }

