using ConsoleRPG.ConsoleApp.GameScreens.Screens.GameEnd;
using ConsoleRPG.ConsoleApp.GameScreens.ScreenTypes;

namespace ConsoleRPG.ConsoleApp.GameScreens.Screens.GameStart
{
    public class StartingMenuScreen : ScrollAndSelectMenuScreen
    {
        public override IEnumerable<string> GetHeader() => new[]
        {
            "- Menu Screen -",
            "",
            "Scroll Up/Down Using Arrow Keys.",
            "Press Enter To Select An Option.",
        };

        public override IEnumerable<(string OptionMessage, BaseScreen NextScreen)> GetOptions() => new[]
        {
            ("Quit Application", new ClosingScreen()),
            ("Return To Opening Screen", new OpeningScreen()),
            ("Refresh This Page", (BaseScreen) this),
        };
    }
}
