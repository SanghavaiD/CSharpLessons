using System.Xml.Linq;
using System.Text;

namespace MyFirstMCPApp.Models
{
    public class AuthorRepository
    {
        public static Dictionary<int , Author> GetAuthorDictionary()
        {
            String fName = @"D:\temp\Author.csv";
            Dictionary<int , Author> list= new Dictionary<int , Author>();
            bool isFilExists=System.IO.File.Exists(fName);
            if (isFilExists)
            {
                using (StreamReader sr = new StreamReader(fName))
                {
                    string strAuthor = $"{sr.ReadLine()}";
                    String[] data = strAuthor.Split(',');
                    Author author = null;
                    if (data.Length == 5)
                    {
                        author = StringToAuthor(data, new Author());
                        list.Add(author.AuthorID, author);
                        while (!sr.EndOfStream) 
                        {
                            strAuthor = $"{sr.ReadLine()}";
                            Console.WriteLine(strAuthor);
                            data = strAuthor.Split(',');
                            if (data.Length == 5)
                            {
                                author = StringToAuthor(data, new Author());
                                list.Add(author.AuthorID, author);
                            }
                        }
                    }
                }
            }
            return list;
        }
        private static Author StringToAuthor(String[] data, Author author)
        {

            author.AuthorID = int.Parse(data[0]);
            author.AuthorName = data[1];
            author.RoyaltyCompany = data[2];
            author.NumberofBooks = float.Parse(data[3]);
            author.AuthorDob = DateTime.Parse(data[4]);
            return author;
        }
        public static Author FindAuthorById(int id)
        {
            Dictionary<int,Author> list=AuthorRepository.GetAuthorDictionary();
            Author author = null;
            if(list !=null)
            {
                author= list.FirstOrDefault(x => (x.Key == id)).Value;
            }
            return author;
        }
        public static void SaveToFile(Author pAuthor)
        {
            String fName = @"d:\temp\author.csv";
            string strAuthor = $"{pAuthor.AuthorID},{pAuthor.AuthorName},{pAuthor.RoyaltyCompany},{pAuthor.NumberofBooks},{pAuthor.AuthorDob}";
                using(StreamWriter sw=new StreamWriter(fName,true))
                {
                    sw.WriteLine(strAuthor);
                }
        }
        public static void UpdateAuthorToFile(Author pAuthor)
        {
            String fName = @"d:\temp\Author.csv";
            Dictionary<int,Author> list=AuthorRepository.GetAuthorDictionary();
            String strAuthor = String.Empty;
            using (StreamWriter sw = new StreamWriter(fName))
            {
                foreach(Author author in list.Values)
                {
                    if(author.AuthorID !=pAuthor.AuthorID)
                        strAuthor=$"{pAuthor.AuthorID},{pAuthor.AuthorName},{pAuthor.RoyaltyCompany},{pAuthor.NumberofBooks},{pAuthor.AuthorDob}";
                    else
                        strAuthor= $"{pAuthor.AuthorID},{pAuthor.AuthorName},{pAuthor.RoyaltyCompany},{pAuthor.NumberofBooks},{pAuthor.AuthorDob}";
                    sw.WriteLine(strAuthor);
                }
            }
        }
        public static void RemoveAuthor(int id)
        {
            String fName = @"d:\temp\Author.csv";
            Dictionary<int, Author> list = AuthorRepository.GetAuthorDictionary();
            StringBuilder sbAuthors = new StringBuilder(list.Count + 100);
            using (StreamWriter sw = new StreamWriter(fName))
            {
                foreach(Author author in list.Values)
                {
                    if(author.AuthorID !=id)
                    {
                        sbAuthors.Append ($"{author.AuthorID},{author.AuthorName},{author.RoyaltyCompany},"+
                            $"{author.NumberofBooks},{author.AuthorDob} {Environment.NewLine}");
                        
                    }
                }
                File.WriteAllText(fName,sbAuthors.ToString());
            }
        }
    }
}
