namespace ConsoleRPG.ConsoleApp.GameManagment.GameSettings
{
    public class ScreenPrinterSettings
    {
        public int MillisecondsToDelayBetweenPrintingCharacters { get; set; } = 30;

        public bool ApplyBorderBeforePrinting = true;

        public bool CenterContentBeforePrinting = true;

        public bool ApplyBorderAroundMenuOptions = true;

        public bool ApplyBorderAroundMenuHeaders = true;

        public bool SyncMenuHeaderAndOptionsBorderWidths = true;
    }
}
