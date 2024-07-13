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
    
let testList = [1;2;3;4]
let result = filterMapReduce testList
printfn $"{result}"
// Lesson 4.2 Partial Application and Currying

// Lesson 4.3 Pipelines and Forward Operators

// Lesson 4.4 Anonymous Functions

// Lesson 4.5 Map, Filter, Fold
