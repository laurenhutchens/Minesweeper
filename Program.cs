
namespace MineSweeper
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to Minesweeper");
            //size 10 and difficulty 0.1
            Board board = new Board(10, 0.1f);
            Console.WriteLine("Here is the answer key for the first board");
            PrintAnswers(board);
        }

        public static void PrintAnswers(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
