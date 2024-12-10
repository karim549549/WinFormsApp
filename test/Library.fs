
module Dictionary


let mutable dictionary: Map<string, string option> = Map.empty


let addWord word translation =
    dictionary <- dictionary.Add(word, Some translation)
    printfn "Added: %s -> %s" word translation

let searchWord word =
    match dictionary.TryFind(word) with
    | Some (Some translation) -> $"{word} means {translation}"
    | Some None -> $"{word} has no translation"
    | None -> $"{word} not found"



let deleteWord word =
    if dictionary.ContainsKey(word) then
        dictionary <- dictionary.Remove(word)
        printfn "Deleted: %s" word
    else
        printfn "%s not found" word


let updateWord word newTranslation =
    if dictionary.ContainsKey(word) then
        dictionary <- dictionary.Add(word, Some newTranslation)
        printfn "Updated: %s -> %s" word newTranslation
    else
        printfn "%s not found" word

open System.IO
open Newtonsoft.Json

let saveToJson filePath =
    let json = JsonConvert.SerializeObject(dictionary)
    File.WriteAllText(filePath, json)
    printfn "Dictionary saved to %s" filePath

