// LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Using Timeout settings for RegEx in .NET

using System;
using System.Text.RegularExpressions;
using System.Diagnostics;

const string thestr = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

// Use a Stopwatch to show elapsed time
Stopwatch sw;

// Define a timeout value (in milliseconds)
TimeSpan Timeout = TimeSpan.FromMilliseconds(500);

try {
    sw = Stopwatch.StartNew();
    // Provide the timeout to the Regex constructor
    Regex CapWords = new Regex(@"(a+a+)+b", RegexOptions.None, Timeout);
    MatchCollection mc = CapWords.Matches(thestr);
    sw.Stop();

    Console.WriteLine($"Found {mc.Count} matches in {sw.Elapsed} time:");
    foreach (Match match in mc) {
        Console.WriteLine($"'{match.Value}' found at position {match.Index}");
    }
}
catch (RegexMatchTimeoutException ex) {
    Console.WriteLine($"Regex timeout occurred: {ex.Message}");
}
catch (Exception e) {
    Console.WriteLine(e);
}
