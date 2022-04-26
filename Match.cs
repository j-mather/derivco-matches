namespace DerivcoMatches
{
    /// <summary>
    /// Object for a matchup of a male and female.
    /// </summary>
    public class Match
    {
        private string output;
        private int percentage;

        /// <summary>
        /// Match constructor.
        /// </summary>
        /// <param name="male">Male name to match.</param>
        /// <param name="female">Female name to match.</param>
        public Match(string male, string female)
        {
            output = match(male, female);
        }

        /// <summary>
        /// Getter for the matching string for the 2 people.
        /// </summary>
        public string getOutput()
        {
            return output;
        }

        /// <summary>
        /// Getter for the percentage match for the 2 people.
        /// </summary>
        public int getPercentage()
        {
            return percentage;
        }

        /// <summary>
        /// Handles the main logic for matching 2 people
        /// and getting a percentage result.
        /// </summary>
        private string match(string male, string female)
        {
            string sentence = $"{male} matches {female}";
            string percString = getMatchNumbers(sentence);
            while (percString.Length > 2)
            {
                percString = reduceCounts(percString);
            }
            percentage = Int32.Parse(percString);
            string output = getOutputMessage(sentence, percString);
            return output;
        }

        /// <summary>
        /// Takes in the matching sentence, and converts
        /// that to concatinated matching letter counts.
        /// </summary>
        private string getMatchNumbers(string sentence)
        {
            string catCounts = "";
            sentence = sentence.Replace(" ", "").ToLower();

            while (sentence.Length > 0)
            {
                string character = sentence.Substring(0, 1);
                string minused = sentence.Replace(character, "");
                int count = sentence.Length - minused.Length;
                catCounts += count.ToString();
                sentence = minused;
            }
            return catCounts;
        }

        /// <summary>
        /// Takes in a concatenated set of numbers
        /// and reduces it by adding the first and the last numbers
        /// until a shorter concatenated set is produced.
        /// </summary>
        private string reduceCounts(string catCounts)
        {
            string reducedCatCounts = "";
            while (catCounts.Length > 1)
            {
                int first = Int32.Parse(catCounts.Substring(0, 1));
                int last = Int32.Parse(catCounts.Substring(catCounts.Length - 1));
                int sum = first + last;
                reducedCatCounts += sum.ToString();
                catCounts = catCounts.Substring(1, catCounts.Length - 2);
            }
            if (catCounts.Length > 0)
            {
                reducedCatCounts += catCounts;
            }
            return reducedCatCounts;
        }

        /// <summary>
        /// Converts the matching sentence
        /// to the final matching sentence.
        /// </summary>
        private string getOutputMessage(string sentence, string percent)
        {
            string additional = "";
            if (Int32.Parse(percent) > 80)
            {
                additional = ", good match";
            }
            string final = $"{sentence} {percent}%{additional}";
            return final;
        }
    }
}