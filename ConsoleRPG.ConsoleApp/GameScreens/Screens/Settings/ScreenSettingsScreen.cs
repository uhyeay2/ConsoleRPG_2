using ConsoleRPG.ConsoleApp.GameScreens.ScreenTypes;

namespace ConsoleRPG.ConsoleApp.GameScreens.Screens.Settings
{
    public class ScreenSettingsScreen : ScrollAndSelectMenuScreen
    {
        private readonly BaseScreen _previousScreen;

        public ScreenSettingsScreen(BaseScreen previousScreen) => _previousScreen = previousScreen;

        public override IEnumerable<string> GetHeader() => new[]
        {
            "- Screen Settings -"
        };

        public override IEnumerable<(string OptionMessage, BaseScreen NextScreen)> GetOptions()
        {
            throw new NotImplementedException();
        }
    }
}
