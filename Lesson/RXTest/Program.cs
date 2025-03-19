// See https://aka.ms/new-console-template for more information

using System.Reactive;
using System.Reactive.Linq;

var a = Observable.Range(1, 10);
var b = a.Zip(a.Skip(1), (x, y) => (x, y)).Subscribe(onNext: s =>
{
    Console.WriteLine(s);
});


