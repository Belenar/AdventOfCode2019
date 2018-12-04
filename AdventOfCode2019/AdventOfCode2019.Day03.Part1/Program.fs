// Learn more about F# at http://fsharp.org
type Rectangle = {
    Number: int;
    XOffset: int;
    YOffset: int;
    Width: int;
    Height: int
}

type SquaredStatus = Unused | Used | Contested



[<EntryPoint>]
let main argv =
    let rectangles = 
        InputReader.readLines("input.txt")
        |> Seq.map (fun str -> Seq.toList str)
        |> List.ofSeq

    let rect = 
        rectangles
        |> List.item 3
    
    printfn "Hello World from F#!"
    0 // return an integer exit code
