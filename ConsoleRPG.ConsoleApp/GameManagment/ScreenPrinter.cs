namespace ConsoleRPG.ConsoleApp.GameManagment
{
    public abstract class ScreenPrinter
    {
        protected readonly GameManager _gameManager;

        public ScreenPrinter(GameManager gameManager) => _gameManager = gameManager;

        public abstract void PrintScreen(IEnumerable<string> linesToPrint);

        public void Print(IEnumerable<string> linesToPrint) => Print(linesToPrint.ToArray());

        public void Print(params string[] linesToPrint)
        {
            IEnumerable<string> content = linesToPrint;

            if(_gameManager.Settings.ScreenPrinter.ApplyBorderBeforePrinting)
            {
                content = content.ApplyBorder();
            }

            if (_gameManager.Settings.ScreenPrinter.CenterContentBeforePrinting)
            {
                content = content.CenterHorizontal(Console.WindowWidth)
                                 .CenterVertical(Console.WindowHeight);
            }

            PrintScreen(content);
        }

        public void ClearThenPrint(IEnumerable<string> linesToPrint) => ClearThenPrint(linesToPrint.ToArray());

        public void ClearThenPrint(params string[] linesToPrint)
        {
            Console.Clear();

            Print(linesToPrint);
        }
    }
}
