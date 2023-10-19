using ConsoleRPG.ConsoleApp.GameManagment;

namespace ConsoleRPG.ConsoleApp.GameScreens.ScreenTypes
{
    public abstract class PressAnyKeyToContinueScreen : BaseScreen
    {
        public abstract IEnumerable<string> GetContent();

        public abstract BaseScreen NextScreen();

        public override BaseScreen DisplayScreenAndGetNext(GameManager gameManager)
        {
            gameManager.Screen.Print(GetContent());

            Console.ReadKey();

            return NextScreen();
        }
    }
}
