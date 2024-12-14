// 第一类公民

using System.Threading.Channels;

var lessThan = (int a, int b) => a < b;
var greaterThan = SwapArgs(lessThan);

Console.WriteLine(lessThan(1, 2));
Console.WriteLine(greaterThan(1, 2));

// 不可变性

int[] seq = [5, 7, 3, 9, 1];
Array.Sort(seq);
Array.Reverse(seq);
Console.WriteLine(string.Join(", ", seq));
seq = [5, 7, 3, 9, 1];
;
Console.WriteLine(string.Join(", ", seq.Order().Reverse()));

var seq2 = Enumerable.Range(1, 100000).Select(s => (long)s).ToArray();
Random.Shared.Shuffle(seq2);

var task1 = () =>
{
    Array.Sort(seq2);
    Array.Reverse(seq2);

    Console.WriteLine(string.Join(",", seq2.Take(6)));
};
var task2 = () => Console.WriteLine("Sum:" + seq2.Sum());

Parallel.Invoke(task1, task2);
Random.Shared.Shuffle(seq2);

task1 = () => Console.WriteLine(string.Join(",", seq2.Order().Take(6)));
task2 = () => Console.WriteLine("Sum:" + seq2.Sum());
Parallel.Invoke(task1, task2);

int a = 0;
int b = 5;
switch (b)
{
    case 1: a = 3; break;
    case 5 :a = 4; break;
    case 7:a = 8; break;
    default: a = 12; break;
}

var a2 = (b switch {1 => 3, 5 => 4, 7 => 8, _ => 12 }).ToString().Reverse();

Action<int> print = Console.WriteLine;



Func<int, int, bool> SwapArgs(Func<int, int, bool> func)
{
    return (a, b) => func(b, a);
}

 