
using System.Threading.Tasks.Sources;
using System.Diagnostics;
using PE_Dictionaries;

internal class Program
{
    public static void Main(string[] args)
        {

            Console.WriteLine("Test test!");
            //Dictionary for the players
            Dictionary<string, Player> playersDictionary = new Dictionary<string, Player>();

            //strings for getting the input
            string inputOne = null;
            string inputTwo = null;


            //creating player one
            if (string.IsNullOrEmpty(inputOne))
            {
                Console.WriteLine("Input Player 1's name: ");
                inputOne = Console.ReadLine();

                //while the Input is null, this will keep repeating 
                while (inputOne == null || inputOne == "")
                {
                    Console.WriteLine("Please input a valid name: ");
                    inputOne = Console.ReadLine();

                }
                Console.WriteLine("Player One's name is " + inputOne);
            }

            //Finishes the creation of player One!
            Player pOne = new Player(inputOne, 100);
            pOne.ToString();


            //Creating player two
            if (string.IsNullOrEmpty(inputTwo))
            {
                Console.WriteLine("Input Player 2's name: ");
                inputTwo = Console.ReadLine();

                //while the Input is null, this will keep repeating 
                while (inputTwo == null || inputTwo == "")
                {
                    Console.WriteLine("Please input a valid name: ");
                    inputOne = Console.ReadLine();

                }
                Console.WriteLine("Player One's name is " + inputTwo);
            }
    

            //Finishes the creation of player 2!
            Player pTwo = new Player(inputTwo, 500);
            pTwo.ToString();


            //Adds the new players to the dictionary
            playersDictionary.Add(inputOne, pOne);

            playersDictionary.Add(inputTwo, pTwo);


            //testing the keys
            Dictionary<string, Player>.KeyCollection keyColl = playersDictionary.Keys;

            //foreach loop that runs with every string in the keyColl.
            Console.WriteLine();
            foreach (string s in keyColl)
            {
                Console.WriteLine("Key = {0}", s);
            }

            //foreach loop that runs with every keyvalue pair in the dictionary
            Console.WriteLine();
            foreach (KeyValuePair<string, Player> kvp in playersDictionary)
            {
                Console.WriteLine(kvp.Key);
            }




        }
    
}