
let lessThan a b = a < b
let swapArgs f = fun a b -> f b a
let greaterThan = swapArgs lessThan

printfn "%A" (lessThan 1 2)
printfn "%A" (greaterThan 1 2)

let data = [5; 7; 3; 9; 1]

data |> List.sort |> printfn "%A"

let b = 10
let a = if b = 10 then 2 else 3
