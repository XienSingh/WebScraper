using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebScraper.ScraperLogic
{
    public class WebScraper
    {

        public static string Scrape(string uri,string toScrape)
        {
            HtmlWeb scraper = new HtmlWeb();
            HtmlDocument htmlContent = scraper.Load(uri);
            var toScrapeElement = string.Empty;
            switch (toScrape.ToLower())
            {
                default:
                case "html":
                    toScrapeElement = "/html";
                    break;
                case "head":
                    toScrapeElement = "/html/head";
                    break;
                case "headstyle":
                    toScrapeElement = "//*[@id=\"Head1\"]/style";
                    break;
                case "headscript":
                    toScrapeElement = "//*[@id=\"Head1\"]/script";
                    break;


            }
            var dom = htmlContent.DocumentNode.SelectNodes(toScrapeElement).ToList();
            var result = string.Empty;
            if (dom.Count() > 1)
            {
                foreach(var item in dom)
                {
                    result += $"Tag:{toScrape} [{item.XPath}]";
                    result +="Attributes of Tag: "+ item.Attributes.Select(i => i.Name).FirstOrDefault() + " value:" +item.Attributes.Select(i=>i.Value).FirstOrDefault();

                    if(!string.IsNullOrEmpty(item.InnerHtml))
                        result += "innerHTML of Tag : " + item.InnerHtml;

                    result += $"Tag:{toScrape} [{item.XPath}]";

                }
                return result;
            }
            return dom[0].InnerHtml.ToString();

        }

    }
}
