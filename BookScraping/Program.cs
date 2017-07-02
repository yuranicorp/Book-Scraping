using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace BookScraping
{
    class Program
    {

        static string baseUrl = "https://www.goodreads.com/search?utf8=%E2%9C%93&query=";

        static List<string> bookList = new List<string>();
        static List<string> penulisList = new List<string>();
        static List<string> ratingList = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Silahkan masukkan jenis buku...");
            string searchKey = Console.ReadLine();
            Console.WriteLine("Sedang mencari informasi buku...");
            baseUrl = baseUrl.Replace("query=", "query=" + searchKey).Replace(" ", "+");

            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(baseUrl);

            var bookName = doc.DocumentNode.SelectNodes("//a[@class='bookTitle']//span[@itemprop='name']").ToList();
            var penulis = doc.DocumentNode.SelectNodes("//a[@class='authorName']//span[@itemprop='name']").ToList();
            var rating = doc.DocumentNode.SelectNodes("//span[@class='minirating']").ToList();

            foreach(var book in bookName)
            {
                bookList.Add(book.InnerText);
            }
            foreach(var writter in penulis)
            {
                penulisList.Add(writter.InnerText);
            }
            foreach(var rate in rating)
            {
                ratingList.Add(rate.InnerText);
            }

            showOutput();
            Console.ReadLine();
        }
        
        static private void showOutput()
        {
            for(int i = 0; i < bookList.Count; i++)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("Nama Buku: " + bookList[i]);
                Console.WriteLine("Penulis  : " + penulisList[i]);
                ratingList[i] = ratingList[i].Replace("&mdash;", "--");
                Console.WriteLine("Rating   : " + ratingList[i]);
                //Thanks for watching :) //Lee Yurani~
            }
        }
    }
}
