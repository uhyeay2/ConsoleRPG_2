using ConsoleRPG.Domain.Constants;

namespace ConsoleRPG.Domain.Extensions
{
    public static class IEnumerableStringExtensions
    {
        #region CenterText

        public static IEnumerable<string> CenterHorizontal(this IEnumerable<string> input, int? targetLength = null)
        {
            var minLength = input.Max(_ => _.Length);

            var length = targetLength.GetValueOrDefault() < minLength ? minLength : targetLength.GetValueOrDefault();

            return input.Select(_ => _.PadToCenter(length));
        }

        public static IEnumerable<string> CenterVertical(this IEnumerable<string> input, int targetHeight)
        {
            if (input.Count() > targetHeight)
            {
                return input;
            }

            var countOfLinesToSkip = (targetHeight - input.Count()) / 2;

            var emptyLines = Enumerable.Range(0, countOfLinesToSkip).Select(_ => string.Empty);

            return emptyLines.Concat(input);
        }

        public static IEnumerable<string> Center(this IEnumerable<string> content, int targetHeight, int targetWidth) =>
            CenterVertical(CenterHorizontal(content, targetWidth), targetHeight);

        #endregion

        #region Border Text

        public static IEnumerable<string> ApplyBorder(this IEnumerable<string> content, int? targetWidth = null)
        {
            var borderWidth = targetWidth.GetValueOrDefault();

            var lengthOfLongestLine = content.Max(_ => _.Length);

            if (lengthOfLongestLine > borderWidth)
            {
                borderWidth = lengthOfLongestLine + BorderConstants.PaddingForExpandingBorderWidth;
            }

            var firstLine  = " _" + new string('_', borderWidth - BorderConstants.WidthOfBorderSides) + "_ ";
            var fillerLine = "| " + new string(' ', borderWidth - BorderConstants.WidthOfBorderSides) + " |";
            var bottomLine = "|_" + new string('_', borderWidth - BorderConstants.WidthOfBorderSides) + "_|";

            var innerLines = content.Select(_ =>
                "| " + _.PadToCenter(borderWidth - BorderConstants.WidthOfBorderSides) + " |");

            return new[] { firstLine, fillerLine, fillerLine }.Concat(innerLines).Concat(new[] { fillerLine, bottomLine });
        }

        public static IEnumerable<string> ApplyConsoleCenteredBorder(this IEnumerable<string> content, int? targetWidth = null) =>
            ApplyBorder(content, targetWidth).Center(Console.WindowHeight, Console.WindowWidth);

        #endregion

        #region ApplyArrows

        /// <summary>
        /// Insert "--> " before and " <--" after the string at index provided. Insert "    " before and after all
        /// other strings to keep spacing the same.
        /// </summary>
        public static IEnumerable<string> InsertArrowBeforeAndAfterIndex(this IEnumerable<string> strings, int index) =>
            strings.Select((s, i) => s.ApplyArrowsOrPad(i == index));

        #endregion
    }
}
