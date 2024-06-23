// Lesson 2.1 Immutability
// When you use let to bind a variable it is immutable.
let y = 3

// In other languages you could mutate it, you could assign a new value to y, in F# that will be an error.
// But suppose you want to mutate y? Then you should declare it as mutable.
let mutable x = 3
// This variable can be mutated and assigned a new value now.
x <- 4
// This way of programming is error-prone and can lead to a lot of problems in situations where
// x is being mutated without us knowing. It's better if we can always know that our variables won't be changed.
// The question then, is how do we do anything useful if we are worried about side effects?
// We will cover that in depth later, but first let's understand the concept of pure functions.

// Note, that you can shadow variables which means you can reassign them. I don't recommend this because it can cause
// confusion on what the state of the variable is.
// let y = 344

// In .NET this is called a doc tag. This enables IDEs to link robust documentation about functions and methods to
// the functions so when they are called you can get more information about them. Just hover over the function name
// and see the description.
/// <summary>
/// A pure function is a function that given the same inputs it always returns the same outputs. It is
/// free from side effects which means it will do exactly what it says without making changes to anything.
/// </summary>
/// <param name="inputOne"></param>
/// <param name="inputTwo"></param>
let pureFunction inputOne inputTwo = inputOne + inputTwo

// Functions like these allow us to optimize our code and write it in cleaner ways than if we were to use mutation
// and side effects. For instance, if you always knew that certain inputs would generate certain outputs you
// could generate a table everytime the function was hit and then do a lookup instead of a calculation. This concept
// is called memoization.
// It's also easier to test and debug these functions as they do one thing without altering anything else.

// Exercise 2.1 
// Before moving on to the next sub-lesson create a function that takes the height and width of a rectangle
// and returns its area.
// Remember you can experiment in F# Interactive to get instant feedback.
// Here's a starter signature:
// let area height width = ??

// Lesson 2.2 Higher-Order Functions
// Let's explore higher-order functions. We went over them a little bit in 1.6, but now we can explore what they are
// about and what superpowers they unlock.

// We talked before about a function that can take another function as an argument.
let slottedFunction f argument = f argument

// Observe the two functions below, we are passing a different function into each slottedFunction.
// Observe also the syntax for what we call "anonymous functions" these are functions that we can
// declare inline and don't need to be named. The let name binding above is a syntactic shortcut for this.
let result = (fun x -> x + 3) 3
let resultTwo = (fun y -> y + 3.0) 3.4
// Last observation, observe that we can use different types and different type functions to pass into slottedFunction.
// F# is a strongly typed language, this is a powerful tool called generics we will talk more about later.
// Remember that we can also return a function we create from another function.
let createdFunction argument = fun () -> argument

// Now that we understand a higher order function and passing functions, let's talk about some higher order functions
// that are built into F#. We always want to reach for the tools that are built in instead of making our own if
// we can help it.
// Let's look at a few of the most common ones.
let groceries = [ "bananas"; "milk"; "chips"; "eggs" ]

// Suppose we want to make all of these capital and return a new list with those changes.
// In an imperative and mutable context we might just loop through each element of the list and alter them.
// But in F# and in functional programming, we are going to use a built-in function called 'map' that will
// create a new list instead.

// This will take every string in the list and make them all capitalized. However, notice the .ToUpper()
// syntax we used. This is called a "method call". This is different from a function because this functionality
// is attached to the variable itself. 
let upperCaseGroceries =
    List.map (fun (grocery: string) -> grocery.ToUpper()) groceries

// Map is a function that is included in the List module. Map is available for most collections and takes every item
// and does some function on them and then collects the result. We are "mapping" an item to another item.

// Next we will take a look at another very useful function, Filter.
let justMilk =
    List.filter (fun grocery -> grocery = "milk") groceries

// Filter will go through and use a predicate on each item in the list and then if the predicate returns true the item
// will go into a new list. The false items will be ignored and not brought into the new list.

// Lastly, let's run a fold on the list. A fold runs a function against each item in the list
// and accumulates the result as the return value.

let groceryCount =
    List.fold (fun acc _grocery -> acc + 1) 0 groceries

// In this case we don't use the grocery itself in our calculation, so we just put an underscore at the start
// to show we don't care about it. We could also have just put an underscore.

// Exercise 2.2
// Now try it yourself, create a list of your favorite foods and then count how many start with the letter p.
// Hint: Because you are being asked for a count you should use a fold.

// Lesson 2.3 Pattern Matching
// Next we will talk in-depth about pattern matching. We went over it a little bit before, but now we will do a full
// investigation of what it is and what it enables us to do.
