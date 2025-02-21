using System.Collections.Immutable;

namespace HowToUseRecord;

// public class Book
// {
//     public string Title { get; set; } = string.Empty;
//     public int Pages { get; set; }
//     public int Price { get; set; }
//     public string[] Contents { get; set; } = [];
// }

public record Page(int PageIndex, string Content);

public record Book(
    string Title
    , string Author
    , int Price
    , ImmutableArray<Page> Pages
    );

public static class BookExtensions
{
    
}

public class Circle
{
    public double Radius { get; set; }

    public void Scale(double factor)
    {
        Radius *= factor;
    }
}