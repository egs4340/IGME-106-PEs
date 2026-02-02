// See https://aka.ms/new-console-template for more information
using GameOfLife;
using System.Xml.Serialization;

class Program
{
    //Added the Main method
    static void Main(string[] args)
    {
        //int for getting choice
        int menuChoice;

        //Game constructor
        Game game = new Game();

        //while loop to keep the game running after you make choices
        while (true)
        {

            //Menu Screen which displays all of the options and asks for the player's input
            Console.WriteLine("Welcome! Please select your Option:");
            Console.WriteLine("1 - Generate Board");
            Console.WriteLine("2 - Display Board");
            Console.WriteLine("3 - Load Board");
            Console.WriteLine("4 - Quit");
            Console.WriteLine("Your choice: ");

            //choice method to parse readlines
            menuChoice = int.Parse(Console.ReadLine());


            //If statement for choosing the generate board
            if (menuChoice == 1)
            {
                game.GenerateBoard();

            }

            //If statement for choosing the display board
            else if (menuChoice == 2)
            {
                game.DisplayBoard();
            }

            //

            else if (menuChoice == 3)
            {
                //
                Console.WriteLine("Enter a file name: ");

                string name = Console.ReadLine();

                game.Load(name);

                Console.WriteLine("File Loaded successfully");

            }

            //
            else if (menuChoice == 4)
            {
                Console.WriteLine("See you later!");
                return;
            }

            //bonus choice to save the game
            else if (menuChoice == 5)
            {
                game.Save("Junk.txt");
            }
        }




























    }

}