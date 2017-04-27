using NewsAggregator.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searcher
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

        public abstract List<Tuple<int, string>> SearchAllNews(List<News> newslist, string pattern);
    }
}
