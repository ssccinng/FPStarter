// For more information see https://aka.ms/fsharp-console-apps
open FSharpPlus.Data
open FSharpPlus.Internals
open FSharpPlus

let a = Some 1
a |> Option.iter (printfn "%A")

type AA = {A: int; B: int Lazy }
