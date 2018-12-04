open System

let areBoxIdsSimilar boxId1 boxId2 = 
    let unMatchedChars = 
        boxId1
        |> Seq.map2 (fun a b -> (a, b)) boxId2
        |> Seq.filter (fun matchedChar -> not (fst matchedChar = snd matchedChar))
        |> Seq.length

    if (unMatchedChars > 1)
    then false
    else true

let getMatchingIdPart boxId1 boxId2 = 
    let matchedChars = 
        boxId1
        |> Seq.map2 (fun a b -> (a, b)) boxId2
        |> Seq.filter (fun matchedChar -> fst matchedChar = snd matchedChar)
        |> Seq.map (fst)

    new string [|for c in matchedChars -> c|]

let rec findMatchingBoxId boxIds = 
    let firstId = boxIds |> Seq.head

    let foundMatches =
        boxIds
        |> Seq.tail
        |> Seq.filter (fun otherId -> areBoxIdsSimilar firstId otherId)

    if (foundMatches |> Seq.isEmpty)
    then findMatchingBoxId (Seq.tail boxIds)
    else getMatchingIdPart firstId (Seq.head foundMatches)

[<EntryPoint>]
let main argv =
    let boxIds = 
        InputReader.readLines("input.txt")
        |> Seq.map (fun str -> Seq.toList str)
        |> List.ofSeq

    let result = 
        boxIds
        |> findMatchingBoxId
    
    printfn "The result is %s" result

    System.Console.ReadKey() |> ignore
    0 