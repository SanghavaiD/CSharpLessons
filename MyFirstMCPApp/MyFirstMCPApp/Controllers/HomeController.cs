using Microsoft.AspNetCore.Mvc;
using MyFirstMCPApp.Models;

using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;

namespace MyFirstMCPApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DoLogin(String txtUser, String txtpwd)
        {
            ViewData["userValue"] =$"{ txtUser},{ txtpwd }";
            return View();
        }
        public IActionResult SayHello(String name)
        {
            if (string.IsNullOrEmpty(name))
            
                ViewData["v1"] = "Name is empty";
            else
                ViewData["v1"] = name;
            return View();
        }
        public IActionResult Add(int x ,int y)
        {
            int result = x + y;
            ViewData["addResult"] = result;
            return View();
        }
        public IActionResult Multiply(int x, int y)
        {
            int result = x * y;
            ViewData["addResult"] = result;
            return View(Add);
        }
        public IActionResult Divide(int x, int y)
        {
            int result = x / y;
            ViewData["addResult"] = result;
            return View(Add);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //WORKING WITH BOOK OBJECT
        public IActionResult AddNewBook()
        {
            Book book = new Book();
            return View();
        }
        public IActionResult SaveNewBook(Book pBook)
        {
            String fName = @"d:\temp\book.csv";
            string strBook = $"{pBook.BookID},{pBook.Title} ,{pBook.AuthorName} , {pBook.Cost}";
            using(StreamWriter sw = new StreamWriter (fName,true))
            {
                sw.WriteLine(strBook);
            }
            return View(pBook);
        }
        public IActionResult ListAllBook()
        {
            String fNmae = @"d:\temp\book.csv";
            List<Book> list = new List<Book>();
            using (StreamReader sr = new StreamReader(fNmae))
            {
                string strBook = $"{sr.ReadLine()}";
                String[] data = strBook.Split(',');
                Book book = StringToBook(data, new Book());
                list.Add(book);
                while (!sr.EndOfStream)
                {
                    strBook = $"{sr.ReadLine()}";
                    data = strBook.Split(',');
                    book = StringToBook(data, new Book());
                    list.Add(book);
                }
            }
            return View(list);
        }
        Book book = new Book();
        private Book StringToBook(String[] data, Book book)

        {
           
            book.BookID = int.Parse(data[0]);
            book.Title = data[1];
            book.AuthorName = data[2];
            book.Cost = float.Parse(data[3]);
            return book;
        }

        //WORKING WITH AUTHOR

        public IActionResult NewAuthor()
        {
            Author author =new Author();
            return View();
        }
        public IActionResult SaveAuthor(Author sauthor)
        {
            String fNames = @"D:\temp\author.csv";
            string strAuthor = $"{sauthor.AuthorID},{sauthor.NumberofBooks},{sauthor.AuthorName},{sauthor.RoyaltyCompany},{sauthor.AuthorDob}";
            using (StreamWriter sw = new StreamWriter(fNames, true))
            {
                sw.WriteLine(strAuthor);
            }
            return View(sauthor);
        }
        public IActionResult ListAllAuthor()
        {
            String fNames = @"D:\temp\author.csv";
            List<Author> list = new List<Author>();
            using (StreamReader sr = new StreamReader(fNames))
            {
                string strAuthor = $"{sr.ReadLine()}";
                String[] data = strAuthor.Split(',');
                Author author = StringToAuthor(data, new Author());
                list.Add(author);
                while (!sr.EndOfStream)
                {
                    strAuthor = $"{sr.ReadLine()}";
                    data = strAuthor.Split(',');
                    author = StringToAuthor(data, new Author());
                    list.Add(author);
                }
            }
            return View(list);
        }

        public IActionResult SearchAuthor(String name)

        {
            string fName = @"D./temp/author.csv";
            Author a1 = new Author();
            using (StreamReader sr = new StreamReader(fName))
            {
                while (!sr.EndOfStream)
                {
                    String strAuthor = $"{sr.ReadLine}";
                    String[] data = strAuthor.Split(',');
                    if (name == data[2])
                    {
                        a1=StringToAuthor(data , new Author());
                        
                    }
                }

            }
            return View(a1);
        }
       Author author = new Author();

        private Author StringToAuthor(String[] data, Author author)

        {
           
            author.AuthorID = int.Parse(data[0]);
            author.AuthorName = data[1];
            author.RoyaltyCompany = data[2];
            author.NumberofBooks = float.Parse(data[3]);

            author.AuthorDob = DateTime.Parse(data[4]);
            return author;
        }
       
        
    }
}