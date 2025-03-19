// See https://aka.ms/new-console-template for more information
var hello = new Some<string>("Hello World");
var markhello = hello.Map(s => s + "1").Map(s => s + "1");
Console.WriteLine(markhello.Match(Some: s => s, () => "None"));
Console.WriteLine(markhello.Map(s => s.Length).Match(Some: s => s, () => 0));
int[] arr= { 1, 2, 3, 4, 5 };
arr.Select(s => s * 2);
var arrDouble = arr.SelectMany(s => new [] { s * 2 });

Console.WriteLine(string.Join(", ", arrDouble));




Option<string> AddMark(Option<string> t) => t.Match<string, Option<string>>(
    Some: v => new Some<string>( v + "!"),
    None: () => new None<string>()
);

Option<int> GetLength(Option<string> t) => t.Match<string, Option<int>>(
    Some: v => new Some<int>( v.Length),
    None: () => new None<int>()
);

string agestr = "20";
var ageInt = agestr.ParseInt();
var age = ageInt.Bind(Age.Create);
// Option<Age>

"6az"
    .ParseInt()
    .Map(s => s * 2)
    .Bind(Age.Create)
    .Map(age => age.Value <= 18)
    
    .ForEach( // iter
        s =>
        {
            Console.WriteLine(s ? "Under 18" : "Over 18");
        });



static class OptionExtensions
{
    public static R
        Match<T, R>(this Option<T> t, Func<T, R> Some, Func<R> None) => t switch
    {
        Some<T>(var s) => Some(s),
        None<T> => None(),
    };
    
    

    public static Option<R> Map<T, R>(this Option<T> t, Func<T, R> f) =>
        t.Match<T, Option<R>>(Some: v => new Some<R>( f(v)), None: () => new None<R>());
    
    public static Option<R> Bind<T, R>(this Option<T> t, Func<T, Option<R>> f) =>
        t.Match<T, Option<R>>(Some: v => f(v), None: () => new None<R>());

    
    public static Option<int> ParseInt(this string s) => int.TryParse(s, out var i) 
        ? new Some<int>(i) 
        : new None<int>(); 
    
    public record Unit;
    public static void ForEach<T> (this Option<T> t, Action<T> f) => t.Match<T, Unit>(
        s => { f(s); return new Unit(); },
        () => new Unit()
    );
}
record Age {
    public int Value { get; }

    public static Option<Age> Create(int value)
    {
        if (value < 1 || value > 120) return new None<Age>();
        return new Some<Age>(new Age(value));
    }

    private Age(int value)
    {
        Value = value;  
    }
}
interface Option<T>;
record Some<T>(T Value): Option<T>;
record None<T>(): Option<T>;