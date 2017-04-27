using NewsAggregator.parser;
using System;
using System.Collections.Generic;

namespace searcher
{
    public class KMP : SearcherAlgorithm
    {
        public KMP(string text, string pattern) : base(text, pattern)
        {

        }

        public override int SearchPattern()
        {
            /* Compute Border */
            int patternlength = this.pattern.Length;
            int textlength = this.text.Length;

            int[] border = new int[this.pattern.Length];
            int i, j;

            border[0] = 0;
            i = 1;
            j = 0;
            while (i < patternlength)
            {
                if (pattern[i] == pattern[j])
                {
                    border[i] = j + 1;
                    i++;
                    j++;
                }
                else if (j > 0)
                {
                    j = border[j - 1];
                }
                else
                {
                    border[i] = 0;
                    i++;
                }

            }

            i = 0;
            j = 0;
            while (i < textlength)
            {
                if (text[i] == pattern[j])
                {
                    if (j == patternlength - 1)
                    {
                        return i - patternlength + 1;
                    }
                    i++;
                    j++;
                }
                else if (j > 0)
                {
                    j = border[j - 1];
                }
                else
                {
                    i++;
                }
            }
            return -1;
        }

        public override List<Tuple<int, string>> SearchAllNews(List<News> newslist, string pattern)
        {
            List<Tuple<int, string>> matchnews = new List<Tuple<int, string>>();
            int i = 0;
            this.pattern = pattern;
            foreach (News news in newslist)
            {
                this.text = news.title;

                int found;
                found = SearchPattern();
                if (found != -1)
                {
                    Tuple<int, string> newsfound = new Tuple<int, string>(i, news.title);

                    matchnews.Add(newsfound);
                }
                else
                {
                    this.text = news.summary;
                    found = SearchPattern();

                    if (found != -1)
                    {
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
                        this.text = news.description;
                        found = SearchPattern();

                        if (found != -1)
                        {
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
            }

            return matchnews;
        }
    }
}
