namespace DerivcoMatches
{
    public class Match
    {
        private string output;
        private int percentage;

        public Match(string male, string female)
        {
            output = match(male, female);
        }

        public string getOutput() {
            return output;
        }

        public int getPercentage() {
            return percentage;
        }

        private string match(string male, string female) {
            string sentence = $"{male} matches {female}";
            string percString = getMatchNumbers(sentence);
            while (percString.Length > 2) {
                percString = reduceCounts(percString);
            }
            percentage = Int32.Parse(percString);
            string output = getOutputMessage(sentence, percString);
            return output;
        }

        private string getMatchNumbers(string sentence)
        {
            string catCounts = "";
            sentence = sentence.Replace(" ", "").ToLower();

            while (sentence.Length > 0) {
                string character = sentence.Substring(0, 1);
                string minused = sentence.Replace(character, "");
                int count = sentence.Length - minused.Length;
                catCounts = catCounts + count.ToString();
                sentence = minused;
            }
            return catCounts;
        }

        private string reduceCounts(string catCounts)
        {
            string reducedCatCounts = "";
            while (catCounts.Length > 1) {
                int first = Int32.Parse(catCounts.Substring(0, 1));
                int last = Int32.Parse(catCounts.Substring(catCounts.Length - 1));
                int sum = first + last;
                reducedCatCounts = reducedCatCounts + sum.ToString();
                catCounts = catCounts.Substring(1, catCounts.Length - 2);
            }
            if (catCounts.Length > 0) {
                reducedCatCounts = reducedCatCounts + catCounts;
            }
            return reducedCatCounts;
        }

        private string getOutputMessage(string sentence, string percentage) {
            string additional = "";
            if (Int32.Parse(percentage) > 80) {
                additional = ", good match";
            }
            string final = $"{sentence} {percentage}%{additional}";
            return final;
        }
    }
}