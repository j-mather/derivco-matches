namespace DerivcoMatches
{
    /// <summary>
    /// Main class for top view logic
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method to implement top view logic
        /// </summary>
        static void Main(string[] args)
        {
            string[] peoplesSet = GetInput.getInput(args);

            List<Match> outputLines = new List<Match>();
            foreach (string names in peoplesSet)
            {
                string[] maleFemale = names.Split(",");
                Match match = new(maleFemale[0], maleFemale[1]);
                outputLines.Add(match);
            }
            HandleOutput.handle(outputLines);
        }
    }
}