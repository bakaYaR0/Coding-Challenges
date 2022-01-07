using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherlockValidString
{
    /// <Task>
    /// Sherlock considers a string to be valid if all characters of the string appear the same number of times. 
    /// It is also valid if he can remove just  character at  index in the string, and the remaining characters will occur the same number of times. 
    /// Given a string , determine if it is valid. If so, return "YES", otherwise return "NO".
    /// </Task>
    public class SherlockValidString
    {
        public static string isValid(string s)
        {
            var numTimes = s.GroupBy(x => x)
                            .Select(x => x.Count())
                            .OrderBy(y => y)
                            .ToList();

            if (numTimes[0] == 1)
                numTimes.RemoveAt(0);
            else if (numTimes[numTimes.Count - 1] - numTimes[numTimes.Count - 2] == 1)
                numTimes.RemoveAt(numTimes.Count - 1);

            if (numTimes.Any(i => i != numTimes[0]))
                return "NO";
            return "YES";
        }
    }
}
