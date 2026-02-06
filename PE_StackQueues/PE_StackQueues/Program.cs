
using PE_StackQueues;
using System.Threading.Tasks.Dataflow;

internal class Program
{
    public static void Main(string[] args)
    {

        GameStack<string> gs = new GameStack<string> ();


        gs.Push("Matt");
        Console.WriteLine(gs.Peek());

        gs.Push("Mark");
        Console.WriteLine(gs.Peek());

        gs.Push("Morris");
        Console.WriteLine(gs.Peek());

        gs.Push("Maven");
        Console.WriteLine(gs.Peek());


        Console.WriteLine(gs.Count);

        while (gs.Count > 0)
        {
            Console.WriteLine(gs.Peek());
            gs.Pop();
        }

        Console.WriteLine(gs.Count);

        gs.Pop();
        gs.Peek();
    }

}
