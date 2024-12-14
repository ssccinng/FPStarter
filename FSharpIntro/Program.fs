namespace FsharpIntro

type BatteryLevel =
    | Ok = 0

type StationType =
    | 拆盘 = 0
    | 组盘 = 1

type PalletChannel =
    {
        BatteryCode: string option
        Level: BatteryLevel
        Idx: int
    }


type Pallet =
    {
        Code: string option
        PalletChannel: PalletChannel array
        
    }
type WorkStation =
    {
        Pallet: Pallet option
        StationNum: int // 是否要可变？
        StationType: StationType
        Enable: bool
    }
    
type Platform =
    {
        WorkStations: WorkStation array
        Name: string
    }


type a = {b: int; c: int}
module Say =
    let Hello =
        printfn "Hello from F#"
        let v =[ for i in 0..2 do yield 1]
        let v1 =[ for i in 0..2 do 1]
        
       
        
        ()