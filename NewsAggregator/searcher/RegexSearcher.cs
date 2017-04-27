using NewsAggregator.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace searcher
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
            if (matches.Count > 0)
            {
                return matches[0].Index;
            }
            else
            {
                return -1;
            }
        }

        public override List<Tuple<int, string>> SearchAllNews(List<News> newslist, string pattern)
        {
            List<Tuple<int, string>> matchnews = new List<Tuple<int, string>>();
            int i = 0;
            this.pattern = pattern;
            foreach (News news in newslist)
            {
                if (news == null)
                {
                    continue;
                }

                Console.WriteLine(news.title);
                this.text = news.title;

                int found;
                Console.WriteLine("Searching in Title: ");
                found = SearchPattern();
                if (found != -1)
                {
                    Console.WriteLine("Found");
                    Tuple<int, string> newsfound = new Tuple<int, string>(i, news.title);
                    matchnews.Add(newsfound);
                }
                else
                {
                    Console.WriteLine("Searching in Summary: ");
                    this.text = news.summary;
                    found = SearchPattern();

                    if (found != -1)
                    {
                        Console.WriteLine("Found");
                        string sentence;
                        if (news.summary.Length - found > 20)
                        {
                            sentence = news.summary.Substring(found, 20);
                        }
                        else
                        {

                            int getsentence = news.summary.Length - found;
                            sentence = news.summary.Substring(found, (getsentence > 20) ? 20 : getsentence);
                            if (getsentence < 20)
                            {
                                int sisa = 20 - getsentence;
                                if (found > sisa)
                                {
                                    sentence = news.summary.Substring(found - sisa, sisa);
                                }
                                else
                                {
                                    sentence = news.summary.Substring(0, sisa);
                                }
                            }
                        }

                        Tuple<int, string> newsfound = new Tuple<int, string>(i, sentence);

                        matchnews.Add(newsfound);
                    }
                    else
                    {
                        Console.WriteLine("Searching in Text");
                        this.text = news.description;
                        found = SearchPattern();


                        if (found != -1)
                        {
                            Console.WriteLine("Found");
                            string sentence;
                            if (news.description.Length - found > 20)
                            {
                                sentence = news.description.Substring(found, 20);
                            }
                            else
                            {
                                int getsentence = news.description.Length - found;
                                sentence = news.description.Substring(found, (getsentence > 20) ? 20 : getsentence);
                                if (getsentence < 20)
                                {
                                    int sisa = 20 - getsentence;
                                    if (found > sisa)
                                    {
                                        sentence = news.description.Substring(found - sisa, sisa);
                                    }
                                    else
                                    {
                                        sentence = news.description.Substring(0, sisa);
                                    }
                                }
                            }

                            Tuple<int, string> newsfound = new Tuple<int, string>(i, sentence);

                            matchnews.Add(newsfound);
                        }
                    }
                }
                i++;
                Console.WriteLine(i + " Done Searching in news, move on");
            }
            Console.WriteLine("Done Searching");
            return matchnews;
        }
    }
}
