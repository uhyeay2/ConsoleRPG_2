using ConsoleRPG.ConsoleApp.GameManagment;
using ConsoleRPG.ConsoleApp.ScreenPrinters;

namespace ConsoleRPG.ConsoleApp.GameScreens.ScreenTypes
{
    public abstract class ScrollAndSelectMenuScreen : BaseScreen
    {
        public abstract IEnumerable<string> GetHeader();

        public abstract IEnumerable<(string OptionMessage, BaseScreen NextScreen)> GetOptions();

        public override BaseScreen DisplayScreenAndGetNext(GameManager gameManager)
        {
            var selectionMade = false;

            var currentIndex = 0;

            var maxIndex = GetOptions().Count() - 1;

            // first print using gameManager printer
            gameManager.Screen.ClearThenPrint(GetContent(currentIndex, gameManager));

            // subsequent prints using standardPrinter for better user experience
            var standardPrinter = new StandardPrinter(gameManager);

            while (!selectionMade) 
            {
                var input = Console.ReadKey().Key;

                Console.SetCursorPosition(0, 0);

                switch (input)
                {
                    case ConsoleKey.Enter:
                        selectionMade = true;
                        break;

                    case ConsoleKey.UpArrow:
                        // 0 goes to max, everything else goes down
                        currentIndex = currentIndex == 0 ? maxIndex : --currentIndex;
                        goto default;


                    case ConsoleKey.DownArrow:
                        // max goes to 0, everything else goes up
                        currentIndex = currentIndex == maxIndex ? 0 : ++currentIndex;
                        goto default;

                    default:
                        //TODO: It prints to the console here - need to stop that
                        standardPrinter.Print(GetContent(currentIndex, gameManager));
                        break;
                }                
            }

            return GetOptions().ElementAt(currentIndex).NextScreen;
        }

        private static readonly string[] FillerLinesBetweenHeaderAndOptions = { "", "" };

        private IEnumerable<string> GetContent(int currentIndex, GameManager gameManager)
        {
            var header = GetHeader();
            
            var optionsWithArrowsApplied = GetOptions().Select(_ => _.OptionMessage).InsertArrowBeforeAndAfterIndex(currentIndex);

            int? borderTargetWidth = null;
            
            if (gameManager.Settings.ScreenPrinter.SyncMenuHeaderAndOptionsBorderWidths)
            {
                var headerMaxLength = header.Max(_ => _.Length);

                var optionsMaxLength = optionsWithArrowsApplied.Max(_ => _.Length);

                borderTargetWidth = (headerMaxLength > optionsMaxLength ? headerMaxLength : optionsMaxLength) + 6;
            }

            if (gameManager.Settings.ScreenPrinter.ApplyBorderAroundMenuHeaders)
            {
                header = header.ApplyBorder(borderTargetWidth);
            }

            if (gameManager.Settings.ScreenPrinter.ApplyBorderAroundMenuOptions)
            {
                optionsWithArrowsApplied = optionsWithArrowsApplied.ApplyBorder(borderTargetWidth);
            }

            return header.Concat(FillerLinesBetweenHeaderAndOptions).Concat(optionsWithArrowsApplied);
        }
    }
}
