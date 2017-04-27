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
            this.pattern = pattern.ToLower();
            foreach (News news in newslist)
            {
                if (news == null)
                {
                    continue;}

                Console.WriteLine(news.title);
                this.text = news.title.ToLower();

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
                    this.text = news.summary.ToLower();
                    found = SearchPattern();

                    if (found != -1)
                    {
                        Console.WriteLine("Found");
                        string sentence;
                        if (news.summary.Length - found > 40)
                        {
                            sentence = news.summary.Substring(found, 40);
                        }
                        else
                        {

                            int getsentence = news.summary.Length - found;
                            sentence = news.summary.Substring(found, (getsentence > 40) ? 40 : getsentence);
                            if (getsentence < 40)
                            {
                                int sisa = 40 - getsentence;
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
                        this.text = news.description.ToLower();
                        found = SearchPattern();


                        if (found != -1)
                        {
                            Console.WriteLine("Found");
                            string sentence;
                            if (news.description.Length - found > 40)
                            {
                                sentence = news.description.Substring(found, 40);
                            }
                            else
                            {
                                int getsentence = news.description.Length - found;
                                sentence = news.description.Substring(found, (getsentence > 40) ? 40 : getsentence);
                                if (getsentence < 40)
                                {
                                    int sisa = 40 - getsentence;
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
                Console.WriteLine(i+" Done Searching in news, move on");
            }
            Console.WriteLine("Done Searching");
            return matchnews;

        }
    }
}
