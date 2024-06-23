// Lesson 1.5 Basic Syntax and Data Types

// How to bind a value to a variable.
let x = 3

// How to print to the console
printfn $"{x}"

// An integer is a non-decimal number such as 1, 100_000, 1_000_000, -5000 and so on.
let intNumber = 1_000_000

// A float is a number that is a decimal, such as 0.1111111, -200.4000, 100.000001 and so on. There are also
// doubles and decimals in .net, but we will cover those later.
let floatNumber = -200.111104

// A character is a single quoted letter/numbers/etc.
let character = 'a'

// A string is a double-quoted collection of characters "I love f#"
let fire = "🔥 I love F# ❤️‍🔥"
// Note that you can put any token you want into the string. Let's go ahead and print it:
// Note your console may not support the emoji characters.
printfn $"{fire}"

// These are what we would consider basic data types, however now we will cover some more sophisticated ones.
// First off, we can cover a 'list'. A list is a singley-linked list
// that is each node in the link points to the next item.
let groceryList = [ "banana"; "flour"; "eggs"; "milk" ]

// A tuple is also a collection of items, however, it can take items of different types.
// Note that the tuple has a signature of the exact types in the tuple it's made up of
// as opposed to above, where we only have a signature of "string list" which means that list can only have strings.
let groceryListWithPrices =
    ("banana", 1.00, "flour", 2.00, "eggs", 6.00, "milk", 5.00)
// This tuple has a lot of drawbacks that you will see soon. The first problem is we can't iterate through it.

// Making a tuple like above can be clunky as we will see later, we usually want to use a more robust and useful
// data type, a record.
type Grocery = { Item: string; Price: float }

// Now instead of having to make a tuple, we can make a list of grocery items we need.
let betterGroceryList =
    [ { Item = "banana"; Price = 1.00 }
      { Item = "flour"; Price = 2.00 }
      { Item = "eggs"; Price = 6.00 }
      { Item = "milk"; Price = 5.00 } ]

// Now it will be more obvious when we want to print this list. We can do this very simply by iterating through
// the list of items with a for loop.
for item in betterGroceryList do
    printfn $"{item}"

// Keep in mind that F# is whitespace sensitive and requires the use of tab to indent the next line
// this is different from languages like C#, where whitespace is ignored.

// Lesson 1.6 Simple Functions and Expressions
// Functions are first class citizens in F# and are used everywhere. Many times when you might reach for a complicated
// design pattern in another language, you can just use a function in F#.

// Here we've created our first function. It is a function called helloFunction
// that takes nothing (called unit and represented by ()) and returns a string.
let helloFunction () = "Hello, World!"

// We can call and use the helloFunction anywhere we want, we can also assign the result of a function to
// a variable.
// Note that () is there because helloFunction expects a unit.
let result = helloFunction ()

printfn $"{result}"

// We could also call this function inside another function.
let helloHelloFunction () = helloFunction ()

let resultTwo = helloHelloFunction ()
printfn $"{resultTwo}"

// We can also create a function inside a function and return it.
// This function doesn't return the result of helloWorld, it returns the function itself that will still need
// to be called.
let createHello () =
    let helloWorld () = "Hello, World!"
    helloWorld

let nestedHello = createHello ()
printfn $"{nestedHello ()}"

// But supposed we wanted to actually give the function something to work on? And what if we want to pass in a function?
// We will start with the first question.
let helloPerson person = $"Hello, {person}!"

// Notice that we didn't have to specify the type of the argument or the return type like in other languages
// the compiler can usually determine the type for us.
let helloTom = helloPerson "Tom"
printfn $"{helloTom}"
// The $"{item}" syntax is called 'string interpolation' which takes another string and plugs it into the spot
// where the brackets are in this string.
// Experiment by putting in your own name.

// Finally, let's also see how we can pass a function into a function.
let createHelloTwo baseHello person = $"{baseHello ()}, {person}!"

let justHello () = "Hello"

let helloTed = createHelloTwo justHello "Ted"
printfn $"{helloTed}"
// You can also pass functions with satisfying their arguments and then satisfying them later in other functions.
// that's a more complicated idea we will explore more later.
let unfinishedHelloWorld = createHelloTwo
// Don't worry if this doesn't make sense yet.
let helloJohn = unfinishedHelloWorld justHello "John"
printfn $"{helloJohn}"

// Next, we will look at expressions.
// We've already looked at one expression, a loop.
// A loop takes a collection, and then we can iterate over it.
// The .. in 1..10 is shorthand to say we want every number from to 10.
for i in 1..10 do
    printfn $"{i}"

// The next expression we want to look at is the 'if then' expression.
if 1 > 0 then
    do printfn "One is greater than 0"

// Finally, let's take a look at the match expression, one of the most powerful expressions in F#.
match helloJohn with
| "Hello, John!" -> printfn "John was greeted."
| "Hello, Tim!" -> printfn "This isn't possible."
| _ -> printfn "This is for sure not possible."

// These are all expressions because they all return something. In the case of using "printfn" a unit () is return.
// But, other things could be returned as well. Any data type could be returned and used.
let johnGreeted =
    match helloJohn with
    | "Hello, John!" -> true
    | _ -> false
// We are able to match on the variable helloJohn and see the value it holds.
// We can match on the value of the variable and determine what the next step of the logic should be.
// Notice the '_' character for any other case we don't cover. Otherwise called the default case.