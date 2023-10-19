using ConsoleRPG.ConsoleApp.GameManagment;

namespace ConsoleRPG.ConsoleApp.GameScreens.ScreenTypes
{
    public abstract class BaseScreen
    {
        public abstract BaseScreen DisplayScreenAndGetNext(GameManager gameManager);
    }
}
