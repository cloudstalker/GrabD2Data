using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace GrabD2Data
{
    class Program
    {
        private static string heroUrl = "https://www.dotabuff.com/heroes";
        private static string siteUrl = "https://www.dotabuff.com";
        private static string itemUrl = "https://www.dotabuff.com/items";
        static void Main(string[] args)
        {
            HtmlWeb heroWeb = new HtmlWeb();
            List<string> heroList = new List<string>();
            var doc = heroWeb.Load(heroUrl);
            var heroNodes = doc.DocumentNode.SelectNodes(
                "//html/body/div/div/div/section/footer/div").Where(s => s.Attributes["class"].Value == "hero-grid").ToList();
            var heroes = heroNodes[0].ChildNodes.Where(s => s.Name == "a").ToList();

            for (int i = 0; i < heroes.Count; i++) // for ruling out the last
            {
                heroList.Add(heroes[i].Attributes["href"].Value);
            }

            Console.WriteLine("All heroes' name parsed.");

            using (StreamWriter streamWriter = new StreamWriter("HeroData.txt"))
            {
                float i = 0f;
                foreach (string temp in heroList)
                {
                    Console.WriteLine("Progress: {0:N3}", i / heroList.Count);
                    streamWriter.WriteLine(temp);
                    var tempDoc = heroWeb.Load(siteUrl + temp);
                    var tempNodes = tempDoc.DocumentNode.SelectNodes(
                        "//html/body/div/div/div/div/div/section")
                        .Where(s => GetAttribValue(s, "class"))
                        .ToList();

                    var tempArticle = tempNodes[0].ChildNodes[1];
                    var tempTables = tempArticle.ChildNodes.ToList();

                    var firstTitle = tempTables[0].FirstChild;
                    var firstData = firstTitle.LastChild;
                    var mainAtrList = firstData.ChildNodes.ToList();
                    foreach (var s in mainAtrList)
                    {
                        streamWriter.Write(s.Attributes["class"].Value);
                        streamWriter.WriteLine(": " + s.InnerText);
                    }

                    var secondTitle = tempTables[1].FirstChild;
                    var secondData = secondTitle.ChildNodes.ToList();
                    foreach (var s in secondData)
                    {
                        streamWriter.Write(s.FirstChild.InnerText);
                        streamWriter.WriteLine(": " + s.LastChild.InnerText);
                    }
                    i += 1;
                    streamWriter.WriteLine();
                }
            }

            HtmlWeb itemWeb = new HtmlWeb();
            List<string> itemList = new List<string>();
            doc = itemWeb.Load(itemUrl);
            var itemNodes = doc.DocumentNode.SelectNodes(
                "//html/body/div/div/div/section/article/table/tbody/tr/td")
                .ToList();
            foreach (var s in itemNodes)
            {
                if (s.Attributes["class"] != null)
                {
                    if (s.Attributes["class"].Value == "cell-xlarge" && s.FirstChild.Name == "a")
                    {
                        itemList.Add(s.FirstChild.Attributes["href"].Value);
                    }
                }
            }
            Console.WriteLine("All items names parsed.");

            using (StreamWriter sr = new StreamWriter("ItemData.txt"))
            {
                float i = 0f;
                foreach (var s in itemList)
                {
                    Console.WriteLine("Progress: {0:N3}", i / itemList.Count);
                    sr.WriteLine(s);
                    var tempDoc = itemWeb.Load(siteUrl + s);
                    var tempNode = tempDoc.DocumentNode.SelectNodes(
                        "/html/body/div/div/div/div/div/div/div/section/article/div/div/div").ToList();
                    foreach (var x1 in tempNode)
                    {
                        if (x1.Attributes["class"] != null)
                        {
                            if (x1.Attributes["class"].Value == "tooltip-header")
                            {
                                foreach(var x2 in x1.ChildNodes)
                                {
                                    if (x2.Attributes["class"].Value == "price")
                                    {
                                        sr.WriteLine(x2.LastChild.FirstChild.InnerText);
                                    }
                                }
                            }
                            if (x1.Attributes["class"].Value == "stats")
                            {
                                foreach (var x2 in x1.ChildNodes)
                                {
                                    sr.WriteLine(x2.InnerText);
                                }
                            }
                        }
                    }
                    sr.WriteLine();
                    i += 1f;
                }

            }
        }

        static private bool GetAttribValue(HtmlNode s, string attrib)
        {
            if (s.Attributes[attrib] != null)
            {
                return s.Attributes[attrib].Value == "hero_attributes"; // the section with such a string
            }
            else
            {
                return false;
            }
        }
    }
}
