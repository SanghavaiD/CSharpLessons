
using LibraryA;
Book book = new Book();
book .Title = "Ton killing a mocking bird";
book.Author = "Harper Lee";
book.Genre = "Social";
book.BookPrice = 250;
book.DateOfPublish = new DateTime(1995, 06, 01);
//book.BookmarkPage(125);
Console.WriteLine(book.GetCurrentPage());
Calculator calculator = new Calculator();
int addResult = calculator.Add(100, 40);
Console.WriteLine(addResult);
int multiplyresult = calculator.Multiply (100, 40);
Console.WriteLine(multiplyresult);
int divideresult = calculator.Divide(100, 40);
Console.WriteLine(divideresult);




