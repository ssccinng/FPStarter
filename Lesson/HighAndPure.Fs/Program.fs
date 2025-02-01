// For more information see https://aka.ms/fsharp-console-apps
let swapArgs f = fun a b -> f b a
let f (a:int) b = a < b
let f1 (a:float) b = a < b
swapArgs f |> ignore
swapArgs f1 |> ignore

let data = [1..100] // 0,1....100
let isMod n = fun c -> c % n = 0
data |> List.filter (fun c -> c % 2 = 0) |> printfn "%A"
data |> List.filter (isMod 2) |> printfn "%A"
printfn ("%A") (List.filter (isMod 2) data)


module MyLinq = 
     let myWhere f l = [for x in l do if f x then yield x]

open MyLinq

data |> myWhere (isMod 2) |> printfn "%A"
let dataf = [1..100] |> List.map (fun x -> x |> float)
dataf |> myWhere (fun x -> x % 2.0 = 0.0) |> printfn "%A"
open System.Net.Sockets
module HofSocket =
    let sendSth (ip: string) port f =
        use socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        socket.Connect(ip, port)
        f socket |> ignore
        let buffer = Array.create 1024 0uy
        let cnt = socket.Receive buffer
        buffer |> Array.take cnt
        
        
    let send2Localhost = sendSth "127.0.0.1" 8080 
    let sendHelloWorld = send2Localhost (fun s -> s.Send(System.Text.Encoding.ASCII.GetBytes("Hello World!")))
        

module methods =
    let mutable sth = 1
    let notPureAddReturn() =
        sth <- sth + 1
        sth
    let getSth() = sth
    
    let notPureAdd() =
        sth <- sth + 1
        ()
    let pureAdd n = n + 1
    
open methods

