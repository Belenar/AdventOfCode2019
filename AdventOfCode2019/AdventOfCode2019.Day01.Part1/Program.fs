open System

[<EntryPoint>]
let main argv =
    let input = InputReader.readLines("input.txt")

    let result = 
        input
        |> Seq.map (fun inStr -> Int32.Parse(inStr))
        |> Seq.sum

    printfn "The result is %d" result

    System.Console.ReadKey() |> ignore
    0 