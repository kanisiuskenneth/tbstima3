using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.ServiceModel.Syndication;
using System.Xml;
using NewsAggregator.parser;

namespace NewsAggregator
{
	public class Global : HttpApplication
	{
	    public static List<SyndicationFeed> feeds;
	    public static List<News> newslist;
	    public static List<string> htmlurls;
	    static void Application_Start()
	    {
	        newslist = new List<News>();
	        feeds = new List<SyndicationFeed>();
	        htmlurls = new List<string>();

	        List<string> urls = new List<string>();
	        urls.Add("http://rss.detik.com/index.php");
	        urls.Add("http://rss.vivanews.com/get/all");
	        //urls.Add("http://www.antaranews.com/rss/terkini");
	        //urls.Add("https://www.tempo.co/rss/terkini");

	        Parser parser = new Parser();

	        /* XML Parser and HTML Parser*/
	        parser.XMLParser(urls);
	        parser.HTMLParser(htmlurls);


	    }

	}
}
