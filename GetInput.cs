namespace DerivcoMatches
{
    static class GetInput
    {
        public static string[] getInput(string[] args) {
            string[] peoplesSet = {"Jack,Jill", "Wesly,Jennya"};

            if (args.Length == 0) {
                return getUserInput();
            } else if (args.Length == 1) {
                try
                {
                    String[] fileLines = readCSVFile(args[0]);
                    return convertFileLines(args[0], fileLines);
                }
                catch (System.Exception)
                {
                    exitWithMessage($"'{args[0]}' could not be found.\nPlease make sure it exists in the same repository.");
                }
            } else if (args.Length == 2) {
                return twoNamesGiven(args);
            }
            
            exitWithMessage($"Too many arguments given!\nExpected 2 or less, but {args.Length} Were given.");
            return args;
        }

        private static void exitWithMessage(string message) {
            Console.WriteLine(message);
            Environment.Exit(0);
        }

        private static string[] getUserInput() {
            string enterMessage1 = "Please enter a male name, or the name of a csv file:";
            string? firstInput;
            while (true) {
                Console.WriteLine(enterMessage1);
                enterMessage1 = "Please pick a valid male name or csv file:";
                firstInput = Console.ReadLine();
                if (firstInput == null || firstInput == "") {continue;}
                try
                {
                    string[] fileLines = readCSVFile(firstInput);
                    return convertFileLines(firstInput, fileLines);
                }
                catch (System.Exception) {}
                if (firstInput.All(Char.IsLetter)) {break;}
            }
            string enterMessage2 = "Please enter a female name:";
            string? secondInput;
            while (true) {
                Console.WriteLine(enterMessage2);
                enterMessage1 = "Please pick a valid female name:";
                secondInput = Console.ReadLine();
                if (secondInput == null || secondInput == "") {continue;}
                if (secondInput.All(Char.IsLetter)) {break;}
            }

            string persons = $"{firstInput},{secondInput}";
            string[] personsSet = {persons};
            return personsSet;
        }

        private static string[] readCSVFile(string filename) {
            string[] lines = {};
            try
            {
                lines = System.IO.File.ReadAllLines(filename);
            }
            catch (System.Exception)
            {
                throw;
            }
            return lines;
        }

        private static string[] convertFileLines(string filename, string[] lines) {
            List<string> males = new List<string>();
            List<string> females = new List<string>();

            int lineCount = 1;
            foreach (string line in lines) {
                string[] columns = line.Split(",");
                if (columns.Length != 2) {
                    exitWithMessage($"{filename}: Line {lineCount} should have 1 comma.");
                }
                string name = columns[0].Trim();
                if (name == "") {
                    exitWithMessage($"{filename}: Line {lineCount} has an empty name.");
                } else if (!name.All(Char.IsLetter)) {
                    exitWithMessage($"{filename}: Line {lineCount} '{name}' is not valid.\nOnly alphabetical characters allowed.");
                }

                string gender = columns[1].Trim();
                if (gender == "") {
                    exitWithMessage($"{filename}: Line {lineCount} has no gender.");
                }

                string lowerGender = gender.ToLower();
                if (lowerGender == "m") {
                    if (!males.Contains(name)) {
                        males.Add(name);
                    }
                } else if (lowerGender == "f") {
                    if (!females.Contains(name)) {
                        females.Add(name);
                    }
                } else {
                    exitWithMessage($"{filename}: Line {lineCount} gender '{gender}' does not exist.");
                }

                lineCount++;
            }
            return generateCombinations(males, females);
        }

        private static string[] generateCombinations(List<string> males, List<string> females) {
            List<string> combList = new List<string>();
            foreach (string male in males)
            {
                foreach (string female in females)
                {
                    combList.Add($"{male},{female}");
                }
            }
            return combList.ToArray();
        }

        private static string[] twoNamesGiven(string[] args) {
            string male = args[0];
            if (!male.All(Char.IsLetter)) {
                exitWithMessage($"The name '{male}' is not valid.\nOnly alphabetical characters allowed.");
            }
            
            string female = args[1];
            if (!female.All(Char.IsLetter)) {
                exitWithMessage($"The name '{female}' is not valid.\nOnly alphabetical characters allowed.");
            }
            string persons = $"{male},{female}";
            string[] personsSet = {persons};
            return personsSet;
        }
    }
}