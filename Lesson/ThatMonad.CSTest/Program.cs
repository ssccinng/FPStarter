// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

// var str = File.ReadAllText("dani.html");

// HttpClient client = new HttpClient();

// Regex.Matches(str, @"https://sns-webpic-qc.xhscdn.com[^""]*")
//     .Select(m => m.Value)
//     .Select(client.GetByteArrayAsync)
//     .Select(t => t.Result)
//     .ToList()
//     .ForEach(t => File.WriteAllBytes(Guid.NewGuid().ToString() + ".jpg", t));

string ageStr = "20";
Option<int> ageInt = ageStr.ParseInt();
Option<Option<Age>> age = ageInt.Map(Age.Create);


int[] ints = { 1, 2, 3, 4, 5 };
var doubled = ints.Select(i => i * 2).ToArray();

var doubled2  = ints.SelectMany(i => new [] {i, i * 2}).ToArray();
System.Console.WriteLine(string.Join(", ", doubled2));
// 1, 2, 2, 4, 3, 6, 4, 8, 5, 10

var a = (string s) => s.ParseInt().Bind(Age.Create);

"23".ParseInt()
    .Map(s => s * 2)
    .Bind(Age.Create)
    .Map(s => s.Value <= 18)
    .ForEach(s => {
        System.Console.WriteLine(s ? "Under 18" : "Over 18");
    });




var t = new Some<string>("Hello");

t.Match(
    Some: s => s + "!",
    None: () => "None"
);

t.Match<string, Option<string>>(
    Some: s => new Some<string>(s + "!"),
    None: () => new None<string>()
);


t.Match<string, Option<int>>(
    Some: s => new Some<int>(s.Length),
    None: () => new None<int>()
);

t.Match<string, Option<int>>(
    Some: s => {
        if (int.TryParse(s, out var i))
            return new Some<int>(i);
        else
            return new None<int>();
    },
    None: () => new None<int>()
);



string AddMark(Option<string> t) => t switch
{
    Some<string> s => s.Value + "!",
    None<string> _ => "None"
};

static class OptionExtention
{
    public static R Match<T, R> (this Option<T> t, Func<T, R> Some, Func<R> None) => t switch
    {
        Some<T> (var s) => Some(s),
        None<T> _ => None(),
        _ => throw new Exception("Invalid Option")

    }; 
    public static Option<R> Map<T, R> (this Option<T> t, Func<T, R> f) => t.Match<T, Option<R>>(
        Some: s => new Some<R>(f(s)),
        None: () => new None<R>()
    );

    public static Option<R> Bind<T, R> (this Option<T> t, Func<T, Option<R>> f) => t.Match<T, Option<R>>(
        Some: s => f(s),
        None: () => new None<R>()
    );
    public record Unit;
    public static void ForEach<T> (this Option<T> t, Action<T> f) => t.Match<T, Unit>(
        Some: s => { f(s); return new Unit(); },
        None: () => new Unit()
    );

    public static Option<int> ParseInt(this string s)
         => int.TryParse(s, out var i) ? new Some<int>(i) : new None<int>(); 
}


interface Option<T>;
record Some<T>(T Value): Option<T>;
record None<T>(): Option<T>;

record Age
{
    public int Value { get; }
    private Age(int value) => Value = value;
    public static Option<Age> Create(int value)
    {
        if (value < 1 || value > 120)
            return new None<Age>();
        else
        {
            return new Some<Age>(new Age(value));
        }
    }
}


