using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.ServiceModel.Syndication;
using System.Xml;
using System.IO.MemoryMappedFiles;

namespace NewsAggregator
{
	public class Global : HttpApplication
	{
	    public static List<SyndicationFeed> feeds;
		protected void Application_Start()
		{
		    feeds = new List<SyndicationFeed>();
		    System.Diagnostics.Debug.WriteLine("Hello");
		    string albumRSS;
		    List<string> urls = new List<string>();
		    urls.Add("http://rss.detik.com");
		    urls.Add("http://rss.vivanews.com/get/all");
		    foreach (string url in urls)
		    {
		        XmlReader x = XmlReader.Create(url);
		        feeds.Add(SyndicationFeed.Load(x));
		        x.Close();
		    }
		}
	}
}
