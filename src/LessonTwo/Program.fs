// Lesson 2.1
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

// In .NET this is called a doc tag. This enables IDEs to link robust documentation about functions and methods to
// the functions so when they are called you can get more information about them. Just hover over the function name
// and see the description.
/// <summary>
/// A pure function is a function that given the same inputs it always returns the same outputs. It is
/// free from side effects which means it will do exactly what it says without making changes to anything.
/// </summary>
/// <param name="inputOne"></param>
/// <param name="inputTwo"></param>
let pureFunction inputOne inputTwo =
    inputOne + inputTwo

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