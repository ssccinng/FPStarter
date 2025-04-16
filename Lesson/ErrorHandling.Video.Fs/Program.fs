// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

let a b = if b = 1 then Ok 1 else Error "gg"
let a1 = 1
let b1 = 0
let b =
    try Ok (a1 / b1)
    with
    | :? System.DivideByZeroException  -> Error "1" 