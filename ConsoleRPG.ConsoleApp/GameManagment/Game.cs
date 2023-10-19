using ConsoleRPG.ConsoleApp.GameScreens.Screens.GameEnd;
using ConsoleRPG.ConsoleApp.GameScreens.Screens.GameStart;
using ConsoleRPG.ConsoleApp.GameScreens.ScreenTypes;

namespace ConsoleRPG.ConsoleApp.GameManagment
{
    public static class Game
    {
        public static void Start()
        {
            var continuePlaying = true;
            var gameManager = new GameManager();
            BaseScreen currentScreen = new OpeningScreen();

            while (continuePlaying)
            {
                continuePlaying = currentScreen is not ClosingScreen;

                currentScreen = currentScreen.DisplayScreenAndGetNext(gameManager);

                Console.Clear();
            }
        }
    }
}
