// Lesson 4.1 Function Composition
// Next, let's talk about how we can compose functions together.
// Function composition is the process of combining two or more functions to produce another.
// Let's examine the type signature, ('a -> 'b) -> ('c -> 'a) -> 'c -> 'b
// That is, a function that takes a and returns b, a function that takes c and returns a, an argument c
// and then finally return b. (These are generic types.)
let compose f g x = f (g x)

// Let's create a function that takes one argument and then adds 1 to it.
let add1 x = x + 1
// Then, we will create a function that takes an argument and multiplies it by 2.
let multiply2 x = x * 2
// Finally, we will compose the two functions, when we give the composed functions an argument it will
// run both functions on it.
// Here we fulfil the contract for the two functions required.
let add1AndMultiply2 = compose multiply2 add1
// Finally, we provide the last argument needed.
printfn $"{add1AndMultiply2 5}"

// We have a shorthand for composing functions.
let sameAsAbove = add1 >> multiply2
printfn $"{sameAsAbove 5}"

let filterMapReduce =
    // We can combine as many functions as we want into one.
    List.filter (fun x -> x > 0) >> List.map (fun x -> x + 1) >> List.sort

let testList = [ 1; 2; 3; 4 ]
let result = filterMapReduce testList
printfn $"{result}"
// Lesson 4.2 Partial Application and Currying
// Partial application is the process of fixing a number of arguments to a function, producing another
// function of smaller arity.
let add x y = x + y
// This is partial application, this is a new function being returned here.
let add5 = add 5
printfn $"{add5 5}"

// Lesson 4.3 Pipelines and Forward Operators
// There are a few ways to set up pipelines, the easiest and clearest is to just use the pipe operator.
let x = 5 |> (fun x -> x + 1) |> (fun x -> x * 2) |> (fun x -> x - 3)

// I am piping the collection into a function, and then I can pipe the results of that function into yet another one.
// I can keep forwarding the data onto each function as much as I'd like.
// We can also pass in a collection of functions into a function and pipe the collection through there.
let pipeline x functions =
    List.fold (fun acc f -> f acc) x functions

let pipeResult = pipeline 5 [ (fun x -> x + 1); (fun x -> x * 2); (fun x -> x - 3) ]
// This way is more useful when we want to create the collection of functions programmatically and then apply
// those functions to values.

// We can also pipe a tuple into a function.
// Notice that we use the ||> double pipe to pipe this tuple into the fold instead of adding them as arguments
// at the end.
// This will print 10.
printfn $"{(0, [| 1; 2; 3; 4 |]) ||> Array.fold (fun x y -> x + y)}"

// Lesson 4.4 Anonymous Functions
// We've been using anonymous functions this whole time, it looks like this:
// (fun x -> x + 1)
// You can bind this function if you want or just directly send it arguments.
let anon = (fun x -> x + 1)
let anonResult = anon 1
printfn $"{anonResult}"
// The way we write functions is syntatic sugar for binding a function to a name:
let other item = item + 1
// This is equivalent to the non function above, but it's a named function. Look at the signature to confirm.


// Lesson 4.5 Map, Filter, Fold
