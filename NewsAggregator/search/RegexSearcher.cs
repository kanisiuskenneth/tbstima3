using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace search
{
    public class RegexSearcher : SearcherAlgorithm
    {
        public RegexSearcher(string text, string pattern) : base(text, pattern)
        {

        }

        public override int SearchPattern()
        {
            Regex R = new Regex(pattern.ToLower());
            MatchCollection matches = R.Matches(text.ToLower());
            if (matches != null)
            {
                return matches[0].Index;
            } else
            {
                return -1;
            }
        }
    }
}
