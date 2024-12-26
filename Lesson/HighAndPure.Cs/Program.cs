// See https://aka.ms/new-console-template for more information

Console.WriteLine(Test.NotPureAddReturn());
Console.WriteLine(Test.NotPureAddReturn());
Console.WriteLine(Test.NotPureAddReturn());
Console.WriteLine(Test.NotPureAddReturn());

Console.WriteLine(1.PureAdd());
Console.WriteLine(1.PureAdd());
Console.WriteLine(1.PureAdd().PureAdd());

// 函数生成函数

int[] seq = Enumerable.Range(1, 100).ToArray();
var evens = seq.Where(i => i % 2 == 0); 
Console.WriteLine(string.Join(",", evens.Take(5)));

// Predicate<int> IsMod(int n) => x => x % n == 0;
Func<int, bool> IsMod(int n) => x => x % n == 0;
evens = seq.Where(IsMod(2));
Console.WriteLine(string.Join(",", evens.Take(5)));

var modby3 = seq.Where(IsMod(3));
Console.WriteLine(string.Join(",", modby3.Take(5)));

// hof避免重复




// 适配器函数
Func<int, int, bool> SwapArgs(Func<int, int, bool> func)
{
    return (a, b) => func(b, a);
}

public static class MyLinq
{
    public static IEnumerable<TSource> MyWhere<TSource, TKey>(
        this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        foreach (var item in source)
        {
            if (keySelector(item) != null)
                yield return item;
        }
    }
}

public static class Test
{
    static int sth = 0;
    public static int NotPureAddReturn()
    {
        return sth++;
    }

    public static int GetSth() => sth;

    public static void NotPureAdd()
    {
        sth++;
    }

    public static int PureAdd(this int num) => num + 1;

}