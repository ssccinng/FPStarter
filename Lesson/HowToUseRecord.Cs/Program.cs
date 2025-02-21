// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;

// Book book = new Book("1", "2");
// Book book2 = new Book("1", "2");
// Console.WriteLine(book);
// Console.WriteLine(book with { Title = "FP" });
// Console.WriteLine(book);

// var (t, a) = book;

Circle circle = new Circle(2);
Console.WriteLine(circle.Scale(2));
Console.WriteLine(circle.Scale(0.5));

string[] authors =
[
    .. Enumerable.Repeat("Scixing", 6),
    .. Enumerable.Repeat("Moob", 6),
    .. Enumerable.Repeat("BoredYear", 6),
];
var books = authors
    .Select(a => new Book
        ("Book", a, 10,
            Enumerable.Range(1, Random.Shared.Next(20))
                .Select(s => 
                    new Page(s, $"Page {s}"))
                .ToImmutableList()
        )
    ).ToList();

var booksWithTailPage = books.Select(BookExtensions.AddTailPage);

Console.WriteLine(string.Join(",", booksWithTailPage.Select(s => s.Pages.Count)));
Console.WriteLine(string.Join(",", books.Select(s => s.Pages.Count)));

var newBooks = books
    .Select(BookExtensions.AddTailPage)
    .Where(s => s is { Author: "Scixing" or "BoredYear", Pages.Count: > 12})
    .Select(s => s.Slice(2, 10))
    ;

var myBook = newBooks.First() switch
{
    { Author: "Scixing" } => true,
    _ => false
};

newBooks.ToList()
    .ForEach(Console.WriteLine);


public record Page(int PageIndex, string Content);

public record Book(
    string Title,
    string Author,
    int Price,
    ImmutableList<Page> Pages
);

public record Circle(double Radius);

public static class CircleExtensions
{
    public static Circle Scale(this Circle circle, double factor) =>
        circle with { Radius = circle.Radius * factor };
}

public static class BookExtensions
{
    public static Book AddTailPage(this Book book)
        => book with
        {
            Pages = book.Pages.Add(new Page(book.Pages.Count + 1,
                book.Pages.Count.ToString()))
        };

    public static Book AddBookTitleMark(this Book book, string symbol)
    {
      return book with { Title = string.Format("{1}{0}{1}", book.Title, symbol) };
    }

    public static Book Slice(this Book book, int start, int count)
    {
        return book with { Pages = book.Pages.Skip(start).Take(count).ToImmutableList() };
    }

}