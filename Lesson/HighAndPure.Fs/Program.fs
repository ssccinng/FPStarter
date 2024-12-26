// For more information see https://aka.ms/fsharp-console-apps
let swapArgs f = fun a b -> f b a

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

