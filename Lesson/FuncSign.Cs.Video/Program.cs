// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Func<string> f1 = () => "Hello, World!";

int AddOne(int a) => a + 1; // int -> int unit ()

var f2 = () => Console.WriteLine("Hello, World!"); // unit -> unit

// int -> bool
// PlayerLv -> bool

//Where Filter: (IEnumerable<T>, (T -> bool)) -> IEnumerable<T>

var f3 = (int a, int b) => a + b; // (int, int) -> int

// Age: int
// 121 * 2 = 242
bool IsAgeYoung(PersonData personData)
{
    return personData.Age.Value <= 24;
} // Age -> bool




// () -> string          () => "Hello, World!"; 
// () -> int             () => 42;
// (int, int) -> int     (int a, int b) => a + b;
// string -> int         (string s) => s.Length;
// int -> bool           (int x) => x % 2 == 0;
// () -> ()              () => Console.WriteLine("Hello, World!");


Func<int, int, bool> SwapArgs(Func<int, int, bool> func)
{
    return (a, b) => func(b, a);
}

public class Age {
    public int Value { get; }
    public Age(int value) {
        if (value < 0 || value > 120) 
            throw new ArgumentException("Age must be between 0 and 120"); 
        Value = value;
    }
}
public enum Gender
{
    Female,
    Male
    }

public class PersonData
{
    public Age Age { get; set; }  = null;
    public Gender Gender { get; set; }
}


// ((int, int) -> bool) -> ((int, int) -> bool)
// ((a, b) -> c) -> ((b, a) -> c)

