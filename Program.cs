namespace DerivcoMatches
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peoplesSet = GetInput.getInput(args);

            List<Match> outputLines = new List<Match>();
            foreach (string names in peoplesSet) {
                string[] maleFemale = names.Split(",");
                Match match = new Match(maleFemale[0], maleFemale[1]);
                outputLines.Add(match);
            }
            HandleOutput.handle(outputLines);
        }
    }
}