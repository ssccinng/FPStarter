using System.Collections.Immutable;
//using LanguageExt;
//using static LanguageExt.Prelude;
string[] authors = [ 
    ..Enumerable.Repeat("Scixing", 6),
    ..Enumerable.Repeat("Moob", 6),
    ..Enumerable.Repeat("BoredYear", 6)
] ;


var books = authors
    .Select(author => 
        new Book("Book", author, 10,
            [.. Enumerable.Range(1, Random.Shared.Next(20))
                .Select(s => new Page(s, $"Page {s}"))]
        )
    )
    .ToList();

var bookWithTailPage = books
    .Select(b => b.AddTailPage(new Page(b.Pages.Count + 1, "Tail Page")))
    .ToList();

books
    .Select(BookExtensions.AddBookTitleMarker)
    .Where(s => s.Author == "Scixing" || s.Author == "Moob")
    .Where(s => s.Pages.Count > 7)
    .ToList()
    .ForEach(Console.WriteLine);
;

books
    .Select(BookExtensions.AddBookTitleMarker)
    .Where(s => (s.Author == "Scixing" || s.Author == "Moob") && s.Pages.Count > 7)
    .ToList()
    .ForEach(Console.WriteLine);
;


books
    .Where
    (s => s is { 
        Author: "Scixing" 
        or "Moob",
        Pages.Count: > 7 
    })
    .Select(BookExtensions.AddBookTitleMarker)
    .Select(b => b.Slice(1, 5))
    .ToList()
    .ForEach(Console.WriteLine);
;


public record Page(int PageIndex, string Content);

public record Book(
    string Title,
    string Author,
    int Price,
    ImmutableList<Page> Pages
);

public static class BookExtensions
{
    public static Book AddTailPage(this Book book, Page page) => book with { Pages = book.Pages.Add(page) };

    public static Book Slice(this Book book, int start, int count) => book with { Pages = [.. book.Pages.Skip(start).Take(count)] };

    public static Book AddBookTitleMarker(this Book book) => book with { Title = $"<<{book.Title}>>" };
}