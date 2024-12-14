// See https://aka.ms/new-console-template for more information

int[] a = [5, 3, 1, 4, 6];
Array.Sort(a);
Console.WriteLine(string.Join(",", a));
//1,3,4,5,6

int[] b = [5, 3, 1, 4, 6];
b.Order().Select(s => s * 2).ToArray(); // -> IOrderEnumerable<int>
Console.WriteLine(string.Join(",", b));
// 5,3,1,4,6

var c = Enumerable.Range(-100000, 200000)
    .Select(s => (long)s)
    .ToArray();
Random.Shared.Shuffle(c);
var task = () =>
{
    Array.Sort(c);
    Console.WriteLine("1:" + c.Sum());
};

var task2 = () => { Console.WriteLine("2:" + c.Sum()); };

Parallel.Invoke(task, task2);


Random.Shared.Shuffle(c);
var task3 = () => { Console.WriteLine("1:" + c.Order().Sum()); };

var task4 = () => { Console.WriteLine("2:" + c.Sum()); };

Parallel.Invoke(task3, task4);


string info = string.Empty;

UserStatus status = UserStatus.Idle;

switch (status)
{
    case UserStatus.Idle:
        info = "Idle";
        break;

    case UserStatus.Offline:
        info = "Offline";
        break;
    default:
        info = "Unknown";
        Console.WriteLine(1);
        break;
        
}

string info2 = status switch
{
    UserStatus.Idle => "Idle",
    UserStatus.Offline => "Offline",
    _ => "Unknown"
};

enum UserStatus
{
    Online,
    Offline,
    Idle,
}