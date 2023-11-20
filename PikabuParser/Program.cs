using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using DBWork;

namespace PikabuParser
{
    internal class Program
    {
        static void Main()
        {
            var web = new HtmlWeb();
            Console.WriteLine();
            string url = Console.ReadLine();
            var doc = web.Load(url);
            List<CommentInfo> comments = ExtractCommentsInfo(url);

        }

        static List<CommentInfo> ExtractCommentsInfo(string url)
        {
            List<CommentInfo> comments = new List<CommentInfo>();

            var web = new HtmlWeb();
            var doc = web.Load(url);

            // Используем XPath для выбора элементов комментариев
            var commentNodes = doc.DocumentNode.SelectNodes("//div[@class='comments__item']");

            if (commentNodes != null)
            {
                foreach (var commentNode in commentNodes)
                {
                    // Извлечение информации о комментарии
                    string id = commentNode.GetAttributeValue("data-comment-id", "");
                    string username = commentNode.SelectSingleNode(".//span[@class='user__nick']/a")?.InnerText ?? "";
                    string content = commentNode.SelectSingleNode(".//div[@class='comment__content']")?.InnerText.Trim() ?? "";

                    // Добавление информации о комментарии в список
                    comments.Add(new CommentInfo
                    {
                        Id = id,
                        Username = username,
                        Content = content
                    });
                }
            }

            return comments;
        }

        static void SaveToDatabase(List<CommentInfo> comments)
        {
            
        }


        class CommentInfo
        {
            public string Id { get; set; }
            public string Username { get; set; }
            public string Content { get; set; }
        }
    }
}
