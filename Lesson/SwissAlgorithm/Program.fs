// For more information see https://aka.ms/fsharp-console-apps
type SwissPlayer = {
    Id: string
    Score: int
    ForceLunkong: bool
    PlayedAgainst: string list
}
  
type BattleInfo = {
    Player1: SwissPlayer
    Player2: SwissPlayer
    
}

type SwissRound = {
    Round: int
    Battles: BattleInfo list
}

type SwissTournament = {
    Players: SwissPlayer list
    Rounds: SwissRound list
}

let aa = try { Id = "1"; Score = 1; ForceLunkong = false; PlayedAgainst = [] } with | ex -> failwithf "Error: %s" ex.Message
let a = [Some 1; None; Some 1]
a |> Option.Tra
module SwissTool =
    let filiterLunkong (players: SwissPlayer list) = 
        players |> List.filter (fun x -> x.ForceLunkong = false)

    let paring  (players: SwissPlayer list) = // 给出的就需要按照排序拍好
        let rec loop (players: SwissPlayer list) (acc: BattleInfo list) = 
            let sortedPlayers = players |> List.sortByDescending (fun x -> x.Score)
            match sortedPlayers with
            | [] -> acc
            | x::xs -> 
                let player1 = x
                let player2 = xs |> List.tryFind (fun x -> not (List.contains x.Id player1.PlayedAgainst))
                match player2 with
                | Some p2 -> 
                    let battle = { Player1 = player1; Player2 = p2 }
                    loop xs (battle::acc)
                | None -> acc
            | _ -> acc
        loop players []