let hasDoubleLetter boxId = 
    let doubleLetters =
        boxId
        |> Seq.groupBy (fun char -> char)
        |> Seq.filter (fun item -> (snd item |> Seq.length) = 2)

    if doubleLetters |> Seq.isEmpty
        then 0
        else 1

let hasTripleLetter boxId = 
    let doubleLetters =
        boxId
        |> Seq.groupBy (fun char -> char)
        |> Seq.filter (fun item -> (snd item |> Seq.length) = 3)

    if doubleLetters |> Seq.isEmpty
        then 0
        else 1

let incrementDoubleAndTriples (doubles, triples) boxId =
    (doubles + (hasDoubleLetter boxId), triples + (hasTripleLetter boxId))

let calculateChecksum boxIds =
    let doubleAndTripleLetters = 
        boxIds
        |> Seq.fold incrementDoubleAndTriples (0,0)

    (fst doubleAndTripleLetters * snd doubleAndTripleLetters)
    

[<EntryPoint>]
let main argv =
    let boxIds = 
        InputReader.readLines("input.txt")
        |> Seq.map (fun str -> Seq.toList str)
        |> List.ofSeq

    let result = 
        boxIds
        |> calculateChecksum
    
    printfn "The result is %d" result

    System.Console.ReadKey() |> ignore
    0 