using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    //Added the Game class
    internal class Game
    {
        //Global integers for the rows and columns, and a bool to check if the board is populated
        int width;
        int height;
        bool boardPopulated = false;
        Cell cell = new Cell();
        string Alive;
        string Dead;


        Random random = new Random();

        //Instantiates a Cell board
        Cell[,] board;

        //Public game constructor
        public Game()
        {

            Alive = cell.AliveSymbol;
            Dead = cell.DeadSymbol;
        }



        //Generate Board Method
        public void GenerateBoard()
        {
            //gets random height and width, sets the board to the cell
            height = random.Next(6, 24);
            width = random.Next(6, 24);
            board = new Cell[height, width];
            boardPopulated = true;

            //For loop to set height
            for (int i = 0; i < height; i++)
            {
                //for loop to set width
                for (int j = 0; j < width; j++)
                {
                    board[i, j] = new Cell();
                }
            }


            //writes out the board's height and width
            Console.WriteLine($"I am generating a board of {height} x {width}!");


        }

        //Method for diplaying the board
        public void DisplayBoard()
        {

            //if statement that checks if has board is false or true
            if (HasBoard() == false)
            {
                Console.WriteLine("WARNING! There is no Board to Load!");
                //return;
            }


            //For loop to get height
            for (int i = 0; i < height; i++)
            {
                //For loop to get width
                for (int j = 0; j < width; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }

            //Popup for the sub menu
            Console.WriteLine("1 - Advance, 2 - Save Current Board, or 3 - Main Menu?");
            int choice = int.Parse(Console.ReadLine());
            
            //Choice for advancing
            if (choice == 1)
            {
                Console.WriteLine("Advance choice to be implemented");
            }
            
            //Choice for saving the current board
            else if (choice == 2)
            {
                Save("Junk.txt");
            }
            
            //choice for Main Menu
            else if (choice == 3)
            {
                return;
            }

        }

        //Had Board Method
        public bool HasBoard()
        {
            //if statement to check if the board is populated
            if (boardPopulated == true)
            {
                return true;
            }

            //else statement for the if statement
            else
            {
                return false;
            }
        }

        //Method for loading the file
        public void Load(string FileName)
        {
            //Streamreader for conway's game of life
            StreamReader conway = null;

            try
            {
                //try block for reading the board
                conway = new StreamReader(FileName);

                string size = "";

                string symbol = "";

                string lineFromFile = "";

                //readline for size
                size = conway.ReadLine();

                //split size that gets the dimentions for height and width and parses it into that
                string[] splitSize = size.Split(",");
                height = int.Parse(splitSize[0]);
                width = int.Parse(splitSize[1]);


                //readline for symbol
                symbol = conway.ReadLine();

                //split symbol that gets which symbol is used for alive cells and dead cells, and puts them into the right
                //position
                string[] splitSymbol = symbol.Split(",");
                Alive = splitSymbol[0];
                Dead = splitSymbol[1];

                //gets height and width from the file, sets the board to the file
                board = new Cell[height, width];
                boardPopulated = true;

                //for loop to get the height
                for (int i = 0; i < height; i++)
                {
                    //for loop to get the width
                    for (int j = 0; j < width; j++)
                    {
                        board[i, j] = new Cell();
                    }
                }

                //while loop that sets the linefromfile to read the next conway line as long as there's lines left to read
                while ((lineFromFile = conway.ReadLine()!) != null)
                {
                    //Gets the save file, tries to save them but it doesn't do a very good job at it. I'm not well versed
                    //in how to take a string and break it into individual pieces without a split character
                    string[] splitLife = lineFromFile.Split();
                    for (int i = 0; i < splitLife.Length; i++)
                    {
                        if (splitLife[i] == "")
                        {
                            Console.Write(Alive);
                        }
                        else
                        {
                            Console.Write(Dead);
                        }
                            
                    }
                    Console.WriteLine();

                }



            }
            //catch for the reader
            catch
            {
                Console.WriteLine("Problem reading the file!");
            }


            //end of the try catch to close the reader
            finally
            {
                if (conway != null)
                {
                    conway.Close();
                }
            }
            //Popup for the sub menu
            Console.WriteLine("1 - Advance, 2 - Save Current Board, or 3 - Main Menu?");
            int choice = int.Parse(Console.ReadLine());

            //Choice for advancing
            if (choice == 1)
            {
                Console.WriteLine("Advance choice to be implemented");
            }

            //Choice for saving the current board
            else if (choice == 2)
            {
                Save("Junk.txt");
            }

            //choice for Main Menu
            else if (choice == 3)
            {
                return;
            }

        }

        //Method for saving the game
        public void Save(string FileName)
        {
            StreamWriter output = null;
            Cell cell = new Cell();
            //try catch for saving the board's attributes
            try
            {
                //Writer for the output
                output = new StreamWriter(FileName);
                output.Write(height);
                output.Write(", ");
                output.WriteLine(width);
                output.Write(cell.AliveSymbol);
                output.Write(", ");
                output.WriteLine(cell.DeadSymbol);

                //Copied for loop to write the board to the output
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (board[i, j].Alive == Alive)
                        {
                            output.Write("x");
                        }
                        else
                        {
                            output.Write("o");
                        }    
                    }
                    output.WriteLine();
                }
                output.Close();

            }

            //catch for saving the board
            catch
            {
                Console.WriteLine("Problem writing to the file!");
            }


            //end of the try catch to close the writer
            finally
            {
                if (output != null)
                {
                    output.Close();
                }
            }

        }
        }
    }
