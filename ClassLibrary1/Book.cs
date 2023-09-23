namespace LibraryA
{
    public class Book
    {
        public string Title = string.Empty;
        public string Author = string.Empty;
        public String Genre = string.Empty;
        public DateTime DateOfPublish;
        public int BookPrice;
        public int TotalPages=300;
       
        public void OpenBook()
        {
            Console.WriteLine("Book is Open");

        }
        public void BookMarkPage(int pageNo)
        {
            Console.WriteLine($"Page No.:{pageNo} BookMarked");
        }

        public int GetCurrentPage()
        {
            Random r = new Random();
            return r.Next(TotalPages);
        }
    }
}