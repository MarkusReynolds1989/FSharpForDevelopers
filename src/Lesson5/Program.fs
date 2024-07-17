open System.IO
// Lesson 5.1 Introduction to Asynchronous Programming

// Lesson 5.2 Async Workflows
let path = "patient_data.csv"

async {
    let! result = File.ReadAllLinesAsync(path) |> Async.AwaitTask
    result |> Array.iter (fun x -> printfn $"{x}")
}
|> Async.Start

// Async is different from Parallel, but they are related.
// We can load several different files at once depending on how many cores we have.
async {
    // These will all run at the same time.
    let! results =
        [ File.ReadAllLinesAsync(path) |> Async.AwaitTask
          File.ReadAllLinesAsync(path) |> Async.AwaitTask
          File.ReadAllLinesAsync(path) |> Async.AwaitTask ]
        |> Async.Parallel

    printfn $"%A{results}"
    ()
}
// Then, the whole thing will start, but it will run in the background across the threads.
// Let's look at what is happening with profiling so, we can see the different threads.
|> Async.Start

// Lesson 5.3 Parallel Programming
// We can take an array of data and do operations on it in parallel.
seq { 0..9999 }
|> Seq.toArray
|> Array.Parallel.map (fun x -> x + 1)
|> Array.Parallel.iter (fun x -> printf $" %d{x} ")
// The map operation will run in parallel, and then it will print to console in parallel.
// Consider that it will print out of order as it will be running on different cores.

// Lesson 5.4 Task Parallel Library TPL

// Lesson 5.5 Handling Exceptions in Async Code
