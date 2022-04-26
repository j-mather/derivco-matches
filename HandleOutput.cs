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

        /// <summary>
        /// Logs text to the logfile with date and time.
        /// </summary>
        public static void log(string message)
        {
            string localDate = DateTime.Now.ToString();
            string seperator = $"--------------- {localDate} ---------------";
            using (StreamWriter writer = File.AppendText("logfile.log"))
            {
                writer.WriteLine(seperator);
                writer.WriteLine(message + "\n");
            }
        }
    }
}