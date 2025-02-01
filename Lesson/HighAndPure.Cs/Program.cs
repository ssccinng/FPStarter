// See https://aka.ms/new-console-template for more information

using System.Net.Sockets;
using System.Text;

Paper paper = new Paper();

int ReturnOne(Student student) {
    paper.Delete();
    student.Sleep();
    throw new Exception("想要1吗 不给你");
}
paper.Write(ReturnOne(me));

Console.WriteLine(WhoPure.NotPureAddReturn());
Console.WriteLine(WhoPure.NotPureAddReturn());
Console.WriteLine(WhoPure.NotPureAddReturn());
Console.WriteLine(WhoPure.NotPureAddReturn());

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
return;
// hof避免重复


Func<string, Func<int, Func<Func<Socket, byte[]>, byte[]>>> sendSth;
sendSth = (string ip) => (int port) => (Func<Socket, byte[]> send) => {
    using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
    {
        socket.Connect(ip, port);
        return send(socket);
    }
};


// 适配器函数
Func<int, int, bool> SwapArgs(Func<int, int, bool> func)
{
    return (a, b) => func(b, a);
}

public static class MyLinq
{
    public static IEnumerable<TSource> MyWhere<TSource, TKey>(
        this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
                yield return item;
        }
    }
}

public class NormalSocket

{

  public byte[]SendHelloWorld(string ip, int port)

  {

    // 反复的using代码与连接代码

   using(var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))

    {

      socket.Connect(ip, port);

      var data = Encoding.UTF8.GetBytes("Hello World");

      socket.Send(data);

      var buffer = new byte[1024];

      var count = socket.Receive(buffer);

      return buffer.Take(count).ToArray();

    }

  }

  public byte[] SendTwoHelloWorld(string ip, int port)

  {

   using(var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))

    {

      socket.Connect(ip, port);

      var data = Encoding.UTF8.GetBytes("Hello World");

      socket.Send(data);

      var buffer = new byte[1024];

      var count = socket.Receive(buffer);

      socket.Send(data);

      count = socket.Receive(buffer);

      return buffer.Take(count).ToArray();

    }

  }

 

}

public static class HofSocket
{
    public static byte[] SendSth(string ip, int port, Action<Socket> send)
    {
        return Connect(ip, port)(send);
    }
    public static byte[] SendHelloWorld(string ip, int port)
    {
        return Connect(ip, port)(socket => {
            var data = Encoding.UTF8.GetBytes("Hello World");
            socket.Send(data);
        });
    }

    public static Func<Action<Socket>, byte[]> Connect(string ip, int port)
    {
        return send => {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Connect(ip, port);
                send(socket);
                var buffer = new byte[1024];
                var count = socket.Receive(buffer);
                return buffer.Take(count).ToArray();
            }
        };
    }

    public static byte[] Send2Localhost( Action<Socket> send)
    {
        return Connect("localhost", 8080)(send);
    }
}

public static class WhoPure
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