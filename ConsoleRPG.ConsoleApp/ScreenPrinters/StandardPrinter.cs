using ConsoleRPG.ConsoleApp.GameManagment;

namespace ConsoleRPG.ConsoleApp.ScreenPrinters
{
    internal class StandardPrinter : ScreenPrinter
    {
        public StandardPrinter(GameManager gameManager) : base(gameManager) { }

        public override void PrintScreen(IEnumerable<string> linesToPrint)
        {
            foreach (var line in linesToPrint)
            {
                Console.WriteLine(line);
            }
        }
    }
}
