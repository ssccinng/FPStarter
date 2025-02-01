// See https://aka.ms/new-console-template for more information
int AddOne(int a) => a + 1;


var f1 = () => "Hello, World!";
var f2 = () => 42;
var f3 = (int a, int b) => a + b;
var f4 = (string s) => s.Length;
var f5 = (int x) => x % 2 == 0;
var f6 = () => Console.WriteLine("Hello, World!");

bool IsAgeYoung(int age)
{
    if (age < 0 || age > 120)
    {
        throw new ArgumentException("Age must be between 0 and 120");
    }
    return age <= 24;
}

bool IsAgeYoung1(Age age) => age.Value <= 24;


public class Age
{
    public int Value { get; }

    public Age(int value)
    {
        if (value < 0 || value > 120) 
            throw new ArgumentException("Age must be between 0 and 120"); 
        Value = value;
    }
}
