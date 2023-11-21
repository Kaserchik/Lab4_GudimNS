using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using DBWork;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace PikabuParser
{
    internal class Program
    {
        static void Main()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.playground.ru/misc/opinion/top_25_anime_o_gejmerah_i_dlya_gejmerov_hudshee_luchshee_i_alternativy_chast_1-1662933";
            IList<IWebElement> names = driver.FindElements(By.ClassName("comments-item-author"));
            IList<IWebElement> texts = driver.FindElements(By.ClassName("comments-item-content"));
            IList<IWebElement> tboxes = driver.FindElements(By.ClassName("comments-item"));
            List<string> ids = new List<string>();
            foreach (IWebElement element in tboxes)
            {
                ids.Add(element.GetAttribute("data-comment-id").ToString());
            }
            Console.WriteLine(names[0].Text);
        }
    }
}