open System

let pastFreq (a, _, _) = a
let currentFreq (_, b, _) = b
let duplicateFreq (_, _, c) = c

let runningTotal seq = 
    (Seq.head seq, Seq.tail seq) ||> Seq.scan (fun accumulator element -> accumulator + element)

let frequencyScanner (pastFrequencies:Set<int>, currentFrequency:int, duplicateFrequency:Option<int>) diff =            
    let newFrequency = currentFrequency + diff;

    if Set.exists (fun el -> el = newFrequency) pastFrequencies
    then
        if(duplicateFrequency.IsSome)
        then
            (pastFrequencies, newFrequency, duplicateFrequency)
        else 
            (pastFrequencies, newFrequency, Some newFrequency)
    else 
        (Set.add newFrequency pastFrequencies, newFrequency, duplicateFrequency)

let rec findRepeatingValue (pastFrequencies:Set<int>, currentFrequency:int) inputList =
    let scanResult = 
        inputList
        |> Seq.fold frequencyScanner (pastFrequencies, currentFrequency, None)

    let foundDuplicate = duplicateFreq scanResult

    if foundDuplicate.IsSome
        then foundDuplicate.Value
        else findRepeatingValue((pastFreq scanResult), (currentFreq scanResult)) inputList 

let findFirstRepeatingFrequency inputList = 
    findRepeatingValue (Set.empty, 0) inputList

[<EntryPoint>]
let main argv =
    let inputValues = 
        InputReader.readLines("input.txt")
        |> Seq.map (fun inStr -> Int32.Parse(inStr))
        |> List.ofSeq

    let result = 
        inputValues
        |> findFirstRepeatingFrequency

    printfn "The result is %d" result

    System.Console.ReadKey() |> ignore
    0 