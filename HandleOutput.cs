namespace DerivcoMatches
{
    static class HandleOutput
    {
        public static void handle(List<Match> matches)
        {
            string[] outputLines = sortMatches(matches);
            writeToFile(outputLines);
            consolePrint(outputLines);
        }

        public static string[] sortMatches(List<Match> unordered) {
            unordered.Sort((x, y) => string.Compare(x.getOutput(), y.getOutput()));
            unordered = unordered.OrderByDescending(x => x.getPercentage()).ToList();
            return unordered.Select(x => x.getOutput()).ToArray();
        }

        private static async void writeToFile(string[] lines) {
            await File.WriteAllLinesAsync("output.txt", lines);
        }

        private static void consolePrint(string[] lines) {
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}