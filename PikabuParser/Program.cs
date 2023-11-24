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
using System.Windows.Markup;

namespace PikabuParser
{
    internal class Program
    {
        static void Main()
        {
            IWebDriver driver = new ChromeDriver(); //создаем драйвер
            driver.Url = "https://4pda.to/forum/index.php?showtopic=1056193";//задаем сылку на страницу форума
            IList<IWebElement> names = driver.FindElements(By.ClassName("normalname"));//находим все IWebElement с наименованием класса normalname
            IList<IWebElement> texts = driver.FindElements(By.ClassName("postcolor"));//находим все IWebElement с наименованием класса postcolor
            IList<IWebElement> idblocks = driver.FindElements(By.ClassName("ipbtable"));//находим все IWebElement с наименованием класса ipbtable
            IList<IWebElement> updatedList = idblocks.Skip(1).ToList();//создаем новый список с ipbtable но без одного лишнего элемента
            List<int> ids = new List<int>();//будущий список с id комментариев
            foreach (IWebElement idblock in updatedList)//для каждого элемента с названием класса ipbtable
            {
                ids.Add(Convert.ToInt32(idblock.GetAttribute("data-post")));//забираем значение атрибута data-post и закидываем его в List
            }
            Console.WriteLine(names[1].Text);//I_M_H_O
            Console.WriteLine(texts[1].Text);//приложение устанавливается без ярлыка
            Console.WriteLine(ids[1]);//117958126

            //Class1 class1 = new Class1();//создание экземпляра класса для работы с бд
            //for (int i = 1; i < names.Count; i++)//запускаем массив
            //{
            //    class1.Add(ids[i], names[i].Text, texts[i].Text);//вставляем все значения по очереди
            //}
        }
    }
}