// See https://aka.ms/new-console-template for more information

using LanguageExt;
using LanguageExt.Common;
using static LanguageExt.Prelude;

Option<int> a;

Either<int, string> b; // Left Right
// MapLeft, BindLeft Either<int, int>
// Option.None
// Either 这个
// Exception

var testEither = DoSth(3);

testEither.Match(
    Left: l => Console.WriteLine(l),
    Right: r => Console.WriteLine($"dosth succ! {r}")
);

Either<string, EquipmentF> DoSth(int id) =>
    id.Get()
        .Bind(EquipmentExtensions.Open)
        .Bind(EquipmentExtensions.Pre)
        .Bind(EquipmentExtensions.DoSth)
        .Bind(EquipmentExtensions.Close);

var tryb = Try(() =>
{
    // throw new Exception("test");
    return 1;
});
var resb = tryb.Invoke();
var s = resb.Match(
    Succ: s => s.ToString(),
    Fail: e => e.Message
);
Console.WriteLine(s);
// Either<IEnumerable<string>,T>>


// balbal t

// Run<T>: (() -> T) -> Result<T>
// public delegate Result<T> Try<T>();
//
// public static class TryExtensions
// {
//     public static Result<T> Run<T>(this Try<T> tryFunc)
//     {
//         try
//         {
//             return tryFunc();
//         }
//         catch (Exception e)
//         {
//             return new(e);
//         }
//     }
// }

int SomeMethod()
{
    throw new NotImplementedException();
    return 1;
}

bool DoSth1(int id)
{
    var equip = Equipment.Get(id);
    if (equip == null)
    {
        throw new Exception("No equipment found");
    }

    var open = equip.Open();
    if (!open)
    {
        throw new Exception("open failed");
        return false;
    }

    var dosth = equip.DoSth();
    if (!dosth)
    {
        throw new Exception("dosth failed");
        return false;
    }

    var close = equip.Close();
    if (!close)
    {
        throw new Exception("close failed");
        return false;
    }

    return true;
}

public record EquipmentF;

public static class EquipmentExtensions
{
    public static Either<string, EquipmentF> Get(this int id)
    {
        Console.WriteLine("Get called");
        return new EquipmentF();
    }

    public static Either<string, EquipmentF> Open(this EquipmentF equipment)
    {
        Console.WriteLine("Open called");
        return equipment;
    }

    public static Either<string, EquipmentF> Pre(this EquipmentF equipment)
    {
        Console.WriteLine("Pre called");
        return "与处理失败";

        return equipment;
    }

    public static Either<string, EquipmentF> DoSth(this EquipmentF equipment)
    {
        Console.WriteLine("DoSth called");


        return equipment;
    }

    public static Either<string, EquipmentF> Close(this EquipmentF equipment)
    {
        Console.WriteLine("Close called");

        return equipment;
    }
}

public class Equipment
{
    public static Equipment Get(int id)
    {
        return new Equipment();
        return null;
    }

    public bool Open()
    {
        return true;
    }

    public bool Pre()
    {
        return true;
    }

    public bool DoSth()
    {
        return true;
    }

    public bool Close()
    {
        return true;
    }
}
