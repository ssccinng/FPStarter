using LanguageExt;
using LanguageExt.Common;
using static LanguageExt.Prelude;
Console.WriteLine("Hello, World!");

var str = Some("Hello");
str.Iter(Console.WriteLine);    
var aa = str.Map(x => None);

var a = retry(Schedule.Forever, SuccessEff(100));
static IO<string> readAllText(string path) =>
    () => File.ReadAllText(path);

static IO<Unit> writeAllText(string path, string text) =>
    () =>
    {
        File.WriteAllText(path, text);
        return unit;
    };
    
public delegate Either<Error, A> IO<A>();
