using ConsoleRPG.ConsoleApp.GameManagment;

namespace ConsoleRPG.ConsoleApp.ScreenPrinting
{
    public class OneCharacterAtATimePrinter : ScreenPrinter
    {
        public OneCharacterAtATimePrinter(GameManager gameManager) : base(gameManager) { }

        public override void PrintScreen(IEnumerable<string> linesToPrint)
        {
            foreach (var line in linesToPrint)
            {
                foreach (var character in line)
                {
                    if (character != ' ' && character != '_' && character != '|' && character != '\n')
                    {
                        Thread.Sleep(_gameManager.Settings.ScreenPrinter.MillisecondsToDelayBetweenPrintingCharacters);
                    }

                    Console.Write(character);
                }
                Console.Write('\n');
            }

            // This fixes a bug so that when we press a key while a screen is being printed, the key press is ignored.
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}
