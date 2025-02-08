using TetrisGame.Controllers;
using TetrisGame.Processors.Implementations.Game;
using TetrisGame.Views;
using Timer = System.Windows.Forms.Timer;

namespace TetrisGame
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize the MVC components
            var gameView = new GameView();
            var gameModel = new Game(20);
            var gameTimer = new Timer { Interval = 50000 };
            var gameController = new GameController(gameView, gameModel, gameTimer);

            // Run the application
            Application.Run(gameView);
        }
    }
}