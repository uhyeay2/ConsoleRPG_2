using ConsoleRPG.ConsoleApp.GameScreens.Screens.GameEnd;
using ConsoleRPG.ConsoleApp.GameScreens.ScreenTypes;

namespace ConsoleRPG.ConsoleApp.GameScreens.Screens.GameStart
{
    public class OpeningScreen : PressAnyKeyToContinueScreen
    {
        public override IEnumerable<string> GetContent() => new[]
        {
            "This is the start of my Console RPG Game.",
            "",
            "I hope you enjoy!",
            "",
            "Press any key to continue."
        };

        public override BaseScreen NextScreen() => new StartingMenuScreen();
    }
}
