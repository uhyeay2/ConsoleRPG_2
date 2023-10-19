using ConsoleRPG.ConsoleApp.GameScreens.ScreenTypes;

namespace ConsoleRPG.ConsoleApp.GameScreens.Screens.GameEnd
{
    public class ClosingScreen : PressAnyKeyToContinueScreen
    {
        public override IEnumerable<string> GetContent() => new[]
        {
            "This is the end of my Console RPG Game.",
            "",
            "I hope you had fun!",
            "",
            "Press any key to end the application."
        };

        public override BaseScreen NextScreen() => this;
    }
}
