// See https://aka.ms/new-console-template for more information
using GameOfLife;

class Program
{
    //Added the Main method
    static void Main(string[] args)
    {
        //Menu Screen which displays all of the options and asks for the player's input
        Console.WriteLine("Welcome! Please select your Option:");
        Console.WriteLine("1 - Generate Board");
        Console.WriteLine("2 - Display Board");
        Console.WriteLine("3 - Load Board");
        Console.WriteLine("4 - Quit");
        Console.WriteLine("Your choice: ");
        Console.ReadLine();
        
        Game game = new Game();


        if (Console.ReadLine == 1)
        {
            GenerateBoard();
        }
        else if {Console.ReadLine == 2)
        {
            DisplayBoard();
        }





























    }

}