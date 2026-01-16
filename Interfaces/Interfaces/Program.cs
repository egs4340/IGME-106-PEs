
using Interfaces;
using System.Drawing;

//Just added a simple console line to begin the program
Console.WriteLine("Beginning test...");

//Created Point 1 and Prints the info
Interfaces.Point point1 = new Interfaces.Point(5, 7);
point1.PrintInfo();


//Created Point 2 and Prints the info
Interfaces.Point point2 = new Interfaces.Point(10, 10);
point2.PrintInfo();


//Created Circle One and prints it's info
Circle circleOne = new Circle(10, 10, 3);
circleOne.PrintInfo();


//Created Circle Two and prints it's info
Circle circleTwo = new Circle(0, 0, 5);
circleTwo.PrintInfo();


//Console Write lines to signify that the points will move
Console.WriteLine("Moving Point 2 to (2, 2)...");

Console.WriteLine("Moving Circle 2 by (-1, -1)...");


//Moves point2 to 2,2
point2.MoveTo(2, 2);


//Moves circleTwo by -1, -1
circleTwo.MoveBy(-1, -1);


//Prints all the points and circles again
point1.PrintInfo();

point2.PrintInfo();

circleOne.PrintInfo();

circleTwo.PrintInfo();


//All console write lines for the distances
Console.WriteLine("Distance from Point 1 to Point 2: " + point1.DistanceTo(point2));

Console.WriteLine("Distance from Point 1 to Circle 1: " + point1.DistanceTo(circleOne));

Console.WriteLine("Distance from Point 1 to Circle 2: " + point1.DistanceTo(circleTwo));

Console.WriteLine("Distance from Point 2 to Circle 1: " + point2.DistanceTo(circleOne));

Console.WriteLine("Distance from Point 2 to Circle 2: " + point1.DistanceTo(circleTwo));


//Determining which circle has the largest area

Console.WriteLine("Circle 2's Area (" + circleTwo.Area + ") is bigger than Circle 1's (" + circleOne.Area + ")");


//Determining which circles contain points

Console.WriteLine("Does Circle 1 contain Point 1? " + circleOne.ContainsPosition(point1));

Console.WriteLine("Does Circle 1 contain Point 2? " + circleOne.ContainsPosition(point1));

Console.WriteLine("Does Circle 2 contain Point 1? " + circleTwo.ContainsPosition(point1));

Console.WriteLine("Does Circle 2 contain Point 2? " + circleTwo.ContainsPosition(point2));
