using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace search
{
    public abstract class SearcherAlgorithm
    {
        protected string pattern;
        protected string text;

        public void SetText(string text)
        {
            this.text = text;
        }
        public void SetPattern(string pattern)
        {
            this.pattern = pattern;
        }

        public SearcherAlgorithm(string text, string pattern)
        {
            this.text = text;
            this.pattern = pattern;
        }

        public abstract int SearchPattern();
    }
}
