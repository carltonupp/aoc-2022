open System
open System.IO
open System.Text.RegularExpressions

let text = File.ReadAllText("./inputs.txt")

let attemptToParseInt i =
    match i with
    | "" -> 0
    | _ -> Int32.Parse i

let parseCalories (calories: string) =
    calories.Split("\n")
    |> Array.map attemptToParseInt

let calculateTotalCalories (calories: String) = parseCalories calories |> Array.sum

let highestCalories =
    Regex.Split(text, @"^\n", RegexOptions.Multiline)
    |> Array.map calculateTotalCalories
    |> Array.max

let topThreeHighestCalories =
    Regex.Split(text, @"^\n", RegexOptions.Multiline)
    |> Array.map calculateTotalCalories
    |> Array.sortDescending
    |> Array.take 3
    |> Array.sum

Console.WriteLine highestCalories
Console.WriteLine topThreeHighestCalories
