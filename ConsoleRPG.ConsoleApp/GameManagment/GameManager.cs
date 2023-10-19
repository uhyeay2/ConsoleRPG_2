using ConsoleRPG.ConsoleApp.ScreenPrinting;

namespace ConsoleRPG.ConsoleApp.GameManagment
{
    public class GameManager
    {
        public GameManager()
        {
            Screen = new OneCharacterAtATimePrinter(this);            
        }

        public GameManager(ScreenPrinter screenPrinter)
        {
            Screen = screenPrinter;
        }

        public ScreenPrinter Screen { get; set; }

        public readonly SettingsContainer Settings = new();
    }
}
