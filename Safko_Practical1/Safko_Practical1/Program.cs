using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safko_Practical1;

    // Local variables needed for successful program run
    Browser myBrowser = new Browser();
    string userOption = "";

    // Print the user's menu
    Console.WriteLine("This menu will appear once at the top, or whenever a user requests to REPEAT it.");
Console.WriteLine("VISIT a webpage.               Print the CURRENT page.");
Console.WriteLine("Go BACK to a previous page.    Move FORWARD to the next page.");
Console.WriteLine("Print the full page HISTORY.   CLEAR the browser history.");
Console.WriteLine("TOTAL actions by user.         EXIT the program.");
Console.WriteLine();

// User input loop
while (userOption != "EXIT")
{
    // Retrieve user's choice
    Console.Write("Choose one of the options: ");
    userOption = Console.ReadLine()!.ToUpper().Trim();

    switch (userOption)
    {
        // Get user's webpage
        case "VISIT":
            Console.Write("Enter webpage to visit: ");
            string page = Console.ReadLine()!;
    myBrowser.VisitNewPage(page);
            break;

        // Move forward a page
        case "FORWARD":
            myBrowser.MoveForward();
            break;

        // Move back a page
        case "BACK":
            myBrowser.MoveBackward();
            break;

        // Print all history
        case "HISTORY":
            myBrowser.PrintFullHistory();
            break;

        // Print current browsing page
        case "CURRENT":
            myBrowser.PrintCurrentPage();
            break;

        // Clear browser history
        case "CLEAR":
            myBrowser.ClearHistory();
            break;

        // Amount of user actions
        case "TOTAL":
            Console.WriteLine($"User has made {myBrowser.UserActions} actions.");
            break;

        // "Close" the browser
        case "EXIT":
            Console.WriteLine("Goodbye!");
            break;

        case "REPEAT":
            // Print the user's menu
            Console.WriteLine("VISIT a webpage.               Print the CURRENT page.");
            Console.WriteLine("Go BACK to a previous page.    Move FORWARD to the next page.");
            Console.WriteLine("Print the full page HISTORY.   CLOSE the browser.");
            Console.WriteLine("EXIT the program.              REPEAT the menu.");
            break;

        // Invalid input
        default:
            Console.WriteLine("Unrecognized input. Try again.");
            break;
        


    // Line break for next iteration
    Console.WriteLine();
        }