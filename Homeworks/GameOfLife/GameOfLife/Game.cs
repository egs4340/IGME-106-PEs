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
            width = random.Next(2, 5);
            height = random.Next(2, 5);
            board = new Cell[width, height];
            boardPopulated = true;

            //For loop to set height
            for (int i = 0; i < width; i++)
            {
                //for loop to set width
                for (int j = 0; j < height; j++)
                {
                    board[i, j] = new Cell();
                }
            }


            //writes out the board's height and width
            Console.WriteLine($"I am generating a board of {width} x {height}!");


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
            for (int j = 0; j < height; j++)
            {
                //For loop to get width
                for (int i = 0; i < width; i++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }

            //Popup for the sub menu
            int choice = 99;

            //loop to keep the submenu popping up
            while (choice != 3)
            {

                Console.WriteLine("1 - Advance, 2 - Save Current Board, or 3 - Main Menu?");
                choice = int.Parse(Console.ReadLine());


                //Choice for advancing


                // ALL OF THIS CODE WAS TAKEN FROM FURTHER BELOW IN THE CODE TO MAKE BOTH PARTS BE ABLE TO RUN IT
                
                if (choice == 1)
                {
                    Cell[,] futureBoard;

                    int neighborCount;

                    futureBoard = new Cell[width, height];

                    //for loops that:
                    //examine all the elements in board
                    //determine if they are alive or dead in the next round
                    //put x for dead or o for alive in future board
                    for (int i = 0; i < width; i++)
                    {
                        neighborCount = 0;

                        for (int j = 0; j < height; j++)
                        {
                            //check northwest
                            if (i - 1 >= 0 && j - 1 >= 0)
                            {
                                if (board[i - 1, j - 1].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //check north
                            if (j - 1 >= 0)
                            {
                                if (board[i, j - 1].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //check northeast
                            if (j - 1 >= 0 && i + 1 < width)
                            {
                                if (board[i + 1, j - 1].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //check west
                            if (i - 1 >= 0)
                            {
                                if (board[i - 1, j].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //check east
                            if (i + 1 < width)
                            {
                                if (board[i + 1, j].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //check south
                            if (j + 1 < height)
                            {
                                if (board[i, j + 1].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //check southwest
                            if (j + 1 < height && i - 1 >= 0)
                            {
                                if (board[i - 1, j + 1].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //check southeast
                            if (j + 1 < height && i + 1 < width)
                            {
                                if (board[i + 1, j + 1].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //sets the cell to dead
                            if (neighborCount <= 1)
                            {
                                futureBoard[i, j] = new Cell();
                                futureBoard[i, j].AliveSymbol = Dead;
                                futureBoard[i, j].alive = false;
                            }

                            //sets the cell to alive
                            if (neighborCount == 2 || neighborCount == 3)
                            {
                                futureBoard[i, j] = new Cell();
                                futureBoard[i, j].AliveSymbol = Alive;
                                futureBoard[i, j].alive = true;

                            }

                            //sets the cell to dead
                            if (neighborCount >= 4)
                            {
                                futureBoard[i, j] = new Cell();
                                futureBoard[i, j].AliveSymbol = Dead;
                                futureBoard[i, j].alive = false;
                            }

                            //sets the dead symbol to life
                            if (board[i, j].alive != true && neighborCount == 3)
                            {
                                futureBoard[i, j] = new Cell();
                                futureBoard[i, j].AliveSymbol = Alive;
                                futureBoard[i, j].alive = true;
                            }
                        }


                    }
                    //sets the board to the futureboard
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            board[i, j] = futureBoard[i, j];
                        }
                    }

                    DisplayBoard();
                }
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
                width = int.Parse(splitSize[0]);
                height = int.Parse(splitSize[1]);


                //readline for symbol
                symbol = conway.ReadLine();

                //split symbol that gets which symbol is used for alive cells and dead cells, and puts them into the right
                //position
                string[] splitSymbol = symbol.Split(",");
                Alive = splitSymbol[0];
                Dead = splitSymbol[1];

                //gets height and width from the file, sets the board to the file
                board = new Cell[width, height];
                boardPopulated = true;

                //for loop to get the height
                for (int i = 0; i < width; i++)
                {
                    //for loop to get the width
                    for (int j = 0; j < height; j++)
                    {
                        board[i, j] = new Cell();

                    }
                }

                //while loop that sets the linefromfile to read the next conway line as long as there's lines left to read
                while ((lineFromFile = conway.ReadLine()!) != null)
                {
                    //Gets the save file, tries to save them but it doesn't do a very good job at it. I found a way to load
                    //the file using a char Array instead of a regular string array.
                    int j = 0;
                    char[] splitLife = lineFromFile.ToCharArray();
                    for (int i = 0; i < splitLife.Length; i++)
                    {
                        if (splitLife[i] == 'o')
                        {

                            Console.Write(Alive);
                            board[i, j] = new Cell();
                            board[i, j].alive = true;
                        }

                        else
                        {
                            Console.Write(Dead);
                            board[i, j] = new Cell();
                            board[i, j].alive = false;
                        }
                            
                    }
                    Console.WriteLine();
                    j++;

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
            int choice = 99;

            //loop to keep the submenu popping up
            while (choice != 3)
            {

                Console.WriteLine("1 - Advance, 2 - Save Current Board, or 3 - Main Menu?");
                choice = int.Parse(Console.ReadLine());


                //Choice for advancing
                if (choice == 1)
                {
                    Cell[,] futureBoard;

                    int neighborCount;

                    futureBoard = new Cell[width, height];

                    //for loops that:
                    //examine all the elements in board
                    //determine if they are alive or dead in the next round
                    //put x for dead or o for alive in future board
                    for(int i  = 0; i < width; i++)
                    {
                        neighborCount = 0;

                        for(int j = 0; j < height; j++)
                        {
                            //check northwest
                            if (i - 1 >= 0 && j - 1 >= 0)
                            {
                                if (board[i - 1, j - 1].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //check north
                            if (j - 1 >= 0)
                            {
                                if (board[i, j - 1].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //check northeast
                            if (j - 1 >= 0 && i + 1 < width)
                            {
                                if (board[i + 1, j - 1].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //check west
                            if (i - 1 >= 0)
                            {
                                if (board[i - 1, j].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //check east
                            if (i + 1 < width)
                            {
                                if (board[i + 1, j].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //check south
                            if (j + 1 < height)
                            {
                                if (board[i, j + 1].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //check southwest
                            if (j + 1 < height && i - 1 >= 0)
                            {
                                if (board[i - 1, j + 1].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //check southeast
                            if (j + 1 < height && i + 1 < width)
                            {
                                if (board[i + 1, j + 1].alive)
                                {
                                    neighborCount++;
                                }
                            }

                            //sets the cell to dead
                            if(neighborCount <= 1)
                            {
                                futureBoard[i, j] = new Cell();
                                futureBoard[i, j].AliveSymbol = Dead;
                                futureBoard[i, j].alive = false;
                            }

                            //sets the cell to alive
                            if(neighborCount == 2 || neighborCount == 3)
                            {
                                futureBoard[i, j] = new Cell();
                                futureBoard[i, j].AliveSymbol = Alive;
                                futureBoard[i, j].alive = true;

                            }

                            //sets the cell to dead
                            if(neighborCount >= 4)
                            {
                                futureBoard[i, j] = new Cell();
                                futureBoard[i, j].AliveSymbol = Dead;
                                futureBoard[i, j].alive = false;
                            }

                            //sets the dead symbol to life
                            if (board[i,j].alive != true && neighborCount == 3)
                            {
                                futureBoard[i, j] = new Cell();
                                futureBoard[i, j].AliveSymbol = Alive;
                                futureBoard[i, j].alive = true;
                            }
                        }


                    }

                    //sets the board to the futureboard
                    for(int i = 0; i < width; i++)
                    {
                        for(int j  = 0; j < height; j++)
                        {
                            board[i,j] = futureBoard[i,j];
                        }
                    }

                    DisplayBoard();
                }

                //Choice for saving the current board
                else if (choice == 2)
                {
                    Save("Junk.txt");
                }

            }

            //breaks the loop to return to the main menu
            return;

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
                output.Write(width);
                output.Write(", ");
                output.WriteLine(height);
                output.Write(cell.AliveSymbol);
                output.Write(", ");
                output.WriteLine(cell.DeadSymbol);

                //Copied for loop to write the board to the output
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (board[i, j].AliveSymbol == Alive)
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
