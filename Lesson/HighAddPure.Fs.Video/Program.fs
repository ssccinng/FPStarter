// For more information see https://aka.ms/fsharp-console-apps
let swapArgs f = fun x y -> f y x

let data = [1..100]
let isMod n = fun x -> x % n = 0
let getmod2 = List.filter (isMod 2)
data |> getmod2 |> printfn "%A"

printfn ("%A") (List.filter (isMod 2) data)

let myWhere f l = [for x in l do if f x then yield x]

data |> myWhere (isMod 3) |> printfn "%A"

