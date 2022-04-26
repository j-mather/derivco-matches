namespace DerivcoMatches
{
    /// <summary>
    /// Class for handling final outputs to user.
    /// </summary>
    static class HandleOutput
    {
        /// <summary>
        /// Sorts matches and writes final outputs to user.
        /// </summary>
        public static void handle(List<Match> matches)
        {
            string[] outputLines = sortMatches(matches);
            writeToFile(outputLines);
            consolePrint(outputLines);
        }

        /// <summary>
        /// Orders the matches by percentage match,
        /// followed by alphabetical in the match description.
        /// </summary>
        private static string[] sortMatches(List<Match> unordered)
        {
            unordered.Sort((x, y) => string.Compare(x.getOutput(), y.getOutput()));
            unordered = unordered.OrderByDescending(x => x.getPercentage()).ToList();
            return unordered.Select(x => x.getOutput()).ToArray();
        }

        /// <summary>
        /// Writes output to 'output.txt' file.
        /// </summary>
        private static async void writeToFile(string[] lines)
        {
            await File.WriteAllLinesAsync("output.txt", lines);
        }

        /// <summary>
        /// Writes output to console.
        /// </summary>
        private static void consolePrint(string[] lines)
        {
            Console.WriteLine();
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}