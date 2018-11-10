using System;
namespace milestone1
{
    public class EmptyClass
    {
        public EmptyClass()
        {
            string factMessage = "Extension methods have all the capabilities of regular static methods.";

            // Write the string and include the quotation marks.
            Console.WriteLine($"\"{factMessage}\"");

            // Simple comparisons are always case sensitive!
            bool containsSearchResult = factMessage.Contains("extension");
            Console.WriteLine($"Starts with \"extension\"? {containsSearchResult}");

            // For user input and strings that will be displayed to the end user, 
            // use the StringComparison parameter on methods that have it to specify how to match strings.
            bool ignoreCaseSearchResult = factMessage.StartsWith("extension", System.StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine($"Starts with \"extension\"? {ignoreCaseSearchResult} (ignoring case)");

            bool endsWithSearchResult = factMessage.EndsWith(".", System.StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine($"Ends with '.'? {endsWithSearchResult}");

        }
    }
}
