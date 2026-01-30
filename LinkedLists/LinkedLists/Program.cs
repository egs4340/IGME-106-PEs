// See https://aka.ms/new-console-template for more information
using LinkedLists;


public class Program()
{
    static void Main(string[] args)

    {
        //initializes a Custom Linked List
        CustomLinkedList<string> linkList = new CustomLinkedList<string>();
        
        //asks for the first input
        Console.WriteLine("Enter item 1:");
        string inputOne = Console.ReadLine();
        linkList.Add(inputOne);

        //asks for the second input
        Console.WriteLine("Enter item 4:");
        string inputTwo = Console.ReadLine();
        linkList.Add(inputTwo);

        //asks for the third item
        Console.WriteLine("Enter number 3: ");
        string inputThree = Console.ReadLine();
        linkList.Add(inputThree);
        
        //asks for the fourth item
        Console.WriteLine("Enter item 4:");
        string inputFour = Console.ReadLine();
        linkList.Add(inputFour);

        //asks for the fifth item
        Console.WriteLine("Enter item 5:");
        string inputFive = Console.ReadLine();
        linkList.Add(inputFive);


        Console.WriteLine(linkList);
        
    }
}