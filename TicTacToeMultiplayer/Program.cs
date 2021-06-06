namespace TicTacToeMultiplayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Board gameBoard = new Board(5);
            gameBoard.GameLoop();
        }
    }
}