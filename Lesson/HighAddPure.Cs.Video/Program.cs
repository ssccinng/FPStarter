// See https://aka.ms/new-console-template for more information

// 高阶函数

using System.Net.Sockets;
using System.Text;



Paper paper = new Paper();
int ReturnOne(Student student) {
    paper.Delete();
    student.Sleep();
    throw new Exception("想要1吗 不给你");
    return 1;
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

Console.WriteLine(WhoPure.NotPureAddReturn());
Console.WriteLine(WhoPure.NotPureAddReturn());
Console.WriteLine(WhoPure.NotPureAddReturn());
Console.WriteLine(WhoPure.NotPureAddReturn());
Console.WriteLine(1.PureAdd());
Console.WriteLine(1.PureAdd());
Console.WriteLine(1.PureAdd().PureAdd());


Func<int> Func(int a, int b, Func<int, int, int> f) => () => f(a, b);
// 适配器函数
Func<int, int, bool> SwapArgs(Func<int, int, bool> func)
{
    return (a, b) => func(b, a);
}

// Linq

int[] seq = Enumerable.Range(1, 100).ToArray();
var evens = seq
.Where(s => s % 2 == 0).Print();
System.Console.WriteLine(string.Join(", ", evens));
Func<int, bool> isMod(int mod) => s => s % mod == 0;
evens = seq.Where(isMod(2));
System.Console.WriteLine(string.Join(", ", evens));
var modby3 = isMod(3);
System.Console.WriteLine(string.Join(", ", seq.Where(modby3)));

System.Console.WriteLine(string.Join(", ", seq.MyWhere(s => s % 2 == 0)));

var sendSth = (string ip) => (string port) => (Action<Socket> send) => 
{
    using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
    {
        socket.Connect(ip, int.Parse(port));
        send(socket);
        var buffer = new byte[1024];
        var count = socket.Receive(buffer);
        return buffer.Take(count).ToArray();
    }
};

var sendLocalhost
 = sendSth("localhost")("8080");

var sendHelloWorld = sendLocalhost(socket => {
    var data = Encoding.UTF8.GetBytes("Hello World");
    socket.Send(data)});

public class NormalSocket
{
    public byte[] SendHelloWorld(string ip, int port)
    {
        // 反复的using代码与连接代码
        using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
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
        using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            socket.Connect(ip, port);
            var data = Encoding.UTF8.GetBytes("Hello World");
            socket.Send(data);
            socket.Send(data);
            var buffer = new byte[1024];
            var count = socket.Receive(buffer);
            count = socket.Receive(buffer);
            return buffer.Take(count).ToArray();
        }
    }
    
}public static class HofSocket
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


public static class MyLinq
{
    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> seq, Func<T, bool> pred)
    {
        foreach (var s in seq)
        {
            if (pred(s))
            {
                yield return s;
            }
        }
    }
}


